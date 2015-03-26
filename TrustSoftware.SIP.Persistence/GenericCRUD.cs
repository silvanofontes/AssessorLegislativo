using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility;
using NHibernate;
using Elmah;
using NHibernate.Criterion;

namespace SilvanoFontes.AL.Persistence
{
    internal class ParametroInternal
    {
        public virtual Criteria Type { get; set; }
        public virtual string Text { get; set; }
        public virtual object Value { get; set; }

        /// <summary>
        /// Por padrão defino o Type como Criteria.Eq
        /// </summary>
        public ParametroInternal()
        {
            Type = Criteria.Eq;
        }
    }

    public class GenericCRUD<T> : IGenericCRUD<T>, IDisposable
    {
        private ISession session;
        private Connection conexao;
        private ITransaction transaction;
        private string _strErro;
        private List<ParametroInternal> _criteria;
        private List<Parametro> _alias;

        public string strErro
        {
            get { return _strErro; }
        }


        public GenericCRUD()
        {
            conexao = new Connection();
            session = conexao.OpenSession();

            _criteria = new List<ParametroInternal>();
            _alias = new List<Parametro>();

        }


        public bool Save(T obj)
        {
            try
            {
                if (!session.IsOpen)
                    session = conexao.OpenSession();

                using (session)
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(obj);
                    tx.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.Message;
                return false;
            }
            finally
            {
                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
            }
        }

        //public bool Merge(T obj)
        //{
        //    if (!session.IsOpen)
        //        session = conexao.OpenSession();

        //    try
        //    {
        //        using (session)
        //        using (ITransaction tx = session.BeginTransaction())
        //        {
        //            session.Merge(obj);
        //            tx.Commit();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorSignal.FromCurrentContext().Raise(ex);
        //        _strErro = ex.Message;
        //        return false;
        //    }
        //    finally
        //    {
        //        if (session.IsOpen)
        //        {
        //            session.Flush();
        //            session.Clear();
        //        }
        //    }
        //}

