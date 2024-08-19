using FirstProject.Infrastructure;
using FirstProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ApplicationDbContextInitialiser
{
    private readonly ModelContext _context;

    public ApplicationDbContextInitialiser(ModelContext context)
    {
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        #region Admin
        if (!_context.Admins.Any())
        {
            _context.Admins.Add(new Admin()
            {
                //Id = 1,
                FirstName = "Khaled",
                LastName = "ATATIRK",
                Phone = "4579842154",
                ImagePath = "dd8b91d8-8712-4819-a25a-f26e7665882b_CEO.png"
            });
        }
        #endregion
        
        await _context.SaveChangesAsync();

        #region HeadSections
        if (!_context.HeadSections.Any())
        {
            _context.HeadSections.Add(new HeadSection()
            {
                //Id = 1,
                ClinicName = "Health Care",
                ClinicAddress = "Address Ta-132/B, Dubai, UAE",
                ClinicEmail = "healthcareBAccoount@gmail.com",
                ImagePath = "6015e130-44c1-4036-8e0a-ddd0ad56f44f_logo2.png"
            });
        }
        #endregion

        #region BannerSection
        if (!_context.BannerSections.Any())
        {
            _context.BannerSections.Add(new BannerSection()
            {
                //Id = 1,
                Title = "Your Most Trusted Health Partner",
                Description = "For more than 30 years, HealthCare Clinic has offered advanced healthcare to our patients and amongst the multiple clinics in Dubai, we stand alone, recognized as the best medical center in Dubai.",
                ImagePath = "081eb5b5-1e5e-44f3-bdcf-ad138a8da730_h3-image.jpeg"
            });
        }
        #endregion

        #region Contacts
        if (!_context.Contacts.Any())
        {
            _context.Contacts.Add(new Contact()
            {
                //Id = 1,
                FullName = "Amar",
                Email = "Amar@gmail.com",
                Topic = "dential",
                Phone = "0798654012",
                Message = "prove your doctors"
            });
            _context.Contacts.Add(new Contact()
            {
                //Id = 2,
                FullName = "Adnan",
                Email = "A545@gmail.com",
                Topic = "dential",
                Phone = "0795654554",
                Message = "change password"
            });
        }
        #endregion

        #region FeaturesSections
        if (!_context.FeaturesSections.Any())
        {
            _context.FeaturesSections.Add(new FeaturesSection()
            {
                //Id = 1,
                TimesunWed = "08:00 - 17:00",
                TimethuFri = "10:00 - 17:00",
                TimesatSun = "08:00 - 17:00",
                EmaegencyCase = "1-800-700-6200"
            });
        }
        #endregion

        #region ServicePages
        if (!_context.ServicePages.Any())
        {
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 1,
                Title = "PERSONAL CARE",
                Description = "Overseeing Your Wellbeing in All Areas",
                ImagePath = "1650ee84-b961-4280-b984-113db1a587ec_service-2.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 2,
                Title = "CHILD CARE",
                Description = "Overseeing Your Wellbeing in All Areas",
                ImagePath = "10c197e4-b66c-4ed7-8364-7e852ce61b6f_Serc_5.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 3,
                Title = "GENERAL DENTISTRY",
                Description = "It?s time to meet the best Dentist in Dubai DLC?s expert team make visiting the Dentist a joyful experience",
                ImagePath = "d849ef9a-f3d8-4a9d-8b46-9720ed7b823d_service-1.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 4,
                Title = "PULMONOLOGY",
                Description = "Ensuring you breathe easily",
                ImagePath = "b6ca484e-6d65-4b61-b062-2550b15073e9_Services_2.png"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 5,
                Title = "PATHOLOGY LAB",
                Description = "On-site Analysis and Fast Turnaround Results",
                ImagePath = "61a1173e-9afe-4ee4-80f5-43a2739b9727_Serc_3.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 6,
                Title = "OPHTHALMOLOGY",
                Description = "Health Care Clinic boasts an amazing team of Ophthalmology Specialists that provide diagnosis and treatment for various eye diseases and conditions.",
                ImagePath = "6a418394-2ed8-46bc-9260-1cf2ea31d9b5_Serc_4.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 7,
                Title = "ANAESTHESIA",
                Description = "Experts in Sedation and Pain Management",
                ImagePath = "4e18ef32-74fb-4cab-bd04-786d5a1bac4d_serc_6.jpg"
            });
            _context.ServicePages.Add(new ServicePage()
            {
                //Id = 8,
                Title = "ORTHOPAEDICS",
                Description = "Protecting your posture and preventing injury Meet the expert Orthopaedic Specialist Dubai London Clinic has in residence",
                ImagePath = "e441e107-638c-4334-a8ec-92d412c5ba66_Serc_7.jpg"
            });
        }
        #endregion

        #region PartnersSections
        if (!_context.PartnersSections.Any())
        {
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 1,
                Description = "",
                ImagePath = "256ceb48-e964-409f-86ba-df64b9b5101a_1.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 2,
                Description = "",
                ImagePath = "8d5846d9-d11d-4aab-ab40-002763793315_2.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 3,
                Description = "",
                ImagePath = "d7cd0de9-1cf9-4d22-bd36-90f645415d59_3.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 4,
                Description = "",
                ImagePath = "3895c396-79dd-4c50-883b-7283c546cc24_05.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 5,
                Description = "",
                ImagePath = "c0a41c80-ac37-43e0-8b6a-151f81b9d126_4.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 6,
                Description = "",
                ImagePath = "65d2bc6d-b159-4b27-9150-177fcf79ff7b_5.png"
            });
            _context.PartnersSections.Add(new PartnersSection()
            {
                //Id = 7,
                Description = "",
                ImagePath = "8cc90106-523d-4a26-bc02-7729661605f3_6.png"
            });
        }
        #endregion

        #region CounterSections
        if (!_context.CounterSections.Any())
        {
            _context.CounterSections.Add(new CounterSection()
            {
                //Id = 1,
                HappyPeopel = "1532",
                SurgeryComeplet = "700",
                ExpertDoctor = "639",
                WordwideBranch = "36"
            });
        }
        #endregion

        #region Departments
        if (!_context.Departments.Any())
        {
            _context.Departments.Add(new Department()
            {
                //Id = 1,
                Name = "DENTISTRY",
                Description = "It?s time to meet the best Dentist in Dubai",
                ImagePath = "67ecd38f-e074-4786-a4db-e63176842fa7_Depa_1.jpg"
            });
            _context.Departments.Add(new Department()
            {
                //Id = 2,
                Name = "CARDIOLOGY",
                Description = "Comitted to Your Heart Health",
                ImagePath = "8897f317-f3ad-4064-b5c3-64dbaaa69be7_dep_2.jpg"
            });
            _context.Departments.Add(new Department()
            {
                //Id = 3,
                Name = "DERMATOLOGY",
                Description = "Medical care for your skin, nails and hair with the best Skin Specialists in Dubai",
                ImagePath = "89d3e305-400b-445c-be88-0921df4a74eb_Dep_3.jpg"
            });
            _context.Departments.Add(new Department()
            {
                //Id = 4,
                Name = "GENERAL SURGERY",
                Description = "Overseeing Your Wellbeing in All Areas",
                ImagePath = "a4ad2482-d52c-4cc5-b4e9-bbb528472360_Dep_5.png"
            });
            _context.Departments.Add(new Department()
            {
                //Id = 5,
                Name = "OPHTHALMOLOGY",
                Description = "The Best Eye Doctors in Dubai",
                ImagePath = "40f13470-15b3-4052-aab7-0365556ad8da_Dep_6.jpg"
            });
            _context.Departments.Add(new Department()
            {
                //Id = 6,
                Name = "ORTHOPAEDICS",
                Description = "Protecting your posture and preventing injury Meet the expert Orthopaedic Specialist",
                ImagePath = "834ba517-79e3-46e7-9365-26861e8a301b_Dep_7.jpg"
            });
        }
        #endregion

        #region Specializations
        if (!_context.Specializations.Any())
        {
            _context.Specializations.Add(new Specialization()
            {
                //Id = 1,
                Name = "Cardiology",
            });
            _context.Specializations.Add(new Specialization()
            {
                //Id = 2,
                Name = "Dental",
            });
            _context.Specializations.Add(new Specialization()
            {
                //Id = 3,
                Name = "Pediatry",
            });
            _context.Specializations.Add(new Specialization()
            {
                //Id = 4,
                Name = "ophthalmology",
            });
            _context.Specializations.Add(new Specialization()
            {
                //Id = 5,
                Name = "General Medicine",
            });
            _context.Specializations.Add(new Specialization()
            {
                //Id = 6,
                Name = "Otolaryngology",
            });
        }
        #endregion

        await _context.SaveChangesAsync();

        #region Doctors
        if (!_context.Doctors.Any())
        {
            _context.Doctors.Add(new Doctor()
            {
                //Id = 1,
                FirstName = "dana",
                LastName = "kanaan",
                Email = "danakanaan125@gmail.com",
                Phone = "4578987410",
                Address = "Jordan",
                Bod = "2000-04-19",
                IsAvailable = "1",
                AvailableTime = "Not decided yet",
                AvailableDay = "Not decided yet",
                Salary = "1200",
                DepartmentId = 6,
                SpecializationId = 2,
                ImagePath = "85af87ff-9a00-4ef9-9f77-10a4e271158b_doc_16.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 2,
                FirstName = "ASEEL",
                LastName = "AL NASSERI",
                Email = "aseel1987@gmail.com",
                Phone = "7909846251",
                Address = "Jordan",
                Bod = "1987-05-11",
                IsAvailable = "",
                AvailableTime = "08:00 - 15:00",
                AvailableDay = "Sunday - Thursday",
                Salary = "1200",
                DepartmentId = 2,
                SpecializationId = 2,
                ImagePath = "5ce11888-1bbd-42b5-afac-d5f89e8ef16c_doc_1.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 3,
                FirstName = "MARIA",
                LastName = "VICTORIA RIVEROS",
                Email = "maria1977@hotmail.com",
                Phone = "7909846251",
                Address = "UAE",
                Bod = "1977-06-14",
                IsAvailable = "",
                AvailableTime = "07:00 - 15:00",
                AvailableDay = "Sunday - Friday",
                Salary = "1200",
                DepartmentId = 2,
                SpecializationId = 3,
                ImagePath = "a1ddc9b0-9fae-4a04-93e5-2b8b3e953061_doc_2.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 4,
                FirstName = "JONE",
                LastName = "FILIPE DE MELO",
                Email = "jone977@hotmail.com",
                Phone = "7909846251",
                Address = "UAE",
                Bod = "1999-06-14",
                IsAvailable = "",
                AvailableTime = "07:00 - 14:00",
                AvailableDay = "Monday - Friday",
                Salary = "1500",
                DepartmentId = 3,
                SpecializationId = 3,
                ImagePath = "f4c00a07-c676-4576-84f6-f08daec18970_doc_3.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 5,
                FirstName = "MOHAMED",
                LastName = "MOURSI",
                Email = "mohammad.Moursi@yahoo.com",
                Phone = "7505546251",
                Address = "UAE",
                Bod = "1988-06-14",
                IsAvailable = "",
                AvailableTime = "09:00 - 16:00",
                AvailableDay = "Monday - Friday",
                Salary = "3500",
                DepartmentId = 1,
                SpecializationId = 3,
                ImagePath = "92849f35-e300-4ad3-800a-21a2a8932704_doc_4.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 6,
                FirstName = "TAMKEEN",
                LastName = "KINAH",
                Email = "tamkeen.k@hotmail.com",
                Phone = "7505546251",
                Address = "UAE",
                Bod = "1988-06-14",
                IsAvailable = "",
                AvailableTime = "09:00 - 16:00",
                AvailableDay = "Tuesday- Saturday",
                Salary = "2500",
                DepartmentId = 3,
                SpecializationId = 1,
                ImagePath = "298c481c-4b4e-43c1-8f0d-44f1baf85e9c_doc_5.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 7,
                FirstName = "BINA",
                LastName = "RABADIA",
                Email = "bina1976@gmail.com",
                Phone = "76554846420",
                Address = "UAE",
                Bod = "1998-06-14",
                IsAvailable = "",
                AvailableTime = "08:00 - 16:00",
                AvailableDay = "Tuesday- Saturday",
                Salary = "2500",
                DepartmentId = 4,
                SpecializationId = 5,
                ImagePath = "d9fc8c61-e0a7-4545-be45-ec1553297e29_doc_6.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 8,
                FirstName = "UMESH",
                LastName = "NIHALANI",
                Email = "umesh.N@hotmail.com",
                Phone = "76554846420",
                Address = "UAE",
                Bod = "1998-06-14",
                IsAvailable = "",
                AvailableTime = "07:00 - 15:00",
                AvailableDay = "Tuesday- Saturday",
                Salary = "1500",
                DepartmentId = 4,
                SpecializationId = 3,
                ImagePath = "74b49cd8-e35f-4c1f-a928-53f533e3d6c4_doc_7.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 9,
                FirstName = "KHUSHBU",
                LastName = "GOEL",
                Email = "Khushbu.G@gmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1968-06-14",
                IsAvailable = "",
                AvailableTime = "07:00 - 15:00",
                AvailableDay = "Tuesday- Saturday",
                Salary = "6500",
                DepartmentId = 6,
                SpecializationId = 5,
                ImagePath = "914540ca-d0a9-400d-8338-0678fc076378_doc_8.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 10,
                FirstName = "ANTONIO",
                LastName = "PRIVITERA",
                Email = "Antonio.P@hotmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1968-06-14",
                IsAvailable = "",
                AvailableTime = "10:00 - 15:00",
                AvailableDay = "Sunday- Friday",
                Salary = "6500",
                DepartmentId = 6,
                SpecializationId = 4,
                ImagePath = "c173251a-20a3-4bfe-806f-880703de1f38_doc_9.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 11,
                FirstName = "AHMAD",
                LastName = "IBRAHIM KAMAR",
                Email = "Ahmad1982@yahoo.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1978-06-14",
                IsAvailable = "",
                AvailableTime = "10:00 - 13:00",
                AvailableDay = "Sunday- Friday",
                Salary = "6500",
                DepartmentId = 1,
                SpecializationId = 1,
                ImagePath = "3878855d-8cd7-4c47-9932-a09e1eaa08ff_doc_10.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 12,
                FirstName = "NAIMA",
                LastName = "BEN MOUSSA",
                Email = "Naima.Ben@gmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1978-06-14",
                IsAvailable = "",
                AvailableTime = "08:00 - 17:00",
                AvailableDay = "Monday - Saturday",
                Salary = "6500",
                DepartmentId = 5,
                SpecializationId = 4,
                ImagePath = "1da01acd-1f9f-414f-993e-aaeb90da42e8_doc_11.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 13,
                FirstName = "VISHAL",
                LastName = "SHAH",
                Email = "SHAH.Ben@gmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1981-06-14",
                IsAvailable = "",
                AvailableTime = "09:00 - 15:00",
                AvailableDay = "Monday - Saturday",
                Salary = "6500",
                DepartmentId = 5,
                SpecializationId = 4,
                ImagePath = "0eae5d70-5420-4c3a-a30b-e45a25ad563a_doc_12.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 14,
                FirstName = "KUTAIBA",
                LastName = "SALMAN",
                Email = "SHAH.Ben@gmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1981-06-14",
                IsAvailable = "",
                AvailableTime = "09:00 - 15:00",
                AvailableDay = "Monday - Saturday",
                Salary = "6500",
                DepartmentId = 3,
                SpecializationId = 4,
                ImagePath = "c0bb876b-86a9-4d6f-8169-484eddc84da4_doc_14.png"
            });
            _context.Doctors.Add(new Doctor()
            {
                //Id = 15,
                FirstName = "MALCOLM",
                LastName = "D PODMORE",
                Email = "MALCOLM@gmail.com",
                Phone = "5124570212",
                Address = "UAE",
                Bod = "1981-06-14",
                IsAvailable = "",
                AvailableTime = "09:00 - 15:00",
                AvailableDay = "Monday - Thursday",
                Salary = "6500",
                DepartmentId = 2,
                SpecializationId = 1,
                ImagePath = "c393ab14-5bb4-4a98-92b4-ce23a18eb66d_doc_14.png"
            });
        }
        #endregion

        #region Roles
        if (!_context.Roles.Any())
        {
            _context.Roles.Add(new Role()
            {
                //Id = 1,
                Rolename = "Admin"
            });
            _context.Roles.Add(new Role()
            {
                //Id = 2,
                Rolename = "Doctor"
            });
            _context.Roles.Add(new Role()
            {
                //Id = 3,
                Rolename = "Patient"
            });
        }
        #endregion

        #region Users
        if (!_context.Users.Any())
        {
            _context.Users.Add(new User()
            {
                //Id = 1,
                UserName = "Admin@healthcare.com",
                Password = "12345678",
                RoleId = 1,
                AdminId = 1,
                DoctorId = null,
                PatientId = null
            });
            _context.Users.Add(new User()
            {
                //Id = 2,
                UserName = "aseel1987@gmail.com",
                Password = "12345678",
                RoleId = 2,
                AdminId = null,
                DoctorId = 1,
                PatientId = null
            });
        }
        #endregion

        await _context.SaveChangesAsync();
    }
}