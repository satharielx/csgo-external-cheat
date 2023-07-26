
namespace keygenapp
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.username = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.key = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.login = new MaterialSkin.Controls.MaterialButton();
            this.resp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Depth = 0;
            this.username.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.username.LeadingIcon = null;
            this.username.Location = new System.Drawing.Point(155, 115);
            this.username.MaxLength = 50;
            this.username.MouseState = MaterialSkin.MouseState.OUT;
            this.username.Multiline = false;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(351, 50);
            this.username.TabIndex = 0;
            this.username.Text = "";
            this.username.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(39, 136);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(76, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Username:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(39, 193);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(31, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Key:";
            // 
            // key
            // 
            this.key.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.key.Depth = 0;
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.key.LeadingIcon = null;
            this.key.Location = new System.Drawing.Point(155, 171);
            this.key.MaxLength = 50;
            this.key.MouseState = MaterialSkin.MouseState.OUT;
            this.key.Multiline = false;
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(351, 50);
            this.key.TabIndex = 2;
            this.key.Text = "";
            this.key.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(268, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(30, 76);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(527, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Wicked Empress Admin Utility, please enter your credentials to continue by.";
            // 
            // login
            // 
            this.login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.login.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.login.Depth = 0;
            this.login.HighEmphasis = true;
            this.login.Icon = null;
            this.login.Location = new System.Drawing.Point(267, 266);
            this.login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.login.MouseState = MaterialSkin.MouseState.HOVER;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(64, 36);
            this.login.TabIndex = 6;
            this.login.Text = "Login";
            this.login.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.login.UseAccentColor = false;
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // resp
            // 
            this.resp.AutoSize = true;
            this.resp.Location = new System.Drawing.Point(152, 235);
            this.resp.Name = "resp";
            this.resp.Size = new System.Drawing.Size(78, 13);
            this.resp.TabIndex = 7;
            this.resp.Text = "Response: Idle";
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 317);
            this.Controls.Add(this.resp);
            this.Controls.Add(this.login);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.key);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.username);
            this.Name = "LoginFrm";
            this.Text = "Wicked Admin x64 - Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox username;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox key;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton login;
        private System.Windows.Forms.Label resp;
    }
}

