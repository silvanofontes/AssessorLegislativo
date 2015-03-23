using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class EstadoCivil
    {
        /// <summary>
        /// CODIGO_ESTADO_CIVIL
        /// Código do estado civil do candidato
        /// (não pode ser auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DESCRICAO_ESTADO_CIVIL 
        /// Descrição do estado civil do candidato
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
