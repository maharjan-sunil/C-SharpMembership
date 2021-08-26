using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using WebGrease.Css.Extensions;

namespace Membership
{
    public class MappingConfig
    {
        public static void Configure()
        {
            var profileTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Profile));
            Mapper.Initialize(a => profileTypes.ForEach(p => a.AddProfile(Activator.CreateInstance(p) as Profile)));
        }
    }
}