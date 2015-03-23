using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Estado
    {
        /// <summary>
        /// Código TSE do Estado
        /// (não pode ser auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Código da Unidade Federativa
        /// </summary>
        public virtual string UF { get; set; }

        /// <summary>
        /// Nome do estado
        /// </summary>
        public virtual string Nome { get; set; }
    }
}
