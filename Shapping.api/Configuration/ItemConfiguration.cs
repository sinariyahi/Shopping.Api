using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shapping.api.Entities;
using System;

namespace Shapping.api.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData
            (
                  new Item()
                  {
                      Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                      StoreId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                      Name = "Ice cream",
                      DateManufacture = "2020/1/5",
                      DateExpiration = "2021/1/5"
                  },
              new Item()
              {
                  Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                  StoreId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                  Name = "Cake",
                  DateManufacture = "2020/8/7",
                  DateExpiration = "2020/12/7"
              }
              );
        }
    }
}
