namespace final_prject_login_trial
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login_username = new System.Windows.Forms.TextBox();
            this.login_password = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.create_account_button = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.code = new System.Windows.Forms.Label();
            this.input_code = new System.Windows.Forms.TextBox();
            this.code_visible = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(103, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(103, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // login_username
            // 
            this.login_username.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.login_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_username.Location = new System.Drawing.Point(107, 266);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(200, 19);
            this.login_username.TabIndex = 2;
            // 
            // login_password
            // 
            this.login_password.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.login_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_password.Location = new System.Drawing.Point(107, 336);
            this.login_password.Name = "login_password";
            this.login_password.Size = new System.Drawing.Size(200, 19);
            this.login_password.TabIndex = 3;
            this.login_password.TextChanged += new System.EventHandler(this.login_password_TextChanged);
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_button.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.login_button.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.login_button.Location = new System.Drawing.Point(86, 458);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(75, 42);
            this.login_button.TabIndex = 4;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            this.login_button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.login_button_KeyDown);
            // 
            // create_account_button
            // 
            this.create_account_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.create_account_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_account_button.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.create_account_button.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.create_account_button.Location = new System.Drawing.Point(167, 458);
            this.create_account_button.Name = "create_account_button";
            this.create_account_button.Size = new System.Drawing.Size(163, 42);
            this.create_account_button.TabIndex = 5;
            this.create_account_button.Text = "Create Account";
            this.create_account_button.UseVisualStyleBackColor = true;
            this.create_account_button.Click += new System.EventHandler(this.create_account_button_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.Location = new System.Drawing.Point(394, 336);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(0, 18);
            this.code.TabIndex = 7;
            // 
            // input_code
            // 
            this.input_code.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.input_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_code.Location = new System.Drawing.Point(107, 405);
            this.input_code.Name = "input_code";
            this.input_code.Size = new System.Drawing.Size(200, 19);
            this.input_code.TabIndex = 8;
            // 
            // code_visible
            // 
            this.code_visible.AutoSize = true;
            this.code_visible.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_visible.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.code_visible.Location = new System.Drawing.Point(103, 380);
            this.code_visible.Name = "code_visible";
            this.code_visible.Size = new System.Drawing.Size(139, 18);
            this.code_visible.TabIndex = 10;
            this.code_visible.Text = "Verification Code";
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Lucida Calligraphy", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logo.ForeColor = System.Drawing.Color.PaleGreen;
            this.logo.Location = new System.Drawing.Point(324, 47);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(90, 31);
            this.logo.TabIndex = 11;
            this.logo.Text = "LOGO";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(107, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(107, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(107, 430);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 1);
            this.panel4.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::final_prject_login_trial.Properties.Resources.gradient_background_green_shades_23_2148363157;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 215);
            this.panel1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(158, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "MyDiet";
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(452, 544);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.code_visible);
            this.Controls.Add(this.input_code);
            this.Controls.Add(this.code);
            this.Controls.Add(this.create_account_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.login_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button create_account_button;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.TextBox input_code;
        private System.Windows.Forms.Label code_visible;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
    }
}

