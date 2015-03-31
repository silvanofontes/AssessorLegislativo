using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class TipoBemMap : ClassMap<TipoBem>
    {
        public TipoBemMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Descricao);
        }
    }
}
