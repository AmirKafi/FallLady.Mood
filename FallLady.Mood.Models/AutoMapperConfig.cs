using AutoMapper;
using FallLady.Mood.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Models
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Configure()
        {
            //var profiles = from t in System.Reflection.Assembly.GetAssembly(typeof(CostProfile))
            //        .GetTypes()
            //    where typeof(Profile).IsAssignableFrom(t)
            //    select (Profile)Activator.CreateInstance(t);
            var profiles = from t in typeof(CourseMapper).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            config.AssertConfigurationIsValid();
            Mapper = new Mapper(config);
        }
    }

    public static class AutoMapperExtensions
    {
        /// <summary>
        /// </summary>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}

