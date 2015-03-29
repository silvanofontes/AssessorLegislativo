using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class TipoBemMap : ClassMap<TipoBen>
    {
        public TipoBemMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Descricao);
        }
    }
}
