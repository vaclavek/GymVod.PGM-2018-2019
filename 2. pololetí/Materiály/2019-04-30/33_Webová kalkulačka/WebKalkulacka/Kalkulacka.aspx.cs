using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebKalkulacka
{
    public partial class Kalkulacka : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {            
            int cislo1 = VratPrvniCislo();
            int cislo2 = VratDruheCislo();
            int vysledek = cislo1 + cislo2;
            litVysledek.Text = vysledek.ToString();
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            litVysledek.Text = (VratPrvniCislo() - VratDruheCislo()).ToString();
        }

        protected void btnKrat_Click(object sender, EventArgs e)
        {
            litVysledek.Text = (VratPrvniCislo() * VratDruheCislo()).ToString();
        }

        protected void btnDeleno_Click(object sender, EventArgs e)
        {
            litVysledek.Text = (VratPrvniCislo() / VratDruheCislo()).ToString();
        }

        private int VratPrvniCislo()
        {
            return Convert.ToInt32(txtPrvniCislo.Text);
        }

        private int VratDruheCislo()
        {
            return Convert.ToInt32(txtDruheCislo.Text);
        }
    }
}