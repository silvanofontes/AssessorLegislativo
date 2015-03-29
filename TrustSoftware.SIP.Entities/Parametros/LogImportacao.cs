using System;

namespace SilvanoFontes.AL.Entities.Parametros
{
    public class LogImportacao
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// Id do Arquivo
        /// </summary>
        public virtual int Arquivo { get; set; }

        /// <summary>
        /// Data da importação
        /// </summary>
        public virtual DateTime Data { get; set; }

        /// <summary>
        /// Tempo total da importação em segundos
        /// </summary>
        public virtual double Tempo { get; set; }

        /// <summary>
        /// Id do usuário logado que fez a importação
        /// </summary>
        public virtual int Usuario { get; set; }

        /// <summary>
        /// Armazenar possíveis erros na hora da importação.
        /// </summary>
        public virtual string Erros { get;  set; }

        /// <summary>
        /// Total de registros importados
        /// </summary>
        public virtual Int32 TotalRegistros { get; set; }

        public virtual void AddErro(string erro)
        {
            Erros += erro + Environment.NewLine;
        }

        public virtual void CalculaTempo()
        {
            Tempo = DateTime.Now.Subtract(Data).TotalSeconds;
        }
    }
}
