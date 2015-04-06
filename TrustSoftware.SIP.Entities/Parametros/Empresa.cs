using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Parametros
{
    /// <summary>
    /// Empresa/Candidato que contratou o sistema
    /// </summary>
    public class Empresa
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual string Nome { get; set; }
        public virtual Int64 CPF_CNPJ { get; set; }
        public virtual Estado UF { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Cargo CargoContratante { get; set; }
        public virtual StatusLogin Status { get; set; }
        public virtual string Foto { get; set; }
        
        public virtual IList<Candidatura> Candidaturas { get; set; }

    }
}
