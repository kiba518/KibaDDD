using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
using CodeFirstStoredProcs;
using EntityFramework.Extensions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using Utility;

namespace Repository
{
    public class BaseRepository
    { 
        public DateBaseContext Database
        {
            get
            {
                var context = RepositoryStatic.DateBaseContext as DateBaseContext;

                if (context == null)
                {
                    context = new DateBaseContext();
                    RepositoryStatic.DateBaseContext = context;
                }
                 
                return context;
            } 
        }


        public BaseRepository()
        { 
                  
        }
        public int SaveChanges()
        {
            int i = 0;
            int saveCount = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    saveCount++;
                    i = Database.SaveChanges();
                    Logger.Debug("SaveChanges Retrun:" + i);

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (saveCount > 3)
                    {
                        throw new Exception("服务器繁忙，请稍后");
                    }
                    Logger.Error("DbUpdateConcurrencyException保存次数：" + saveCount, ex);
                    saveFailed = true;
                    try
                    {
                        ex.Entries.Single().Reload();
                    }
                    catch (Exception exReload)
                    {
                        Logger.Info("exReload保存失败");
                        throw exReload;
                    }
                }
                catch (DbUpdateException ex)
                {
                    if (ex.Message.Contains("与另一个进程被死锁在 锁 资源上，并且已被选作死锁牺牲品。请重新运行该事务。"))
                    {
                        throw new Exception("服务器繁忙，请稍后");
                    }
                    else
                    {
                        throw ex;
                    } 
                }
                catch (DbEntityValidationException dbEx)
                {
                    Logger.Error(dbEx);
                    throw dbEx;
                }

                catch (Exception ex)
                {
                    Logger.Info("SaveChanges保存失败");
                    throw ex;
                }

            } while (saveFailed);
            return i;
        }

        public int SaveChangesNoValidate()
        {
            try
            {
                Database.Configuration.ValidateOnSaveEnabled = false;
                int result = Database.SaveChanges();
                Database.Configuration.ValidateOnSaveEnabled = true;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Info("SaveChanges保存失败");
                throw ex;
            }
        }

        #region 事务
        public object BeginTransaction()
        {
            try
            {
                var tran = Database.Database.BeginTransaction(IsolationLevel.ReadCommitted);
                return tran;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EndTransaction(object tran)
        {
            DbContextTransaction dbtran = tran as DbContextTransaction;
            try
            {
                dbtran.Commit();
            }
            catch (Exception ex)
            {
                dbtran.Rollback();
                throw ex;
            }
            finally
            {
                dbtran.Dispose();
            }
        }

        public void RollbackTransaction(object tran)
        {
            DbContextTransaction dbtran = tran as DbContextTransaction;
            dbtran.Rollback();
            dbtran.Dispose();
        }
        #endregion

        public void Initialize(bool force)
        {
            try
            {
                Database.Database.Initialize(force);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        #region SQL查询
        public List<T> SqlQuery<T>(string sqlQueryStr)
        {
            try
            {
                List<T> list = new List<T>();
                list = Database.Database.SqlQuery<T>(sqlQueryStr).ToList();
                return list;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public List<T> SqlQuery<T>(string sqlQueryStr, params object[] parameters)
        {
            List<T> list = new List<T>();
            list = Database.Database.SqlQuery<T>(sqlQueryStr, parameters).ToList();
            return list;
        }
        public int ExecuteSqlCommand(string sqlStr)
        {
            return Database.Database.ExecuteSqlCommand(sqlStr);
        }
        public int ExecuteSqlCommand(string sqlStr, params object[] parameters)
        {
            return Database.Database.ExecuteSqlCommand(sqlStr, parameters);
        }
        public void ExecuteSqlCommandTrans(List<string> sqlList)
        {
            using (var tran = Database.Database.BeginTransaction())
            {
                try
                {
                    foreach (var sqlStr in sqlList)
                    {
                        Database.Database.ExecuteSqlCommand(sqlStr);
                    }
                    Database.SaveChanges();
                    //处理业务
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        #endregion

        #region 实体状态修改
        public void DelEntityState(object obj)
        {
            if (obj != null)
            {
                Database.Entry(obj).State = EntityState.Deleted;
            }
        }

        public void AddEntityState(object obj)
        {
            Database.Entry(obj).State = EntityState.Added;
        }

        public void ModifyEntityState(object obj)
        {
            Database.Entry(obj).State = EntityState.Modified;
        }

        public string GetEntityState(object obj)
        {
            return Database.Entry(obj).State.ToString();
        }
        #endregion



    }

}