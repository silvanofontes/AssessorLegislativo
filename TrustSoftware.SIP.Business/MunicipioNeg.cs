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
        public Municipio getById(int id)
        {
            return base.getById(id);
        }

        public Municipio getByNome(string nomeMunicipio)
        {
            base.AddCriteria(x => x.Descricao, Utility.Criteria.Eq, nomeMunicipio.ToUpper().Trim());
            return base.ByFilter();
        }

        /// <summary>
        /// Busca Município por Nome e por UF
        /// </summary>
        /// <param name="nomeMunicipio"></param>
        /// <returns></returns>
        public Municipio getByNomeUF(string nomeMunicipio, string uf)
        {
            base.AddCriteria(x => x.Descricao, Utility.Criteria.Eq, nomeMunicipio.ToUpper().Trim());
            base.AddAlias(new Utility.Parametro() { Text = "UF", Value = "u" });
            base.AddCriteria(Utility.Criteria.Eq, new Utility.Parametro() { Text = "u.UF", Value = uf });

            return base.ByFilter();
        }

        /// <summary>
        /// Lista todos os municipios
        /// </summary>
        /// <returns>List Munic</returns>
        public List<Municipio> listAll()
        {
            return base.ListAll();
        }

        public Municipio VerificaSalva(Municipio municipio)
        {
            if (base.getById(municipio.Id) == null)
                base.Save(municipio);

            return municipio;
        }
    }
}
