using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class CandidatoMap : ClassMap<Candidato>
    {
        public CandidatoMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.IdSequencial);

            Map(i => i.CPF);

            Map(i => i.Nome);

            Map(i => i.NomeUrna);

            Map(i => i.NumeroCandidato);

            References(i => i.Ocupacao)
                .ForeignKey("FK_CandidatoOcupacao")
                .Not.LazyLoad()
                .Cascade.None();

            Map(x => x.DataNascimento);

            Map(i => i.NumeroTituloEleitor);

            Map(i => i.Idade);

            Map(i => i.Sexo).CustomType<Sexo>();

            References(i => i.Escolaridade)
                .ForeignKey("FK_CandidatoEscolaridade")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.EstadoCivil)
                .ForeignKey("FK_CandidatoEstadoCivil")
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.CorRaca).CustomType<CorRaca>();

            References(i => i.Nacionalidade)
                .ForeignKey("FK_CandidatoNacionalidade")
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Naturalidade)
                .ForeignKey("FK_CandidatoNaturalidade")
                .Not.LazyLoad()
                .Cascade.None();

            HasMany(x => x.Bens)
                .ForeignKeyConstraintName("FK_CandidatoBens")
                .KeyColumn("IdCandidato")
                .Not.LazyLoad()
                .Cascade.None();

        }
    }
}
