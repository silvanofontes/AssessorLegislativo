using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class VotoCandiatoPorSecaoNeg : GenericBusiness<VotoCandiatoPorSecao>
    {
        public VotoCandiatoPorSecaoNeg() { }

        public VotoCandiatoPorSecao getById(int id)
        {
            return base.getById(id);
        }

        public List<VotoCandiatoPorSecao> listAllByAnoUF(int ano,int uf)
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);

            return base.listByFilter();
        }

        public bool DeleteByAnoUF(int ano, int uf)
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);

            return base.DeleteByFilter();
        }

        public bool Save(VotoCandiatoPorSecao votoCand)
        {
            return base.Save(votoCand);
        }
    }
}
