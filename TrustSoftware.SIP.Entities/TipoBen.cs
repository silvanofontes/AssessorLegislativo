using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class TipoBem
    {
        /// <summary>
        /// CD_TIPO_BEM_CANDIDATO - Código do tipo do bem do candidato
        /// ATENÇÃO: não usar campo auto-incremento
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DS_TIPO_BEM_CANDIDATO - Descrição do tipo do bem do candidato
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
