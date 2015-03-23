using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.MapCandidatura
{
    public class ResultadoCampanhaMap : ClassMap<ResultadoCampanha>
    {
        public ResultadoCampanhaMap()
        {
            Id(i => i.Id).GeneratedBy.Assigned();

            Map(i => i.Resultado);
        }
    }
}
