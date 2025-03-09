namespace Chief
{
    partial class OutDocs
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tcOutMode = new System.Windows.Forms.TabControl();
            this.tpPrepare = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvForMailDocs = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.создатьИсходящийДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpListing = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tvSendOutDocument = new System.Windows.Forms.TreeView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pDFФорматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIsendToJob = new System.Windows.Forms.ToolStripMenuItem();
            this.tcOutMode.SuspendLayout();
            this.tpPrepare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tpListing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tcOutMode
            // 
            this.tcOutMode.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcOutMode.Controls.Add(this.tpPrepare);
            this.tcOutMode.Controls.Add(this.tpListing);
            this.tcOutMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOutMode.Location = new System.Drawing.Point(0, 25);
            this.tcOutMode.Name = "tcOutMode";
            this.tcOutMode.SelectedIndex = 0;
            this.tcOutMode.Size = new System.Drawing.Size(881, 558);
            this.tcOutMode.TabIndex = 1;
            this.tcOutMode.SelectedIndexChanged += new System.EventHandler(this.tcOutMode_SelectedIndexChanged);
            // 
            // tpPrepare
            // 
            this.tpPrepare.Controls.Add(this.splitContainer3);
            this.tpPrepare.Location = new System.Drawing.Point(4, 4);
            this.tpPrepare.Name = "tpPrepare";
            this.tpPrepare.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpPrepare.Size = new System.Drawing.Size(873, 532);
            this.tpPrepare.TabIndex = 0;
            this.tpPrepare.Text = "Подготовка исходящей корреспонденции";
            this.tpPrepare.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvForMailDocs);
            this.splitContainer3.Size = new System.Drawing.Size(867, 526);
            this.splitContainer3.SplitterDistance = 288;
            this.splitContainer3.TabIndex = 0;
            // 
            // tvForMailDocs
            // 
            this.tvForMailDocs.ContextMenuStrip = this.contextMenuStrip1;
            this.tvForMailDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvForMailDocs.Location = new System.Drawing.Point(0, 0);
            this.tvForMailDocs.Name = "tvForMailDocs";
            this.tvForMailDocs.Size = new System.Drawing.Size(288, 526);
            this.tvForMailDocs.TabIndex = 0;
            this.tvForMailDocs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvForMailDocs_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьИсходящийДокументToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(239, 48);
            // 
            // создатьИсходящийДокументToolStripMenuItem
            // 
            this.создатьИсходящийДокументToolStripMenuItem.Name = "создатьИсходящийДокументToolStripMenuItem";
            this.создатьИсходящийДокументToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.создатьИсходящийДокументToolStripMenuItem.Text = "Создать исходящий документ";
            this.создатьИсходящийДокументToolStripMenuItem.Click += new System.EventHandler(this.создатьИсходящийДокументToolStripMenuItem_Click);
            // 
            // tpListing
            // 
            this.tpListing.Controls.Add(this.splitContainer4);
            this.tpListing.Location = new System.Drawing.Point(4, 4);
            this.tpListing.Name = "tpListing";
            this.tpListing.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpListing.Size = new System.Drawing.Size(873, 537);
            this.tpListing.TabIndex = 1;
            this.tpListing.Text = "Рассылка исходящей корреспонденции";
            this.tpListing.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tvSendOutDocument);
            this.splitContainer4.Size = new System.Drawing.Size(867, 531);
            this.splitContainer4.SplitterDistance = 216;
            this.splitContainer4.TabIndex = 0;
            // 
            // tvSendOutDocument
            // 
            this.tvSendOutDocument.ContextMenuStrip = this.contextMenuStrip2;
            this.tvSendOutDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSendOutDocument.Location = new System.Drawing.Point(0, 0);
            this.tvSendOutDocument.Name = "tvSendOutDocument";
            this.tvSendOutDocument.Size = new System.Drawing.Size(216, 531);
            this.tvSendOutDocument.TabIndex = 0;
            this.tvSendOutDocument.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSendOutDocument_AfterSelect);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFФорматToolStripMenuItem,
            this.TSMIsendToJob});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(184, 48);
            // 
            // pDFФорматToolStripMenuItem
            // 
            this.pDFФорматToolStripMenuItem.Name = "pDFФорматToolStripMenuItem";
            this.pDFФорматToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pDFФорматToolStripMenuItem.Text = "PDF формат";
            this.pDFФорматToolStripMenuItem.Visible = false;
            this.pDFФорматToolStripMenuItem.Click += new System.EventHandler(this.pDFФорматToolStripMenuItem_Click);
            // 
            // TSMIsendToJob
            // 
            this.TSMIsendToJob.Name = "TSMIsendToJob";
            this.TSMIsendToJob.Size = new System.Drawing.Size(183, 22);
            this.TSMIsendToJob.Text = "Направить в работу";
            // 
            // OutDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 583);
            this.Controls.Add(this.tcOutMode);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OutDocs";
            this.Text = "Исходящая корреспонденция";
            this.tcOutMode.ResumeLayout(false);
            this.tpPrepare.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpListing.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tcOutMode;
        private System.Windows.Forms.TabPage tpPrepare;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView tvForMailDocs;
        private System.Windows.Forms.TabPage tpListing;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView tvSendOutDocument;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem создатьИсходящийДокументToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem pDFФорматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMIsendToJob;
    }
}