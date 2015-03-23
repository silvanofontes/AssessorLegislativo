using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Nacionalidade
    {
        /// <summary>
        /// CODIGO_NACIONALIDADE
        /// Código da nacionalidade do candidato
        /// (não usar campo auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DESCRICAO_NACIONALIDADE
        /// Descrição da nacionalidade do candidato
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
