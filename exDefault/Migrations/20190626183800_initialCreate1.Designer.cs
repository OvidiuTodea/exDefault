﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using exDefault.Models;

namespace exDefault.Migrations
{
    [DbContext(typeof(EntitiesDbContext))]
    [Migration("20190626183800_initialCreate1")]
    partial class initialCreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("exDefault.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOff");

                    b.Property<DateTime>("DateOn");

                    b.Property<int>("EntityType");

                    b.Property<bool>("IsOrNot");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });
#pragma warning restore 612, 618
        }
    }
}
