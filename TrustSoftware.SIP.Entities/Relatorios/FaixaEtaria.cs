using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities.Relatorios
{
    public class FaixaEtaria
    {

        public virtual int Id { get; set; }

        /// <summary>
        /// FAIXA_ETARIA - Faixa Etária
        /// </summary>
        public virtual string Faixa { get; set; }
    }
}
