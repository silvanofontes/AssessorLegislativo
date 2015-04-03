using System;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Login { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual StatusLogin Status { get; set; }
        public virtual DateTime DtUltimoLogin { get; set; }
        public virtual string IdFacebook { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual PerfilUsuario Perfil { get; set; }

    }
}
