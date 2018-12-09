using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 

namespace Repository
{
    public class Kiba_VideoRepo : BaseRepository
    {   
        public List<T> GetSelector<T>(Expression<Func<Kiba_Video, T>> selector, Expression<Func<Kiba_Video, bool>> where)
        {
            return Database.Kiba_Video.Where(where).Select(selector).ToList();
        } 
        public List<Kiba_Video> GetWhere(Expression<Func<Kiba_Video, bool>> where, int currentPage, int pageCount)
        {
            return Database.Kiba_Video.Where(where).OrderByDescending(p => p.VideoId).Skip((currentPage - 1) * pageCount).Take(pageCount).ToList();
        }
        public int GetWhereCount(Expression<Func<Kiba_Video, bool>> where)
        {
            return Database.Kiba_Video.Where(where).Count();
        } 
        public Kiba_Video Add(Kiba_Video model)
        {
            var addModel = Database.Kiba_Video.Add(model);
            return addModel;
        }
        public Kiba_Video Delete(Kiba_Video model)
        {
            var delModel = Database.Kiba_Video.Remove(model);
            return delModel;
        }
    }
}
