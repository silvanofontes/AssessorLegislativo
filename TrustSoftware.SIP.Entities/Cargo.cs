using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Cargo
    {
        /// <summary>
        /// CODIGO_CARGO (*) 
        /// Código do cargo a que o candidato concorre
        /// não pode ser auto-numérico
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DESCRICAO_CARGO
        /// Descrição do cargo a que o candidato concorre
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
