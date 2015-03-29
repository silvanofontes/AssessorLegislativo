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
            if (base.getById(arquivo.Id) == null)
                base.Save(arquivo);

            return arquivo;
        }

    }
}
