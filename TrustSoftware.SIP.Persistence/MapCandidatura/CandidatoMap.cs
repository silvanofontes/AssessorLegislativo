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
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.NumeroTituloEleitor);

            Map(i => i.Idade);

            Map(i => i.Sexo).CustomType<Sexo>();

            References(i => i.Escolaridade)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.EstadoCivil)
                .Not.LazyLoad()
                .Cascade.None();

            Map(i => i.CorRaca).CustomType<CorRaca>();

            References(i => i.Nacionalidade)
                .Not.LazyLoad()
                .Cascade.None();

            References(i => i.Municipio)
                .Not.LazyLoad()
                .Cascade.None();

        }
    }
}
