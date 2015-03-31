using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class FaixaEtaria
    {

        /// <summary>
        /// Id - AutoIncremento
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// FAIXA_ETARIA - Faixa Etária
        /// </summary>
        public virtual string Faixa { get; set; }
    }
}
