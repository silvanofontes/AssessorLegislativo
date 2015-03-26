using System;
using System.Collections.Generic;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Business
{
    public class CandidatoNeg : GenericBusiness<Candidato>
    {
        public CandidatoNeg()
        { }

        public Candidato getById(int id)
        {
            return base.getById(id);
        }

        public Candidato getByCPF(Int64 cpf)
        {
            base.AddCriteria(x => x.CPF, Criteria.Eq, cpf);
            return base.ByFilter();
        }

        public Candidato getByNome(TipoNome tpNome, string nome)
        {
            if (tpNome == TipoNome.NomeCompleto)
                base.AddCriteria(x => x.Nome, Criteria.Eq, nome);
            else
                base.AddCriteria(x => x.NomeUrna, Criteria.Eq, nome);

            return base.ByFilter();
        }

        public List<Candidato> listByNome(TipoNome tpNome, string nome)
        {
            if (tpNome == TipoNome.NomeCompleto)
                base.AddCriteria(x => x.Nome, Criteria.Like, nome);
            else
                base.AddCriteria(x => x.NomeUrna, Criteria.Like, nome);

            return base.listByFilter();
        }

        /// <summary>
        /// Verifica se o candidato existe utilizando o ID Sequencial do candidato
        /// Se não existir, Salvo.
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns></returns>
        public Candidato VerificaSalva(Candidato candidato)
        {
            if (base.getById(candidato.IdSequencial) == null)
                base.Save(candidato);

            return candidato;
        }

        /// <summary>
        /// Carrega a Classe Candidato com os dados partir do array gerado da linha do arquivo.
        /// </summary>
        /// <param name="row">Array criado à partir da linha do arquivo</param>
        /// <returns>Classe Candidato</returns>
        public Candidato CarregaDadosCandidato(string[] row)
        {
            Candidato candidato = new Candidato();
            candidato.Nome = row[10].ToUpper();
            candidato.IdSequencial = int.Parse(row[11]);
            candidato.NumeroCandidato = int.Parse(row[12]);
            candidato.CPF = Int64.Parse(row[13]);
            candidato.NomeUrna = row[14].ToUpper();
            candidato.Ocupacao =
                new OcupacaoNeg().VerificaSalva(
                    new Ocupacao()
                    {
                        Id = int.Parse(row[24]),
                        Descricao = row[25]
                    }
                );

            candidato.DataNascimento = DateTime.Parse(row[25]);
            candidato.NumeroTituloEleitor = Int64.Parse(row[27]);
            candidato.Idade = int.Parse(row[28]);
            candidato.Sexo = (Sexo)int.Parse(row[29]);
            candidato.Escolaridade = 
                new EscolaridadeNeg().VerificaSalva(
                    new Escolaridade()
                    {
                        Id = int.Parse(row[31]),
                        Descricao = row[32].ToUpper().Trim()
                    }
                );

            candidato.EstadoCivil = new EstadoCivil();


            return new Candidato();
        }
    }

    public enum TipoNome
    {
        NomeCompleto = 1,
        NomeUrna = 2
    }
}
