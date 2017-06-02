using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace PasswordRecorder
{
    public partial class Form1 : Form
    {
        int iterator;
        bool mouseClicked;
        XmlWriter writer;
        FileStream fStream;
        string dataDoc = "data.xml";

        public Form1()
        {
            InitializeComponent();

            styles();

            SignInWithPassword();
        }
        private void SignInWithPassword()
        {
            if (Properties.Settings.Default.passwordUsing)
            {
                tableLayoutPanel1.Hide();
                Form3 signInForm = new Form3();
                signInForm.Show();
                signInForm.TopMost = true;
                signInForm.VisibleChanged += SignInForm_VisibleChanged;
                signInForm.FormClosed += SignInForm_FormClosing;
            }
        }

        private void SignInForm_VisibleChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Show();
        }

        private void SignInForm_FormClosing(object sender, EventArgs e)
        {
            this.Close();
        }

        private void styles()
        {
            this.BackColor = Color.FromArgb(23, 20, 31);
            contentForm.BackColor = Color.FromArgb(23, 20, 31);
            tableLayoutPanel1.BackColor = contentForm.BackColor;
            tableLayoutHeader.BackColor = Color.FromArgb(23, 20, 31);

            CreateBtn.BackColor = Color.FromArgb(255, 23, 68);
            CreateBtn.ForeColor = Color.White;

            Save.BackColor = Color.FromArgb(255, 23, 68);
            Save.ForeColor = Color.White;

            UnwrapAll.BackColor = Color.FromArgb(255, 23, 68);
            UnwrapAll.ForeColor = Color.White;

            protectBtn.BackColor = Color.FromArgb(255, 23, 68);
            protectBtn.ForeColor = Color.White;

            tableLayoutPanel1.HorizontalScroll.Enabled = false;
            tableLayoutPanel1.AutoScroll = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set max window size
            int maxX = Screen.GetWorkingArea(this).Width;
            int maxY = Screen.GetWorkingArea(this).Height;
            MaximumSize = new Size(maxX, maxY);
            Load_Data();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            AddLoginInfo();
        }

        private void SlideAnimation(object sender, EventArgs e) // unwrap animation
        {
            FlowLayoutPanel pan;
            TextBox txt;                    // title textbox
            Type t = sender.GetType();
            if (t.Equals(typeof(FlowLayoutPanel)))
            {
                pan = (FlowLayoutPanel)sender;
            }
            else
            {
                txt = (TextBox)sender;
                pan = (FlowLayoutPanel)txt.Parent;
            }

            UnwrapPanel(pan);
        }

        private void UnwrapPanel(Panel pan)
        {
            if (pan.Height > 50)
            {
                while (pan.Height > 50)
                {
                    pan.Height -= 5;
                    if (pan.Height > 260)
                        pan.Height -= 10;
                }
                foreach (Control ctrl in pan.Controls)
                {
                    if (ctrl.Name == "Description_Data")
                    {
                        ctrl.Height = 115;   // returns default state
                    }
                }
            }
            else
            {
                while (pan.Height < 260)
                {
                    pan.Height += 5;
                }
            }
        }

        private void onMouseDown(object sender, EventArgs e) { mouseClicked = true; }
        private void onMouseUp(object sender, EventArgs e) { mouseClicked = false; }

        private void panelResize(object sender, MouseEventArgs e)   // resize button
        {
            PictureBox pct = (PictureBox)sender;
            Panel pan = (Panel)pct.Parent;
            if (mouseClicked)
            {
                foreach (Control ctrl in pan.Controls)
                {
                    if (ctrl.Name == "Description_Data")
                    {
                        if (ctrl.Height + e.Y < ctrl.MaximumSize.Height)
                            ctrl.Height = ctrl.Height + e.Y - 10;               // 10 - это паддинг

                        if (ctrl.Bottom > pan.Height && ctrl.Top < pan.Height)  // при резких изменениях позиции мыши 
                            ctrl.Height = ctrl.Height - e.Y + 10;               // область с текстом вылетала за область панели
                        break;
                    }
                }

                if (pct.Top + e.Y < pan.MaximumSize.Height)
                {
                    pan.Height = pct.Top + e.Y + 5;
                }
                else
                    mouseClicked = false;
            }               
        }

        private void DeletePanel(object sender, EventArgs e)        // delete btn
        {
            Panel pan = (Panel)((PictureBox)sender).Parent;
            contentForm.Controls.Remove(pan);
        }

        private void Save_Click(object sender, EventArgs e)         // save btn
        {
            try
            {
                fStream = new FileStream(dataDoc, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ops: " + ex.Message);
            }
            if (fStream != null)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                writer = XmlWriter.Create(fStream, settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("Data");
                foreach (Control ctrl in contentForm.Controls)
                {
                    writer.WriteStartElement("Panel");
                    foreach (Control ctrlChild in ctrl.Controls)
                    {
                        if (ctrlChild.Name == "Title" || ctrlChild.Name == "Login_Data" || 
                            ctrlChild.Name == "Password_Data" || ctrlChild.Name == "Description_Data")
                        {
                            writer.WriteElementString(ctrlChild.Name, Crypt.crypt(ctrlChild.Text));
                        }
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.Close();
                fStream.Close();
                
            }
        }

        private void protectBtn_Click(object sender, EventArgs e)   // protect btn
        {
            BackColor = Color.FromArgb(23, 20, 31);
            Form2 protectForm = new Form2();
            protectForm.FormClosed += PasswordForm_FormClosed;
            protectForm.Show();
        }

        private void PasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableLayoutPanel1.Show();
        }

        private void Load_Data()    // loading passwords from xml
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(dataDoc);
                foreach (XmlElement element in xml.GetElementsByTagName("Panel"))
                {
                    string title = "", login = "", password = "", description = "";

                    foreach (XmlElement e in element)
                    {
                        if (e.Name == "Title") title = Crypt.deCrypt(e.InnerText);
                        else if (e.Name == "Login_Data") login = Crypt.deCrypt(e.InnerText);
                        else if (e.Name == "Password_Data") password = Crypt.deCrypt(e.InnerText);
                        else if (e.Name == "Description_Data") description = Crypt.deCrypt(e.InnerText);
                    }

                    AddLoginInfo(title, login, password, description);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UnwrapAll_Click(object sender, EventArgs e)    // unwrap button
        {
            foreach (Control ctrl in contentForm.Controls)
            {
                UnwrapPanel((Panel)ctrl);
            }
        }

        private void AddLoginInfo(string titleValue = "Title", string loginValue = "", 
                                    string passwordValue = "", string descriptionValue = "")
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Location = new Point(0, 0);
            panel.Size = new Size(450, 50);
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.FromArgb(245, 245, 245);
            panel.Tag = iterator++;
            panel.MaximumSize = new Size(458, 500);
            panel.MinimumSize = new Size(458, 50);
            panel.Margin = new Padding(1);
            //
            // Title
            //
            TextBox title = new TextBox();
            title.Height = 30;
            title.Width = 408;
            title.BorderStyle = BorderStyle.None;
            title.TextAlign = HorizontalAlignment.Center;
            title.Font = new Font("Microsoft Sans Serif", 16);
            title.ForeColor = Color.FromArgb(23, 20, 31);   // font color
            title.Multiline = true;
            title.Margin = new Padding(10, 10, 0, 10);
            title.MaxLength = 100;                          // count of chars
            title.WordWrap = true;
            title.Cursor = Cursors.Hand;
            title.Text = titleValue;
            title.Name = "Title";
            title.Click += SlideAnimation;
            panel.Controls.Add(title);
            //
            // Delete panel (button)
            //
            PictureBox pict = new PictureBox();         
            pict.Size = new Size(30, 30);
            FileStream fs = new FileStream("delete.png", FileMode.Open, FileAccess.Read);
            pict.Image = Image.FromStream(fs);
            fs.Close();
            pict.SizeMode = PictureBoxSizeMode.StretchImage;
            pict.Margin = new Padding(0, 10,0,0);
            pict.Click += DeletePanel;
            pict.Name = "Delete_Button";
            panel.Controls.Add(pict);
            //
            // LOG IN
            //
            Label loginLab = new Label();
            loginLab.Text = "Login: ";
            loginLab.Name = "Login";
            loginLab.Font = new Font("Rockwell", 12, FontStyle.Bold);
            loginLab.Width = 60;
            loginLab.Margin = new Padding(10, 0, 0, 0);
            panel.Controls.Add(loginLab);

            TextBox login = new TextBox();
            login.Width = 370;
            login.Height = 25;
            login.Name = "Login_Data";
            login.Text = loginValue;
           // login.BackColor = Color.FromArgb(250, 250, 250);
            login.BorderStyle = BorderStyle.None;
            login.TextAlign = HorizontalAlignment.Left;
            login.Font = new Font("Microsoft Sans Serif", 12);
            login.ForeColor = Color.FromArgb(23, 20, 31);
            login.Multiline = true;
            login.Margin = new Padding(0, 0, 0, 0);
            login.MaxLength = 100;                     
            panel.Controls.Add(login);
            //
            // PASSWORD
            //
            Label passLab = new Label();
            passLab.Name = "Password";
            passLab.Text = "Pass: ";
            passLab.Font = new Font("Rockwell", 12, FontStyle.Bold);
            passLab.ForeColor = Color.FromArgb(23, 20, 31);
            passLab.Width = 60;
            passLab.Margin = new Padding(10, 0, 0, 0);
            panel.Controls.Add(passLab);

            TextBox pass = new TextBox();
            pass.Name = "Password_Data";
            pass.Text = passwordValue;
            pass.Width = 370;
            pass.Height = 25;
           // pass.BackColor = Color.FromArgb(23, 20, 31);
            pass.BorderStyle = BorderStyle.None;
            pass.TextAlign = HorizontalAlignment.Left;
            pass.Font = new Font("Microsoft Sans Serif", 12);
            pass.ForeColor = Color.FromArgb(23, 20, 31);
            pass.Multiline = true;
            pass.Margin = new Padding(0, 0, 0, 0);
            pass.MaxLength = 100;
            panel.Controls.Add(pass);
            //
            // DESCRIPTION
            //
            Label descLab = new Label();
            descLab.Name = "Description";
            descLab.Text = "Description: ";
            descLab.Font = new Font("Rockwell", 12, FontStyle.Bold);
            descLab.ForeColor = Color.FromArgb(23, 20, 31);
            descLab.Width = 200;
            descLab.Margin = new Padding(10, 0, 0, 0);
            panel.Controls.Add(descLab);

            TextBox desc = new TextBox();
            desc.Width = 430;
            desc.Height = 115;
            desc.MaximumSize = new Size(438, 365);
            desc.BackColor = Color.FromArgb(250, 250, 250);
            desc.BorderStyle = BorderStyle.None;
            desc.TextAlign = HorizontalAlignment.Left;
            desc.Font = new Font("Microsoft Sans Serif", 12);
            desc.ForeColor = Color.FromArgb(23, 20, 31);
            desc.Multiline = true;
            desc.Margin = new Padding(15, 0, 0, 0);
            desc.MaxLength = 4000;
            desc.ScrollBars = ScrollBars.Vertical;    // displa scroll
            desc.WordWrap = true;
            desc.Name = "Description_Data";
            desc.Text = descriptionValue;
            panel.Controls.Add(desc);
            //
            // Show more information (button)
            //
            PictureBox moreBtn = new PictureBox();         
            moreBtn.Anchor = AnchorStyles.Bottom;
            moreBtn.Size = new Size(430, 10);
            moreBtn.Name = "Bottom_Arrow";
            FileStream fstrm = new FileStream("bottom_arrow.png", FileMode.Open, FileAccess.Read);
            moreBtn.Image = Image.FromStream(fstrm);
            fstrm.Close();
            moreBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            moreBtn.Margin = new Padding(10, 5, 0, 0);
            moreBtn.Cursor = Cursors.SizeNS;
            moreBtn.MouseDown += onMouseDown;
            moreBtn.MouseUp += onMouseUp;
            moreBtn.MouseMove += panelResize;
            panel.Controls.Add(moreBtn);

            contentForm.Controls.Add(panel);
        }

    }

    public class Crypt
    {
        public static string crypt(string data)
        {
            char[] value = new char[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                if (i % 2 == 0)
                    value[i] = Convert.ToChar(data[i] + 33);
                else
                    value[i] = Convert.ToChar(data[i] + 27);
            }
            return new string(value);
        }
        public static string deCrypt(string data)
        {
            char[] value = new char[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                if (i % 2 == 0)
                    value[i] = Convert.ToChar(data[i] - 33);
                else
                    value[i] = Convert.ToChar(data[i] - 27);
            }
            return new string(value);
        }
    }
}
