using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Persistence.Parametros
{
    public class ArquivoMap : ClassMap<Arquivo>
    {
        public ArquivoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Nome);

            Map(x => x.Descricao);

            Map(x => x.NomeArquivo);

            Map(x => x.Fonte);
        }
    }
}
