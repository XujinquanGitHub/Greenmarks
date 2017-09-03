using Greenmarks.DAL;
using System;
using System.Data.Entity;
using System.Linq;

namespace Greenmarks.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {


        public DbContext CurrentDbSession => DBContextFactory.CreateDbContext();

        public BaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();

        protected BaseService()
        {
            SetCurrentDal();//子类一定要实现抽象方法。
        }
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<TS>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, TS>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<TS>(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDbSession.SaveChanges() > 0;
        }

        public bool Delete(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return true;
            //return currentdbsession.set<T>
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Edit(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDbSession.SaveChanges();
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDbSession.SaveChanges();
            return entity;
        }
    }
}
