using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities
{
    public class Pessoa
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual string RG { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string Endereco { get; set; }
        public virtual DateTime DataCadastro { get; set; }


        public virtual IList<Pastoral> Pastorais { get; set; }

        public Pessoa()
        {
            Pastorais = new List<Pastoral>();
        }

        public virtual void AddPastoral(Pastoral pastoral)
        {
            Pastorais.Add(pastoral);
        }
    }
}
