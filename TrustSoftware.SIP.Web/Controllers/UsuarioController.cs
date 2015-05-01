using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Business.Parametros;
using Newtonsoft.Json;
using SilvanoFontes.AL.Utility;

namespace SilvanoFontes.AL.Web.Controllers
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

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5", "value6" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}