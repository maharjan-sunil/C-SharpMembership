using AutoMapper;
using Membership.Controllers;
using Membership.Extension;

namespace Membership.Mapping
{
    public class LogMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Log, DomainModel.Log>()
                .IgnoreAllNonExisting();
            Mapper.CreateMap<DomainModel.Log, Log>()
                .IgnoreAllNonExisting();
        }
    }
}