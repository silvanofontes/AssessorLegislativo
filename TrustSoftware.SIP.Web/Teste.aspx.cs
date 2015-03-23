using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Business;

namespace SilvanoFontes.AL.Web
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Caixa caix = new Caixa();
            caix.Email = "ecc@trust";
            caix.NomeCaixa = "ECC";

            Pastoral pastoral = new Pastoral();
            pastoral.Nome = "ECC";
            pastoral.EmailGrupo = "ecc@trustsoftware.com.br";
            pastoral.Nucleo = null;
            pastoral.Paroquia = null;
            caix.AddPastoral(pastoral);

            pastoral = new Pastoral();
            pastoral.Nome = "EAC";
            pastoral.EmailGrupo = "eac@trustsfoteare.com.br";
            pastoral.Nucleo = null;
            pastoral.Paroquia = null;
            caix.AddPastoral(pastoral);

            PastoralNeg<Pastoral> past = new PastoralNeg<Pastoral>();
            past.verifica(1);

            GenericBusiness<Pastoral> neg = new GenericBusiness<Pastoral>();
            
        }
    }
}