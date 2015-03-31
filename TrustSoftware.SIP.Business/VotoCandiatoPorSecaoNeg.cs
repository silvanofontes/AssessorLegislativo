using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Business
{
    public class VotoCandiatoPorSecaoNeg : GenericBusiness<VotoCandiatoPorSecao>
    {
        public VotoCandiatoPorSecaoNeg() { }

        public VotoCandiatoPorSecao getById(int id)
        {
            return base.getById(id);
        }
    }
}
