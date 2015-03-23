using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class ImportacaoTXT
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string DtNascimento { get; set; }
        public virtual string DtEmissao { get; set; }
        public virtual string Cpf { get; set; }
    }
}
