using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class ResultadoCampanha
    {
        /// <summary>
        /// COD_SIT_TOT_TURNO 
        /// Código da situação de totalização do candidato naquele turno
        /// (não pode ser auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DESC_SIT_TOT_TURNO 
        /// Descrição da situação de totalização do candidato naquele turno
        /// </summary>
        public virtual string Resultado { get; set; }
    }
}
