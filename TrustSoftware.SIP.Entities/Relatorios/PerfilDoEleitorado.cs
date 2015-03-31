using System;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Entities.Relatorios
{
    public class PerfilDoEleitorado
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Ano da eleição
        /// </summary>
        public virtual Int32 Ano { get; set; }

        /// <summary>
        /// Id da UF
        /// </summary>
        public virtual int UF { get; set; }

        /// <summary>
        /// Código do município no TSE 
        /// </summary>
        public virtual int Municipio { get; set; }

        /// <summary>
        /// Número da Zona eleitoral
        /// </summary>
        public virtual int Zona { get; set; }

        /// <summary>
        /// Sexo - Enum
        /// </summary>
        public virtual Sexo Sexo { get; set; }

        /// <summary>
        /// Id da faixa etaria salva no banco
        /// Não uso a entiddade pois o volume de dados é grande
        /// </summary>
        public virtual int FaixaEtaria { get; set; }

        /// <summary>
        /// Id da Escolaridade salva no banco. 
        /// Não uso a entiddade pois o volume de dados é grande
        /// </summary>
        public virtual int GrauEscolaridade { get; set; }

        /// <summary>
        /// Quantidade de eleitores no perfil
        /// </summary>
        public virtual Int32 QuantidadeEleitores { get; set; }
    }
}
