﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TomTec.Intermed.Data;

namespace TomTec.Intermed.API.Migrations
{
    [DbContext(typeof(IntermedDBContext))]
    [Migration("20220623135949_SpecialtyIdProp")]
    partial class SpecialtyIdProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TomTec.Intermed.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.ContactCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CelphoneNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Link")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ContactCards");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.CreditCardInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Expire")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FourLastNumbers")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CreditCardInfos");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.HealthProfessional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsultingAddressId")
                        .HasColumnType("int");

                    b.Property<int>("ContactCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreditCardInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingAddressId");

                    b.HasIndex("ContactCardId");

                    b.HasIndex("CreditCardInfoId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("HealthProfessionals");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.Signature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Expire")
                        .HasColumnType("datetime2");

                    b.Property<int>("HealthProfessionalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreeTrial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsYearlyPack")
                        .HasColumnType("bit");

                    b.Property<int>("SignatureTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HealthProfessionalId");

                    b.HasIndex("SignatureTypeId");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.SignatureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("SignatureTypes");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("HealthProfessionalId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("Email", "UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.UsersClaims", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClaimId");

                    b.HasIndex("ClaimId");

                    b.ToTable("UsersClaims");
                });

            modelBuilder.Entity("TomTec.Intermed.Models.HealthProfessional", b =>
                {
                    b.HasOne("TomTec.Intermed.Models.Address", "ConsultingAddress")
                        .WithMany()
                        .HasForeignKey("ConsultingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.ContactCard", "ContactCard")
                        .WithMany()
                        .HasForeignKey("ContactCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.CreditCardInfo", "CreditCardInfo")
                        .WithMany()
                        .HasForeignKey("CreditCardInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.User", "User")
                        .WithOne("HealthProfessional")
                        .HasForeignKey("TomTec.Intermed.Models.HealthProfessional", "UserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("TomTec.Intermed.Models.Signature", b =>
                {
                    b.HasOne("TomTec.Intermed.Models.HealthProfessional", "HealthProfessional")
                        .WithMany()
                        .HasForeignKey("HealthProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.SignatureType", "SignatureType")
                        .WithMany()
                        .HasForeignKey("SignatureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TomTec.Intermed.Models.User", b =>
                {
                    b.HasOne("TomTec.Intermed.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TomTec.Intermed.Models.UsersClaims", b =>
                {
                    b.HasOne("TomTec.Intermed.Models.Claim", "Claim")
                        .WithMany("UsersClaims")
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TomTec.Intermed.Models.User", "User")
                        .WithMany("UsersClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
