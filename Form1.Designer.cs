namespace PasswordRecorder
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.UnwrapAll = new System.Windows.Forms.Button();
            this.protectBtn = new System.Windows.Forms.Button();
            this.contentForm = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutHeader = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.contentForm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(300, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(923, 613);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CreateBtn
            // 
            this.CreateBtn.AutoSize = true;
            this.CreateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateBtn.FlatAppearance.BorderSize = 0;
            this.CreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBtn.Location = new System.Drawing.Point(0, 0);
            this.CreateBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(230, 48);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.Create_Click);
            // 
            // Save
            // 
            this.Save.AutoSize = true;
            this.Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Save.FlatAppearance.BorderSize = 0;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(231, 0);
            this.Save.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(229, 48);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // UnwrapAll
            // 
            this.UnwrapAll.AutoSize = true;
            this.UnwrapAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UnwrapAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnwrapAll.FlatAppearance.BorderSize = 0;
            this.UnwrapAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnwrapAll.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnwrapAll.Location = new System.Drawing.Point(461, 0);
            this.UnwrapAll.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.UnwrapAll.Name = "UnwrapAll";
            this.UnwrapAll.Size = new System.Drawing.Size(229, 48);
            this.UnwrapAll.TabIndex = 2;
            this.UnwrapAll.Text = "Unwrap All";
            this.UnwrapAll.UseVisualStyleBackColor = true;
            this.UnwrapAll.Click += new System.EventHandler(this.UnwrapAll_Click);
            // 
            // protectBtn
            // 
            this.protectBtn.AutoSize = true;
            this.protectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.protectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protectBtn.FlatAppearance.BorderSize = 0;
            this.protectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.protectBtn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protectBtn.Image = ((System.Drawing.Image)(resources.GetObject("protectBtn.Image")));
            this.protectBtn.Location = new System.Drawing.Point(691, 0);
            this.protectBtn.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.protectBtn.Name = "protectBtn";
            this.protectBtn.Size = new System.Drawing.Size(230, 48);
            this.protectBtn.TabIndex = 3;
            this.protectBtn.Text = "Protect";
            this.protectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.protectBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.protectBtn.UseVisualStyleBackColor = true;
            this.protectBtn.Click += new System.EventHandler(this.protectBtn_Click);
            // 
            // contentForm
            // 
            this.contentForm.AutoSize = true;
            this.contentForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentForm.BackColor = System.Drawing.SystemColors.Control;
            this.contentForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentForm.Location = new System.Drawing.Point(0, 50);
            this.contentForm.Margin = new System.Windows.Forms.Padding(0);
            this.contentForm.MinimumSize = new System.Drawing.Size(300, 150);
            this.contentForm.Name = "contentForm";
            this.contentForm.Size = new System.Drawing.Size(923, 563);
            this.contentForm.TabIndex = 0;
            // 
            // tableLayoutHeader
            // 
            this.tableLayoutHeader.AutoSize = true;
            this.tableLayoutHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutHeader.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutHeader.ColumnCount = 4;
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutHeader.Controls.Add(this.protectBtn, 3, 0);
            this.tableLayoutHeader.Controls.Add(this.UnwrapAll, 2, 0);
            this.tableLayoutHeader.Controls.Add(this.Save, 1, 0);
            this.tableLayoutHeader.Controls.Add(this.CreateBtn, 0, 0);
            this.tableLayoutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutHeader.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutHeader.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutHeader.Name = "tableLayoutHeader";
            this.tableLayoutHeader.RowCount = 1;
            this.tableLayoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutHeader.Size = new System.Drawing.Size(921, 48);
            this.tableLayoutHeader.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(923, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Recorder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutHeader.ResumeLayout(false);
            this.tableLayoutHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel contentForm;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button UnwrapAll;
        private System.Windows.Forms.Button protectBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutHeader;
    }
}

