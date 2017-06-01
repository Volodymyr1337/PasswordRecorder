using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordRecorder
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Crypt.crypt(f3password.Text) != Properties.Settings.Default.userPassword)
                MessageBox.Show("Incorrect Password!");
            else
                this.Hide();
        }
    }
}
