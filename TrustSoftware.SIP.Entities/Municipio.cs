using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Municipio
    {
        /// <summary>
        /// Código TSE do município
        /// (não pode ser auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Nome do município
        /// </summary>
        public virtual string Descricao { get; set; }

        /// <summary>
        /// Unidade Federativa
        /// </summary>
        public virtual Estado UF { get; set; }

        public Municipio()
        {
            UF = new Estado();
        }
    }
}
