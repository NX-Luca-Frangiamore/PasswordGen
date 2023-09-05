namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            TextUsername = new TextBox();
            TextPassword = new TextBox();
            LabelUser = new Label();
            LabelPassword = new Label();
            ButtonLogin = new Button();
            ButtonSignIn = new Button();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // TextUsername
            // 
            TextUsername.Location = new Point(11, 53);
            TextUsername.Name = "TextUsername";
            TextUsername.Size = new Size(125, 27);
            TextUsername.TabIndex = 1;
            // 
            // TextPassword
            // 
            TextPassword.Location = new Point(12, 118);
            TextPassword.Name = "TextPassword";
            TextPassword.Size = new Size(125, 27);
            TextPassword.TabIndex = 2;
            // 
            // LabelUser
            // 
            LabelUser.AutoSize = true;
            LabelUser.Location = new Point(12, 30);
            LabelUser.Name = "LabelUser";
            LabelUser.Size = new Size(38, 20);
            LabelUser.TabIndex = 3;
            LabelUser.Text = "User";
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Location = new Point(12, 95);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(70, 20);
            LabelPassword.TabIndex = 4;
            LabelPassword.Text = "Password";
            LabelPassword.Click += LabelPassword_Click;
            // 
            // ButtonLogin
            // 
            ButtonLogin.Location = new Point(27, 161);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(94, 29);
            ButtonLogin.TabIndex = 5;
            ButtonLogin.Text = "Login";
            ButtonLogin.UseVisualStyleBackColor = true;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // ButtonSignIn
            // 
            ButtonSignIn.Location = new Point(27, 206);
            ButtonSignIn.Name = "ButtonSignIn";
            ButtonSignIn.Size = new Size(94, 29);
            ButtonSignIn.TabIndex = 6;
            ButtonSignIn.Text = "Sign in";
            ButtonSignIn.UseVisualStyleBackColor = true;
            ButtonSignIn.Click += ButtonSignIn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(148, 275);
            Controls.Add(ButtonSignIn);
            Controls.Add(ButtonLogin);
            Controls.Add(LabelPassword);
            Controls.Add(LabelUser);
            Controls.Add(TextUsername);
            Controls.Add(TextPassword);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox TextUsername;
        private TextBox TextPassword;
        private Label LabelUser;
        private Label LabelPassword;
        private Button ButtonLogin;
        private Button ButtonSignIn;
    }
}