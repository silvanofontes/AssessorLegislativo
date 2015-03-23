using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class ContribuicaoMap : ClassMap<Contrubuicao>
    {
        public ContribuicaoMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            References(i => i.Despesa)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Contribuinte)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.Valor);
            Map(i => i.DataPagamento);

        }
    }
}
