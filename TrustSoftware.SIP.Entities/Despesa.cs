using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilvanoFontes.AL.Entities
{
    public class Despesa
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual DateTime DataVencimento { get; set; }
        
        public virtual Pastoral Pastoral { get; set; }

        public Despesa()
        {
            Pastoral = new Pastoral();
        }

    }
}
