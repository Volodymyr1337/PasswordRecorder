using System;
using System.Windows.Forms;

namespace PasswordRecorder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            checkBox1.Checked = Properties.Settings.Default.passwordUsing;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text == textBox2.Text && textBox1.Text.Length < 4)
                {
                    MessageBox.Show("Password length must be greater than 4 chars!");
                }
                else if (textBox1.Text == textBox2.Text)
                {
                    Properties.Settings.Default.userPassword = Crypt.crypt(textBox1.Text);
                    Properties.Settings.Default.Save();
                    Close();
                    MessageBox.Show("Done");
                }
                else
                    MessageBox.Show("Passwords do not match");
            }
            else
                Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.passwordUsing = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
