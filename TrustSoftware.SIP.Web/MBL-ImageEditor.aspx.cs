using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Windows.Forms;

namespace SilvanoFontes.AL.Web
{
    public partial class MBL_ImageEditor : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdicionarTexto(object sender, EventArgs e)
        {
            try
            {

                System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath("image/Banner.png"));

                //ImageInfo.Text = "Image Size: [ " + image.Size + " ] - Pixel Format: [ " + image.PixelFormat + " ]";

                using (Graphics g = Graphics.FromImage(image))
                {
                    Brush solidBrush = new SolidBrush(Color.Black);

                    FontFamily family = new FontFamily("Verdana");

                    Font font = new Font(family, 40.00f, FontStyle.Bold);

                    Size textSize = TextRenderer.MeasureText(txtCidade.Text, font);
                    float presentFontSize = font.Size;


                    while ((textSize.Width > 400 || textSize.Height > 115) && presentFontSize - 0.2F > 0)
                    {
                        presentFontSize -= 0.2F;
                        font = new Font(family, presentFontSize, FontStyle.Bold);
                        textSize = TextRenderer.MeasureText(txtCidade.Text, font);
                    }

                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;

                    g.DrawString(txtCidade.Text, font, Brushes.Black, new PointF(200, 150), sf);

                    presentFontSize = 20.00f;
                    font = new Font(family, presentFontSize, FontStyle.Bold);
                    textSize = TextRenderer.MeasureText(txtLocal.Text, font);
                    while ((textSize.Width > 400 || textSize.Height > 50) && presentFontSize - 0.2F > 0)
                    {
                        presentFontSize -= 0.2F;
                        font = new Font(family, presentFontSize, FontStyle.Bold);
                        textSize = TextRenderer.MeasureText(txtLocal.Text, font);
                    }

                    g.DrawString(txtLocal.Text, font, Brushes.Black, new PointF(200, 200), sf);

                    font = new Font(family, 20.00f, FontStyle.Bold);
                    g.DrawString(txtHorario.Text, font, Brushes.Black, new PointF(200, 230), sf);

                    //g.DrawString(txtLocal.Text, font, solidBrush, new PointF(20, 180));


                    image.Save(Server.MapPath("image/BanerAlterado.png"));
                    imagem.ImageUrl = "~/image/BanerAlterado.png";
                }

            }
            catch (Exception ex) { ImageInfo.Text = "Ocorreu um problema: " + ex.Message; }
        }

    }
}