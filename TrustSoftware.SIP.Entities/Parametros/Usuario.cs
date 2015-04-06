using System;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Referência a classe empresa
        /// </summary>
        public virtual int Empresa { get; set; }
        
        public virtual DateTime DataCadastro { get; set; }
        public virtual StatusLogin Status { get; set; }
        public virtual PerfilUsuario Perfil { get; set; }

        /// <summary>
        /// Somente se o perfil for eleitor.
        /// </summary>
        public virtual Eleitor Eleitor { get; set; }

        public virtual string IdFacebook { get; set; }
        public virtual string UltimoAccessToken { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual DateTime DtUltimoLogin { get; set; }

    }
}