        public bool Update(T obj)
        {
            try
            {
                if (!session.IsOpen)
                    session = conexao.OpenSession();

                using (session)
                {
                    transaction = session.BeginTransaction();

                    session.Update(obj);

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.Message;
                return false;
            }
            finally
            {
                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (session)
                {
                    transaction = session.BeginTransaction();

                    T objeto = session.Get<T>(id);

                    session.Delete(objeto);

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.Message;
                return false;
            }
            finally
            {
                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
            }
        }

        public bool DeleteByFilter()
        {
            var queryString = string.Format("delete {0} where ", typeof(T));
            try
            {

                using (session)
                {
                    transaction = session.BeginTransaction();

                    ICriteria criteria = session.CreateCriteria(typeof(T));

                    bool ColocaAnd = false;

                    //cria os parametros
                    foreach (ParametroInternal item in _criteria)
                    {
                        if (ColocaAnd)
                            queryString += " and ";
                        else
                            ColocaAnd = true;

                        switch (item.Type)
                        {
                            case Criteria.Eq:

                                queryString += " " + item.Text + " = :" + item.Text;

                                break;

                            case Criteria.Like:

                                queryString += " " + item.Text + " like '%:" + item.Text + "%'";

                                break;

                            case Criteria.Ge:

                                queryString += " " + item.Text + " > " + item.Text;

                                break;

                            case Criteria.Le:

                                queryString += " " + item.Text + " < " + item.Text;

                                break;
                        }
                    }

                    IQuery query = session.CreateQuery(queryString);

                    //Preenche os parametros
                    foreach (ParametroInternal item in _criteria)
                    {
                        query.SetParameter(item.Text, item.Value);
                    }

                    query.ExecuteUpdate();

                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ErrorSignal.FromCurrentContext().Raise(ex);
                throw;
            }
            return true;
        }

        public T getById(int id)
        {
            if (!session.IsOpen)
                session = conexao.OpenSession();

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
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.Message;
                throw;
            }
            finally
            {
                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
            }
        }

        public T ByFilter()
        {
            return ByFilter(null);
        }

        public T ByFilter(List<Parametro> parametros)
        {
            try
            {
                using (session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(T));

                    //Alias
                    foreach (Parametro item in _alias)
                    {
                        criteria
                            .CreateAlias(item.Text, item.Value.ToString());
                    }

                    //Criteria
                    foreach (ParametroInternal item in _criteria)
                    {
                        switch (item.Type)
                        {
                            case Criteria.Eq:

                                criteria
                                    .Add(Restrictions.Eq(item.Text, item.Value));
                                break;

                            case Criteria.Like:

                                criteria
                                    .Add(Restrictions.Like(item.Text, "'%" + item.Value + "%'"));
                                break;

                            case Criteria.Month:

                                criteria
                                    .Add(Restrictions.Eq(Projections.SqlFunction("month", NHibernateUtil.DateTime, Projections.Property(item.Text)), item.Value));
                                break;

                            case Criteria.Year:

                                criteria
                                    .Add(Restrictions.Eq(Projections.SqlFunction("year", NHibernateUtil.DateTime, Projections.Property(item.Text)), item.Value));
                                break;

                            default:

                                criteria
                                    .Add(Restrictions.Eq(item.Text, item.Value));
                                break;
                        }
                    }

                    return criteria.UniqueResult<T>();
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.ToString();
                throw;
            }
            finally
            {
                Clear();

                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
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
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.Message;
                throw;
            }
            finally
            {
                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
            }
        }

        public List<T> listByFilter()
        {
            return listByFilter(null);
        }

        public List<T> listByFilter(List<Parametro> parametros)
        {
            try
            {
                using (session)
                {
                    ICriteria criteria = session.CreateCriteria(typeof(T));

                    //Alias
                    foreach (Parametro item in _alias)
                    {
                        criteria
                            .CreateAlias(item.Text, item.Value.ToString());
                    }

                    //Criteria
                    foreach (ParametroInternal item in _criteria)
                    {
                        switch (item.Type)
                        {
                            case Criteria.Eq:

                                criteria
                                    .Add(Restrictions.Eq(item.Text, item.Value));
                                break;

                            case Criteria.Like:

                                criteria
                                    .Add(Restrictions.Like(item.Text, item.Value.ToString(), MatchMode.Anywhere));
                                break;

                            case Criteria.Ge:

                                criteria
                                    .Add(Restrictions.Ge(item.Text, item.Value));
                                break;

                            case Criteria.Le:

                                criteria
                                    .Add(Restrictions.Le(item.Text, item.Value));
                                break;

                            case Criteria.Month:

                                criteria
                                    .Add(Restrictions.Eq(Projections.SqlFunction("month", NHibernateUtil.DateTime, Projections.Property(item.Text)), item.Value));
                                break;

                            case Criteria.Year:

                                criteria
                                    .Add(Restrictions.Eq(Projections.SqlFunction("year", NHibernateUtil.DateTime, Projections.Property(item.Text)), item.Value));
                                break;

                            default:

                                criteria
                                    .Add(Restrictions.Eq(item.Text, item.Value));
                                break;
                        }
                    }

                    List<T> list = new List<T>(criteria.List<T>());

                    return list;
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                _strErro = ex.ToString();
                throw;
            }
            finally
            {
                Clear();

                if (session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                }
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

        public void AddCriteria(Criteria type, Parametro parametro)
        {
            _criteria.Add(new ParametroInternal() { Type = type, Text = parametro.Text, Value = parametro.Value });
        }

        public void AddAlias(Parametro parametro)
        {
            _alias.Add(new Parametro() { Text = parametro.Text, Value = parametro.Value });
        }

        /// <summary>
        /// Limpa os parametros
        /// </summary>
        public void Clear()
        {
            _criteria.Clear();
            _alias.Clear();
        }
    }
}
