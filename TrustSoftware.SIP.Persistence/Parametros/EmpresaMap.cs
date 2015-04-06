using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Persistence.Parametros
{
    public class EmpresaMap : ClassMap<Empresa>
    {
        public EmpresaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.DataCadastro);
            Map(x => x.Nome);
            Map(x => x.CPF_CNPJ);
            Map(x => x.Status).CustomType<StatusLogin>();
            Map(x => x.Foto);

            References(x => x.UF)
                .Cascade.None()
                .Not.LazyLoad();

            References(x => x.Municipio)
                .Cascade.None()
                .Not.LazyLoad();

            References(x => x.CargoContratante)
                .Cascade.None()
                .Not.LazyLoad();

            HasManyToMany(x => x.Candidaturas)
                .Cascade.None()
                .Table("EmpresaCandidaturas");


        }
    }
}
