using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClinicApp.EntityModels;

namespace ClinicApp.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    [Migration("20230912090315_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicApp.EntityModels.PatientCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("PatientCardDbSet");
                });

            modelBuilder.Entity("ClinicApp.EntityModels.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfRequest");

                    b.Property<int?>("PatientId")
                        .IsRequired();

                    b.Property<string>("Purpose");

                    b.Property<int>("RequestType");

                    b.HasKey("RequestId");

                    b.HasIndex("PatientId");

                    b.ToTable("RequestDbSet");
                });

            modelBuilder.Entity("ClinicApp.EntityModels.Request", b =>
                {
                    b.HasOne("ClinicApp.EntityModels.PatientCard", "Patient")
                        .WithMany("Requests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
