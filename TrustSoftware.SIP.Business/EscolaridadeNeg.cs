using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class EscolaridadeNeg : GenericBusiness<Escolaridade>
    {
        public EscolaridadeNeg()
        { }

        public Escolaridade getById(int id)
        {
            return base.getById(id);
        }

        public Escolaridade getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Eq, descr);
            return base.ByFilter();
        }

        public Escolaridade VerificaSalva(Escolaridade escolaridade)
        {
            if (base.getById(escolaridade.Id) == null)
                base.Save(escolaridade);

            return escolaridade;
        }
    }
}
