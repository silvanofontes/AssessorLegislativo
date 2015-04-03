using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class SecaoNeg : GenericBusiness<Secao>
    {
        public SecaoNeg() { }

        public bool Save(Secao secao)
        {
            return base.Save(secao);
        }

        public void DeletaImportAnterior(int uf)
        {
            base.AddCriteria(x => x.UF, Criteria.Eq, uf);
            base.DeleteByFilter();
        }

        public Secao getById(int id)
        {
            return base.getById(id);
        }

        public List<Secao> listByZona(int zona)
        {
            base.AddCriteria(x => x.Zona, Criteria.Eq, zona);
            return base.listByFilter();
        }

        public List<Secao> listByMunicipio(int municipio)
        {
            base.AddCriteria(x => x.Municipio, Criteria.Eq, municipio);
            return base.listByFilter();
        }

        public List<Secao> listByBairro(int municipio, string bairro)
        {
            base.AddCriteria(x => x.Municipio, Criteria.Eq, municipio);
            base.AddCriteria(x => x.Bairro, Criteria.Eq, bairro);
            return base.listByFilter();
        }


    }
}
