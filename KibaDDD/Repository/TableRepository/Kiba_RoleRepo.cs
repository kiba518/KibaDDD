using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 

namespace Repository
{
    public class Kiba_RoleRepo : BaseRepository
    {   
        public List<T> GetSelector<T>(Expression<Func<Kiba_Role, T>> selector, Expression<Func<Kiba_Role, bool>> where)
        {
            return Database.Kiba_Role.Where(where).Select(selector).ToList();
        } 
        public List<Kiba_Role> GetWhere(Expression<Func<Kiba_Role, bool>> where, int currentPage, int pageCount)
        {
            return Database.Kiba_Role.Where(where).OrderByDescending(p => p.RoleId).Skip((currentPage - 1) * pageCount).Take(pageCount).ToList();
        }
        public int GetWhereCount(Expression<Func<Kiba_Role, bool>> where)
        {
            return Database.Kiba_Role.Where(where).Count();
        } 
        public Kiba_Role Add(Kiba_Role model)
        {
            var addModel = Database.Kiba_Role.Add(model);
            return addModel;
        }
        public Kiba_Role Delete(Kiba_Role model)
        {
            var delModel = Database.Kiba_Role.Remove(model);
            return delModel;
        }
    }
}
