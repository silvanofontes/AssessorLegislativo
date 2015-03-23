using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class ParoquiaMap : ClassMap<Paroquia>
    {
        public ParoquiaMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            References(i => i.Paroco)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();

            HasMany(i => i.Pastorais)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
}
