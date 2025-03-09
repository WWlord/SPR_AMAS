namespace AMASControlRegisters
{
    partial class UCDocsTree
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDocsTree));
            this.imageListFolders = new System.Windows.Forms.ImageList(this.components);
            this.toolStripDocTree = new System.Windows.Forms.ToolStrip();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbAnswer = new System.Windows.Forms.ToolStripButton();
            this.tsbNewDoc = new System.Windows.Forms.ToolStripButton();
            this.treeViewDocs = new System.Windows.Forms.TreeView();
            this.panelStructure = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.treeViewStructure = new System.Windows.Forms.TreeView();
            this.contextMenuStripDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCalendar = new System.Windows.Forms.ToolStripComboBox();
            this.FuelBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbComment = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripDocTree.SuspendLayout();
            this.panelStructure.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripDocs.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListFolders
            // 
            this.imageListFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFolders.ImageStream")));
            this.imageListFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFolders.Images.SetKeyName(0, "Book_Green");
            this.imageListFolders.Images.SetKeyName(1, "112_Tick_Grey");
            this.imageListFolders.Images.SetKeyName(2, "Reminder");
            this.imageListFolders.Images.SetKeyName(3, "clock");
            this.imageListFolders.Images.SetKeyName(4, "envelope");
            this.imageListFolders.Images.SetKeyName(5, "Flag_Yellow");
            this.imageListFolders.Images.SetKeyName(6, "Lightbulb");
            this.imageListFolders.Images.SetKeyName(7, "Favorites");
            this.imageListFolders.Images.SetKeyName(8, "Folder_Back");
            this.imageListFolders.Images.SetKeyName(9, "Folder_stuffed");
            this.imageListFolders.Images.SetKeyName(10, "Task");
            this.imageListFolders.Images.SetKeyName(11, "SecurityLock");
            this.imageListFolders.Images.SetKeyName(12, "icons8-документ-16.png");
            this.imageListFolders.Images.SetKeyName(13, "icons8-редактировать-32.png");
            this.imageListFolders.Images.SetKeyName(14, "SingleMessage.ico");
            // 
            // toolStripDocTree
            // 
            this.toolStripDocTree.BackColor = System.Drawing.Color.MidnightBlue;
            this.toolStripDocTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExecute,
            this.tsbAnswer,
            this.tsbNewDoc,
            this.FuelBar});
            this.toolStripDocTree.Location = new System.Drawing.Point(0, 0);
            this.toolStripDocTree.Name = "toolStripDocTree";
            this.toolStripDocTree.Size = new System.Drawing.Size(535, 25);
            this.toolStripDocTree.TabIndex = 2;
            // 
            // tsbExecute
            // 
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExecute.Image = global::AMASControlRegisters.Properties.Resources.Utility_VBScript;
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(23, 22);
            this.tsbExecute.Text = " На исполнение";
            this.tsbExecute.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // tsbAnswer
            // 
            this.tsbAnswer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnswer.Image = global::AMASControlRegisters.Properties.Resources.CLIP07;
            this.tsbAnswer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnswer.Name = "tsbAnswer";
            this.tsbAnswer.Size = new System.Drawing.Size(23, 22);
            this.tsbAnswer.Text = "Ответить";
            this.tsbAnswer.Click += new System.EventHandler(this.tsbAnswer_Click);
            // 
            // tsbNewDoc
            // 
            this.tsbNewDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewDoc.Image = global::AMASControlRegisters.Properties.Resources.PLUS;
            this.tsbNewDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewDoc.Name = "tsbNewDoc";
            this.tsbNewDoc.Size = new System.Drawing.Size(23, 22);
            this.tsbNewDoc.Text = "Новый документ";
            this.tsbNewDoc.Click += new System.EventHandler(this.tsbNewDoc_Click);
            // 
            // treeViewDocs
            // 
            this.treeViewDocs.BackColor = System.Drawing.Color.LightSteelBlue;
            this.treeViewDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDocs.ImageIndex = 0;
            this.treeViewDocs.ImageList = this.imageListFolders;
            this.treeViewDocs.Location = new System.Drawing.Point(0, 25);
            this.treeViewDocs.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewDocs.Name = "treeViewDocs";
            this.treeViewDocs.SelectedImageIndex = 5;
            this.treeViewDocs.Size = new System.Drawing.Size(535, 311);
            this.treeViewDocs.TabIndex = 4;
            // 
            // panelStructure
            // 
            this.panelStructure.Controls.Add(this.toolStrip1);
            this.panelStructure.Controls.Add(this.treeViewStructure);
            this.panelStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStructure.Location = new System.Drawing.Point(0, 25);
            this.panelStructure.Margin = new System.Windows.Forms.Padding(2);
            this.panelStructure.Name = "panelStructure";
            this.panelStructure.Size = new System.Drawing.Size(535, 311);
            this.panelStructure.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.tsbCalendar,
            this.tsbComment});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(535, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AMASControlRegisters.Properties.Resources.SingleMessage;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Назначить";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::AMASControlRegisters.Properties.Resources.icons8_редактировать_32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::AMASControlRegisters.Properties.Resources.icons8_документ_16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // treeViewStructure
            // 
            this.treeViewStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewStructure.Location = new System.Drawing.Point(0, 0);
            this.treeViewStructure.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewStructure.Name = "treeViewStructure";
            this.treeViewStructure.Size = new System.Drawing.Size(535, 311);
            this.treeViewStructure.TabIndex = 6;
            this.treeViewStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewStructure_AfterSelect);
            // 
            // contextMenuStripDocs
            // 
            this.contextMenuStripDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem});
            this.contextMenuStripDocs.Name = "contextMenuStripDocs";
            this.contextMenuStripDocs.Size = new System.Drawing.Size(129, 26);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.RefreshToolStripMenuItem.Text = "Обновить";
            // 
            // tsbCalendar
            // 
            this.tsbCalendar.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.tsbCalendar.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.tsbCalendar.Name = "tsbCalendar";
            this.tsbCalendar.Size = new System.Drawing.Size(75, 25);
            // 
            // FuelBar
            // 
            this.FuelBar.Name = "FuelBar";
            this.FuelBar.Size = new System.Drawing.Size(100, 22);
            // 
            // tsbComment
            // 
            this.tsbComment.AutoSize = false;
            this.tsbComment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbComment.Name = "tsbComment";
            this.tsbComment.Size = new System.Drawing.Size(196, 23);
            // 
            // UCDocsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStructure);
            this.Controls.Add(this.treeViewDocs);
            this.Controls.Add(this.toolStripDocTree);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCDocsTree";
            this.Size = new System.Drawing.Size(535, 336);
            this.toolStripDocTree.ResumeLayout(false);
            this.toolStripDocTree.PerformLayout();
            this.panelStructure.ResumeLayout(false);
            this.panelStructure.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripDocs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageListFolders;
        private System.Windows.Forms.ToolStrip toolStripDocTree;
        private System.Windows.Forms.ToolStripButton tsbAnswer;
        private System.Windows.Forms.ToolStripButton tsbNewDoc;
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.TreeView treeViewDocs;
        private System.Windows.Forms.Panel panelStructure;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TreeView treeViewStructure;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDocs;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripProgressBar FuelBar;
        private System.Windows.Forms.ToolStripComboBox tsbCalendar;
        private System.Windows.Forms.ToolStripTextBox tsbComment;
    }
}
