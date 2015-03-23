using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class PartidoMap : ClassMap<Partido>
    {
        public PartidoMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.Numero);

            Map(i => i.Sigla); 
            
            Map(i => i.Nome);

        }
    }
}
