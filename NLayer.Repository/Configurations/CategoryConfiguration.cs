﻿using Microsoft.EntityFrameworkCore;
using NLayer.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).UseIdentityColumn();
           builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories"); 
        }
    }
}
