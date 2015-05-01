using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{

    public class Retorno
    {
        /*
        public virtual int sEcho { get; set; }
        public virtual int iTotalRecords { get; set; }
        public virtual int iTotalDisplayRecords { get; set; }
         */
        public virtual object[] aaData { get; set; }

    }
}