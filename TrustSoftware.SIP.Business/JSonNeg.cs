using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Business
{
    public class JSonNeg
    {
        public string Summary()
        {
            return "";
        }

        public string UsuarioJson(ActionApi action, string id)
        {
            string retorno = "";
            UsuarioNeg neg = new UsuarioNeg();
            switch (action)
            {
                case ActionApi.Get:
                    Usuario usuario = neg.getById(int.Parse(id));
                    retorno = usuario.ToString();
                    break;

                case ActionApi.GetAll:
                    List<Usuario> usuarios = neg.listAll();
                    retorno = Functions.ToJson(usuarios);
                    break;

                case ActionApi.Delete:
                    retorno = neg.Delete(int.Parse(id)) ? "Excluído com sucesso" : "Não excluido";
                    break;

                default:
                    retorno = "ActioApi não identificada";
                    break;
            }
            return retorno;
        }
    }
}
