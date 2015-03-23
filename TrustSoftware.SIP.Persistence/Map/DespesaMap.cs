using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class DespesaMap : ClassMap<Despesa>
    {
        public DespesaMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.Nome);
            Map(i => i.Descricao);
            Map(i => i.Valor);
            Map(i => i.Data);
            Map(i => i.DataVencimento);

            References(i => i.Pastoral)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.None();

        }
    }
}
