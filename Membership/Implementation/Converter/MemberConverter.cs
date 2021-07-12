using Membership.Database;
using Membership.Implementation.Interface;
using Membership.Models;

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
                Gender = model.Gender
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
                Gender = model.Gender
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

            return self;
        }
    }
}