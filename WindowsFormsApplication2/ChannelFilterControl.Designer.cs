namespace WindowsFormsApplication2
{
    partial class ChannelFilterControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelFilterControl));
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar3 = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar2 = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.Chartreuse;
            this.metroButton2.Location = new System.Drawing.Point(272, 146);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(102, 23);
            this.metroButton2.TabIndex = 17;
            this.metroButton2.Text = "Accept";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Magenta;
            this.metroButton1.Location = new System.Drawing.Point(164, 146);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(102, 23);
            this.metroButton1.TabIndex = 16;
            this.metroButton1.Text = "Cancel";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(22, 121);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(85, 19);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Blue Channel";
            // 
            // metroTrackBar3
            // 
            this.metroTrackBar3.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar3.Location = new System.Drawing.Point(167, 121);
            this.metroTrackBar3.Maximum = 255;
            this.metroTrackBar3.Name = "metroTrackBar3";
            this.metroTrackBar3.Size = new System.Drawing.Size(207, 19);
            this.metroTrackBar3.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTrackBar3.TabIndex = 14;
            this.metroTrackBar3.Text = "metroTrackBar3";
            this.metroTrackBar3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar3.UseCustomBackColor = true;
            this.metroTrackBar3.Value = 0;
            this.metroTrackBar3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar3_Scroll);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 92);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(95, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Green Channel";
            // 
            // metroTrackBar2
            // 
            this.metroTrackBar2.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar2.Location = new System.Drawing.Point(167, 92);
            this.metroTrackBar2.Maximum = 255;
            this.metroTrackBar2.Name = "metroTrackBar2";
            this.metroTrackBar2.Size = new System.Drawing.Size(207, 19);
            this.metroTrackBar2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTrackBar2.TabIndex = 12;
            this.metroTrackBar2.Text = "metroTrackBar2";
            this.metroTrackBar2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar2.UseCustomBackColor = true;
            this.metroTrackBar2.Value = 0;
            this.metroTrackBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar2_Scroll);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Red Channel";
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(167, 63);
            this.metroTrackBar1.Maximum = 255;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(207, 19);
            this.metroTrackBar1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTrackBar1.TabIndex = 10;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTrackBar1.UseCustomBackColor = true;
            this.metroTrackBar1.Value = 0;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // ChannelFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 182);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroTrackBar3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTrackBar2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTrackBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChannelFilterControl";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Color Channel";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.ChannelFilterControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
    }
}