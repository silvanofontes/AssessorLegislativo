using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Business.Parametros
{
    public class EmpresaNeg : GenericBusiness<Empresa>
    {
        public EmpresaNeg() { }

        public Empresa getById(int id)
        {
            return base.getById(id);
        }

        public List<Empresa> listAll()
        {
            return base.ListAll();
        }

        public bool Save(Empresa empresa)
        {
            return base.Save(empresa);
        }

        public bool Update(Empresa empresa)
        {
            return base.Update(empresa);
        }
    }
}
