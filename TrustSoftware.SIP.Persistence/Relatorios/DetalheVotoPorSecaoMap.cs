using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities.Relatorios;
namespace SilvanoFontes.AL.Persistence.Relatorios
{
    public class DetalheVotoPorSecaoMap : ClassMap<DetalheVotoPorSecao>
    {
        public DetalheVotoPorSecaoMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Ano);

            Map(x => x.Turno);

            Map(x => x.UF);

            Map(x => x.UE);

            Map(x => x.Municipio);

            Map(x => x.Zona);

            Map(x => x.Secao);

            Map(x => x.Cargo);

            Map(x => x.QuantAptos);

            Map(x => x.QuantComparecimento);

            Map(x => x.QuantAbstencoes);

            Map(x => x.QuantVotosNominais);

            Map(x => x.QuantVotosBrancos);

            Map(x => x.QuantVotosNulos);

            Map(x => x.QuantVotosLegenda);

            Map(x => x.QuantVotosAnuladosApuradosSeparados);

            Map(x => x.QuantVotosTransito);
        }
    }
}
