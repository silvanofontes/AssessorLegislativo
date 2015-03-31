using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Persistence;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class EstadoNeg : GenericBusiness<Estado>
    {
        public EstadoNeg()
        { }

        public Estado getEstadoById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Estado> listAll()
        {
            return base.ListAll();
        }

        public Estado getByUF(string uf)
        {
            //GenericBusiness<Estado> negEstado = new GenericBusiness<Estado>();
            base.AddCriteria(x => x.UF, Criteria.Eq, uf.ToUpper());
            Estado estado = new Estado();
            estado = base.ByFilter();
            return (estado);
        }

        public Estado VerificaSalva(Estado estado)
        {
            if (getById(estado.Id) == null)
                base.Save(estado);

            return estado;

        }


    }
}
