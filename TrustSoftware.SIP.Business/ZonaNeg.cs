using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class ZonaNeg : GenericBusiness<Zona>
    {
        public ZonaNeg() { }

        public Zona getById(int id)
        {
            return base.getById(id);
        }

        public Zona getByZonaUF(int zona, int uf)
        {
            base.AddCriteria(x => x.NumeroZona, Criteria.Eq, zona);
            base.AddCriteria(x => x.UF, Criteria.Eq, uf);
            return base.ByFilter();
        }

        public List<Zona> getByCEP(string cep)
        {
            base.AddCriteria(x => x.CEP, Criteria.Eq, cep);
            return base.listByFilter();
        }

        public Zona VerificaSalva(Zona zona)
        {

            if ((zona = getByZonaUF(zona.NumeroZona, zona.UF)) == null)
                base.Save(zona);

            return zona;
        }
    }
}
