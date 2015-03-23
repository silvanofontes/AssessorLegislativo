using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class BensCandidato
    {
        public virtual int Id { get; set; }

        //Não vou importar aqui. Vou adicionar essas informações no log da importação do arquivo.
        //DATA_GERACAO Data de geração do arquivo (data da extração)
        //HORA_GERACAO Hora de geração do arquivo (hora da extração) - Horário de Brasília
        //DESCRICAO_ELEICAO (*) Descrição da eleição



        /// <summary>
        /// ANO_ELEICAO Ano da eleição
        /// </summary>
        public virtual int Ano { get; set; }

        /// <summary>
        /// SIGLA_UF (*) - Sigla da Unidade da Federação em que ocorreu a eleição
        /// </summary>
        public virtual Estado UF { get; set; }


        /// <summary>
        /// SQ_CANDIDATO (*) Número sequencial do candidato gerado internamente pelos sistemas 
        /// eleitorais. Não é o número de campanha do candidato.
        /// ATENÇÃO: Não vou quardar o sequencial do candidato, mas fazer referencia a entidade Candidato
        /// </summary>
        public virtual Candidato Candidato { get; set; }

        /// <summary>
        /// Tipo do bem do candidato
        /// </summary>
        public virtual TipoBen TipoBem { get; set; }

        /// <summary>
        /// DETALHE_BEM - Detalhe do bem do candidato
        /// </summary>
        public virtual string Detalhe { get; set; }

        /// <summary>
        /// VALOR_BEM - Valor declarado do bem do candidato
        /// </summary>
        public virtual double Valor { get; set; }

        /// <summary>
        /// DATA_ULTIMA_ATUALIZACAO Data da última atualização do registro do bem
        /// HORA_ULTIMA_ATUALIZACAO Hora da última atualização do registro do bem
        /// ATENÇÃO: os dois campos acima foram unificados em um só
        /// </summary>
        public virtual DateTime DataAtualizacao { get; set; }


    }
}
