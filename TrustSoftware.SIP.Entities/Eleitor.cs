using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Eleitor
    {
        public virtual int Id { get; set; }
        public virtual string IdFacebook { get; set; }
        
        public virtual Int64 CPF { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Endereco { get; set; }

        public virtual string CEP { get; set; }

        public virtual int UF { get; set; }
        public virtual int Municipio { get; set; }

        public virtual DateTime DataNascimento { get; set; }

        /// <summary>
        /// TODO: Ver listagem de profissões, para não ficar digitando
        /// </summary>
        public virtual string Profissão { get; set; }
        public virtual string TelefoneResidencial { get; set; }
        public virtual string TelefoneCelular { get; set; }
        public virtual string TelefoneWhatsApp { get; set; }

        public virtual string Titulo { get; set; }
        public virtual int Zona { get; set; }
        public virtual int Secao { get; set; }

        /// <summary>
        /// TODO: Verificar se vai ser criado uma lista de indicações
        /// </summary>
        public virtual string Indicacao { get; set; }


    }
}
