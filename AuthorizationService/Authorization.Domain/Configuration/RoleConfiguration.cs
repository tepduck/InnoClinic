﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Domain.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name= "Patient",
                    NormalizedName = "PATIENT"
                },
                new IdentityRole
                {
                    Name= "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole
                { 
                    Name= "Receptionist",
                    NormalizedName = "RECEPTIONIST"
                });
        }
    }
}
