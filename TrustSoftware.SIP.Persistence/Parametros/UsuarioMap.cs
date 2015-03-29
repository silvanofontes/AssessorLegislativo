using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence.Parametros
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.DataCadastro);

            Map(x => x.Login);

            Map(x => x.Status).CustomType<StatusLogin>();

            Map(x => x.DtUltimoLogin);
        }
    }
}
