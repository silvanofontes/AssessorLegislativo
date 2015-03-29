using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Parametros;

namespace SilvanoFontes.AL.Business.Parametros
{
    public class LogImportacaoNeg : GenericBusiness<LogImportacao>
    {
        public LogImportacaoNeg() { }

        public LogImportacao getById(int id)
        {
            return base.getById(id);
        }

        public List<LogImportacao> listAll()
        {
            return base.ListAll();
        }

        public override bool Save(LogImportacao log)
        {
            return base.Save(log);
        }

        public override void Dispose()
        {
            base.Dispose();
        }


    }
}
