using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class PastoralMap : ClassMap<Pastoral>
    {
        public PastoralMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();
            
            Map(i => i.Nome);
            Map(i => i.EmailGrupo);

            References(i => i.Paroquia)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();

            References(i => i.Coordenador)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();

            HasMany(i => i.Nucleo)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();

        }
    }
}
