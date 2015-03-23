using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;


namespace SilvanoFontes.AL.Persistence.Map
{
    class ImportacaoTXTMap : ClassMap<ImportacaoTXT>
    {
        public ImportacaoTXTMap()
        { 
            Id(i => i.Id).GeneratedBy.Identity();
            Map(i => i.Nome);
            Map(i => i.Cpf);
            Map(i => i.DtNascimento);
            Map(i => i.DtEmissao);
        }
    }
}
