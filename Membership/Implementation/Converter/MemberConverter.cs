using Membership.Database;
using Membership.Implementation.Enum;
using Membership.Implementation.Interface;
using Membership.Models;
using System;

namespace Membership.Implementation.Converter
{
    public class MemberConverter : IConverter<Member, MemberModel>
    {
        public MemberModel ConverToModel(Member model)
        {
            return new MemberModel
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Age = model.Age,
                Contact = model.Contact,
                DOB = model.DOB,
                DOBLabel = model.DOB.ToShortDateString(),
                Gender = model.Gender,
                GenderLabel = System.Enum.GetName(typeof(Gender), model.Gender),
                FileName = model.FileName
            };
        }

        public Member ConvertToEntity(MemberModel model)
        {
            return new Member
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Age = model.Age,
                Contact = model.Contact,
                DOB = model.DOB,
                Gender = model.Gender,
                FileName = model.FileName
            };
        }

        public Member ConvertToEntity(MemberModel model, Member self)
        {
            self.Id = model.Id;
            self.Name = model.Name;
            self.Address = model.Address;
            self.Age = model.Age;
            self.Contact = model.Contact;
            self.DOB = model.DOB;
            self.Gender = model.Gender;
            self.FileName = model.FileName;
            return self;
        }
    }
}