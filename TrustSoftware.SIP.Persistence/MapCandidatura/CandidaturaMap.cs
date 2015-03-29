using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class CandidaturaMap : ClassMap<Candidatura>
    {
        public CandidaturaMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.Ano);

            Map(i => i.Turno);

            References(i => i.UF)
                .ForeignKey("FK_CandidaturaEstado")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Candidato)
                .ForeignKey("FK_CandidaturaCandidato")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Cargo)
                .ForeignKey("FK_CandidaturaCargo")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.SituacaoCandidatura)
                .ForeignKey("FK_CandidaturaSituacaoCandidatura")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Partido)
                .ForeignKey("FK_CandidaturaPartido")
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.CodigoLegenda);

            Map(i => i.SiglaLegenda);

            Map(i => i.ComposicaoLegenda);

            Map(i => i.NomeLegenda);

            Map(i => i.DespesaMaximaCampanha);

            References(i => i.ResultadoCampanha)
                .ForeignKey("FK_CandidaturaResultadoCampanha")
                .Not.LazyLoad()
                .Cascade.None();

        }
    }
}
