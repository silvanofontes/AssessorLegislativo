using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SilvanoFontes.AL.Entities;
using SilvanoFontes.AL.Business;
using Ext.Net;

namespace SilvanoFontes.AL.Web.Controles
{
    public partial class UCPessoa : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsIPhone)
            {
                FormPanel1.LabelAlign = LabelAlign.Top;
            }
        }

        protected void VerificaPessoa(object sender, EventArgs e)
        {
            txtRG.Text = "00000000";
        }

        public void CarregaPessoa(int idPessoa)
        {
            Pessoa pessoa = new Pessoa();
            GenericBusiness<Pessoa> negPessoa = new GenericBusiness<Pessoa>();
            pessoa = negPessoa.gerById(idPessoa);
            
            
        }

        public void CarregaPessoa(Pessoa pessoa)
        {

        }

        public Pessoa RetornaPessoa()
        {
            return new Pessoa();
        }
    }
}