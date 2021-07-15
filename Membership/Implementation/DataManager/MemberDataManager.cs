using Membership.Database;
using Membership.Implementation.Converter;
using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Membership.Implementation.DataManager
{
    public class MemberDataManager : BaseDataManager<MemberConverter>, IDataManager<MemberModel>
    {
        private readonly FileDataManager fileDataManager;
        private const string Directory = "Member"; 
        public MemberDataManager()
        {
            fileDataManager = new FileDataManager();
        }
        public bool Add(MemberModel model)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    model.FileName = fileDataManager.UploadHttpPostedFileBase(model.File, Directory);
                    var member = converter.ConvertToEntity(model);
                    db.Members.Add(member);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    var member = db.Members.FirstOrDefault(m => m.Id == id);
                    db.Members.Remove(member);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MemberModel GetDetail(int id)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    var member = db.Members.FirstOrDefault(m => m.Id == id);
                    return converter.ConverToModel(member);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MemberModel> GetList()
        {
            List<MemberModel> listOfMember = new List<MemberModel>();
            try
            {
                using (var db = new MembershipEntities())
                {
                    var list = db.Members.ToList();
                    foreach (var data in list)
                    {
                        var model = converter.ConverToModel(data);
                        listOfMember.Add(model);
                    }
                    return listOfMember;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Edit(MemberModel model)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    if (model.File != null)
                        model.FileName = fileDataManager.UploadHttpPostedFileBase(model.File, Directory);
                    var member = db.Members.FirstOrDefault(m => m.Id == model.Id);
                    converter.ConvertToEntity(model, member);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MemberModel> GetList(MemberModel model)
        {
            List<MemberModel> listOfMember = new List<MemberModel>();
            try
            {
                using (var db = new MembershipEntities())
                {
                    var query = db.Members.AsQueryable();
                    if (!string.IsNullOrEmpty(model.Name))
                        query = query.Where(q => q.Name.Contains(model.Name));
                    if (!string.IsNullOrEmpty(model.Contact))
                        query = query.Where(q => q.Contact.Contains(model.Contact));
                    if (model.Age > 0)
                        query = query.Where(q => q.Age == model.Age);
                    foreach (var data in query)
                    {
                        var member = converter.ConverToModel(data);
                        listOfMember.Add(member);
                    }
                    return listOfMember;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}