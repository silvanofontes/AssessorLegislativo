using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Candidatura
    {
        public virtual int Id { get; set; }

        // A principio não vou usar esses campos
        // Vai ser armazenado no log de importação do arquivo
        // DATA_GERACAO { get; set; }
        // HORA_GERACAO { get; set; }
        // DESCRICAO_ELEICAO (*) Descrição da eleição

        /// <summary>
        /// ANO_ELEICAO 
        /// Ano da eleição
        /// </summary>
        public virtual int Ano { get; set; }

        /// <summary>
        /// NUM_TURNO (*) Número do turno
        /// </summary>
        public virtual int Turno { get; set; }

        /// <summary>
        /// SIGLA_UF 
        /// Sigla da Unidade da Federação em que ocorreu a eleição
        /// </summary>
        public virtual Estado UF { get; set; }
        
        // A principio não vou usar esses campos
        //public virtual string SIGLA_UE { get; set; }
        //public virtual string DESCRICAO_UE { get; set; }

        /// <summary>
        /// Candidato
        /// </summary>
        public virtual Candidato Candidato { get; set; }
        
        /// <summary>
        /// Cargo a que o candidato concorre
        /// </summary>
        public virtual Cargo Cargo { get; set; }

        /// <summary>
        /// Situação de candidatura
        ///     - Deferido, Indeferido, Cassado com Recurso, etc.
        /// </summary>
        public virtual SituacaoCandidatura SituacaoCandidatura { get; set; }

        /// <summary>
        /// Pardido do candidato
        /// </summary>
        public virtual Partido Partido { get; set; }

        /// <summary>
        /// CODIGO_LEGENDA 
        /// Código sequencial da legenda gerado pela Justiça Eleitoral
        /// </summary>
        public virtual Int64 CodigoLegenda { get; set; }

        /// <summary>
        /// SIGLA_LEGENDA 
        /// Sigla da legenda
        /// </summary>
        public virtual string SiglaLegenda { get; set; }

        /// <summary>
        /// COMPOSICAO_LEGENDA 
        /// Composição da legenda
        /// </summary>
        public virtual string ComposicaoLegenda { get; set; }

        /// <summary>
        /// NOME_LEGENDA 
        /// Nome da legenda
        /// </summary>
        public virtual string NomeLegenda { get; set; }

        /// <summary>
        /// DESPESA_MAX_CAMPANHA 
        /// Despesa máxima de campanha declarada pelo partido para aquele cargo. 
        /// Valores em Reais.
        /// </summary>
        public virtual double DespesaMaximaCampanha { get; set; }

        /// <summary>
        /// Situação de totalização do candidato naquele turno
        /// </summary>
        public virtual ResultadoCampanha ResultadoCampanha { get; set; }
        

    }
}
