using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Entities.Parametros;
using Newtonsoft.Json;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Business;

namespace SilvanoFontes.AL.Web.Controllers
{
    public partial class WebControllers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strReturn = "";

            if (!IsPostBack)
            {
                string controller = "", action = "", parameter = "";

                controller = RouteData.Values["controller"] != null ? RouteData.Values["controller"].ToString().Trim() : "";
                action = RouteData.Values["action"] != null ? RouteData.Values["action"].ToString().Trim() : "";
                parameter = RouteData.Values["parameter"] != null ? RouteData.Values["parameter"].ToString().Trim() : "";

                if ((controller + action + parameter) != "")
                {
                    ActionApi actionApi = Functions.ParseEnum<ActionApi>(action);

                    JSonNeg neg = new JSonNeg();

                    switch (controller)
                    {
                        case "summary":
                            //Exibe o summary
                            strReturn = neg.Summary();

                            break;
                        case "usuario":
                            strReturn = neg.UsuarioJson(actionApi, parameter);
                            //Usuarios();
                            break;

                        default:
                            //Exibe o Summary
                            strReturn = neg.Summary();
                            break;
                    }
                }
                else
                {
                    strReturn ="Não encontrado parametros para API: <b>\"~/api/{controller}/{action}/{*id}\"</b>";
                }

                

            }

            Response.Write(strReturn);
            

        }

        protected void Usuarios()
        {
            List<Usuario> usuarios = new UsuarioNeg().listAll();
            string _JSON;

            if (usuarios != null)
            {

                _JSON = Functions.ToJson(usuarios);

                //_JSON = JsonConvert.SerializeObject(usuarios, set);

                Response.Write(_JSON);

            }
        }
    }
}