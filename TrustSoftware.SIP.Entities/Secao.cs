using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Secao
    {
        public virtual int Id { get; set; }

        public virtual int IdSecao { get; set; }

        public virtual int Zona { get; set; }

        /// <summary>
        /// Cod TSE do estado
        /// </summary>
        public virtual int UF { get; set; }

        /// <summary>
        /// Cód TSE do município
        /// </summary>
        public virtual Int32 Municipio { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Endereco { get; set; }

        public virtual string CEP { get; set; }

        public virtual int NumLocal { get; set; }

        public virtual string NomeLocal { get; set; }

        public virtual int QuantVotosAptosSecao { get; set; }

        public virtual int QuantVotosAptosLocalVotacao { get; set; }
    }
}
