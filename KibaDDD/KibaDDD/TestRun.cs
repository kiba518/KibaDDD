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
        public TestRun()
        {
            Kiba_UserRepo repo = new Kiba_UserRepo();
            repo.Add(new Kiba_User() { UserName = "kiba518" });
            repo.SaveChanges(); 
        }
    }
}
