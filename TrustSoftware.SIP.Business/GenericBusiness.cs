using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using SilvanoFontes.AL.Persistence;
using SilvanoFontes.AL.Utility;


namespace SilvanoFontes.AL.Business
{
    public class GenericBusiness<T> : IGenericCRUD<T>, IDisposable
    {
        private GenericCRUD<T> objCRUD;

        public GenericBusiness()
        {
            objCRUD = new GenericCRUD<T>();
        }

        public string strErro
        {
            get { return objCRUD.strErro; }
        }

        public bool Save(T obj)
        {
            return objCRUD.Save(obj);
        }

        //public bool Merge(T obj)
        //{
        //    return objCRUD.Merge(obj);
        //}

        public bool Update(T obj)
        {
            return objCRUD.Update(obj);
        }

        public bool Delete(int id)
        {
            return objCRUD.Delete(id);
        }

        public bool DeleteByFilter()
        {
            return objCRUD.DeleteByFilter();
        }

        public T getById(int id)
        {
            return objCRUD.getById(id);
        }

        public List<T> ListAll()
        {
            return objCRUD.ListAll();
        }

        public List<T> listByFilter()
        { return objCRUD.listByFilter(); }

        public List<T> listByFilter(List<Parametro> obj)
        {
            return objCRUD.listByFilter(obj);
        }


        public T ByFilter()
        {
            return objCRUD.ByFilter();
        }

        public T ByFilter(List<Parametro> obj)
        {
            return objCRUD.ByFilter(obj);
        }

        public void AddCriteria(Criteria type, Parametro parametro)
        {
            objCRUD.AddCriteria(type, parametro);
        }

        public void AddAlias(Parametro parametro)
        {
            objCRUD.AddAlias(parametro);
        }

        public void Dispose()
        {
            objCRUD.Dispose();
            objCRUD = null;
        }
        public void Clear()
        { objCRUD.Clear(); }

        public void AddCriteria(Expression<Func<T, object>> expression, Criteria type, object value)
        {

            string text = GetPropertyByName(expression);

            AddCriteria(type, new Parametro() { Text = text, Value = value });

        }

        public virtual string GetEntityByProperty(Expression<Func<T, object>> expression, object value)
        {
            string selectedProperty = GetPropertyByName(expression);

            string sqlStatement = string.Format("SELECT * FROM <Entity Table> WHERE {0} = {1}", selectedProperty, value);

            return sqlStatement;
        }

        public static string GetPropertyByName(Expression<Func<T, object>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            MemberExpression memberExpr = expression.Body as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = expression.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;

                Expression test1 = unaryExpr.Operand;

            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                return memberExpr.Member.Name;

            throw new ArgumentException("No property reference expression was found.", "expression");

        }


    }

}
