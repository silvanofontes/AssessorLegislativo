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

            ///TODO: Conferir resultado
            References(x => x.Empresa)
                .ForeignKey("FK_UsuarioEmpresa")
                .Cascade.None()
                .Not.LazyLoad();

            Map(x => x.DataCadastro);

            Map(x => x.Status).CustomType<StatusLogin>();

            Map(x => x.Perfil).CustomType<PerfilUsuario>();

            References(x => x.Eleitor)
                .Cascade.None();

            Map(x => x.LoginFacebook).CustomType<SimNao>();

            Map(x => x.IdFacebook);
            Map(x => x.UltimoAccessToken);


            Map(x => x.UserName);
            Map(x => x.Password);

            Map(x => x.DtUltimoLogin);

        }
    }
}
