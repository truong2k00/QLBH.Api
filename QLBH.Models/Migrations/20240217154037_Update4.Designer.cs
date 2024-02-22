﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLBH.Models;

#nullable disable

namespace QLBH.Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240217154037_Update4")]
    partial class Update4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLBH.Models.Entities.Account", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Update")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IsConfirm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number_CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Work")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Address_Receive", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Confirm")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Address_Receive");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Bill", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Address_ReceiveID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("Status_BillID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("Address_ReceiveID");

                    b.HasIndex("Status_BillID");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Cart", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Comment_Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Datetime_Comment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ProductID");

                    b.ToTable("Comment_Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ConfirmEmail", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Address_ReceiveID")
                        .HasColumnType("bigint");

                    b.Property<string>("CodeiVerification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Expired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<long?>("MailSettingID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("Address_ReceiveID");

                    b.HasIndex("MailSettingID");

                    b.ToTable("ConfirmEmail");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Decentralization", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("RoleID");

                    b.ToTable("Decentralization");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Detail_Cart", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("CartID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.ToTable("Detail_Cart");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Details", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Detail_Introduce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("QLBH.Models.Entities.FeedBack", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<string>("FeedBack_Quality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<int>("star")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ProductID");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ImageProduct", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Image_Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ImageProduct");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Image_Comment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("Comment_ProductID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("href")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Comment_ProductID");

                    b.ToTable("Image_Comment");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Invoice_Details", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("BillID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("BillID");

                    b.HasIndex("ProductID");

                    b.ToTable("Invoice_Details");
                });

            modelBuilder.Entity("QLBH.Models.Entities.MailSetting", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MailSetting");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Notification", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<string>("Notification_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notification_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("watched_at")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Date_Delete")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Evaluate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_New")
                        .HasColumnType("bit");

                    b.Property<string>("Meta_Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long?>("Price_Sale")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductCatogoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("Product_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<bool>("Sale")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ProductCatogoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ProductCatogory", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("CatogoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("ProductCatogory");
                });

            modelBuilder.Entity("QLBH.Models.Entities.RefeshToken", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date_Expired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("RefeshToken");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("Role_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Role_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Status_Bill", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Status_Bill");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Type_Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<string>("Type_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Type_Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Voucher", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Expiration_Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Reducted_Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Release_Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("VoucherId")
                        .HasColumnType("bigint");

                    b.Property<string>("VoucherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Work")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Address_Receive", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Address_Receive")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Bill", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Bill")
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.Address_Receive", "Address_Receive")
                        .WithMany("Bill")
                        .HasForeignKey("Address_ReceiveID");

                    b.HasOne("QLBH.Models.Entities.Status_Bill", "Status_Bill")
                        .WithMany("Bill")
                        .HasForeignKey("Status_BillID");

                    b.Navigation("Account");

                    b.Navigation("Address_Receive");

                    b.Navigation("Status_Bill");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Cart", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Cart")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Comment_Product", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany("Comment_Product")
                        .HasForeignKey("ProductID");

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ConfirmEmail", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("ConfirmEmail")
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.Address_Receive", "Address_Receive")
                        .WithMany("ConfirmEmail")
                        .HasForeignKey("Address_ReceiveID");

                    b.HasOne("QLBH.Models.Entities.MailSetting", "MailSetting")
                        .WithMany("ConfirmEmail")
                        .HasForeignKey("MailSettingID");

                    b.Navigation("Account");

                    b.Navigation("Address_Receive");

                    b.Navigation("MailSetting");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Decentralization", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Decentralizations")
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.Role", "Role")
                        .WithMany("Decentralization")
                        .HasForeignKey("RoleID");

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Detail_Cart", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Cart", "Cart")
                        .WithMany("Detail_Cart")
                        .HasForeignKey("CartID");

                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany("Detail_Cart")
                        .HasForeignKey("ProductID");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Details", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.FeedBack", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("FeedBack")
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany("FeedBack")
                        .HasForeignKey("ProductID");

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ImageProduct", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany("ImageProduct")
                        .HasForeignKey("ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Image_Comment", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Comment_Product", "Comment_Product")
                        .WithMany("Image_Comment")
                        .HasForeignKey("Comment_ProductID");

                    b.Navigation("Comment_Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Invoice_Details", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Bill", "Bill")
                        .WithMany("Invoice_Details")
                        .HasForeignKey("BillID");

                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Notification", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Notification")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Product", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("Product")
                        .HasForeignKey("AccountID");

                    b.HasOne("QLBH.Models.Entities.ProductCatogory", "ProductCatogory")
                        .WithMany("Product")
                        .HasForeignKey("ProductCatogoryID");

                    b.Navigation("Account");

                    b.Navigation("ProductCatogory");
                });

            modelBuilder.Entity("QLBH.Models.Entities.RefeshToken", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Account")
                        .WithMany("RefeshToken")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Type_Product", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Voucher", b =>
                {
                    b.HasOne("QLBH.Models.Entities.Account", "Acount")
                        .WithMany("Voucher")
                        .HasForeignKey("AccountID");

                    b.Navigation("Acount");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Account", b =>
                {
                    b.Navigation("Address_Receive");

                    b.Navigation("Bill");

                    b.Navigation("Cart");

                    b.Navigation("ConfirmEmail");

                    b.Navigation("Decentralizations");

                    b.Navigation("FeedBack");

                    b.Navigation("Notification");

                    b.Navigation("Product");

                    b.Navigation("RefeshToken");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Address_Receive", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("ConfirmEmail");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Bill", b =>
                {
                    b.Navigation("Invoice_Details");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Cart", b =>
                {
                    b.Navigation("Detail_Cart");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Comment_Product", b =>
                {
                    b.Navigation("Image_Comment");
                });

            modelBuilder.Entity("QLBH.Models.Entities.MailSetting", b =>
                {
                    b.Navigation("ConfirmEmail");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Product", b =>
                {
                    b.Navigation("Comment_Product");

                    b.Navigation("Detail_Cart");

                    b.Navigation("Details");

                    b.Navigation("FeedBack");

                    b.Navigation("ImageProduct");
                });

            modelBuilder.Entity("QLBH.Models.Entities.ProductCatogory", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Role", b =>
                {
                    b.Navigation("Decentralization");
                });

            modelBuilder.Entity("QLBH.Models.Entities.Status_Bill", b =>
                {
                    b.Navigation("Bill");
                });
#pragma warning restore 612, 618
        }
    }
}
