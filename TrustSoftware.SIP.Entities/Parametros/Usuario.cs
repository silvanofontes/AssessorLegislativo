using System;
using SilvanoFontes.AL.Utility.Enums;
using System.Collections.Generic;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Referência a classe empresa
        /// </summary>
        public virtual Empresa Empresa { get; set; }
        
        public virtual DateTime DataCadastro { get; set; }
        public virtual StatusLogin Status { get; set; }
        public virtual PerfilUsuario Perfil { get; set; }

        /// <summary>
        /// Somente se o perfil for eleitor.
        /// </summary>
        public virtual Eleitor Eleitor { get; set; }

        public virtual SimNao LoginFacebook { get; set; }

        public virtual string IdFacebook { get; set; }
        public virtual string UltimoAccessToken { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual DateTime DtUltimoLogin { get; set; }

        public override string ToString()
        {
            return "[" + Id + ", \"" + DataCadastro.ToShortDateString() + "\", \"" + Status.ToString() + "\", \"" + LoginFacebook.ToString() + "\", \"" + UserName + "\", \"" + DtUltimoLogin.ToShortDateString() + "\"]";
        }


    }
}
