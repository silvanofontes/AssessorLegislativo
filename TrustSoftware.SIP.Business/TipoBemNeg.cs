using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class TipoBemNeg : GenericBusiness<TipoBem>
    {
        public TipoBem getById(int id)
        {
            return base.getById(id);
        }

        public TipoBem getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);
            return base.ByFilter();
        }

        public TipoBem VerificaSalva(TipoBem tipoBem)
        {
            if (base.getById(tipoBem.Id) == null)
                base.Save(tipoBem);

            return tipoBem;
        }
    }
}
