using APi.Context;
using APi.Handler;
using APi.Models;
using APi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APi.Repositories.Data
{
    public class AccountRepository : GeneralRepository<string, Account>
    {
        private readonly MyContext context;
        private readonly EmployeeRepository empRepository;

        public AccountRepository(MyContext context, EmployeeRepository empRepository) : base(context)
        {
            this.context = context;
            this.empRepository = empRepository;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var getAccounts = await context.Employees
                .Include(e => e.Account)
                .Select(e => new LoginVM
                {
                    Email = e.Email,
                    Password = e.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            //var getAccounts = context.Employees.Join(
            //    context.Accounts,
            //    e => e.NIK,
            //    a => a.EmployeeNIK,
            //    (e, a) => new LoginVM
            //    {
            //        Email = e.Email,
            //        Password = a.Password
            //    }).FirstOrDefault(a => a.Email == loginVM.Email);

            if (getAccounts is null)
            {
                return false;
            }
            return Hashing.ValidatePassword(loginVM.Password, getAccounts.Password);
        }

        public async Task<int> Register(RegisterVM registerVM)
        {
            int result = 0;
            University university = new University
            {
                Name = registerVM.UniversityName
            };

            // Bikin kondisi untuk mengecek apakah data university sudah ada
            if (await context.Universities.AnyAsync(u => u.Name == university.Name))
            {
                university.Id = context.Universities
                    .FirstOrDefault(u => u.Name == university.Name)
                    .Id;
            }
            else
            {
                await context.Universities.AddAsync(university);
                result = context.SaveChanges();
            }

            Education education = new Education
            {
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                Gpa = registerVM.GPA,
                UniversityId = university.Id
            };
            await context.Educations.AddAsync(education);
            result = await context.SaveChangesAsync();

            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                HiringDate = registerVM.HiringDate,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            await context.Employees.AddAsync(employee);
            result = await context.SaveChangesAsync();

            Account account = new Account
            {
                EmployeeNIK = registerVM.NIK,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            await context.Accounts.AddAsync(account);
            result = await context.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                AccountNIK = registerVM.NIK,
                RoleId = 2
            };

            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();

            Profiling profiling = new Profiling
            {
                EmployeeId = registerVM.NIK,
                EducationId = education.Id
            };
            await context.Profilings.AddAsync(profiling);
            result = await context.SaveChangesAsync();

            return result;
        }

        //public async Task<List<AccountEmployeeVM>> GetEmployeeAccount()
        //{
        //    var results = (from a in GetAll()
        //                   join e in empRepository.GetAll()
        //                   on a.EmployeeNIK equals e.NIK
        //                   select new AccountEmployeeVM
        //                   {
        //                       Email = e.Email,
        //                       Password = a.Password
        //                   }).ToList();
        //    return results;
        //}

        public async Task<UserDataVM> GetUserData(string email)
        {
            //Menggunakan Method Syntax
            //var userdataMethod = context.Employees
            //  .Join(context.Accounts,
            //  e => e.NIK,
            //  a => a.EmployeeNIK,
            //  (e, a) => new { e, a })
            //  .Join(context.AccountRoles,
            //  ea => ea.a.EmployeeNIK,
            //  ar => ar.AccountNIK,
            //  (ea, ar) => new { ea, ar })
            //  .Join(context.Roles,
            //  eaar => eaar.ar.RoleId,
            //  r => r.Id,
            //  (eaar, r) => new UserDataVM
            //  {
            //      Email = eaar.ea.e.Email,
            //      FullName = String.Concat(eaar.ea.e.FirstName, eaar.ea.e.LastName),
            //      Role = r.Name
            //  }).FirstOrDefault(u => u.Email == email);

            //Menggunakan Query Syntax 
            var userdata = await (from e in context.Employees //seharusnya jangan pake context tapi import dari repository nya table bersangkutan
                            join a in context.Accounts
                            on e.NIK equals a.EmployeeNIK
                            join ar in context.AccountRoles
                            on a.EmployeeNIK equals ar.AccountNIK
                            join r in context.Roles
                            on ar.RoleId equals r.Id
                            where e.Email == email
                            select new UserDataVM
                            {
                                Email = e.Email,
                                FullName = string.Concat(e.FirstName, " ", e.LastName)
                            }).FirstOrDefaultAsync();

            return userdata;
        }

        public async Task<List<string>> GetRolesByNIK(string email)
        {
            var getNIK = await context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return context.AccountRoles.Where(ar => ar.AccountNIK == getNIK.NIK).Join(
                context.Roles,
                ar => ar.RoleId,
                r => r.Id,
                (ar, r) => r.Name).ToList();
        }
    }
}
