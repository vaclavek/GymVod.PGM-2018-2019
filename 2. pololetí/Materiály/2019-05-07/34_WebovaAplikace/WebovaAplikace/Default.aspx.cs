using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebovaAplikace
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            litInformace.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
                litInformace.Text = "Zaškrtnuto";
            else
                litInformace.Text = "Není zaškrtnuto";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            litInformace.Text = "Vybráno: " + DropDownList1.SelectedValue;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(DropDownList1.SelectedValue))
            {
                case 1:
                    HyperLink1.NavigateUrl = "http://www.seznam.cz";
                    HyperLink1.Text = "Jdi na Seznam";
                    break;
                case 2:
                    HyperLink1.NavigateUrl = "http://www.google.cz";
                    HyperLink1.Text = "Jdi na Google";
                    break;
                case 3:
                    HyperLink1.NavigateUrl = "http://www.gymvod.cz";
                    HyperLink1.Text = "Jdi na GymVod";
                    break;
            }
            HyperLink1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "obrazek.jpg";

            if (Calendar1.SelectedDate.Day == 7)
            {
                Image1.ImageUrl = "7.png";
            }

            if (Image1.Visible)
            {
                Button2.Text = "Zobraz obrázek";
                Image1.Visible = false;
            }
            else
            {
                Button2.Text = "Skryj obrázek";
                Image1.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // vpřed
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // zpět
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "heslo")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                litVysledek.Text = "Přihlášení se nepovedlo, zkuste to znovu.";
            }
        }
    }
}