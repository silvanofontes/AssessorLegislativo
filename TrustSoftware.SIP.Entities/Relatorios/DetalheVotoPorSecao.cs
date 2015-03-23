using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Relatorios
{
    /// <summary>
    /// NOTAÇÃO: DETALHE_VOTACAO_SECAO_{ANO ELEIÇÃO}_{SIGLA UF}
    /// </summary>
    public class DetalheVotoPorSecao
    {
        public virtual int Id { get; set; }

        //TODO: A principio não vou importar estes dados. Vou informálos no log de importação do arquuivo.
        //DATA_GERACAO Data de geração do arquivo (data da extração)
        //HORA_GERACAO Hora de geração do arquivo (hora da extração) - Horário de Brasília
        //DESCRICAO_ELEICAO (*) Sigla da Unidade da Federação em que ocorreu a eleição

        /// <summary>
        /// ANO_ELEICAO - Ano da eleição
        /// </summary>
        public virtual int Ano { get; set; }

        /// <summary>
        /// NUM_TURNO (*) - Número do turno
        /// </summary>
        public virtual int Turno { get; set; }

        /// <summary>
        /// SIGLA_UE (*) Sigla da Unidade Eleitoral (Em caso de eleição majoritária é a sigla da UF
        /// que o candidato concorre e em caso de eleição municipal é o código TSE 
        /// do município). Assume os valores especiais BR, ZZ e VT para designar,
        /// respectivamente, o Brasil, Exterior e Voto em Trânsito
        /// TODO: Atenção  na importação, pois podem vir dados numéricos e caracteres.
        /// </summary>
        public virtual Estado UE { get; set; }

        /// <summary>
        /// Município onde ocorreu a eleição
        /// ATENÇÃO: Utilizar o Código TSE do municipio
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// NUMERO_ZONA (*) - Número da Zona Eleitoral
        /// </summary>
        public virtual int Zona { get; set; }

        /// <summary>
        /// NUMERO_SECAO (*) - Número da seção eleitoral
        /// </summary>
        public virtual int Secao { get; set; }

        /// <summary>
        /// CODIGO_CARGO (*) - Código do cargo
        /// </summary>
        public virtual Cargo Cargo { get; set; }

        /// <summary>
        /// QTD_APTOS - Quantidade de eleitores aptos a votar naquele município e Zona
        /// </summary>
        public virtual int QuantAptos { get; set; }

        /// <summary>
        /// QTD_COMPARECIMENTO - Quantidade de eleitores que compareceram às eleições naquela seção eleitoral, naquele cargo
        /// </summary>
        public virtual int QuantComparecimento { get; set; }

        /// <summary>
        /// QTD_ABSTENCOES - Quantidade de eleitores que não compareceram às eleições naquela seção eleitoral
        /// </summary>
        public virtual int QuantAbstencoes { get; set; }

        /// <summary>
        /// QT_VOTOS_NOMINAIS - Quantidade de votos nominais naquela seção eleitoral
        /// </summary>
        public virtual int QuantVotosNominais { get; set; }

        /// <summary>
        /// QT_VOTOS_BRANCOS - Quantidade de votos brancos naquela seção eleitoral
        /// </summary>
        public virtual int QuantVotosBrancos { get; set; }

        /// <summary>
        /// QT_VOTOS_NULOS - Quantidade de votos nulos naquela seção eleitoral
        /// </summary>
        public virtual int QuantVotosNulos { get; set; }
        
        /// <summary>
        /// QT_VOTOS_LEGENDA - Quantidade de votos em legenda naquela seção eleitoral
        /// </summary>
        public virtual int QuantVotosLegenda { get; set; }

        /// <summary>
        ///QT_VOTOS_ANULADOS_APU_SEP
        ///Quantidade de votos anulados e apurados em separado naquela
        ///seção eleitoral. Esse quantitativo reflete os votos oriundos de alguma
        ///urna que está sub-júdice. Ainda não são votos válidos nem nulos até
        ///a decisão do juiz eleitoral.
        /// </summary>
        public virtual int QuantVotosApuradosSeparados { get; set; }

    }
}
