using System;
using System.IO;
using System.Text;
using SilvanoFontes.AL.Business.Parametros;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Entities.Relatorios;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Utility.Enums;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business.Import
{
    public class ImportaPerfilDoEleitorado : PerfilDoEleitoradoNeg
    {
        private int _AnoArquivo { get; set; }
        private string _UFArquivo { get; set; }
        private int _IdUsuario { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="idUsuario">Id do usuario loga do no sistema</param>
        public ImportaPerfilDoEleitorado(int idUsuario)
        {
            _IdUsuario = idUsuario;
        }

        public void Import(int idArquivo)
        {
            Arquivo arquivo = new ArquivoNeg().getById(idArquivo);

            bool deletaImportacaoAnterior = true;

            if (arquivo != null)
            {

                string row = "";

                using (StreamReader objArquivo = new StreamReader(arquivo.NomeArquivo, Encoding.UTF7))
                {
                    string[] rowArr = null;
                    Int32 TotalRegistros = 0;
                    
                    LogImportacao logImportacao = new LogImportacao();
                    logImportacao.Arquivo = arquivo.Id;
                    logImportacao.Data = DateTime.Now;
                    logImportacao.Usuario = _IdUsuario;


                    PerfilDoEleitorado perfilEleitorado;

                    while ((row = objArquivo.ReadLine()) != null)
                    {
                        row = row.Replace("\"", "");

                        rowArr = row.Split(';');

                        ///Na primeira passada, deleto a importacao anterior
                        if (deletaImportacaoAnterior)
                        {
                            DeletaImportacaoAnterior(int.Parse(rowArr[0]));
                            deletaImportacaoAnterior = false;
                        }


                        perfilEleitorado = new PerfilDoEleitorado();

                        perfilEleitorado.Ano = int.Parse(rowArr[0]);

                        perfilEleitorado.UF = new EstadoNeg().getByUF(rowArr[1]).Id;

                        MunicipioNeg negMunicipio = new MunicipioNeg();
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(rowArr[3].Trim());
                        municipio.Descricao = rowArr[2].ToUpper().Trim();
                        municipio.UF.Id = perfilEleitorado.UF;

                        negMunicipio.VerificaSalva(municipio);
                        

                        perfilEleitorado.Municipio = municipio.Id;

                        perfilEleitorado.Zona = int.Parse(rowArr[4]);

                        if (rowArr[5].ToUpper().Trim() == "MASCULINO")
                            perfilEleitorado.Sexo = Sexo.Masculino;
                        else
                            perfilEleitorado.Sexo = Sexo.Feminino;

                        perfilEleitorado.FaixaEtaria =
                            new FaixaEtariaNeg().VerificaSalva(
                                new FaixaEtaria()
                                {
                                    Faixa = rowArr[6].ToUpper().Trim()
                                }).Id;

                        Escolaridade escolaridade = new EscolaridadeNeg().getByDescricao(rowArr[7]);

                        if (escolaridade != null)
                            perfilEleitorado.GrauEscolaridade = escolaridade.Id;
                        else
                            perfilEleitorado.GrauEscolaridade = 
                                new EscolaridadeNeg().VerificaSalva(new Escolaridade() { Descricao = rowArr[7].ToUpper().Trim() }).Id;

                        perfilEleitorado.QuantidadeEleitores = Int32.Parse(rowArr[8].Trim());

                        try
                        {
                            base.Save(perfilEleitorado);
                            TotalRegistros++;
                        }
                        catch (Exception ex)
                        {
                            logImportacao.AddErro(ex.Message);
                        }

                    }


                    logImportacao.CalculaTempo();
                    logImportacao.TotalRegistros = TotalRegistros;

                    using (LogImportacaoNeg negLogImportacao = new LogImportacaoNeg())
                    {
                        negLogImportacao.Save(logImportacao);
                    }

                    logImportacao = null;


                }
            }
        }

        public void DeletaImportacaoAnterior(Int32 ano)
        {
            base.AddCriteria(x => x.Ano, Criteria.Eq, ano);
            base.DeleteByFilter();
        }

    }
}
