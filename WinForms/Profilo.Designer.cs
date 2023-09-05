namespace WinForms
{
    partial class Profilo
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
            Username = new Label();
            panel2 = new Panel();
            ButtonCreate = new Button();
            ButtonChange = new Button();
            ButtonGet = new Button();
            LabelPassword = new Label();
            TextPassword = new TextBox();
            LabelPasswordName = new Label();
            TextPasswordName = new TextBox();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.BorderStyle = BorderStyle.FixedSingle;
            Username.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Username.Location = new Point(12, 9);
            Username.Name = "Username";
            Username.Size = new Size(64, 69);
            Username.TabIndex = 0;
            Username.Text = "...";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(ButtonCreate);
            panel2.Controls.Add(ButtonChange);
            panel2.Controls.Add(ButtonGet);
            panel2.Controls.Add(LabelPassword);
            panel2.Controls.Add(TextPassword);
            panel2.Controls.Add(LabelPasswordName);
            panel2.Controls.Add(TextPasswordName);
            panel2.Location = new Point(12, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 289);
            panel2.TabIndex = 10;
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(180, 231);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(142, 29);
            ButtonCreate.TabIndex = 15;
            ButtonCreate.Text = "Create password";
            ButtonCreate.UseVisualStyleBackColor = true;
            // 
            // ButtonChange
            // 
            ButtonChange.Location = new Point(180, 135);
            ButtonChange.Name = "ButtonChange";
            ButtonChange.Size = new Size(142, 29);
            ButtonChange.TabIndex = 14;
            ButtonChange.Text = "Change password";
            ButtonChange.UseVisualStyleBackColor = true;
            // 
            // ButtonGet
            // 
            ButtonGet.Location = new Point(180, 56);
            ButtonGet.Name = "ButtonGet";
            ButtonGet.Size = new Size(142, 29);
            ButtonGet.TabIndex = 13;
            ButtonGet.Text = "Get password";
            ButtonGet.UseVisualStyleBackColor = true;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPassword.Location = new Point(3, 135);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(91, 25);
            LabelPassword.TabIndex = 12;
            LabelPassword.Text = "Password";
            LabelPassword.Click += LabelPassword_Click;
            // 
            // TextPassword
            // 
            TextPassword.Location = new Point(3, 163);
            TextPassword.Name = "TextPassword";
            TextPassword.Size = new Size(125, 27);
            TextPassword.TabIndex = 11;
            TextPassword.TextChanged += TextPassword_TextChanged;
            // 
            // LabelPasswordName
            // 
            LabelPasswordName.AutoSize = true;
            LabelPasswordName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPasswordName.Location = new Point(3, 56);
            LabelPasswordName.Name = "LabelPasswordName";
            LabelPasswordName.Size = new Size(148, 25);
            LabelPasswordName.TabIndex = 10;
            LabelPasswordName.Text = "Nome password";
            LabelPasswordName.Click += LabelPasswordName_Click;
            // 
            // TextPasswordName
            // 
            TextPasswordName.Location = new Point(3, 84);
            TextPasswordName.Name = "TextPasswordName";
            TextPasswordName.Size = new Size(125, 27);
            TextPasswordName.TabIndex = 9;
            TextPasswordName.TextChanged += TextPasswordName_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(125, 12);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 16;
            label1.Text = "Password";
            // 
            // Profilo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 450);
            Controls.Add(panel2);
            Controls.Add(Username);
            Name = "Profilo";
            Text = "Profilo";
            Load += Profilo_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Username;
        private Panel panel2;
        private Button ButtonCreate;
        private Button ButtonChange;
        private Button ButtonGet;
        private Label LabelPassword;
        private TextBox TextPassword;
        private Label LabelPasswordName;
        private TextBox TextPasswordName;
        private Label label1;
    }
}