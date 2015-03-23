using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class CaixaMap : ClassMap<Caixa>
    {
        public CaixaMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.NomeCaixa);
            Map(i => i.Email);

            HasMany(i => i.Pastorais)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
}
