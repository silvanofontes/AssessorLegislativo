using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Business;
using SilvanoFontes.AL.Business.Import;

namespace SilvanoFontes.AL.Web
{
    public partial class ImportaTXTPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string file = "E:\\Silvano\\Sites - Particulares\\AssessorLegislativo\\Arquivos\\consulta_cand_2012_RJ.txt";
            CandidaturaNeg negCandidatura = new CandidaturaNeg(file);
            
        }

        public void Importar(object sender, EventArgs e)
        {
            string mensagem = "";
            int inicio = 17;
            string arquivo = "C:\\Temp\\TXTAline.txt";
            
            ImportacaoTXT objTXT = new ImportacaoTXT();

            GenericBusiness<ImportacaoTXT> neg = new GenericBusiness<ImportacaoTXT>();

            using (StreamReader texto = new StreamReader(arquivo))
            {
                while ((mensagem = texto.ReadLine()) != null)
                {
                    if (mensagem.Substring(0, 4) == "NOME")
                    {
                        objTXT = new ImportacaoTXT();
                        objTXT.Nome = mensagem.Substring(inicio, mensagem.Length - inicio);

                        mensagem = texto.ReadLine();

                        if (mensagem.Substring(0, 9) == "DATA NASC")
                        {
                            objTXT.DtNascimento = mensagem.Substring(inicio, mensagem.Length - inicio);
                            
                            mensagem = texto.ReadLine();

                            if (mensagem.Substring(0, 6) == "ADMISS")
                            {
                                objTXT.DtEmissao = mensagem.Substring(inicio, mensagem.Length - inicio);
                                mensagem = texto.ReadLine();

                                if (mensagem.Substring(0, 3) == "CPF")
                                {
                                    objTXT.Cpf = mensagem.Substring(inicio, mensagem.Length - inicio);

                                    neg.Save(objTXT);
                                }
                            }
                        }
                    }
                }
                
            }
        }

    }
}