namespace Bank_Forms
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
            this.btn_singin = new System.Windows.Forms.Button();
            this.btn_signup = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_singin
            // 
            this.btn_singin.Location = new System.Drawing.Point(12, 12);
            this.btn_singin.Name = "btn_singin";
            this.btn_singin.Size = new System.Drawing.Size(214, 59);
            this.btn_singin.TabIndex = 0;
            this.btn_singin.Text = "Вход";
            this.btn_singin.UseVisualStyleBackColor = true;
            this.btn_singin.Click += new System.EventHandler(this.btn_singin_Click);
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(12, 77);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(214, 38);
            this.btn_signup.TabIndex = 1;
            this.btn_signup.Text = "Регистрация";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(12, 121);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(214, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "ИЗХОД";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 157);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.btn_singin);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_singin;
        private Button btn_signup;
        private Button btn_exit;
    }
}