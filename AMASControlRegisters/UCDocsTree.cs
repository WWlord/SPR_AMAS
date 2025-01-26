using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AMAS_Query;
using AMAS_DBI;
using ClassStructure;

namespace AMASControlRegisters
{
    public partial class UCDocsTree : UserControl
    {
        private Class_syb_acc SybAcc;
        const int MAX_TREE_Fall = 5; //20;
        private int year = 0;
        private int month = 0;
        private int day = 0;
        DocTipGrow DTG = null;
        private Document_Viewer ShowDocument;
        private Structure A_Struct;
        private int DocID = 0;
        public UCDocsTree(Class_syb_acc Acc, Document_Viewer DocView)
        {
            InitializeComponent();

            SybAcc = Acc;

            treeViewDocs.Nodes.Add("Current", "Очередные документы", "Folder_stuffed");
            treeViewDocs.Nodes.Add("Executed", "Исполненные документы", "Folder_stuffed");
            treeViewDocs.Nodes.Add("Sended", "Назначенные документы", "Folder_stuffed");
            //treeViewDocs.Nodes.Add("New", "Новые документы", "Folder_stuffed");
            treeViewDocs.Nodes.Add("Own", "Свои документы", "Folder_stuffed");
            treeViewDocs.AfterSelect += new TreeViewEventHandler(treeViewDocs_AfterSelect);

            treeViewDocs.ContextMenuStrip = contextMenuStripDocs;

            DTG = new DocTipGrow(MAX_TREE_Fall);

            ShowDocument = DocView;

            DocID = ShowDocument.Doc_ID;

            A_Struct = new Structure(SybAcc, treeViewStructure, true, true)
            {
                Show_Empl = true
            };
            treeViewStructure.BringToFront();
            treeViewStructure.Dock = DockStyle.Fill;
            treeViewStructure.CheckBoxes = true;

            panelStructure.SendToBack();

            contextMenuStripDocs.ItemClicked += ContextMenuStripDocs_ItemClicked;
        }

