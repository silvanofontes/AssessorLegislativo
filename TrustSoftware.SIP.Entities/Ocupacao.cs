using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Ocupacao
    {
        /// <summary>
        /// Código da ocupação do candidato
        /// Numero indormado, não pode ser auto-numérico
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Descrição da ocupação do candidato
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
