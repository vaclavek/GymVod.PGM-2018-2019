using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Files.Properties;

namespace Files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllBytes("kote.jpg");
            //Bitmap data = Resources.kote
            pictureBox1.Image = ByteToImage(data);
        }

        private static Bitmap ByteToImage(byte[] data)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = data;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}
