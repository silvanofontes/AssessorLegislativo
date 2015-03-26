using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business
{
    public class MunicipioNeg : GenericBusiness<Municipio>
    {
        public MunicipioNeg()
        { }

        /// <summary>
        /// Busca o municipio pelo Código do TSE
        /// </summary>
        /// <param name="id">Informar o Código do TSE</param>
        /// <returns>Class Municipio</returns>
        public Municipio getMunicipioById(int id)
        {
            return base.getById(id);
        }

        /// <summary>
        /// Lista todos os municipios
        /// </summary>
        /// <returns>List Munic</returns>
        public List<Municipio> listAll()
        {
            return base.ListAll();
        }
    }
}
