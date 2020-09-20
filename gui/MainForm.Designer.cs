namespace gui
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.clientConnectionCountLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverConnectionCountLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.requestInfoSplitter = new System.Windows.Forms.SplitContainer();
            this.requestTabControl = new System.Windows.Forms.TabControl();
            this.requestTab = new System.Windows.Forms.TabPage();
            this.requestTextbox = new System.Windows.Forms.TextBox();
            this.responseTabControl = new System.Windows.Forms.TabControl();
            this.resposeTab = new System.Windows.Forms.TabPage();
            this.responseTextbox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestInfoSplitter)).BeginInit();
            this.requestInfoSplitter.Panel1.SuspendLayout();
            this.requestInfoSplitter.Panel2.SuspendLayout();
            this.requestInfoSplitter.SuspendLayout();
            this.requestTabControl.SuspendLayout();
            this.requestTab.SuspendLayout();
            this.responseTabControl.SuspendLayout();
            this.resposeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientConnectionCountLbl,
            this.serverConnectionCountLbl});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // clientConnectionCountLbl
            // 
            this.clientConnectionCountLbl.Name = "clientConnectionCountLbl";
            this.clientConnectionCountLbl.Size = new System.Drawing.Size(118, 17);
            this.clientConnectionCountLbl.Text = "Client connections: 0";
            // 
            // serverConnectionCountLbl
            // 
            this.serverConnectionCountLbl.Name = "serverConnectionCountLbl";
            this.serverConnectionCountLbl.Size = new System.Drawing.Size(119, 17);
            this.serverConnectionCountLbl.Text = "Server connections: 0";
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 0);
            this.mainSplitter.Name = "mainSplitter";
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.dataGridView);
            this.mainSplitter.Panel1MinSize = 400;
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.requestInfoSplitter);
            this.mainSplitter.Panel2MinSize = 300;
            this.mainSplitter.Size = new System.Drawing.Size(800, 428);
            this.mainSplitter.SplitterDistance = 400;
            this.mainSplitter.TabIndex = 1;
            // 
            // requestInfoSplitter
            // 
            this.requestInfoSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestInfoSplitter.Location = new System.Drawing.Point(0, 0);
            this.requestInfoSplitter.Name = "requestInfoSplitter";
            this.requestInfoSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // requestInfoSplitter.Panel1
            // 
            this.requestInfoSplitter.Panel1.Controls.Add(this.requestTabControl);
            this.requestInfoSplitter.Panel1MinSize = 180;
            // 
            // requestInfoSplitter.Panel2
            // 
            this.requestInfoSplitter.Panel2.Controls.Add(this.responseTabControl);
            this.requestInfoSplitter.Panel2MinSize = 180;
            this.requestInfoSplitter.Size = new System.Drawing.Size(396, 428);
            this.requestInfoSplitter.SplitterDistance = 180;
            this.requestInfoSplitter.TabIndex = 0;
            // 
            // requestTabControl
            // 
            this.requestTabControl.Controls.Add(this.requestTab);
            this.requestTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestTabControl.Location = new System.Drawing.Point(0, 0);
            this.requestTabControl.Name = "requestTabControl";
            this.requestTabControl.SelectedIndex = 0;
            this.requestTabControl.Size = new System.Drawing.Size(396, 180);
            this.requestTabControl.TabIndex = 0;
            // 
            // requestTab
            // 
            this.requestTab.Controls.Add(this.requestTextbox);
            this.requestTab.Location = new System.Drawing.Point(4, 22);
            this.requestTab.Name = "requestTab";
            this.requestTab.Padding = new System.Windows.Forms.Padding(3);
            this.requestTab.Size = new System.Drawing.Size(388, 154);
            this.requestTab.TabIndex = 0;
            this.requestTab.Text = "Request";
            this.requestTab.UseVisualStyleBackColor = true;
            // 
            // requestTextbox
            // 
            this.requestTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestTextbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.requestTextbox.Location = new System.Drawing.Point(3, 3);
            this.requestTextbox.Multiline = true;
            this.requestTextbox.Name = "requestTextbox";
            this.requestTextbox.ReadOnly = true;
            this.requestTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.requestTextbox.Size = new System.Drawing.Size(382, 148);
            this.requestTextbox.TabIndex = 1;
            // 
            // responseTabControl
            // 
            this.responseTabControl.Controls.Add(this.resposeTab);
            this.responseTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTabControl.Location = new System.Drawing.Point(0, 0);
            this.responseTabControl.Name = "responseTabControl";
            this.responseTabControl.SelectedIndex = 0;
            this.responseTabControl.Size = new System.Drawing.Size(396, 244);
            this.responseTabControl.TabIndex = 0;
            // 
            // resposeTab
            // 
            this.resposeTab.Controls.Add(this.responseTextbox);
            this.resposeTab.Location = new System.Drawing.Point(4, 22);
            this.resposeTab.Name = "resposeTab";
            this.resposeTab.Padding = new System.Windows.Forms.Padding(3);
            this.resposeTab.Size = new System.Drawing.Size(388, 218);
            this.resposeTab.TabIndex = 0;
            this.resposeTab.Text = "Response";
            this.resposeTab.UseVisualStyleBackColor = true;
            // 
            // responseTextbox
            // 
            this.responseTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.responseTextbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.responseTextbox.Location = new System.Drawing.Point(3, 3);
            this.responseTextbox.Multiline = true;
            this.responseTextbox.Name = "responseTextbox";
            this.responseTextbox.ReadOnly = true;
            this.responseTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.responseTextbox.Size = new System.Drawing.Size(382, 212);
            this.responseTextbox.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Result,
            this.Protocol,
            this.Host,
            this.URL,
            this.Body,
            this.Process});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(400, 428);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // Number
            // 
            this.Number.HeaderText = "#";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // Protocol
            // 
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Name = "Protocol";
            this.Protocol.ReadOnly = true;
            // 
            // Host
            // 
            this.Host.HeaderText = "Host";
            this.Host.Name = "Host";
            this.Host.ReadOnly = true;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            // 
            // Body
            // 
            this.Body.HeaderText = "Body";
            this.Body.Name = "Body";
            this.Body.ReadOnly = true;
            // 
            // Process
            // 
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main form";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.requestInfoSplitter.Panel1.ResumeLayout(false);
            this.requestInfoSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestInfoSplitter)).EndInit();
            this.requestInfoSplitter.ResumeLayout(false);
            this.requestTabControl.ResumeLayout(false);
            this.requestTab.ResumeLayout(false);
            this.requestTab.PerformLayout();
            this.responseTabControl.ResumeLayout(false);
            this.resposeTab.ResumeLayout(false);
            this.resposeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel clientConnectionCountLbl;
        private System.Windows.Forms.ToolStripStatusLabel serverConnectionCountLbl;
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer requestInfoSplitter;
        private System.Windows.Forms.TabControl requestTabControl;
        private System.Windows.Forms.TabPage requestTab;
        private System.Windows.Forms.TabControl responseTabControl;
        private System.Windows.Forms.TabPage resposeTab;
        private System.Windows.Forms.TextBox requestTextbox;
        private System.Windows.Forms.TextBox responseTextbox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Body;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
    }
}

