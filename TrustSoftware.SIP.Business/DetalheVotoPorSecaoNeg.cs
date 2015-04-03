using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class DetalheVotoPorSecaoNeg : GenericBusiness<DetalheVotoPorSecao>
    {
        public DetalheVotoPorSecaoNeg() { }

        public DetalheVotoPorSecao getById(int id)
        {
            return base.getById(id);
        }

        public List<DetalheVotoPorSecao> getByAnoUF(int ano, int uf)
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);
            base.AddCriteria(x => x.UF, Criteria.Eq, uf);

            return base.listByFilter();
        }

        public bool Save(DetalheVotoPorSecao detalhe)
        {
            return base.Save(detalhe);
        }

        public bool DeleteByAnoUF(int ano, int uf)
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);
            base.AddCriteria(x => x.UF, Criteria.Eq, uf);

            return base.DeleteByFilter();
        }
        
    }
}
