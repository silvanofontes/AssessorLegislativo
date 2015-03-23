using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();

            Map(i => i.Nome);
            Map(i => i.Email);
            Map(i => i.Telefone);
            Map(i => i.Celular);
            Map(i => i.Endereco);

            HasMany(i => i.Pastorais)
                .Fetch.Join()
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
}
