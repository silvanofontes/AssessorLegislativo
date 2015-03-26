using System.Collections.Generic;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class CargoNeg : GenericBusiness<Cargo>
    {
        public CargoNeg()
        { }

        public Cargo getById(int id)
        {
            return base.getById(id);
        }

        public List<Cargo> listAll()
        {
            return base.ListAll();
        }

        public Cargo getByDescricao(string descr)
        {
            base.AddCriteria(x => x.Descricao, Criteria.Like, descr);

            return base.ByFilter();
        }

        public Cargo VerificaSalva(Cargo cargo)
        {
            if (base.getById(cargo.Id) == null)
                base.Save(cargo);

            return cargo;
        }

    }
}
