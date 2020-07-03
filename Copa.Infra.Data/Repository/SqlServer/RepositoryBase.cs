using Microsoft.EntityFrameworkCore;
using Copa.Domain.Entities;
using Copa.Domain.Interfaces.Repositories;
using Copa.Infra.Data.Contexto;
using Copa.Infra.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Copa.Infra.Data.Repository.SqlServer
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal readonly ILiteCollection<T> colecao;
        internal readonly LiteDatabase contexto;

        public RepositoryBase()
        {
            contexto = new ContextoFactory().GetSingleInstance();
            colecao = contexto.GetCollection<T>();
        }

        public bool Edit(T obj)
        {
            try
            {
                contexto.BeginTrans();
                colecao.Update(obj);
                contexto.Commit();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Remove(T obj)
        {
            try
            {
                contexto.BeginTrans();
                colecao.DeleteAll();
                contexto.Commit();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Add(T obj)
        {
            try
            {
                contexto.BeginTrans();
                colecao.Insert(obj);
                contexto.Commit();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<T> Get()
        {
            return colecao.FindAll().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> expression)
        {
            return colecao.FindAll().Where(expression);
        }
    }
}