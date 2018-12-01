using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class RepositoryStatic
    {
        [ThreadStatic]
        public static Object DateBaseContext;
    }
}
