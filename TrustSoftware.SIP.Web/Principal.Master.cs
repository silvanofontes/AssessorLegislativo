﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilvanoFontes.AL.Web
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Header.DataBind();

            imgUser.ImageUrl = "image/silvano_fontes.jpg";
            lblUser.Text = "Silvano Fontes";
        }
    }
}