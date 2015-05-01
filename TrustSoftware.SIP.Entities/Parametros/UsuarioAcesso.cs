using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class UsuarioAcesso
    {
        public virtual int Id { get; set; }
        public virtual int Usuario { get; set; }
        public virtual DateTime DataLogin { get; set; }
        public virtual string IP { get; set; }
        public virtual TipoLogin TipoLogin { get; set; }
    }
}
