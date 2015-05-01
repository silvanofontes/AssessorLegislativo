using System;
using System.Web;

namespace SilvanoFontes.AL.Persistence
{
    public class FNHModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(OnEndRequest);
        }

        public void OnEndRequest(Object source, EventArgs e)
        {
            FNHSessionManager.CloseSession();
        }
    }
}