using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SilvanoFontes.AL.Entities;

namespace SilvanoFontes.AL.Business.Import
{
    public class CandidaturaNeg
    {
        private string FileName = "";
        public CandidaturaNeg(string file)
        {
            FileName = file;
        }

        public void Import()
        {
            string row = "";


            using (StreamReader objArquivo = new StreamReader(FileName))
            {
                string[] rowArr = null;

                while ((row = objArquivo.ReadLine()) != null)
                {
                    row = row.Replace("\"", "");

                    rowArr = row.Split(';');

                    Candidatura Candidatura = new Candidatura();
                    Candidatura.Ano = int.Parse(rowArr[2]);
                    Candidatura.Turno = int.Parse(rowArr[3]);
                    Candidatura.UF = int.Parse(rowArr[2]);
                }
            }
        }
    }
}
