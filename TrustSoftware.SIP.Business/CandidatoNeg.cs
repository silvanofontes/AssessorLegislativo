using System;
using System.Collections.Generic;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Entities.Parametros;
using SilvanoFontes.AL.Utility;
using SilvanoFontes.AL.Utility.Enums;

namespace SilvanoFontes.AL.Business
{
    public class CandidatoNeg : GenericBusiness<Candidato>
    {
        public CandidatoNeg(Usuario usuario)
        {
            if (usuario != null)
            {
                switch (usuario.Perfil)
                {
                    case PerfilUsuario.Administrador:
                        break;

                    case PerfilUsuario.Parlamentar:
                    case PerfilUsuario.Usuario:
                    case PerfilUsuario.Eleitor:

                        if (usuario.Empresa != null)
                        {
                            for (int i = 0; i < usuario.Empresa.Candidaturas.Count; i++)
                            {
                                base.AddCriteria(x => x.Id, Criteria.Eq, usuario.Empresa.Candidaturas[i].Id);
                            }
                        }
                        else
                        {
                            ///throw new Exception("Usuário não possui empresa associada");
                        }
                        break;

                }
            }
        }

        public Candidato getById(int id)
        {
            return base.getById(id);
        }

        public Candidato getByCPF(Int64 cpf)
        {
            base.AddCriteria(x => x.CPF, Criteria.Eq, cpf);
            return base.ByFilter();
        }

        public Candidato getByIdSequencial(Int64 idSeq)
        {
            base.AddCriteria(x => x.IdSequencial, Criteria.Eq, idSeq);
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
            //base.Refresh(candidato);
            //base.Clear();
            base.AddCriteria(x => x.IdSequencial, Criteria.Eq, candidato.IdSequencial);
            if (base.ByFilter() == null)
                base.Save(candidato);

            return candidato;
        }

        /// <summary>
        /// USADO IMPORTAÇÃO DO ARQUIVO
        /// Carrega a Classe Candidato com os dados partir do array gerado da linha do arquivo.
        /// </summary>
        /// <param name="row">Array criado à partir da linha do arquivo</param>
        /// <returns>Classe Candidato</returns>
        public Candidato CarregaDadosCandidato(string[] row)
        {
            Candidato candidato = new Candidato();
            candidato = getByIdSequencial(Int64.Parse(row[11]));

            if (candidato == null)
            {
                AnoLayout anoLayout;
                int flagAno;

                if (int.Parse(row[2]) >= 2012)
                {
                    flagAno = 0;
                    anoLayout = AnoLayout.Apos2012;
                }
                else
                {
                    flagAno = 1;
                    anoLayout = AnoLayout.Ate2008;
                }

                candidato = new Candidato();
                candidato.Nome = row[10].ToUpper();
                candidato.IdSequencial = Int64.Parse(row[11]);
                candidato.NumeroCandidato = int.Parse(row[12]);

                ///------------------
                ///o CPF só foi incluído a partir da eleição de 2014
                if (anoLayout == AnoLayout.Apos2012)
                    candidato.CPF = Int64.Parse(row[13]);

                candidato.NomeUrna = row[14 - (int)flagAno].ToUpper();

                candidato.Ocupacao =
                    new OcupacaoNeg().VerificaSalva(
                        new Ocupacao()
                        {
                            Id = int.Parse(row[24 - (int)flagAno]),
                            Descricao = row[25 - (int)flagAno]
                        }
                    );

                candidato.DataNascimento = DateTime.Parse(row[26 - (int)flagAno]);
                candidato.NumeroTituloEleitor = Int64.Parse(row[27 - (int)flagAno]);
                candidato.Idade = int.Parse(row[28 - (int)flagAno]);
                candidato.Sexo = (Sexo)int.Parse(row[29 - (int)flagAno]);
                candidato.Escolaridade =
                    new EscolaridadeNeg().VerificaSalva(
                        new Escolaridade()
                        {
                            Id = int.Parse(row[31 - (int)flagAno]),
                            Descricao = row[32 - (int)flagAno].ToUpper().Trim()
                        }
                    );

                candidato.EstadoCivil =
                    new EstadoCivilNeg().VerificaSalva(
                        new EstadoCivil()
                        {
                            Id = int.Parse(row[33 - flagAno]),
                            Descricao = row[34 - flagAno].ToUpper().Trim()
                        }
                    );
                if (anoLayout == AnoLayout.Apos2014)
                    candidato.CorRaca = (CorRaca)int.Parse(row[35 - flagAno]);
                else
                    flagAno += 2;

                candidato.Nacionalidade =
                    new NacionalidadeNeg().VerificaSalva(
                        new Nacionalidade()
                        {
                            Id = int.Parse(row[37 - flagAno]),
                            Descricao = row[38 - flagAno]
                        }
                    );

                Municipio naturalidade = new Municipio();
                MunicipioNeg negMunicipio = new MunicipioNeg();
                naturalidade = negMunicipio.getById(int.Parse(row[40 - flagAno]));

                if (naturalidade == null)
                    naturalidade = negMunicipio.getByNomeUF(row[41 - flagAno], row[39 - flagAno]);

                if (naturalidade != null)
                    candidato.Naturalidade = naturalidade;
                else
                    candidato.Naturalidade = negMunicipio.getById(0); // Se não encontrar o municipio, coloco o "NÃO INFORMADO"

                negMunicipio = null;
                naturalidade = null;

                ///Usado no carregamento do arquivo de Benss
                candidato.Bens = null;

                base.Clear();

            }
            if (candidato.Id == 0)
                Save(candidato);

            return candidato;
        }
    }

    public enum TipoNome
    {
        NomeCompleto = 1,
        NomeUrna = 2
    }
}
