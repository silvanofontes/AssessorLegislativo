using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class FaixaEtariaMap : ClassMap<FaixaEtaria>
    {
        public FaixaEtariaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Faixa);
        }
    }
}
