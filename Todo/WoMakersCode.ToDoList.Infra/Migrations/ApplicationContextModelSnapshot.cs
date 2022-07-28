﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WoMakersCode.ToDoList.Infra.Database;

namespace WoMakersCode.ToDoList.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.Alarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdTaskDetail")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTaskDetail");

                    b.ToTable("alarms");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.TaskDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("Executado")
                        .HasColumnType("INT");

                    b.Property<int>("IdTaskList")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTaskList");

                    b.ToTable("taskdetails");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.TaskList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("tasklists");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.Alarm", b =>
                {
                    b.HasOne("WoMakersCode.ToDoList.Core.Entities.TaskDetail", "TaskDetail")
                        .WithMany("Alarms")
                        .HasForeignKey("IdTaskDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskDetail");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.TaskDetail", b =>
                {
                    b.HasOne("WoMakersCode.ToDoList.Core.Entities.TaskList", "TaskList")
                        .WithMany("Details")
                        .HasForeignKey("IdTaskList")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.TaskDetail", b =>
                {
                    b.Navigation("Alarms");
                });

            modelBuilder.Entity("WoMakersCode.ToDoList.Core.Entities.TaskList", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
