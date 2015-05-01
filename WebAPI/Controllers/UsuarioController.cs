using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using System.Web.Http;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using SilvanoFontes.AL.Utility;

namespace WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        
        // GET api/Usuario/5
        public Usuario GetUsuario(int id)
        {
            Usuario usuario = new UsuarioNeg().getById(id);

            if (usuario == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return usuario;
        }

        public string GetAll()
        {
            List<Usuario> usuarios = new UsuarioNeg().listAll();
            string _JSON;

            if (usuarios == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Retorno ret = new Retorno();
                ret.aaData = usuarios.ToArray();

                var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
                json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Arrays;

                JsonSerializerSettings setings = new JsonSerializerSettings();
                setings.TypeNameHandling = TypeNameHandling.None;

                _JSON = Functions.ToJson(usuarios);
                

            }
            return _JSON;
        }
    }
}
