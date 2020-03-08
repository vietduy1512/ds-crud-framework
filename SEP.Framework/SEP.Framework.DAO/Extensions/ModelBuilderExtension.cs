using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SEP.Framework.DAO.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return assembly.GetTypes()
                           .Where(x => x.IsClass && !x.IsAbstract &&
                                       x.GetInterfaces().Any(interfacce =>
                                       {
                                           return interfacce.IsGenericType && interfacce.GetGenericTypeDefinition() == mappingInterface;
                                       }));
        }

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityTypeConfiguration<>))
                                       .Select(Activator.CreateInstance);

            foreach (dynamic config in mappingTypes)
            {
                modelBuilder.ApplyConfiguration(config);
            }
        }
    }
}
