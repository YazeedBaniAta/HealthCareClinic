﻿// <auto-generated />
using System;
using FirstProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstProject.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirstProject.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("PHONE")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ADMINS");
                });

            modelBuilder.Entity("FirstProject.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AppointmentDate")
                        .IsRequired()
                        .HasColumnName("APPOINTMENT_DATE")
                        .HasColumnType("DATE");

                    b.Property<string>("AppointmentTime")
                        .IsRequired()
                        .HasColumnName("APPOINTMENT_TIME")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("DepartmentId")
                        .IsRequired()
                        .HasColumnName("DEPARTMENT_ID")
                        .HasColumnType("INT");

                    b.Property<int?>("DoctorId")
                        .IsRequired()
                        .HasColumnName("DOCTOR_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Message")
                        .HasColumnName("MESSAGE")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int?>("PatientId")
                        .HasColumnName("PATIENT_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("STATUS")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql(@"0 
")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("APPOINTMENTS");
                });

            modelBuilder.Entity("FirstProject.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttendanceDate")
                        .HasColumnName("ATTENDANCE_DATE")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int?>("DoctorId")
                        .HasColumnName("DOCTOR_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Status")
                        .HasColumnName("STATUS")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("ATTENDANCES");
                });

            modelBuilder.Entity("FirstProject.Models.BannerSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("BANNER_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("FULL_NAME")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnName("MESSAGE")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("PHONE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnName("TOPIC")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("CONTACT");
                });

            modelBuilder.Entity("FirstProject.Models.CounterSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpertDoctor")
                        .HasColumnName("EXPERT_DOCTOR")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("HappyPeopel")
                        .HasColumnName("HAPPY_PEOPEL")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SurgeryComeplet")
                        .HasColumnName("SURGERY_COMEPLET")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("WordwideBranch")
                        .HasColumnName("WORDWIDE_BRANCH")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("COUNTER_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("DEPARTMENTS");
                });

            modelBuilder.Entity("FirstProject.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("AvailableDay")
                        .HasColumnName("AVAILABLE_DAY")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("AvailableTime")
                        .HasColumnName("AVAILABLE_TIME")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Bod")
                        .IsRequired()
                        .HasColumnName("BOD")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<int?>("DepartmentId")
                        .IsRequired()
                        .HasColumnName("DEPARTMENT_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("IsAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IS_AVAILABLE")
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("1 ")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("PHONE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnName("SALARY")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<int?>("SpecializationId")
                        .IsRequired()
                        .HasColumnName("SPECIALIZATION_ID")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("DOCTORS");
                });

            modelBuilder.Entity("FirstProject.Models.FeaturesSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmaegencyCase")
                        .HasColumnName("EMAEGENCY_CASE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TimesatSun")
                        .HasColumnName("TIMESAT_SUN")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TimesunWed")
                        .HasColumnName("TIMESUN_WED")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TimethuFri")
                        .HasColumnName("TIMETHU_FRI")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("FEATURES_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.FooterSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Column1")
                        .HasColumnName("COLUMN1")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("FOOTER_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.HeadSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClinicAddress")
                        .HasColumnName("CLINIC_ADDRESS")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClinicEmail")
                        .HasColumnName("CLINIC_EMAIL")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("ClinicName")
                        .HasColumnName("CLINIC_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("HEAD_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BookingAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BOOKING_AMOUNT")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasDefaultValueSql(@"10 
");

                    b.Property<string>("BookingDate")
                        .HasColumnName("BOOKING_DATE")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("CardNumber")
                        .HasColumnName("CARD_NUMBER")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("DoctorId")
                        .HasColumnName("DOCTOR_ID")
                        .HasColumnType("INT");

                    b.Property<int?>("PatientId")
                        .HasColumnName("PATIENT_ID")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("INVOICES");
                });

            modelBuilder.Entity("FirstProject.Models.PartnersSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("PARTNERS_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Bod")
                        .IsRequired()
                        .HasColumnName("BOD")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("GENDER")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("PHONE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("PATIENTS");
                });

            modelBuilder.Entity("FirstProject.Models.PatientsVesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BALANCE")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasDefaultValueSql("1000 ");

                    b.Property<int?>("PatientId")
                        .HasColumnName("PATIENT_ID")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PATIENTS_VESA");
                });

            modelBuilder.Entity("FirstProject.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rolename")
                        .HasColumnName("ROLENAME")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("FirstProject.Models.ServicePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("SERVICE_PAGE");
                });

            modelBuilder.Entity("FirstProject.Models.ServiceSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("ImagePath")
                        .HasColumnName("IMAGE_PATH")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnName("TITLE")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("SERVICE_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("SPECIALIZATION");
                });

            modelBuilder.Entity("FirstProject.Models.Subscrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("SUBSCRIP");
                });

            modelBuilder.Entity("FirstProject.Models.TestimonialSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<int?>("PatientId")
                        .HasColumnName("PATIENT_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("STATUS")
                        .HasColumnType("varchar(20)")
                        .HasDefaultValueSql(@"0 
")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Subject")
                        .HasColumnName("SUBJECT")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("TESTIMONIAL_SECTION");
                });

            modelBuilder.Entity("FirstProject.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId")
                        .HasColumnName("ADMIN_ID")
                        .HasColumnType("INT");

                    b.Property<int?>("DoctorId")
                        .HasColumnName("DOCTOR_ID")
                        .HasColumnType("INT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("PatientId")
                        .HasColumnName("PATIENT_ID")
                        .HasColumnType("INT");

                    b.Property<int?>("RoleId")
                        .HasColumnName("ROLE_ID")
                        .HasColumnType("INT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoleId");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("FirstProject.Models.Appointment", b =>
                {
                    b.HasOne("FirstProject.Models.Department", "Department")
                        .WithMany("Appointments")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("APPOINTMENT_FK1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FirstProject.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("APPOINTMENT_FK2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstProject.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("APPOINTMENT_FK3")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirstProject.Models.Attendance", b =>
                {
                    b.HasOne("FirstProject.Models.Doctor", "Doctor")
                        .WithMany("Attendances")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("ATTENDANCE_FK1")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("FirstProject.Models.Doctor", b =>
                {
                    b.HasOne("FirstProject.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("DOCTOR_FK1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FirstProject.Models.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .HasConstraintName("DOCTOR_FK2")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstProject.Models.Invoice", b =>
                {
                    b.HasOne("FirstProject.Models.Doctor", "Doctor")
                        .WithMany("Invoices")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("INVOICES_FK2")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FirstProject.Models.Patient", "Patient")
                        .WithMany("Invoices")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("INVOICES_FK1")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirstProject.Models.PatientsVesa", b =>
                {
                    b.HasOne("FirstProject.Models.Patient", "Patient")
                        .WithMany("PatientsVesas")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("PATIENTS_VESA_FK1")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirstProject.Models.TestimonialSection", b =>
                {
                    b.HasOne("FirstProject.Models.Patient", "Patient")
                        .WithMany("TestimonialSections")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("TESTIMONIAL_SECTION_FK1")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("FirstProject.Models.User", b =>
                {
                    b.HasOne("FirstProject.Models.Admin", "Admin")
                        .WithMany("Users")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("USERS_FK2")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("FirstProject.Models.Doctor", "Doctor")
                        .WithMany("Users")
                        .HasForeignKey("DoctorId")
                        .HasConstraintName("USERS_FK3")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirstProject.Models.Patient", "Patient")
                        .WithMany("Users")
                        .HasForeignKey("PatientId")
                        .HasConstraintName("USERS_FK4")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirstProject.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("USERS_FK1")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}