using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class MunicipioMap : ClassMap<Municipio>
    {
        public MunicipioMap()
        {
            Id(i => i.Id).GeneratedBy.Assigned();

            Map(i => i.Descricao);

            References(i => i.UF)
                .ForeignKey("FK_MunicipioEstado")
                .Column("Estado_Id")
                .Not.LazyLoad()
                .Cascade.None();
        }
    }
}
