using FluentNHibernate.Mapping;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Persistence.Map
{
    public class ZonaMap : ClassMap<Zona>
    {
        public ZonaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.NumeroZona);

            Map(x => x.CodigoProcessualResCNJ);

            Map(x => x.Endereco);

            Map(x => x.CEP);

            Map(x => x.Bairro);

            Map(x => x.NomeMunicipio);

            Map(x => x.Municipio);

            Map(x => x.UF);

        }
    }
}
