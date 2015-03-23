using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Partido
    {

        public virtual int Id { get; set; }

        /// <summary>
        /// NUMERO_PARTIDO
        /// Número do partido
        /// </summary>
        public virtual int Numero { get; set; }

        /// <summary>
        /// SIGLA_PARTIDO
        /// Sigla do partido
        /// </summary>
        public virtual string Sigla { get; set; }

        /// <summary>
        /// NOME_PARTIDO
        /// Nome do partido
        /// </summary>
        public virtual string Nome { get; set; }
    }
}
