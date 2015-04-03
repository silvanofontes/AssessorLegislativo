using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities.Relatorios
{
    /// <summary>
    /// NOTAÇÃO: VOTO_SECAO_{ANO ELEIÇÃO}_{SIGLA UF}
    /// </summary>
    public class VotoCandiatoPorSecao
    {
        public virtual int Id { get; set; }

        //Estes campos ficarão no log de importação do arquivo, pois se repetem.
        //DATA_GERACAO Data de geração do arquivo (data da extração)
        //HORA_GERACAO Hora de geração do arquivo (hora da extração) - Horário de Brasília
        //DESCRICAO_ELEICAO (*) Descrição da eleição

        /// <summary>
        /// ANO_ELEICAO - Ano da eleição
        /// </summary>
        public virtual int Ano { get; set; }

        /// <summary>
        /// Turno da eleição
        /// </summary>
        public virtual int Turno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int UF { get; set; }

        /// <summary>
        /// SIGLA_UE (*) Sigla da Unidade Eleitoral (Em caso de eleição majoritária é a sigla da UF
        /// que o candidato concorre e em caso de eleição municipal é o código TSE 
        /// do município). Assume os valores especiais BR, ZZ e VT para designar,
        /// respectivamente, o Brasil, Exterior e Voto em Trânsito
        /// TODO: Atenção na importação, pois podem vir dados numéricos e caracteres.
        /// </summary>
        public virtual int UE { get; set; }

        /// <summary>
        /// Município onde ocorreu a eleição (unificados os campos SIGLA_UF e NOME_MUNI..)
        /// ATENÇÃO: Utilizar o Código TSE
        /// </summary>
        public virtual int Municipio { get; set; }

        /// <summary>
        /// NUM_ZONA (*) Número da Zona Eleitoral
        /// </summary>
        public virtual int Zona { get; set; }

        /// <summary>
        /// NUM_SECAO (*) - Número da seção eleitoral
        /// </summary>
        public virtual int Secao { get; set; }

        /// <summary>
        /// CODIGO_CARGO (*) - Código do cargo
        /// </summary>
        public virtual int Cargo { get; set; }

        //NUM_VOTAVEL (*) Número do votável – é o número do candidato (quando voto nominal) ou
        //do partido (quando voto em legenda). “Voto Branco” recebe código
        //votável 95; “Voto Nulo” recebe código votável 96 e “Voto Anulado e
        //Apurado em Separado” recebe código votável 97.
        /// <summary>
        /// NUM_VOTAVEL
        /// TODO: Verificar se vai usar o numero do candidato ou a entidade Candidato mesmo.
        /// </summary>
        public virtual Int32 NumeroCandidato { get; set; }

        /// <summary>
        /// Id do Candidato, não é o IdSequencial
        /// </summary>
        public virtual int Candidato { get; set; }
    
        /// <summary>
        /// QTDE_VOTOS - Quantidade de votos apurados na seção para o votável
        /// </summary>
        public virtual Int32 QuantidadeVotos { get; set; }

    }
}
