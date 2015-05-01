using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence.Parametros
{
    public class UsuarioAcessoMap : ClassMap<UsuarioAcesso>
    {
        public UsuarioAcessoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Usuario);
            Map(x => x.DataLogin);
            Map(x => x.IP);
            Map(x => x.TipoLogin).CustomType<TipoLogin>();
        }
    }
}
