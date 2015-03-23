using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Relatorios
{
    /// <summary>
    /// NOTAÇÃO: PERFIL_ELEITORADO_{ANO ELEIÇÃO}_{SIGLA UF}
    /// </summary>
    public class PerfilEleitorado
    {
        /// <summary>
        /// Período a que se referem os dados. É o ano da eleição nos arquivos
        /// referentes ao eleitorado da eleição ou então o ano e mês no caso ao
        /// arquivo ATUAL.
        /// </summary>
        public virtual int Ano { get; set; }
        public virtual int Mes { get; set; }

        /// <summary>
        /// Este campo não existe no arquivo, mas verifico no nome do arquivo
        /// se possui o ano da eleição ou a palacra "ATUAL".
        /// Se for "ATUAL" refere-se a ultima analise mesmo fora de período de eleição, então marco AnoEleitoral = SIM
        /// Se for o ano (Ex: 2014) refe-se a analise feita antes da campanha de 2014 (no exemplo)  então marco AnoEleitoral = NÃO
        /// </summary>
        public virtual SimNao AnoEleitoral { get; set; }

        /// <summary>
        /// Nome do município
        /// Já vem com UF
        ///     ATENÇÃO: utiliar o código TSE do município
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// NR_ZONA - Número da Zona Eleitoral
        /// </summary>
        public virtual int Zona { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        public virtual Sexo Sexo { get; set; }

        /// <summary>
        /// GRAU_DE_ESCOLARIDADE – ATENÇÃO ao trabalhar com esta informação, pois
        /// esta é a escolaridade declarada pelo eleitor.
        /// Em muitos casos, o eleitor se cadastra com um determinado grau de
        /// escolaridade, por exemplo: com ensino médio aos 16 anos de idade, e
        /// não volta ao cartório eleitoral para atualizar esta informação.
        /// </summary>
        public virtual Escolaridade Escolaridade { get; set; }

        /// <summary>
        /// QTD_ELEITORES_NO_PERFIL - Quantidade de eleitores no perfil
        /// </summary>
        public virtual int QuantidadeEleitores { get; set; }
    }
}

/// PERIODO Período a que se referem os dados. É o ano da eleição nos arquivos
/// referentes ao eleitorado da eleição ou então o ano e mês no caso ao
/// arquivo ATUAL.

/// UF Sigla da Unidade da federação

/// MUNICIPIO Nome do município

/// COD_MUNICIPIO_TSE Código TSE do município

/// NR_ZONA Número da Zona Eleitoral
/// SEXO Sexo
/// FAIXA_ETARIA Faixa Etária
/// GRAU_DE_ESCOLARIDADE Grau de Escolaridade – Atenção ao trabalhar com esta informação, pois
/// esta é a escolaridade declarada pelo eleitor.
/// Em muitos casos, o eleitor se cadastra com um determinado grau de
/// escolaridade, por exemplo: com ensino médio aos 16 anos de idade, e
/// não volta ao cartório eleitoral para atualizar esta informação.

/// QTD_ELEITORES_NO_PERFIL Quantidade de eleitores no perfil
