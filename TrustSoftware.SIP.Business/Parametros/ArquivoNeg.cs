using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Business.Parametros
{
    public class ArquivoNeg : GenericBusiness<Arquivo>
    {
        public ArquivoNeg() { }

        public Arquivo getById(int id)
        {
            return base.getById(id);
        }

        public List<Arquivo> listAll()
        {
            return base.ListAll();
        }

        public Arquivo VerificaSalva(Arquivo arquivo)
        {
            base.AddCriteria(x => x.Nome, Utility.Criteria.Eq, arquivo.Nome);
            Arquivo arq = base.ByFilter();
            if (arq == null)
                base.Save(arquivo);
            else
                arquivo = arq;

            return arquivo;
        }

    }
}
