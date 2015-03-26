using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Business;
using SilvanoFontes.AL.Business.Import;

namespace SilvanoFontes.AL.Web
{
    public partial class ImportaTXTPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string file = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\consulta_cand_2012_RJ.txt";
            //CandidaturaNeg negCandidatura = new CandidaturaNeg(file);

            EstadoNeg neg = new EstadoNeg();
            Estado estado = neg.getByUF("RJ");
            
            
        }
   }
}