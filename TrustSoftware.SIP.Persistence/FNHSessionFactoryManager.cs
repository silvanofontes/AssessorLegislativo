using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Context;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace SilvanoFontes.AL.Persistence
{
    public static class FNHSessionFactoryManager
    {
        private static ISessionFactory sessionFactory = null;
        private static Object createLock = new Object();


        public static ISessionFactory CreateSessionFactory()
        {
            lock (createLock)
            {
                if (sessionFactory == null)
                {
                    FluentConfiguration config = Configuration();

                    sessionFactory = config.BuildSessionFactory();
                }
            }

            return sessionFactory;
        }

        private static FluentConfiguration Configuration()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.AppSettings["strConexao"].Replace("\\\\", "\\")))                    
                .CurrentSessionContext<WebSessionContext>()
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));

            //configuration.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            return configuration;
        }
    }
}
