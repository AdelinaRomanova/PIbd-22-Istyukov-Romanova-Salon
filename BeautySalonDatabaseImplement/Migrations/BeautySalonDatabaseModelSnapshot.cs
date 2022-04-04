﻿// <auto-generated />
using System;
using BeautySalonDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeautySalonDatabaseImplement.Migrations
{
    [DbContext(typeof(BeautySalonDatabase))]
    partial class BeautySalonDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Cosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CosmeticName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Cosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Distribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VisitId");

                    b.ToTable("Distributions");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.DistributionCosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DistributionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CosmeticId");

                    b.HasIndex("DistributionId");

                    b.ToTable("DistributionCosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("FIO_Master")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProcedureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ProcedurePurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("ProcedurePurchases");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ProcedureVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcedureId");

                    b.HasIndex("VisitId");

                    b.ToTable("ProcedureVisits");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ReceiptCosmetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CosmeticId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CosmeticId");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptCosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Cosmetic", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Cosmetic")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Distribution", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Distribution")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Visit", "Visit")
                        .WithMany("Distributions")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.DistributionCosmetic", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Cosmetic", "Cosmetic")
                        .WithMany("DistributionCosmetics")
                        .HasForeignKey("CosmeticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Distribution", "Distribution")
                        .WithMany("DistributionCosmetics")
                        .HasForeignKey("DistributionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cosmetic");

                    b.Navigation("Distribution");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Procedure", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Procedure")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ProcedurePurchase", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Procedure", "Procedure")
                        .WithMany("ProcedurePurchase")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Purchase", "Purchase")
                        .WithMany("ProcedurePurchase")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Procedure");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ProcedureVisit", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Procedure", "Procedure")
                        .WithMany("ProcedureVisit")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Visit", "Visit")
                        .WithMany("ProcedureVisit")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Procedure");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Purchase", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Purchase")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Receipt", "Receipt")
                        .WithMany("Purchases")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Receipt", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Receipt")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.ReceiptCosmetic", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Cosmetic", "Cosmetic")
                        .WithMany("ReceiptCosmetics")
                        .HasForeignKey("CosmeticId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautySalonDatabaseImplement.Models.Receipt", "Receipt")
                        .WithMany("ReceiptCosmetics")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cosmetic");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Visit", b =>
                {
                    b.HasOne("BeautySalonDatabaseImplement.Models.Client", "Client")
                        .WithMany("Visit")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("Procedure");

                    b.Navigation("Purchase");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Cosmetic", b =>
                {
                    b.Navigation("DistributionCosmetics");

                    b.Navigation("ReceiptCosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Distribution", b =>
                {
                    b.Navigation("DistributionCosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Employee", b =>
                {
                    b.Navigation("Cosmetic");

                    b.Navigation("Distribution");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Procedure", b =>
                {
                    b.Navigation("ProcedurePurchase");

                    b.Navigation("ProcedureVisit");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Purchase", b =>
                {
                    b.Navigation("ProcedurePurchase");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Receipt", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("ReceiptCosmetics");
                });

            modelBuilder.Entity("BeautySalonDatabaseImplement.Models.Visit", b =>
                {
                    b.Navigation("Distributions");

                    b.Navigation("ProcedureVisit");
                });
#pragma warning restore 612, 618
        }
    }
}
