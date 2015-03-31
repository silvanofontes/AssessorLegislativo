using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilvanoFontes.AL.Entities
{
    public class Zona
    {

        ///"Nr Zona";"Cod Processual Res nº 65/CNJ";"Endereço";"CEP";"Bairro";"Município Sede";"UF"
        

        /// <summary>
        /// 
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Número da Zona Eleitoral
        /// </summary>
        public virtual int NumeroZona { get; set; }

        /// <summary>
        /// Código Processual Resolução nr 65/CNJ
        /// </summary>
        public virtual string CodigoProcessualResCNJ { get; set; }

        /// <summary>
        /// Endereço da Zona
        /// </summary>
        public virtual string Endereco { get; set; }

        /// <summary>
        /// CEP do local
        /// </summary>
        public virtual string CEP { get; set; }

        /// <summary>
        /// Bairro onde se localiza a Zona
        /// </summary>
        public virtual string Bairro { get; set; }

        /// <summary>
        /// Código do município no TSE
        /// </summary>
        public virtual int Municipio { get; set; }

        /// <summary>
        /// Nome do município
        /// </summary>
        public virtual string NomeMunicipio { get; set; }

        /// <summary>
        /// Id da UF
        /// </summary>
        public virtual int UF { get; set; }

    }
}
