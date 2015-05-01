using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility.Enums;
namespace SilvanoFontes.AL.Persistence.Map
{
    public class EleitorMap : ClassMap<Eleitor>
    {
        public EleitorMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Empresa);
            Map(x => x.CPF);
            Map(x => x.Nome);
            Map(x => x.Email);
            Map(x => x.Endereco);
            Map(x => x.Bairro);
            Map(x => x.CEP);
            Map(x => x.UF);
            Map(x => x.Municipio);
            Map(x => x.DataNascimento);
            Map(x => x.Profissão);
            Map(x => x.TelefoneResidencial);
            Map(x => x.TelefoneCelular);
            Map(x => x.TelefoneWhatsApp);
            Map(x => x.Titulo);
            Map(x => x.Zona);
            Map(x => x.Secao);
            Map(x => x.eEleitor).CustomType<SimNao>();
            Map(x => x.Indicacao);
            References(x => x.Usuario)
                .ForeignKey("FK_EleitorUsuario")
                .LazyLoad()
                .Cascade.All();

        }
    }
}
