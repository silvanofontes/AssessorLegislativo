using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities
{
    public class Candidato
    {
        public virtual int Id { get; set; }
        
        /// <summary>
        /// Número sequencial do candidato gerado internamente pelos
        /// sistemas eleitorais. Não é o número de campanha do candidato.
        /// </summary>
        public virtual int IdSequencial { get; set; }

        /// <summary>
        /// CPF do candidato
        /// </summary>
        public virtual Int64 CPF { get; set; }

        /// <summary>
        /// Nome completo do candidato
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// Nome de urna do candidato
        /// </summary>
        public virtual string NomeUrna { get; set; }

        /// <summary>
        /// Número do candidato na urna
        /// </summary>
        public virtual int NumeroCandidato { get; set; }

        /// <summary>
        /// Código da ocupação do candidato e
        /// Descrição da ocupação do candidato
        /// </summary>
        public virtual Ocupacao Ocupacao { get; set; }

        /// <summary>
        /// Data de nascimento do candidato
        /// </summary>
        public virtual DateTime DataNascimento { get; set; }

        /// <summary>
        /// Número do título eleitoral do candidato
        /// </summary>
        public virtual Int64 NumeroTituloEleitor { get; set; }

        /// <summary>
        /// Idade do candidato na data da eleição
        /// </summary>
        public virtual int Idade { get; set; }
        
        /// <summary>
        /// Sexo do candidato
        /// </summary>
        public virtual Sexo Sexo { get; set; }

        /// <summary>
        /// Escolaridade do Candidato
        /// </summary>
        public virtual Escolaridade Escolaridade { get; set; }

        /// <summary>
        /// Estado civil do candidato
        /// </summary>
        public virtual EstadoCivil EstadoCivil { get; set; }

        /// <summary>
        /// Cor/raça do candidato (auto declaração)
        /// </summary>
        public virtual CorRaca CorRaca { get; set; }

        /// <summary>
        /// Nacionalidade do candidato
        /// </summary>
        public virtual Nacionalidade Nacionalidade { get; set; }

        /// <summary>
        /// Município do candidato
        /// </summary>
        public virtual Municipio Municipio { get; set; }



    }
}
