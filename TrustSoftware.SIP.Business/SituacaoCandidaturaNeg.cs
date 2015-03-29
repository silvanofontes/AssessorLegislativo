using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class SituacaoCandidaturaNeg : GenericBusiness<SituacaoCandidatura>
    {
        public SituacaoCandidaturaNeg()
        { }

        public SituacaoCandidatura getById(int id)
        {
            return base.getById(id);
        }

        public SituacaoCandidatura getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);

            return base.ByFilter();
        }

        public SituacaoCandidatura VerificaSalva(SituacaoCandidatura situacao)
        {
            if (base.getById(situacao.Id) == null)
                base.Save(situacao);

            return situacao;
        }
    }
}
