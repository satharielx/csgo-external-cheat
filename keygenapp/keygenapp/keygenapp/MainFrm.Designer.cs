
namespace keygenapp
{
    partial class MainFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.key = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.user = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.respkey = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.existinguser = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.ipadr = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ipadr);
            this.panel1.Controls.Add(this.materialLabel7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.key);
            this.panel1.Controls.Add(this.materialLabel3);
            this.panel1.Controls.Add(this.materialButton1);
            this.panel1.Controls.Add(this.user);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 366);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "After typing the username, press Add. \r\nSystem will display their key in the text" +
    "box below";
            // 
            // key
            // 
            this.key.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.key.Depth = 0;
            this.key.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.key.LeadingIcon = null;
            this.key.Location = new System.Drawing.Point(116, 142);
            this.key.MaxLength = 50;
            this.key.MouseState = MaterialSkin.MouseState.OUT;
            this.key.Multiline = false;
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(239, 50);
            this.key.TabIndex = 3;
            this.key.Text = "";
            this.key.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 164);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(31, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Key:";
            this.materialLabel3.Click += new System.EventHandler(this.materialLabel3_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(143, 315);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 1;
            this.materialButton1.Text = "Add";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // user
            // 
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user.Depth = 0;
            this.user.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.user.LeadingIcon = null;
            this.user.Location = new System.Drawing.Point(116, 86);
            this.user.MaxLength = 50;
            this.user.MouseState = MaterialSkin.MouseState.OUT;
            this.user.Multiline = false;
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(239, 50);
            this.user.TabIndex = 1;
            this.user.Text = "";
            this.user.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(16, 106);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(76, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Username:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(102, 13);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(163, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Add New User with Key";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.respkey);
            this.panel2.Controls.Add(this.materialLabel4);
            this.panel2.Controls.Add(this.materialButton2);
            this.panel2.Controls.Add(this.existinguser);
            this.panel2.Controls.Add(this.materialLabel5);
            this.panel2.Controls.Add(this.materialLabel6);
            this.panel2.Location = new System.Drawing.Point(404, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 366);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "After typing the username, press Change. \r\nSystem will display their new key in t" +
    "he textbox below.";
            // 
            // respkey
            // 
            this.respkey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.respkey.Depth = 0;
            this.respkey.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.respkey.LeadingIcon = null;
            this.respkey.Location = new System.Drawing.Point(116, 142);
            this.respkey.MaxLength = 50;
            this.respkey.MouseState = MaterialSkin.MouseState.OUT;
            this.respkey.Multiline = false;
            this.respkey.Name = "respkey";
            this.respkey.Size = new System.Drawing.Size(239, 50);
            this.respkey.TabIndex = 3;
            this.respkey.Text = "";
            this.respkey.TrailingIcon = null;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(16, 164);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(31, 19);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "Key:";
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(161, 244);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.Size = new System.Drawing.Size(80, 36);
            this.materialButton2.TabIndex = 1;
            this.materialButton2.Text = "Change";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // existinguser
            // 
            this.existinguser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.existinguser.Depth = 0;
            this.existinguser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.existinguser.LeadingIcon = null;
            this.existinguser.Location = new System.Drawing.Point(116, 86);
            this.existinguser.MaxLength = 50;
            this.existinguser.MouseState = MaterialSkin.MouseState.OUT;
            this.existinguser.Multiline = false;
            this.existinguser.Name = "existinguser";
            this.existinguser.Size = new System.Drawing.Size(239, 50);
            this.existinguser.TabIndex = 1;
            this.existinguser.Text = "";
            this.existinguser.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(16, 106);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(76, 19);
            this.materialLabel5.TabIndex = 1;
            this.materialLabel5.Text = "Username:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(127, 13);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(128, 19);
            this.materialLabel6.TabIndex = 1;
            this.materialLabel6.Text = "Change user\'s key";
            // 
            // ipadr
            // 
            this.ipadr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipadr.Depth = 0;
            this.ipadr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ipadr.LeadingIcon = null;
            this.ipadr.Location = new System.Drawing.Point(116, 208);
            this.ipadr.MaxLength = 50;
            this.ipadr.MouseState = MaterialSkin.MouseState.OUT;
            this.ipadr.Multiline = false;
            this.ipadr.Name = "ipadr";
            this.ipadr.Size = new System.Drawing.Size(239, 50);
            this.ipadr.TabIndex = 6;
            this.ipadr.Text = "";
            this.ipadr.TrailingIcon = null;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(16, 230);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(80, 19);
            this.materialLabel7.TabIndex = 5;
            this.materialLabel7.Text = "IP Address:";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainFrm";
            this.Text = "Wicked Empress Admin x64";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox user;
        private MaterialSkin.Controls.MaterialTextBox key;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTextBox respkey;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox existinguser;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox ipadr;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
    }
}