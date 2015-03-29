using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class Arquivo
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// Nome resumido do arquivo
        /// (Não é o nome físico do arquivo
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// Descrição do conteúdo do arquivo, qual a finalidade, etc
        /// </summary>
        public virtual string Descricao { get; set; }

        /// <summary>
        /// Fonte de onde o arquivo pode ser encontrado
        /// URL, Nome de sistemas que geraram, etc
        /// </summary>
        public virtual string Fonte { get; set; }

        /// <summary>
        /// Nome do arquivo físico no diretório.
        /// Este nome pode variar, pois os arquivos são anuais e regionais.
        /// Em caso de variável, utilizar a estrutura:
        /// Ex:
        ///    NOME_DO_ARQUIVO_#ANO#_#REGIAO#.txt
        /// </summary>
        public virtual string NomeArquivo { get; set; }

    }
}
