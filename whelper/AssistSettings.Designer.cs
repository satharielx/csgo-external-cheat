namespace whelper
{
    partial class AssistSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssistSettings));
            this.smoothSl = new Bunifu.Framework.UI.BunifuSlider();
            this.label1 = new System.Windows.Forms.Label();
            this.currentVal = new System.Windows.Forms.Label();
            this.fovVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fovSl = new Bunifu.Framework.UI.BunifuSlider();
            this.label4 = new System.Windows.Forms.Label();
            this.boneDropdown = new Bunifu.Framework.UI.BunifuDropdown();
            this.useRecoil = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.yawVal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuSlider1 = new Bunifu.Framework.UI.BunifuSlider();
            this.label8 = new System.Windows.Forms.Label();
            this.pitchVal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bunifuSlider2 = new Bunifu.Framework.UI.BunifuSlider();
            this.label2 = new System.Windows.Forms.Label();
            this.curveYVal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bunifuSlider3 = new Bunifu.Framework.UI.BunifuSlider();
            this.curveXVal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bunifuSlider4 = new Bunifu.Framework.UI.BunifuSlider();
            this.label13 = new System.Windows.Forms.Label();
            this.useCurve = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // smoothSl
            // 
            this.smoothSl.BackColor = System.Drawing.Color.Transparent;
            this.smoothSl.BackgroudColor = System.Drawing.Color.DarkGray;
            this.smoothSl.BorderRadius = 0;
            this.smoothSl.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.smoothSl.Location = new System.Drawing.Point(115, 23);
            this.smoothSl.MaximumValue = 1000;
            this.smoothSl.Name = "smoothSl";
            this.smoothSl.Size = new System.Drawing.Size(207, 30);
            this.smoothSl.TabIndex = 0;
            this.smoothSl.Value = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Smoothness:";
            // 
            // currentVal
            // 
            this.currentVal.AutoSize = true;
            this.currentVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentVal.Location = new System.Drawing.Point(336, 27);
            this.currentVal.Name = "currentVal";
            this.currentVal.Size = new System.Drawing.Size(25, 13);
            this.currentVal.TabIndex = 2;
            this.currentVal.Text = "0.0f";
            // 
            // fovVal
            // 
            this.fovVal.AutoSize = true;
            this.fovVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fovVal.Location = new System.Drawing.Point(336, 61);
            this.fovVal.Name = "fovVal";
            this.fovVal.Size = new System.Drawing.Size(25, 13);
            this.fovVal.TabIndex = 5;
            this.fovVal.Text = "0.0f";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "FOV:";
            // 
            // fovSl
            // 
            this.fovSl.BackColor = System.Drawing.Color.Transparent;
            this.fovSl.BackgroudColor = System.Drawing.Color.DarkGray;
            this.fovSl.BorderRadius = 0;
            this.fovSl.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.fovSl.Location = new System.Drawing.Point(115, 57);
            this.fovSl.MaximumValue = 1000;
            this.fovSl.Name = "fovSl";
            this.fovSl.Size = new System.Drawing.Size(207, 30);
            this.fovSl.TabIndex = 3;
            this.fovSl.Value = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Body Part:";
            // 
            // boneDropdown
            // 
            this.boneDropdown.BackColor = System.Drawing.Color.Transparent;
            this.boneDropdown.BorderRadius = 3;
            this.boneDropdown.ForeColor = System.Drawing.Color.White;
            this.boneDropdown.Location = new System.Drawing.Point(115, 93);
            this.boneDropdown.Name = "boneDropdown";
            this.boneDropdown.NomalColor = System.Drawing.Color.Blue;
            this.boneDropdown.onHoverColor = System.Drawing.Color.Navy;
            this.boneDropdown.selectedIndex = -1;
            this.boneDropdown.Size = new System.Drawing.Size(207, 27);
            this.boneDropdown.TabIndex = 7;
            // 
            // useRecoil
            // 
            this.useRecoil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.useRecoil.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.useRecoil.Checked = true;
            this.useRecoil.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.useRecoil.ForeColor = System.Drawing.Color.White;
            this.useRecoil.Location = new System.Drawing.Point(115, 180);
            this.useRecoil.Name = "useRecoil";
            this.useRecoil.Size = new System.Drawing.Size(20, 20);
            this.useRecoil.TabIndex = 8;
            this.useRecoil.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Recoil Control:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // yawVal
            // 
            this.yawVal.AutoSize = true;
            this.yawVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.yawVal.Location = new System.Drawing.Point(334, 213);
            this.yawVal.Name = "yawVal";
            this.yawVal.Size = new System.Drawing.Size(25, 13);
            this.yawVal.TabIndex = 12;
            this.yawVal.Text = "0.0f";
            this.yawVal.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(10, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Yaw Recoil Reduce";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // bunifuSlider1
            // 
            this.bunifuSlider1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSlider1.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuSlider1.BorderRadius = 0;
            this.bunifuSlider1.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.bunifuSlider1.Location = new System.Drawing.Point(116, 206);
            this.bunifuSlider1.MaximumValue = 200;
            this.bunifuSlider1.Name = "bunifuSlider1";
            this.bunifuSlider1.Size = new System.Drawing.Size(207, 30);
            this.bunifuSlider1.TabIndex = 10;
            this.bunifuSlider1.Value = 0;
            this.bunifuSlider1.ValueChanged += new System.EventHandler(this.bunifuSlider1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(12, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "-Recoil Settings";
            // 
            // pitchVal
            // 
            this.pitchVal.AutoSize = true;
            this.pitchVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pitchVal.Location = new System.Drawing.Point(334, 249);
            this.pitchVal.Name = "pitchVal";
            this.pitchVal.Size = new System.Drawing.Size(25, 13);
            this.pitchVal.TabIndex = 16;
            this.pitchVal.Text = "0.0f";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(9, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Pitch Recoil Reduce";
            // 
            // bunifuSlider2
            // 
            this.bunifuSlider2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSlider2.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuSlider2.BorderRadius = 0;
            this.bunifuSlider2.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.bunifuSlider2.Location = new System.Drawing.Point(116, 242);
            this.bunifuSlider2.MaximumValue = 200;
            this.bunifuSlider2.Name = "bunifuSlider2";
            this.bunifuSlider2.Size = new System.Drawing.Size(207, 30);
            this.bunifuSlider2.TabIndex = 14;
            this.bunifuSlider2.Value = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "-Precision Settings";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // curveYVal
            // 
            this.curveYVal.AutoSize = true;
            this.curveYVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.curveYVal.Location = new System.Drawing.Point(334, 374);
            this.curveYVal.Name = "curveYVal";
            this.curveYVal.Size = new System.Drawing.Size(25, 13);
            this.curveYVal.TabIndex = 25;
            this.curveYVal.Text = "0.0f";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(13, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Curve Y:";
            // 
            // bunifuSlider3
            // 
            this.bunifuSlider3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSlider3.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuSlider3.BorderRadius = 0;
            this.bunifuSlider3.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.bunifuSlider3.Location = new System.Drawing.Point(116, 369);
            this.bunifuSlider3.MaximumValue = 1000;
            this.bunifuSlider3.Name = "bunifuSlider3";
            this.bunifuSlider3.Size = new System.Drawing.Size(207, 30);
            this.bunifuSlider3.TabIndex = 23;
            this.bunifuSlider3.Value = 0;
            // 
            // curveXVal
            // 
            this.curveXVal.AutoSize = true;
            this.curveXVal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.curveXVal.Location = new System.Drawing.Point(334, 346);
            this.curveXVal.Name = "curveXVal";
            this.curveXVal.Size = new System.Drawing.Size(25, 13);
            this.curveXVal.TabIndex = 22;
            this.curveXVal.Text = "0.0f";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(12, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Curve X:";
            // 
            // bunifuSlider4
            // 
            this.bunifuSlider4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSlider4.BackgroudColor = System.Drawing.Color.DarkGray;
            this.bunifuSlider4.BorderRadius = 0;
            this.bunifuSlider4.IndicatorColor = System.Drawing.Color.MediumBlue;
            this.bunifuSlider4.Location = new System.Drawing.Point(116, 339);
            this.bunifuSlider4.MaximumValue = 1000;
            this.bunifuSlider4.Name = "bunifuSlider4";
            this.bunifuSlider4.Size = new System.Drawing.Size(207, 30);
            this.bunifuSlider4.TabIndex = 20;
            this.bunifuSlider4.Value = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(12, 318);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Aim Curve:";
            // 
            // useCurve
            // 
            this.useCurve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.useCurve.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.useCurve.Checked = true;
            this.useCurve.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.useCurve.ForeColor = System.Drawing.Color.White;
            this.useCurve.Location = new System.Drawing.Point(115, 313);
            this.useCurve.Name = "useCurve";
            this.useCurve.Size = new System.Drawing.Size(20, 20);
            this.useCurve.TabIndex = 18;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.Color.Black;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "Apply";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.Black;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.Location = new System.Drawing.Point(114, 421);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(181, 54);
            this.bunifuThinButton21.TabIndex = 26;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssistSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(368, 480);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.curveYVal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bunifuSlider3);
            this.Controls.Add(this.curveXVal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bunifuSlider4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.useCurve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pitchVal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bunifuSlider2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.yawVal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bunifuSlider1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.useRecoil);
            this.Controls.Add(this.boneDropdown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fovVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fovSl);
            this.Controls.Add(this.currentVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.smoothSl);
            this.Name = "AssistSettings";
            this.Text = "Aim Assist Settings";
            this.Load += new System.EventHandler(this.AssistSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuSlider smoothSl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentVal;
        private System.Windows.Forms.Label fovVal;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuSlider fovSl;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown boneDropdown;
        private Bunifu.Framework.UI.BunifuCheckbox useRecoil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yawVal;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuSlider bunifuSlider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label pitchVal;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuSlider bunifuSlider2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label curveYVal;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuSlider bunifuSlider3;
        private System.Windows.Forms.Label curveXVal;
        private System.Windows.Forms.Label label12;
        private Bunifu.Framework.UI.BunifuSlider bunifuSlider4;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuCheckbox useCurve;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
    }
}