using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Relatorios;

namespace SilvanoFontes.AL.Persistence.Relatorios
{
    public class VotoCandiatoPorSecaoMap : ClassMap<VotoCandiatoPorSecao>
    {
        public VotoCandiatoPorSecaoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Ano);
            Map(x => x.Turno);
            Map(x => x.UF);
            Map(x => x.UE);
            Map(x => x.Municipio);
            Map(x => x.Zona);
            Map(x => x.Secao);
            Map(x => x.Cargo);
            Map(x => x.NumeroCandidato);
            Map(x => x.Candidato);
            Map(x => x.QuantidadeVotos);
        }
    }
}
