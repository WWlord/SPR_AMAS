using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AMAS_DBI;

namespace Chief
{
    public partial class Address : Form
    {
        Class_syb_acc Ass_base;

        public Address(Class_syb_acc AACC)
        {
            InitializeComponent();

            Ass_base = AACC;
            addressReg.connect(AACC);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = addressReg.get_address().ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            addressReg.set_address(Convert.ToInt32( numericUpDown1.Value));
        }

        FormKLADR FmKLADR; 
        private void btnKLADR_Click(object sender, EventArgs e)
        {
            if (FmKLADR == null) FmKLADR = new FormKLADR(Ass_base);
            FmKLADR.Show();
        }

        private void buttonNorm_Click(object sender, EventArgs e)
        {
            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_trc set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("TStateHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullStateList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_trc(region,sta_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
                Ass_base.ReturnTable();

                Ass_base.SQLCommand.CommandType = CommandType.Text;
                Ass_base.SQLCommand.Parameters.Clear();
                Ass_base.SQLCommand.CommandText = "update dbo.ADR_areal set sinonim=id where sinonim is null";
                Ass_base.SQLCommand.ExecuteNonQuery();
                if (Ass_base.Set_table("TTrcHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullTrcList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_areal(areal,trc_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();

            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_city set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("TArealHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullArealList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_city(name_city,areal_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();

            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_district set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("TCityHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullCityList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_district(district,cit_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();

            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_street set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("TDistrictHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullDistrictList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_street(streetname,district_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();

            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_house set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("TStreetHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullStreetList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_house(house,str_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();

            Ass_base.SQLCommand.CommandType = CommandType.Text;
            Ass_base.SQLCommand.Parameters.Clear();
            Ass_base.SQLCommand.CommandText = "update dbo.ADR_flat set sinonim=id where sinonim is null";
            Ass_base.SQLCommand.ExecuteNonQuery();
            if (Ass_base.Set_table("THouseHavenotNull", AMAS_Query.Class_AMAS_Query.GetNullHouseList, null))
            {
                if (Ass_base.Rows_count > 0)
                    for (int i = 0; i < Ass_base.Rows_count; i++)
                    {
                        Ass_base.Get_row(i);
                        Ass_base.Find_Field("id");
                        Ass_base.SQLCommand.CommandType = CommandType.Text;
                        Ass_base.SQLCommand.Parameters.Clear();
                        Ass_base.SQLCommand.CommandText = "insert into dbo.ADR_flat(flat,hou_id) values(null," + Ass_base.get_current_Field().ToString() + ")";
                        Ass_base.SQLCommand.ExecuteNonQuery();
                    }
            }
            Ass_base.ReturnTable();
        }
    }
}