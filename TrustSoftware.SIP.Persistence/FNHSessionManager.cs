using System;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Context;

namespace SilvanoFontes.AL.Persistence
{
    public class FNHSessionManager
    {
        public static ISession OpenSession()
        {
            if (!WebSessionContext.HasBind(FNHSessionFactoryManager.CreateSessionFactory()))
            {
                WebSessionContext.Bind(FNHSessionFactoryManager.CreateSessionFactory().OpenSession());
            }

            return FNHSessionFactoryManager.CreateSessionFactory().GetCurrentSession();
        }

        public static void CloseSession()
        {
            if (WebSessionContext.HasBind(FNHSessionFactoryManager.CreateSessionFactory()))
            {
                if (FNHSessionFactoryManager.CreateSessionFactory().GetCurrentSession().IsOpen)
                {
                    FNHSessionFactoryManager.CreateSessionFactory().GetCurrentSession().Close();
                    WebSessionContext.Unbind(FNHSessionFactoryManager.CreateSessionFactory());
                }
            }
        }
    }
}
