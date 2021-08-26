using Membership.Database;
using Membership.Implementation.Converter;
using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Membership.Implementation.DataManager
{
    public class MemberDataManager : BaseDataManager<MemberConverter>, IDataManager<MemberModel,MemberViewNodel>
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
                    model.FileName = fileDataManager.UploadHttpPostedFileBase(model.PDFFile, Directory);
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

        public bool Edit(MemberModel model)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    if (model.PDFFile != null)
                        model.FileName = fileDataManager.UploadHttpPostedFileBase(model.PDFFile, Directory);
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

        public MemberViewNodel GetList(MemberViewNodel model)
        {
            var list = new List<MemberModel>();
            int total = 0;
            try
            {
                using (var db = new MembershipEntities())
                {
                    var query = db.Members.AsQueryable();

                    // will be replace by jquery table
                    //if (!string.IsNullOrEmpty(model.Name))
                    //    query = query.Where(q => q.Name.Contains(model.Name));
                    //if (!string.IsNullOrEmpty(model.Contact))
                    //    query = query.Where(q => q.Contact.Contains(model.Contact));
                    //if (model.Age > 0)
                    //    query = query.Where(q => q.Age == model.Age);
                    //end 
                    total = query.Count();
                    query = query.OrderBy(q => q.Name);
                    var queryList = PagingService.QueryRecordsForPage(query, model.Pager.CurrentPage, model.Pager.RecordPerPage);

                    foreach (var member in queryList)
                    {
                        var memberModel = converter.ConverToModel(member);
                        list.Add(memberModel);
                    }
                    model.ListOfModel = list;
                    model.Pager = PagingService.CalculateTotalPageAndRecords(model.Pager, total);
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}