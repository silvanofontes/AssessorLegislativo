using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class EstadoMap : ClassMap<Estado>
    {
        public EstadoMap()
        {
            Id(i => i.Id).GeneratedBy.Assigned();

            Map(i => i.UF);

            Map(i => i.Nome);

        }
    }
}
