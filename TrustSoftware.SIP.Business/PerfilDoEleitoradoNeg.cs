using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Entities.Relatorios;

namespace SilvanoFontes.AL.Business
{
    public class PerfilDoEleitoradoNeg : GenericBusiness<PerfilDoEleitorado>
    {
        public PerfilDoEleitoradoNeg() { }
        
        public PerfilDoEleitorado getById(int id)
        {
            return base.getById(id);
        }

        public bool Save(PerfilDoEleitorado perfil)
        {
            return base.Save(perfil);
        }

    }
}
