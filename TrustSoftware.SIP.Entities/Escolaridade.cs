using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Escolaridade
    {
        /// <summary>
        /// COD_GRAU_INSTRUCAO - Código do grau de instrução do candidato. Gerado
        /// internamente pelos sistemas eleitorais
        /// (não usar auto-incremento)
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// DESCRICAO_GRAU_INSTRUCAO - Descrição do grau de instrução do candidato
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
