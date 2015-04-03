using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class SecaoMap : ClassMap<Secao>
    {
        public SecaoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IdSecao);
            Map(x => x.Zona);
            Map(x => x.UF);
            Map(x => x.Municipio);
            Map(x => x.Bairro);
            Map(x => x.Endereco);
            Map(x => x.CEP);
            Map(x => x.NumLocal);
            Map(x => x.NomeLocal);
            Map(x => x.QuantVotosAptosSecao);
            Map(x => x.QuantVotosAptosLocalVotacao);
        }
    }
}
