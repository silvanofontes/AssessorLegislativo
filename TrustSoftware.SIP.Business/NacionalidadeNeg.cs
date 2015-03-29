using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class NacionalidadeNeg : GenericBusiness<Nacionalidade>
    {
        public NacionalidadeNeg()
        { }

        public Nacionalidade getById(int id)
        {
            return base.getById(id);
        }

        public Nacionalidade getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);
            return base.ByFilter();
        }

        public Nacionalidade VerificaSalva(Nacionalidade nacionalidade)
        {
            if (base.getById(nacionalidade.Id) == null)
                base.Save(nacionalidade);

            return nacionalidade;
        }
    }
}
