using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 

namespace Repository
{
    public class Kiba_CompanyRepo : BaseRepository
    {   
        public List<T> GetSelector<T>(Expression<Func<Kiba_Company, T>> selector, Expression<Func<Kiba_Company, bool>> where)
        {
            return Database.Kiba_Company.Where(where).Select(selector).ToList();
        } 
        public List<Kiba_Company> GetWhere(Expression<Func<Kiba_Company, bool>> where, int currentPage, int pageCount)
        {
            return Database.Kiba_Company.Where(where).OrderByDescending(p => p.CompanyId).Skip((currentPage - 1) * pageCount).Take(pageCount).ToList();
        }
        public int GetWhereCount(Expression<Func<Kiba_Company, bool>> where)
        {
            return Database.Kiba_Company.Where(where).Count();
        } 
        public Kiba_Company Add(Kiba_Company model)
        {
            var addModel = Database.Kiba_Company.Add(model);
            return addModel;
        }
        public Kiba_Company Delete(Kiba_Company model)
        {
            var delModel = Database.Kiba_Company.Remove(model);
            return delModel;
        }
    }
}
