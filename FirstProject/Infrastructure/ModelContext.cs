using System;
using System.Reflection;
using FirstProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirstProject.Infrastructure
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<BannerSection> BannerSections { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CounterSection> CounterSections { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<FeaturesSection> FeaturesSections { get; set; }
        public virtual DbSet<FooterSection> FooterSections { get; set; }
        public virtual DbSet<HeadSection> HeadSections { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PartnersSection> PartnersSections { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientsVesa> PatientsVesas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServicePage> ServicePages { get; set; }
        public virtual DbSet<ServiceSection> ServiceSections { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Subscrip> Subscrips { get; set; }
        public virtual DbSet<TestimonialSection> TestimonialSections { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///if (!optionsBuilder.IsConfigured)
            ///{

            optionsBuilder.UseSqlServer("Server=.;Database=HealthCare;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;");
            ///}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            ///modelBuilder.HasDefaultSchema("HealthCare.dbo")
            ///    .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            ///    IF U WANT TO USE THE ORACLE DATABASE PLZ REPLACE THE (INT AND DECIMAL) DATATYPE
            ///    WITH NUMBER AND DELETE THE 

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMINS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd()
                    ;

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENTS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("APPOINTMENT_DATE");

                entity.Property(e => e.AppointmentTime)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APPOINTMENT_TIME");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("INT")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("INT")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.PatientId)
                    .HasColumnType("INT")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 \n");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("APPOINTMENT_FK1");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("APPOINTMENT_FK2");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("APPOINTMENT_FK3");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCES");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.AttendanceDate)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ATTENDANCE_DATE");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("INT")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("ATTENDANCE_FK1");
            });

            modelBuilder.Entity<BannerSection>(entity =>
            {
                entity.ToTable("BANNER_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Topic)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TOPIC");
            });

            modelBuilder.Entity<CounterSection>(entity =>
            {
                entity.ToTable("COUNTER_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.ExpertDoctor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPERT_DOCTOR");

                entity.Property(e => e.HappyPeopel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HAPPY_PEOPEL");

                entity.Property(e => e.SurgeryComeplet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SURGERY_COMEPLET");

                entity.Property(e => e.WordwideBranch)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WORDWIDE_BRANCH");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("DOCTORS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.AvailableDay)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AVAILABLE_DAY");

                entity.Property(e => e.AvailableTime)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AVAILABLE_TIME");

                entity.Property(e => e.Bod)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("BOD");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("INT")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.IsAvailable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IS_AVAILABLE")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Salary)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("SALARY");

                entity.Property(e => e.SpecializationId)
                    .HasColumnType("INT")
                    .HasColumnName("SPECIALIZATION_ID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("DOCTOR_FK1");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("DOCTOR_FK2");
            });

            modelBuilder.Entity<FeaturesSection>(entity =>
            {
                entity.ToTable("FEATURES_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.EmaegencyCase)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAEGENCY_CASE");

                entity.Property(e => e.TimesatSun)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMESAT_SUN");

                entity.Property(e => e.TimesunWed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMESUN_WED");

                entity.Property(e => e.TimethuFri)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIMETHU_FRI");
            });

            modelBuilder.Entity<FooterSection>(entity =>
            {
                entity.ToTable("FOOTER_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Column1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN1");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<HeadSection>(entity =>
            {
                entity.ToTable("HEAD_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.ClinicAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_ADDRESS");

                entity.Property(e => e.ClinicEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_EMAIL");

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLINIC_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICES");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.BookingAmount)
                    .HasColumnType("DECIMAL(8,2)")
                    .HasColumnName("BOOKING_AMOUNT")
                    .HasDefaultValueSql("10 \n");

                entity.Property(e => e.BookingDate)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BOOKING_DATE");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("INT")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.PatientId)
                    .HasColumnType("INT")
                    .HasColumnName("PATIENT_ID");


                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("INVOICES_FK2");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("INVOICES_FK1");

            });


            modelBuilder.Entity<PartnersSection>(entity =>
            {
                entity.ToTable("PARTNERS_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("PATIENTS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Bod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BOD");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");
            });

            modelBuilder.Entity<PatientsVesa>(entity =>
            {
                entity.ToTable("PATIENTS_VESA");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Balance)
                    .HasColumnType("DECIMAL(8,2)")
                    .HasColumnName("BALANCE")
                    .HasDefaultValueSql("1000 ");

                entity.Property(e => e.PatientId)
                    .HasColumnType("INT")
                    .HasColumnName("PATIENT_ID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientsVesas)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PATIENTS_VESA_FK1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<ServicePage>(entity =>
            {
                entity.ToTable("SERVICE_PAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<ServiceSection>(entity =>
            {
                entity.ToTable("SERVICE_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("SPECIALIZATION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Subscrip>(entity =>
            {
                entity.ToTable("SUBSCRIP");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");
            });

            modelBuilder.Entity<TestimonialSection>(entity =>
            {
                entity.ToTable("TESTIMONIAL_SECTION");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.PatientId)
                    .HasColumnType("INT")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("0 \n");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TestimonialSections)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("TESTIMONIAL_SECTION_FK1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    ;

                entity.Property(e => e.AdminId)
                    .HasColumnType("INT")
                    .HasColumnName("ADMIN_ID");

                entity.Property(e => e.DoctorId)
                    .HasColumnType("INT")
                    .HasColumnName("DOCTOR_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PatientId)
                    .HasColumnType("INT")
                    .HasColumnName("PATIENT_ID");

                entity.Property(e => e.RoleId)
                    .HasColumnType("INT")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("USERS_FK2");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERS_FK3");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERS_FK4");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("USERS_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
