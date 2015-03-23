using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Paroquia : Pessoa
    {
        public virtual int Id { get; protected set; }
        public virtual Pessoa Paroco { get; set; }

        public virtual IList<Pastoral> Pastorais { get; set; }

        public Paroquia()
        {
            Paroco = new Pessoa();
        }

        public virtual void AddPastoral(Pastoral pastoral)
        {
            Pastorais.Add(pastoral);
        }
    }
}
