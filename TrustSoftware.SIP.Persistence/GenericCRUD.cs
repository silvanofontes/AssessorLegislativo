using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence
{
    public class GenericCRUD<T> : IGenericCRUD<T>, IDisposable
    {
        private ISession session;
        private Connection conexao;
        private ITransaction transaction;

        public GenericCRUD()
        {
            conexao = new Connection();
            session = conexao.OpenSession();
        }

        public void Save(T obj)
        {
            if (!session.IsOpen)
                session = conexao.OpenSession();

            try
            {
                using (session)
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(obj);
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                using (session)
                {
                    transaction = session.BeginTransaction();

                    session.Update(obj);

                    transaction.Commit();
                }
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (session)
                {
                    transaction = session.BeginTransaction();

                    T objeto = session.Get<T>(id);

                    session.Delete(objeto);

                    transaction.Commit();
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public T getById(int id)
        {
            try
            {
                using (session)
                {
                    T entidade = session.CreateCriteria(typeof(T))
                        .Add(Expression.Eq("Id", id))
                        .UniqueResult<T>();
                    return entidade;
                }

            }
            catch
            {
                throw;
            }
        }

        public List<T> ListAll()
        {
            try
            {
                using (session)
                {
                    List<T> listaCliente = (List<T>)session
                                        .CreateCriteria(typeof(T))
                                        .List<T>();
                    return listaCliente;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                session.Close();
            }
        }

        public void Dispose()
        {
            if (session.IsOpen)
            {
                session.Close();
            }
            session = null;
        }
    }
}
