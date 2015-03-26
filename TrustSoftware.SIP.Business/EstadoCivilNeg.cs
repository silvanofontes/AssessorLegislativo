using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class EstadoCivilNeg : GenericBusiness<EstadoCivil>
    {
        public EstadoCivilNeg()
        { }

        public EstadoCivil getById(int id)
        {
            return base.getById(id);
        }

        public EstadoCivil getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);
            return base.ByFilter();
        }

        public EstadoCivil VerificaSalva(EstadoCivil estadocivil)
        {
            if (base.getById(estadocivil.Id) == null)
                base.Save(estadocivil);

            return estadocivil;
        }

    }
}
