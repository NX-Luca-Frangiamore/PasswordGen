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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 118);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 53);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
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
            ButtonLogin.Location = new Point(12, 170);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(94, 29);
            ButtonLogin.TabIndex = 5;
            ButtonLogin.Text = "Login";
            ButtonLogin.UseVisualStyleBackColor = true;
            // 
            // ButtonSignIn
            // 
            ButtonSignIn.Location = new Point(12, 215);
            ButtonSignIn.Name = "ButtonSignIn";
            ButtonSignIn.Size = new Size(94, 29);
            ButtonSignIn.TabIndex = 6;
            ButtonSignIn.Text = "Sign in";
            ButtonSignIn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 450);
            Controls.Add(ButtonSignIn);
            Controls.Add(ButtonLogin);
            Controls.Add(LabelPassword);
            Controls.Add(LabelUser);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label LabelUser;
        private Label LabelPassword;
        private Button ButtonLogin;
        private Button ButtonSignIn;
    }
}