using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class FaixaEtariaNeg : GenericBusiness<FaixaEtaria>
    {
        public FaixaEtariaNeg() { }

        public FaixaEtaria getById(int id)
        {
            return base.getById(id);
        }

        public FaixaEtaria getByFaixa(string faixa)
        {
            base.AddCriteria(x => x.Faixa, Criteria.Eq, faixa);
            return base.ByFilter();
        }

        public FaixaEtaria VerificaSalva(FaixaEtaria faixaEtaria)
        {
            base.AddCriteria(x => x.Faixa, Criteria.Eq, faixaEtaria.Faixa);
            FaixaEtaria faixaBanco = base.ByFilter();
            if (faixaBanco == null)
                base.Save(faixaEtaria);
            else
                faixaEtaria = faixaBanco;

            return faixaEtaria;

        }

    }
}
