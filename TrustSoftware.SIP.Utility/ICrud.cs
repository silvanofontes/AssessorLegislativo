using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Utility
{
    public enum Criteria
    {
        Eq,
        Ge,
        Le,
        Like,
        Month,
        Year
    }

    public enum TipoParametro
    {
        CriteriaLike,
        CriteriaEq,
        Alias
    }

    public class Parametro
    {
        //protected virtual TipoParametro Type { get; set; }
        public virtual string Text { get; set; }
        public virtual object Value { get; set; }

        /// <summary>
        /// Por padrão defino o Type como Criteria.Eq
        /// </summary>
        public Parametro()
        { }
    }
}
