namespace LightBulb
{
    partial class MainForm
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
            this.btnLightBulbCtrl = new System.Windows.Forms.Button();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLightBulbCtrl
            // 
            this.btnLightBulbCtrl.Enabled = false;
            this.btnLightBulbCtrl.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.btnLightBulbCtrl.Location = new System.Drawing.Point(38, 56);
            this.btnLightBulbCtrl.Name = "btnLightBulbCtrl";
            this.btnLightBulbCtrl.Size = new System.Drawing.Size(159, 61);
            this.btnLightBulbCtrl.TabIndex = 0;
            this.btnLightBulbCtrl.Text = "Turn ON";
            this.btnLightBulbCtrl.UseVisualStyleBackColor = true;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIpAddress.ForeColor = System.Drawing.Color.Gray;
            this.lblIpAddress.Location = new System.Drawing.Point(72, 24);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(98, 19);
            this.lblIpAddress.TabIndex = 1;
            this.lblIpAddress.Text = "192.168.0.100";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(236, 147);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.btnLightBulbCtrl);
            this.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Light Bulb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLightBulbCtrl;
        private System.Windows.Forms.Label lblIpAddress;
    }
}

