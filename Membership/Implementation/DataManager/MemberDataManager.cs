using Membership.Database;
using Membership.Implementation.Converter;
using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Implementation.DataManager
{
    public class MemberDataManager : BaseDataManager<MemberConverter>, IDataManager<MemberModel>
    {
        public bool Add(MemberModel model)
        {
            try
            {
                using (var db = new MembershipEntities())
                {
                    var member = converter.ConvertToEntity(model);
                    db.Members.Add(member);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        //public List<MemberModel> GetList(string query)
        //{
        //    throw new NotImplementedException();
        //}
    }
}