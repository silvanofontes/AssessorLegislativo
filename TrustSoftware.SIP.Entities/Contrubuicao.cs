using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Contrubuicao
    {
        public virtual int Id { get; protected set; }
        public virtual Despesa Despesa { get; set; }
        public virtual Pessoa Contribuinte { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime DataPagamento { get; set; }

        public Contrubuicao()
        {
            Despesa = new Despesa();
            Contribuinte = new Pessoa();
        }

    }
}
