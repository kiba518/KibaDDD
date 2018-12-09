using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace KibaDDD
{
    public class TestRun
    {
        public void AddCompany()
        {
            try
            {
                Kiba_CompanyRepo companyRepo = new Kiba_CompanyRepo();


                var user = new Kiba_User() { UserName = "kiba518" };
                user.Kiba_Role = new List<Kiba_Role>();
                user.Kiba_Role.Add(new Kiba_Role() { RoleName = "管理员" });


                Kiba_Company company = new Kiba_Company();
                company.CompanyName = "Kiba";
                company.Kiba_User = new List<Kiba_User>();
                company.Kiba_User.Add(user);
                companyRepo.Add(company);


                companyRepo.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public void AddUser()
        {
            try
            {
                Kiba_UserRepo userRepo = new Kiba_UserRepo();

                var user = new Kiba_User() { UserName = "kiba518", CompanyId = 1 };
                user.Kiba_Role = new List<Kiba_Role>();
                user.Kiba_Role.Add(new Kiba_Role() { RoleName = "管理员" });
                userRepo.Add(user);

                userRepo.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public void AddRole()
        {
            try
            {
                Kiba_RoleRepo roleRepo = new Kiba_RoleRepo();
                var role = new Kiba_Role()
                {
                    RoleName = "视频管理员"
                };

                role.Kiba_Video = new List<Kiba_Video>();
                role.Kiba_Video.Add(new Kiba_Video() { VideoName = "测试视频" });

                roleRepo.Add(role);

                roleRepo.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
