using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encriptador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Encriptar(object sender, EventArgs e)
        {
            richTextBox2.Text = Cryptography.Encrypt(richTextBox1.Text, richTextBox3.Text);
        }

        private void Desencriptar(object sender, EventArgs e)
        {
            richTextBox2.Text = Cryptography.Decrypt(richTextBox1.Text, richTextBox3.Text);
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
