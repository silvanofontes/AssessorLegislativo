using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Caixa
    {
        public virtual int Id { get; set; }
        public virtual string NomeCaixa { get; set; }
        public virtual string Email { get; set; }

        public virtual IList<Pastoral> Pastorais { get; set; }

        public Caixa()
        {
            Pastorais = new List<Pastoral>();
        }

        public virtual void AddPastoral(Pastoral pastoral)
        {
            Pastorais.Add(pastoral);
        }

    }
}
