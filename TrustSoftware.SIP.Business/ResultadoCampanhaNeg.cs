using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business
{
    public class ResultadoCampanhaNeg : GenericBusiness<ResultadoCampanha>
    {
        public ResultadoCampanhaNeg()
        { }

        public ResultadoCampanha getById(int id)
        {
            return base.getById(id);
        }

        public ResultadoCampanha getByDescricao(string resultado)
        {
            base.AddCriteria(x => x.Resultado, Utility.Criteria.Eq, resultado);
            return base.ByFilter();
        }

        public ResultadoCampanha VerificaSalva(ResultadoCampanha resultado)
        {
            if (base.getById(resultado.Id) == null)
                base.Save(resultado);

            return resultado;
        }
    }
}
