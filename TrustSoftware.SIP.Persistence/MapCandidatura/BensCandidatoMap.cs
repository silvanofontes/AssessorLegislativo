using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;


namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class BensCandidatoMap : ClassMap<BensCandidato>
    {
        public BensCandidatoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Ano);

            Map(x => x.UF);

            Map(x => x.IdCandidato);

            References(x => x.TipoBem)
                .ForeignKey("FK_BensCandidatoTipoBem")
                .Not.LazyLoad()
                .Cascade.None();

            Map(x => x.Detalhe);

            Map(x => x.Valor);

            Map(x => x.DataAtualizacao);

        }
    }
}
