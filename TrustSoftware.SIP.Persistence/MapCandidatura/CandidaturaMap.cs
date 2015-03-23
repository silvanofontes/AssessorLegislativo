using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class CandidaturaMap : ClassMap<Candidatura>
    {
        public CandidaturaMap()
        {
            Id(i => i.Id).GeneratedBy.Assigned();

            Map(i => i.Ano);

            Map(i => i.Turno);

            References(i => i.UF)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Candidato)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Cargo)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.SituacaoCandidatura)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Partido)
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.CodigoLegenda);

            Map(i => i.SiglaLegenda);

            Map(i => i.ComposicaoLegenda);

            Map(i => i.NomeLegenda);

            Map(i => i.DespesaMaximaCampanha);

            References(i => i.ResultadoCampanha)
                .Not.LazyLoad()
                .Cascade.None();

        }
    }
}
