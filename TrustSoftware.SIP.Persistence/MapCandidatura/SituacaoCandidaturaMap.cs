using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class SituacaoCandidaturaMap : ClassMap<SituacaoCandidatura>
    {
        public SituacaoCandidaturaMap()
        {
            Id(i => i.Id).GeneratedBy.Assigned();

            Map(i => i.Descricao);
        }
    }
}
