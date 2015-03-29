using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Persistence.Parametros
{
    public class LogImportacaoMap : ClassMap<LogImportacao>
    {
        public LogImportacaoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Arquivo);

            Map(x => x.Data);

            Map(x => x.Tempo);

            Map(x => x.Usuario);

            Map(x => x.Erros);

            Map(x => x.TotalRegistros);
        }
    }
}
