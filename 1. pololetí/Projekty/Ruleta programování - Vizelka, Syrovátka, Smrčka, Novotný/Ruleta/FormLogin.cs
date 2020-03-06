using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Ruleta
{
    public partial class FormLogin : Form
    {

        private Users users;
        private string fileName;

        public FormLogin()
        {
            InitializeComponent();
           
            var fileDir = AppDomain.CurrentDomain.BaseDirectory;

            
            fileName = Path.Combine(fileDir, "users.bin");

         
            if (File.Exists(fileName))
                using (var fs = File.OpenRead(fileName))
                    users = (Users)new BinaryFormatter().Deserialize(fs);
            else
                users = new Users();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                users.SignIn(textBox1.Text, textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

   
            FormHra Hra = new FormHra();
            Hra.ShowDialog();
           
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
