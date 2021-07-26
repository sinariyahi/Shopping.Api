using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shapping.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData
            (
                 new Store()
                 {
                     Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                     Name = "Farhad",
                     City = "Tehran",
                     Address = "Azadi",
                     Email="Farhadi25@gmail.com",
                     Phone="09362322511"
                 },
                new Store()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Nima",
                    City = "Amol",
                    Address = "Amam",
                    Email="nima11@gmail.com",
                    Phone="09306628281"
                }
                );
        }
    }
}
