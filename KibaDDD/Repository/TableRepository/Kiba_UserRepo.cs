using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 

namespace Repository
{
    public class Kiba_UserRepo : BaseRepository
    {   
        public List<T> GetSelector<T>(Expression<Func<Kiba_User, T>> selector, Expression<Func<Kiba_User, bool>> where)
        {
            return Database.Kiba_User.Where(where).Select(selector).ToList();
        } 
        public List<Kiba_User> GetWhere(Expression<Func<Kiba_User, bool>> where, int currentPage, int pageCount)
        {
            return Database.Kiba_User.Where(where).OrderByDescending(p => p.UserId).Skip((currentPage - 1) * pageCount).Take(pageCount).ToList();
        }
        public int GetWhereCount(Expression<Func<Kiba_User, bool>> where)
        {
            return Database.Kiba_User.Where(where).Count();
        } 
        public Kiba_User Add(Kiba_User model)
        {
            var addModel = Database.Kiba_User.Add(model);
            return addModel;
        }
        public Kiba_User Delete(Kiba_User model)
        {
            var delModel = Database.Kiba_User.Remove(model);
            return delModel;
        }
    }
}
