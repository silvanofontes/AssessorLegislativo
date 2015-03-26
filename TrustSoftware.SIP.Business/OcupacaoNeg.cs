using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;
using System.Collections.Generic;

namespace SilvanoFontes.AL.Business
{
    public class OcupacaoNeg : GenericBusiness<Ocupacao>
    {
        public OcupacaoNeg()
        { }

        public Ocupacao getById(int id)
        {
            return base.getById(id);
        }

        public Ocupacao getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);
            return base.ByFilter();
        }
        
        public List<Ocupacao> listAll()
        {
            return base.ListAll();
        }

        public Ocupacao VerificaSalva(Ocupacao ocupacao)
        {
            if (base.getById(ocupacao.Id) == null)
                base.Save(ocupacao);

            return ocupacao;
        }
    }
}
