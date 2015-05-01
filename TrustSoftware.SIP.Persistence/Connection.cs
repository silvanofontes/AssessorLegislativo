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
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence
{
    public class Connection
    {
        ISessionFactory session;
        public ISession getConnection()
        {
            if (session == null)
            {
                if (System.Web.HttpContext.Current.Session["conexao"] != null)
                {
                    session = (ISessionFactory)System.Web.HttpContext.Current.Session["conexao"];
                }
                else
                {

                    var db = ConfigurationManager.AppSettings["strConexao"];
                    session = Fluently.Configure().Database(MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(db.Replace("\\\\", "\\")))
                        //.ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); })//atualiza
                        //.ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })//criar
                        //.ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile(System.Web.HttpContext.Current.Server.MapPath("~/Log")+"\\scripts.sql").Create(true, false))//Exportar Schema
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();

                    System.Web.HttpContext.Current.Session["conexao"] = session;
                }
            }

            return session.OpenSession();

        }
        public ISession OpenSession()
        {
            //return getConnection();
            return FNHSessionManager.OpenSession();
        }

        public bool DBMaintenance(DBAction action)
        {
            ISessionFactory session2;
            var db = ConfigurationManager.AppSettings["strConexao"];

            FluentConfiguration confg;
            confg = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(db.Replace("\\\\", "\\")));
            
            switch (action)
            {
                case DBAction.Create:
                    confg.ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); }); // create
                    break;
                case DBAction.Update:
                    confg.ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); });//atualiza
                    break;
                case DBAction.Export:
                    confg.ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile(System.Web.HttpContext.Current.Server.MapPath("~/Log") + "\\scripts.sql").Create(true, false));//Exportar Schema
                    break;
                default:
                    break;
            }
            
            
            confg.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
            session2 = confg.BuildSessionFactory();
            return true;
        }
    }
    
}
