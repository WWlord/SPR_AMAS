using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMAS_DBI;
using ClassPattern;

namespace AMASControlRegisters
{
    public partial class UCNewDocument : UserControl
    {

        private int a_width;
        private int a_heiht;

        //private System.Windows.Forms.GroupBox gbCommom; 
        private Label label1;
        private Label label2;
        private ComboBox cbTemy;
        private ComboBox cbKinds;

        private Address_ids KindBox;
        private Address_ids TemaBox;

        private Class_syb_acc SYB_acc;
        private Document_Viewer document_New;
        private int parentDoc;
        bool eriseDoc = false;
        public int DocId=0;

        private bool From_pattern = false;

        public UCNewDocument(Class_syb_acc Acc, Document_Viewer docum,int parentId, bool killDoc)
        {
            InitializeComponent();

            document_New = docum;
            SYB_acc = Acc;
            parentDoc = parentId;
            eriseDoc = killDoc;
            a_width=this.Width;
            a_heiht = this.Height;

            // 
            // label2
            // 
            this.label2 = new Label
            {
                AutoSize = true,
                Location = new Point(37, 60),
                Margin = new Padding(4, 0, 4, 0),
                Name = "label2",
                Size = new Size(42, 17),
                TabIndex = 7,
                Text = "Тема",
                TextAlign = System.Drawing.ContentAlignment.TopRight
            };
            // 
            // label1
            // 
            this.label1 = new Label
            {
                AutoSize = true,
                Location = new Point(5, 27),
                Margin = new Padding(4, 0, 4, 0),
                Name = "label1",
                Size = new Size(73, 17),
                TabIndex = 6,
                Text = "Документ",
                TextAlign = System.Drawing.ContentAlignment.TopRight
            };

            // 
            // cbTemy
            // 
            this.cbTemy = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(96, 57),
                Margin = new Padding(4),
                Name = "cbTemy",
                Size = new Size(213, 24),
                TabIndex = 5
            };
            // 
            // cbKinds
            // 
            this.cbKinds = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(96, 23),
                Margin = new Padding(4),
                Name = "cbKinds",
                Size = new Size(213, 24),
                TabIndex = 4
            };

            this.panelKIndTema.Controls.Add(this.label2);
            this.panelKIndTema.Controls.Add(this.label1);
            this.panelKIndTema.Controls.Add(this.cbTemy);
            this.panelKIndTema.Controls.Add(this.cbKinds);

            KindBox = new Address_ids(cbKinds);
            TemaBox = new Address_ids(cbTemy);
            KindBox.connect(SYB_acc);
            TemaBox.connect(SYB_acc);
            KindBox.Select_Subject(AMAS_Query.Class_AMAS_Query.Wflow_kinds(), "kind", "kod");
            TemaBox.Select_Subject(AMAS_Query.Class_AMAS_Query.Wflow_temy(KindBox.get_ident()), "description_", "tema");
            cbKinds.SelectedIndexChanged += new EventHandler(cbKinds_SelectedIndexChanged);
            this.Resize += new EventHandler(UCNewDocument_Resize);
        }

        void cbKinds_SelectedIndexChanged(object sender, EventArgs e)
        {
            TemaBox.Select_Subject(AMAS_Query.Class_AMAS_Query.Wflow_temy(KindBox.get_ident()), "description_", "tema");
        }

        void UCNewDocument_Resize(object sender, EventArgs e)
        {
            if (this.Width < a_width) this.Width = a_width;
            if (this.Height < a_heiht) this.Height = a_heiht;
        }

        public void answer(string cod)
        {
            tbxmetadata.Text = cod;
        }

        private void btnPattern_Click(object sender, EventArgs e)
        {
            DocumentProcessing DoPr = new DocumentProcessing(SYB_acc, document_New);
            DoPr.AddDot(KindBox.get_ident(), TemaBox.get_ident());
            From_pattern = true;
        }

        private void buaatonAddFile_Click(object sender, EventArgs e)
        {
            document_New.File_Append();
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            document_New.File_Delete();
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            document_New.Editor_append();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {            
            this.SendToBack();
            this.Visible = false;
            if (eriseDoc)
            {
                document_New.Parent.Controls.Remove(document_New);
                document_New.Visible = false;
            }
            else if (DocId > 0)
            {
                document_New.Edit_document = false;
                document_New.New_document = false;
                document_New.Doc_ID = DocId;
            }
            this.Parent.Controls.Remove(this);
        }

        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
           if (document_New != null)
            {
                int document = AMAS_DBI.AMASCommand.Append_Indoor_document(KindBox.get_ident(), TemaBox.get_ident(), document_New.Annotation, parentDoc, From_pattern);
                if (document > 0)
                {
                    document_New.SaveDocument(document);
                    AMASCommand.AnswerDocument(document, document_New.Sender);
                }
                document_New.New_document = true;
                document_New.Doc_ID = 0;
                From_pattern = false;
            }

        }
    }
}
