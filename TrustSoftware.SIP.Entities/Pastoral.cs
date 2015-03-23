using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Pastoral
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual string EmailGrupo { get; set; }

        public virtual Pessoa Coordenador { get; set; }
        public virtual IList<Pessoa> Nucleo { get; set; }
        public virtual Paroquia Paroquia { get; set; }

        public Pastoral()
        {
            Coordenador = new Pessoa();
            Nucleo = new List<Pessoa>();
        }

        public virtual void AddNucleo(Pessoa integrante)
        {
            Nucleo.Add(integrante);
        }
    }
}
