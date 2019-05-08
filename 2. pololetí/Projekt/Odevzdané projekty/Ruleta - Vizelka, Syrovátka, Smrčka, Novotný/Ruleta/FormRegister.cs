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
    public partial class FormRegister : Form
    {
        private Users users;
        private string fileName;

        public FormRegister()
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
                   
                    users.SignupNewUser(textBox1.Text, textBox2.Text);
                 
                    using (var fs = File.OpenWrite(fileName))
                        new BinaryFormatter().Serialize(fs, users);   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.Close();
            MessageBox.Show("Uzivatel byl zaregistrovan");
           

        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}