        private void ContextMenuStripDocs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "RefreshToolStripMenuItem":
                        Grow_Folders(treeViewDocs.SelectedNode.Name.Trim(), treeViewDocs.SelectedNode);  // e.Node.Name.Trim(), e.Node);
                        break;
                }
            }
            catch { }
        }

        void treeViewDocs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Grow_Folders(e.Node.Name.Trim(), e.Node);
            DocID = ShowDocument.Doc_ID;
        }

        public void Grow_Folders(string Crone, TreeNode DocNod)
        {
            int Count_fall = 0;
            day = 0;
            month = 0;
            year = 0;
            try
            {
                foreach (TreeNode nd in DocNod.Nodes)
                    nd.Remove();
                switch (Crone.Substring(2, 1))
                {
                    case "y":
                    case "Y":
                        year = (int)Convert.ToInt32(DocNod.Name.Substring(3, 4)); //DocNod.Name.Length - 3));
                        break;
                    case "m":
                    case "M":
                        month = (int)Convert.ToInt32(DocNod.Name.Substring(3, 2)); //DocNod.Name.Length - 3));
                        year = (int)Convert.ToInt32(DocNod.Name.Substring(5, 4));  // DocNod.Name.Length - 3);  
                        break;
                    case "d":
                    case "D":
                        day = (int)Convert.ToInt32(DocNod.Name.Substring(3, 2)); //DocNod.Name.Length - 3));
                        month = (int)Convert.ToInt32(DocNod.Name.Substring(5, 2)); //DocNod.Name.Length - 3));
                        year = (int)Convert.ToInt32(DocNod.Name.Substring(7, 4));  // DocNod.Name.Length - 3);  
                        break;
                }
            }
            catch { }

            Crone = ThePrefix(Crone);

            switch (Crone.ToLower())
            {
                case "cta":
                    Count_fall = CountDocsInFolder(DTG.YearsCountCurrentmoving()) + CountDocsInFolder(DTG.YearsCountCurrentvizing()) + CountDocsInFolder(DTG.YearsCountCurrentnews());
                    break;
                case "eda":
                    Count_fall = CountDocsInFolder(DTG.YearsCountExecutedmoving()) + CountDocsInFolder(DTG.YearsCountExecutedvizing()) + CountDocsInFolder(DTG.YearsCountExecutednews());
                    break;
                case "sda":
                    Count_fall = CountDocsInFolder(DTG.YearsCountSendedmoving()) + CountDocsInFolder(DTG.YearsCountSendedvizing()) + CountDocsInFolder(DTG.YearsCountSendednews());
                    break;
                case "nwa":
                    Count_fall = CountDocsInFolder(DTG.YearsCountNew());
                    break;
                case "owa":
                    Count_fall = CountDocsInFolder(DTG.YearsCountOwn());
                    break;
                case "cty":
                    Count_fall = CountDocsInFolder(DTG.MoonthCountCurrentmoving(year)) + CountDocsInFolder(DTG.MoonthCountCurrentvizing(year)) + CountDocsInFolder(DTG.MoonthCountCurrentnews(year));
                    break;
                case "edy":
                    Count_fall = CountDocsInFolder(DTG.MoonthCountExecutedmoving(year)) + CountDocsInFolder(DTG.MoonthCountExecutedvizing(year)) + CountDocsInFolder(DTG.MoonthCountExecutednews(year));
                    break;
                case "sdy":
                    Count_fall = CountDocsInFolder(DTG.MoonthCountSendedmoving(year)) + CountDocsInFolder(DTG.MoonthCountSendedvizing(year)) + CountDocsInFolder(DTG.MoonthCountSendednews(year));
                    break;
                case "nwy":
                    Count_fall = CountDocsInFolder(DTG.MoonthCountNew(year));
                    break;
                case "owy":
                    Count_fall = CountDocsInFolder(DTG.MoonthCountOwn(year));
                    break;
                case "ctm":
                    Count_fall = CountDocsInFolder(DTG.DayCountCurrentmoving(year, month)) + CountDocsInFolder(DTG.DayCountCurrentvizing(year, month)) + CountDocsInFolder(DTG.DayCountCurrentnews(year, month));
                    break;
                case "edm":
                    Count_fall = CountDocsInFolder(DTG.DayCountExecutedmoving(year, month)) + CountDocsInFolder(DTG.DayCountExecutedvizing(year, month)) + CountDocsInFolder(DTG.DayCountExecutednews(year, month));
                    break;
                case "sdm":
                    Count_fall = CountDocsInFolder(DTG.DayCountSendedmoving(year, month)) + CountDocsInFolder(DTG.DayCountSendedvizing(year, month)) + CountDocsInFolder(DTG.DayCountSendednews(year, month));
                    break;
                case "nwm":
                    Count_fall = CountDocsInFolder(DTG.DayCountNew(year, month));
                    break;
                case "owm":
                    Count_fall = CountDocsInFolder(DTG.DayCountOwn(year, month));
                    break;
            }


            if (Count_fall > MAX_TREE_Fall)
            {

                switch (Crone.ToLower())
                {
                    case "cta":
                        DocsYearList(DTG.YearsCurrentmovingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsCurrentvizingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsCurrentnewsID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        break;
                    case "eda":
                        DocsYearList(DTG.YearsExecutedmovingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsExecutedvizingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsExecutednewsID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        break;
                    case "sda":
                        DocsYearList(DTG.YearsSendedmovingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsSendedvizingID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        DocsYearList(DTG.YearsSendednewsID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        break;
                    case "nwa":
                        DocsYearList(DTG.YearsNewID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        break;
                    case "owa":
                        DocsYearList(DTG.YearsOwnID(), Crone.Substring(0, 2) + "y", DocNod, 0);
                        break;
                    case "cty":
                        DocsMonthList(DTG.MoonthCurrentmovingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthCurrentvizingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthCurrentnewsID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        break;
                    case "edy":
                        DocsMonthList(DTG.MoonthExecutedmovingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthExecutedvizingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthExecutednewsID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        break;
                    case "sdy":
                        DocsMonthList(DTG.MoonthSendedmovingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthSendedvizingID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        DocsMonthList(DTG.MoonthSendednewsID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        break;
                    case "nwy":
                        DocsMonthList(DTG.MoonthNewID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        break;
                    case "owy":
                        DocsMonthList(DTG.MoonthOwnID(year), Crone.Substring(0, 2) + "m", DocNod, 0);
                        break;
                    case "ctm":
                        DocsDayList(DTG.DayCurrentmovingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        DocsDayList(DTG.DayCurrentvizingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        DocsDayList(DTG.DayCurrentnewsID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        break;
                    case "edm":
                        DocsDayList(DTG.DayExecutedmovingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0); //DTG.DayCountExecutedmoving
                        DocsDayList(DTG.DayExecutedvizingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0); //DTG.DayCountExecutedvizing
                        DocsDayList(DTG.DayExecutednewsID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0); //DTG.DayCountExecutednews
                        break;
                    case "sdm":
                        DocsDayList(DTG.DaySendedmovingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        DocsDayList(DTG.DaySendedvizingID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        DocsDayList(DTG.DaySendednewsID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        break;
                    case "nwm":
                        DocsDayList(DTG.DayNewID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        break;
                    case "owm":
                        DocsDayList(DTG.DayOwnID(year, month), Crone.Substring(0, 2) + "d", DocNod, 0);
                        break;
                    case "nwd":
                    case "ctd":
                    case "edd":
                    case "sdd":
                        Fill_Tree(DocNod);
                        break;
                    case "nwf":
                    case "ctf":
                    case "edf":
                    case "sdf":
                        ShowDocument.Doc_ID = Convert.ToInt32(DocNod.Name.Substring(3));
                        break;
                }
            }
            else if (Crone.Substring(2, 1).CompareTo("f") == 0) ShowDocument.Doc_ID = Convert.ToInt32(DocNod.Name.Substring(3));
            else Fill_Tree(DocNod);
        }

        private string ThePrefix(string Crone)
        {
            switch (Crone)
            {
                case "Current":
                    Crone = "cta";
                    break;
                case "Executed":
                    Crone = "eda";
                    break;
                case "Sended":
                    Crone = "sda";
                    break;
                case "New":
                    Crone = "nwa";
                    break;
                case "Own":
                    Crone = "owa";
                    break;
                default:
                    Crone = Crone.Substring(0, 3);
                    break;
            }
            return Crone;
        }

        private void DocsYearList(string sql, string cron, TreeNode DocNod, int Docimage)
        {
            string nodName = "";
            TreeNode[] AlianNodes;
            TreeNode ItsNode;

            if (SybAcc.Set_table("TCSDocs5", sql, null))
            {
                try
                {
                    SybAcc.Find_Field("Year");
                    for (int i = 0; i < SybAcc.Rows_count; i++)
                    {
                        SybAcc.Get_row(i);
                            nodName = cron + (string)Convert.ToString(SybAcc.get_current_Field());
                        if (nodName.Trim().CompareTo(cron)!=0)
                        {
                            AlianNodes = treeViewDocs.Nodes.Find(nodName, true);   //DocNod.Nodes.Find(nodName, true);
                            if (AlianNodes.LongLength < 1)  //== null) //if (DocNod.Nodes.Find(nodName, true).LongLength < 1)  //== null)
                                try
                                {
                                    ItsNode = DocNod.Nodes.Add(Convert.ToString(SybAcc.get_current_Field()) + " год");
                                    ItsNode.Name = nodName;
                                    ItsNode.ImageIndex = Docimage;
                                }
                                catch { }
                        }
                    }
                }
                catch { }
            }
            SybAcc.ReturnTable();
        }

        private void DocsMonthList(string sql, string cron, TreeNode DocNod, int Docimage)
        {
            string nodName = "";
            TreeNode[] AlianNodes;
            int moon;
            TreeNode ItsNode;

            if (SybAcc.Set_table("TCSDocs7", sql, null))
            {
                try
                {
                    for (int i = 0; i < SybAcc.Rows_count; i++)
                    {
                        SybAcc.Get_row(i);
                        SybAcc.Find_Field("month");
                        moon = (int)SybAcc.get_current_Field();
                        nodName = cron + (moon < 10 ? "0" + moon.ToString() : moon.ToString()) + DocNod.Name.Substring(3, 4);
                        AlianNodes = treeViewDocs.Nodes.Find(nodName, true);   //DocNod.Nodes.Find(nodName, true);
                        if (AlianNodes.Length < 1)  //== null) //if (DocNod.Nodes.Find(nodName, true).LongLength < 1)  //== null)
                            try
                            {
                                SybAcc.Get_row(i);
                                ItsNode = DocNod.Nodes.Add(Get_month((int)SybAcc.get_current_Field()));
                                ItsNode.Name = nodName;
                                ItsNode.ImageIndex = Docimage;
                            }
                            catch { }
                    }
                }
                catch { }
            }
            SybAcc.ReturnTable();
        }


        private void DocsDayList(string sql, string cron, TreeNode DocNod, int Docimage)
        {
            string nodName = "";
            TreeNode[] AlianNodes;
            int a_day;
            TreeNode ItsNode;

            if (SybAcc.Set_table("TCSDocs7", sql, null))
            {
                try
                {
                    for (int i = 0; i < SybAcc.Rows_count; i++)
                    {
                        SybAcc.Get_row(i);
                        SybAcc.Find_Field("day");
                        a_day = (int)SybAcc.get_current_Field();
                        nodName = cron + (a_day < 10 ? "0" + a_day.ToString() : a_day.ToString()) + DocNod.Name.Substring(3, 6);
                        AlianNodes = treeViewDocs.Nodes.Find(nodName, true);   //DocNod.Nodes.Find(nodName, true);
                        if (AlianNodes.Length < 1)  //== null) //if (DocNod.Nodes.Find(nodName, true).LongLength < 1)  //== null)
                            try
                            {
                                SybAcc.Get_row(i);
                                ItsNode = DocNod.Nodes.Add(SybAcc.get_current_Field().ToString());
                                ItsNode.Name = nodName;
                                ItsNode.ImageIndex = Docimage;
                            }
                            catch (Exception Ex) { SybAcc.AddError(Ex.Message,Ex.StackTrace,Ex.Source); }
                    }
                }
                catch (Exception Ex) { SybAcc.AddError(Ex.Message, Ex.StackTrace, Ex.Source); }
            }
            SybAcc.ReturnTable();
        }



        private int CountDocsInFolder(string sql)
        {
            int Count_fall = 0;
            if (SybAcc.Set_table("TCSDocs3", sql, null))
            {
                try
                {
                    Count_fall = (int)SybAcc.Find_Field("cnt");
                }
                catch { Count_fall = SybAcc.Rows_count; }
                SybAcc.ReturnTable();
            }
            return Count_fall;
        }

        public void Fill_Tree(TreeNode DocNod)
        {
            int day = 0; int month = 0; int year = 0;
            string cron = "";

            switch (DocNod.Name)
            {
                case "Current":
                    cron = "cta";
                    break;
                case "Executed":
                    cron = "eda";
                    break;
                case "Sended":
                    cron = "sda";
                    break;
                case "New":
                    cron = "nwa";
                    break;
                case "own":
                    cron = "owa";
                    break;
                default:
                    cron = DocNod.Name.Substring(0, 3);
                    break;
            }
            try
            {
                switch (cron.Substring(2, 1).ToUpper())
                {
                    case "Y":
                        year = (int)Convert.ToInt32(DocNod.Name.Substring(3, 2)); // DocNod.Name.Length - 3));
                        break;
                    case "M":
                        month = (int)Convert.ToInt32(DocNod.Name.Substring(3, 2)); // DocNod.Name.Length - 3));
                        year = (int)Convert.ToInt32(DocNod.Name.Substring( 5, 4)); // DocNod.Parent.Name.Length - 3));
                        break;
                    case "D":
                        day = (int)Convert.ToInt32(DocNod.Name.Substring(3, 2)); // DocNod.Name.Length - 3));
                        month = (int)Convert.ToInt32(DocNod.Name.Substring(5, 2)); // DocNod.Parent.Name.Length - 3));
                        year = (int)Convert.ToInt32(DocNod.Name.Substring(7, 4)); // DocNod.Parent.Parent.Name.Length - 3));
                        break;
                }
            }
            catch { }

            cron = cron.Substring(0, 2);
            Documents_Catalog(DTG.Documents_Catalog(day, month, year, cron), DocNod, cron);
        }

        public string Get_month(int month)
        {
            string mon = "";
            switch (month)
            {
                case 1:
                    mon = "январь";
                    break;
                case 2:
                    mon = "февраль";
                    break;
                case 3:
                    mon = "март";
                    break;
                case 4:
                    mon = "апрель";
                    break;
                case 5:
                    mon = "май";
                    break;
                case 6:
                    mon = "июнь";
                    break;
                case 7:
                    mon = "июль";
                    break;
                case 8:
                    mon = "август";
                    break;
                case 9:
                    mon = "сентябрь";
                    break;
                case 10:
                    mon = "октябрь";
                    break;
                case 11:
                    mon = "ноябрь";
                    break;
                case 12:
                    mon = "декарь";
                    break;
            }
            return mon;
        }

        private int with_image(int imgNum)
        {
            int img=4;
            switch (imgNum)
            {
                case 1:
                    img = 10;
                    break;
                case 2:
                    img = 1;
                    break;
                case 3:
                    img = 0;
                    break;
                case 4:
                    img = 3;
                    break;
                case 5:
                    img = 4;
                    break;
            }
            return img;
        }
        public void Documents_Catalog(string sql, TreeNode DocNod, string cron)
        {
            int kod = 0;
            string Resultset = "";
            TreeNode Node = null;
            if (SybAcc.Set_table("TCSDocsList", sql, null))
            {
                try
                {
                    if (FuelBar != null)
                    {
                        FuelBar.Minimum = 0;
                        if (SybAcc.Rows_count > 1)
                            FuelBar.Maximum = SybAcc.Rows_count - 1;
                        else
                            FuelBar.Maximum = 1;
                        FuelBar.Visible = true;
                    }
                    for (int i = 0; i < SybAcc.Rows_count; i++)
                    {
                        SybAcc.Get_row(i);
                        if (FuelBar != null) FuelBar.Value = i;
                        try
                        {
                            string findKod = "???";
                            try
                            {
                                findKod = (string)SybAcc.Find_Field("find_cod");
                                kod = (int)SybAcc.Find_Field("kod");
                            }
                            catch { findKod = "???"; }

                            string keynod = cron + "f" + kod.ToString();

                            int img=4;
                            try
                            {
                                img=with_image((int)SybAcc.Find_Field("img"));
                            }
                            catch { img = 4; }
                            //img = 4;

                            if (DocNod != null)
                            {
                                if (!DocNod.Nodes.ContainsKey(keynod))
                                    Node = DocNod.Nodes.Add(keynod, findKod, img);
                            }
                            else
                                if (!DocNod.Nodes.ContainsKey(keynod))
                                treeViewDocs.Nodes.Add(keynod, findKod, img);
                        }
                        catch (Exception ex)
                        {
                            SybAcc.EBBLP.AddError(ex.Message, "Select Document - 1", ex.StackTrace);
                            Resultset = ex.Message;
                        }
                    }
                    if (FuelBar != null) FuelBar.Visible = false;
                }
                catch (Exception ex)
                {
                    SybAcc.EBBLP.AddError(ex.Message, "Select Document - 2", ex.StackTrace);
                    Resultset = ex.Message;
                }
                SybAcc.ReturnTable();
            }
        }

        private void tsbNewDoc_Click(object sender, EventArgs e)
        {
            ShowDocument.Doc_ID = 0;
            ShowDocument.New_document = true;
            ShowDocument.Edit_document = true;
            if (NewDocExecution != null) this.Controls.Remove(NewDocExecution);
            NewDocExecution = new UCNewDocument(SybAcc, ShowDocument, 0, false);
            this.Controls.Add(NewDocExecution);
            NewDocExecution.Dock = DockStyle.Fill;
            NewDocExecution.Visible = true;
            NewDocExecution.BringToFront();
        }

        UCNewDocument NewDocExecution;
        private void tsbAnswer_Click(object sender, EventArgs e)
        {
            if (ShowDocument.Doc_ID > 0)
            /* {
                 Document_Viewer Newdoc = new Document_Viewer(SybAcc, null)
                 {
                     Doc_ID = 0,
                     New_document = true,
                     Edit_document = true
                 };
                 ShowDocument.Controls.Add(Newdoc);
                 Newdoc.Dock = DockStyle.Fill;
                 UCNewDocument NewDocExecution = new UCNewDocument(SybAcc, Newdoc, ShowDocument.Doc_ID,true);
                 this.Controls.Add(NewDocExecution);
                 NewDocExecution.Dock = DockStyle.Fill;
                 NewDocExecution.Visible = true;
                 NewDocExecution.BringToFront();
             } */
            {
                Get_Answer_to_Doc(ShowDocument);
            }
            else MessageBox.Show("Не выбран документ");

        }

        private void Get_Answer_to_Doc(Document_Viewer document_View)
        {
            if (DocumentAnswer != null) this.Controls.Remove(DocumentAnswer); //.lvALARM.Controls.Remove(DocumentAnswer);

            if (document_View != null)
            {
                try
                {
                    int Answer_count = 0;
                    int[] Movings = null;
                    if (SybAcc.Set_table("MST71", "select * from dbo.rkk_moving where document= " + document_View.Doc_ID.ToString() + " and for_  in (select cod from dbo.emp_dep_degrees where employee=dbo.user_ident() and executed is null)", null))
                    {
                        Answer_count = SybAcc.Rows_count;
                        Movings = new int[Answer_count];
                        for (int i = 0; i < SybAcc.Rows_count; i++)
                        {
                            SybAcc.Find_Field("moving");
                            Movings[i] = (int)SybAcc.get_current_Field();
                        }
                        SybAcc.ReturnTable();
                    }

                    if (Answer_count > 0)
                    {
                        int movId = 0;
                        if (Answer_count > 1)
                        {
                            //FormMovingList MovList = new FormMovingList(SybAcc, document_View.Doc_ID);
                            //MovList.ShowDialog();
                            //movId = MovList.movId[0];
                        }
                        else movId = Movings[0];
                        if (document_New != null) document_View.Controls.Remove(document_New);
                        document_New = new Document_Viewer(SybAcc, null);
                        document_View.Controls.Add(document_New);
                        document_New.Dock = DockStyle.Fill;
                        document_New.Visible = false;
                        document_New.Sender = movId;

                        if (document_New.Sender > 0)
                        {
                            DocumentAnswer = new UCNewDocument(SybAcc, document_New, document_View.Doc_ID, true);
                            this.Controls.Add(DocumentAnswer);
                            DocumentAnswer.Dock = DockStyle.Fill;
                            DocumentAnswer.Visible = true;
                            DocumentAnswer.BringToFront();
                            DocumentAnswer.answer("Ответ на поручение по документу " + document_View.DocumentNumber);

                            document_New.New_document = true;
                            document_New.Doc_ID = 0;
                            document_New.Refresh();
                            document_New.Visible = true;
                            document_New.BringToFront();
                        }
                    }
                    else if (Answer_count == 0)
                    {
                        SybAcc.AddError("Вы не можете дать ответ, поскольку отсутствует поручение по данному документу", "UCDocTree - 1.3", "");
                        MessageBox.Show("Вы не можете дать ответ, поскольку отсутствует поручение по данному документу.");
                        document_New.Visible = false;
                        document_View.Controls.Remove(document_New);
                    }
                }
                catch { document_View.Controls.Remove(document_New); }
            }

        }

        UCNewDocument DocumentAnswer;
        private Document_Viewer document_New;

        enum ToDo { nothing, executing, vizing, news }
        ToDo whatToDo = ToDo.nothing;

        private void tsbExecute_Click(object sender, EventArgs e)
        {
            if (whatToDo == ToDo.nothing)
            {
                whatToDo = ToDo.executing;
                panelStructure.BringToFront();
            }
            else
            {
                whatToDo = ToDo.nothing;
                panelStructure.SendToBack();
            }
        }

        private void tbsVizing_Click(object sender, EventArgs e)
        {
            whatToDo = ToDo.vizing;
            panelStructure.BringToFront();
        }

        private void tsbNews_Click(object sender, EventArgs e)
        {
            whatToDo = ToDo.news;
            panelStructure.BringToFront();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*panelStructure.SendToBack();
            switch (whatToDo)
            {
                case ToDo.news:
                    //A_Struct.push_new(,(long)ShowDocument.Doc_ID);
                    break;
                case ToDo.executing:
                    A_Struct.push_letter(false, Exe_date.ToString(), DocID, tsbComment.Text.Trim(), 0);
                    break ;
                case ToDo.vizing:
                    break;
            }*/

            A_Struct.push_letter(false, Exe_date.ToString(), DocID, tsbComment.Text.Trim(), 0);

        }

        private void treeViewStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        DateTime Exe_date;
        private void tsbCalendar_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            A_Struct.push_viza(Exe_date.ToString(), DocID, 0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            A_Struct.push_new(Exe_date.ToString(), DocID);
        }

        private void tsbCalendar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Exe_date = DateTime.Now;
                Exe_date = Exe_date.AddDays(Convert.ToDouble(tsbCalendar.Text.ToString()));
            }
            catch { }
        }
    }
}
