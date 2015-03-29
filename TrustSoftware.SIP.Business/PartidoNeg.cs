using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class PartidoNeg : GenericBusiness<Partido>
    {
        public PartidoNeg()
        { }

        public Partido getById(int id)
        {
            return base.getById(id);
        }

        public Partido getBySigla(string sigla)
        {
            base.AddCriteria(x => x.Sigla, Criteria.Eq, sigla);
            return base.ByFilter();
        }

        public Partido getByNome(string nome)
        {
            base.AddCriteria(x => x.Nome, Criteria.Eq, nome);
            return base.ByFilter();
        }

        public Partido getByNumero(int numero)
        {
            base.AddCriteria(x => x.Numero, Criteria.Eq, numero);
            return base.ByFilter();
        }

        public Partido VerificaSalva(Partido partido)
        {
            base.AddCriteria(x => x.Numero, Criteria.Eq, partido.Numero);
            Partido _partido = new Partido();
            _partido = base.ByFilter();
            if (_partido == null)
                base.Save(partido);

            return _partido;
        }

    }
}
