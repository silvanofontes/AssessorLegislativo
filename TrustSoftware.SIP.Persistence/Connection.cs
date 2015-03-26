using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using SilvanoFontes.AL.Entities;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate;

namespace SilvanoFontes.AL.Persistence
{
    public class Connection
    {
        ISessionFactory session;
        public ISession getConnection()
        {
            if (session == null)
            {
                
                    var db = ConfigurationManager.AppSettings["strConexao"];
                    session = Fluently.Configure().Database(MsSqlConfiguration
                    .MsSql2005
                    .ConnectionString(db.Replace("\\\\", "\\")))
                        //.ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); })//atualiza
                        //.ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })//criar
                        //.ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile(System.Web.HttpContext.Current.Server.MapPath("~/Log")+"\\scripts.sql").Create(true, false))//Exportar Schema
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
                
            }
            return session.OpenSession();

        }
        public ISession OpenSession()
        {
            return getConnection();
        }
    }
}
