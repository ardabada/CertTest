namespace gui
{
    partial class LoadingForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.internalSetupLbl = new gui.StatusLabel();
            this.certRemoveLbl = new gui.StatusLabel();
            this.proxyStopLbl = new gui.StatusLabel();
            this.listenLbl = new gui.StatusLabel();
            this.startProxyLbl = new gui.StatusLabel();
            this.certLabel = new gui.StatusLabel();
            this.detourLabel = new gui.StatusLabel();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 110);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(420, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // internalSetupLbl
            // 
            this.internalSetupLbl.AutoSize = true;
            this.internalSetupLbl.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.internalSetupLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.internalSetupLbl.ForeColor = System.Drawing.Color.Gray;
            this.internalSetupLbl.Location = new System.Drawing.Point(12, 9);
            this.internalSetupLbl.Name = "internalSetupLbl";
            this.internalSetupLbl.Size = new System.Drawing.Size(105, 14);
            this.internalSetupLbl.TabIndex = 7;
            this.internalSetupLbl.Text = "Internal setup";
            // 
            // certRemoveLbl
            // 
            this.certRemoveLbl.AutoSize = true;
            this.certRemoveLbl.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.certRemoveLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.certRemoveLbl.ForeColor = System.Drawing.Color.Gray;
            this.certRemoveLbl.Location = new System.Drawing.Point(12, 93);
            this.certRemoveLbl.Name = "certRemoveLbl";
            this.certRemoveLbl.Size = new System.Drawing.Size(140, 14);
            this.certRemoveLbl.TabIndex = 6;
            this.certRemoveLbl.Text = "Remove certificates";
            // 
            // proxyStopLbl
            // 
            this.proxyStopLbl.AutoSize = true;
            this.proxyStopLbl.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.proxyStopLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.proxyStopLbl.ForeColor = System.Drawing.Color.Gray;
            this.proxyStopLbl.Location = new System.Drawing.Point(12, 79);
            this.proxyStopLbl.Name = "proxyStopLbl";
            this.proxyStopLbl.Size = new System.Drawing.Size(77, 14);
            this.proxyStopLbl.TabIndex = 5;
            this.proxyStopLbl.Text = "Stop proxy";
            // 
            // listenLbl
            // 
            this.listenLbl.AutoSize = true;
            this.listenLbl.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.listenLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.listenLbl.ForeColor = System.Drawing.Color.Gray;
            this.listenLbl.Location = new System.Drawing.Point(12, 65);
            this.listenLbl.Name = "listenLbl";
            this.listenLbl.Size = new System.Drawing.Size(49, 14);
            this.listenLbl.TabIndex = 4;
            this.listenLbl.Text = "Listen";
            // 
            // startProxyLbl
            // 
            this.startProxyLbl.AutoSize = true;
            this.startProxyLbl.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.startProxyLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.startProxyLbl.ForeColor = System.Drawing.Color.Gray;
            this.startProxyLbl.Location = new System.Drawing.Point(12, 51);
            this.startProxyLbl.Name = "startProxyLbl";
            this.startProxyLbl.Size = new System.Drawing.Size(84, 14);
            this.startProxyLbl.TabIndex = 3;
            this.startProxyLbl.Text = "Start proxy";
            // 
            // certLabel
            // 
            this.certLabel.AutoSize = true;
            this.certLabel.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.certLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.certLabel.ForeColor = System.Drawing.Color.Gray;
            this.certLabel.Location = new System.Drawing.Point(12, 37);
            this.certLabel.Name = "certLabel";
            this.certLabel.Size = new System.Drawing.Size(147, 14);
            this.certLabel.TabIndex = 2;
            this.certLabel.Text = "Install certificates";
            // 
            // detourLabel
            // 
            this.detourLabel.AutoSize = true;
            this.detourLabel.CurrentStatus = gui.StatusLabel.Status.Disabled;
            this.detourLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.detourLabel.ForeColor = System.Drawing.Color.Gray;
            this.detourLabel.Location = new System.Drawing.Point(12, 23);
            this.detourLabel.Name = "detourLabel";
            this.detourLabel.Size = new System.Drawing.Size(98, 14);
            this.detourLabel.TabIndex = 1;
            this.detourLabel.Text = "Inject detour";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 143);
            this.ControlBox = false;
            this.Controls.Add(this.internalSetupLbl);
            this.Controls.Add(this.certRemoveLbl);
            this.Controls.Add(this.proxyStopLbl);
            this.Controls.Add(this.listenLbl);
            this.Controls.Add(this.startProxyLbl);
            this.Controls.Add(this.certLabel);
            this.Controls.Add(this.detourLabel);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingForm_FormClosing);
            this.Shown += new System.EventHandler(this.LoadingForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private StatusLabel detourLabel;
        private StatusLabel certLabel;
        private StatusLabel startProxyLbl;
        private StatusLabel listenLbl;
        private StatusLabel proxyStopLbl;
        private StatusLabel certRemoveLbl;
        private StatusLabel internalSetupLbl;
    }
}