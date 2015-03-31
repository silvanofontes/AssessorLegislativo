using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence.Relatorios
{
    public class PerfilDoEleitoradoMap : ClassMap<PerfilDoEleitorado>
    {
        public PerfilDoEleitoradoMap() 
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Ano);

            Map(x => x.UF);

            Map(x => x.Municipio);

            Map(x => x.Zona);

            Map(x => x.Sexo).CustomType<Sexo>();

            Map(x => x.FaixaEtaria);

            Map(x => x.GrauEscolaridade);

            Map(x => x.QuantidadeEleitores);

        }
    }
}
