using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form8 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
        Form form6;
        DataTable dtb1;
        DataTable dtb3;
        public Form8(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form6 = form;
          
        }

        private void Form8_Load(object sender, EventArgs e)
        {


             dtb3 = new DataTable();
            dtb3.Columns.Add(new DataColumn("dim", typeof(string)));
            dtb3.Columns.Add(new DataColumn("pk", typeof(string)));
            dtb3.Columns.Add(new DataColumn("fact", typeof(string)));
            dtb3.Columns.Add(new DataColumn("fk", typeof(string)));



            //metroGrid1.Columns.Add(new DataGridViewTextBoxColumn());
            // metroGrid1.Columns.Add(new DataGridViewTextBoxColumn());
            foreach (Table t in h.fact)
            { listBox1.Items.Add(t); }
            foreach (Table t in h.dim)
            { listBox2.Items.Add(t); }



            string serv = h.serv.Name;
            string mot = "Server";
            string[] row1 = { mot, serv };
            metroGrid2.Rows.Add(row1);

            string slog = h.user;
            string mot2 = "SQL_Login";
            string[] row2 = { mot2, slog };
            metroGrid2.Rows.Add(row2);

            string spass = h.password;
            char etoile = '*';
            string spass2 ="";
            for (int i = 0; i < spass.Length; i++)
            {
                spass2 = spass2 + Convert.ToString(etoile); 
             
            }

                string mot3 = "SQL_Passwd";
            string[] row3 = { mot3, spass2 };
            metroGrid2.Rows.Add(row3);

            string dat = h.datab.Name;
            string mot4 = "DataBaseName";
            string[] row4 = { mot4, dat };
            metroGrid2.Rows.Add(row4);

            try
            {

                string conx = string.Format("Data Source={0};Initial Catalog={1}; User ID={2};Password={3};", h.serv.Name, h.datab.Name, h.user, h.password);

                if (h.testconnc(conx))
                {
                    //MessageBox.Show("test connexon succed!!! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (SqlConnection k = new SqlConnection(conx))
                    {
                        SqlDataAdapter sqlda2 = new SqlDataAdapter(
                        "  SELECT tab2.name as Dim_Table," +
                        " col2.name as Prim_Key," +
                        " tab1.name as Fact_Tab," +
                        " col1.name as Forei_Key" +
                        " from sys.foreign_key_columns fkc" +
                         " INNER JOIN sys.tables tab1" +
                          " ON tab1.object_id = fkc.parent_object_id" +
                          " INNER JOIN sys.columns col1" +
                          " ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id" +
                          " INNER JOIN sys.tables tab2" +
                           " ON tab2.object_id = fkc.referenced_object_id" +
                            " INNER JOIN sys.columns col2" +
                             " ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id", k);
                         dtb1 = new DataTable();
                        sqlda2.Fill(dtb1);


                        foreach (DataRow row in dtb1.Rows)
                        {

                            foreach (Table t in h.dim)
                            {
                                if (row["Dim_Table"].ToString() == t.Name)
                                    //  metroGrid1.Rows.Add(row.ItemArray);
                                    dtb3.Rows.Add(row.ItemArray);
                            }
                        }
                    }


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            metroGrid1.DataSource = dtb3;

                /* foreach (DataColumn dc in h.tabmesure.Columns)
                 {
                     var c = new DataGridViewTextBoxColumn() { HeaderText = dc.ColumnName }; //Let say that the default column template of DataGridView is DataGridViewTextBoxColumn

                     //metroGrid2.Columns.Add(new DataGridViewTextBoxColumn());
                     metroGrid3.Columns.Add(c);
                 }
                 foreach (DataRow row in h.tabmesure.Rows)
                 {



                     metroGrid3.Rows.Add(row.ItemArray);

                 }*/
                metroGrid3.DataSource = h.tabmesure;

          
          /*  BindingSource bs = new BindingSource();
            bs.DataSource = h.tabmesure;
            metroGrid3.DataSource = bs;*/


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            h.rela = new DataTable();
            h.rela.Columns.Add(new DataColumn("dimtab", typeof(string)));
            h.rela.Columns.Add(new DataColumn("primkey", typeof(string)));
            h.rela.Columns.Add(new DataColumn("facttable", typeof(string)));
            h.rela.Columns.Add(new DataColumn("forkey", typeof(string)));

            DataRow drLocal = null;

            foreach (DataRow row in dtb3.Rows)
            {
                drLocal = h.rela.NewRow();
                drLocal["dimtab"] = row["dim"];
                drLocal["primkey"] = row["pk"];
                drLocal["facttable"] = row["fact"];
                drLocal["forkey"] = row["fk"];
                h.rela.Rows.Add(drLocal);


            }



            this.Hide();
            Form7 f = new Form7(h, this);
            f.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form6.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            h.tabmesure.DefaultView.RowFilter = string.Format("[measure] LIKE '%{0}%'", metroTextBox1.Text);
           // metroGrid3.Columns["measure"].Visible = false;







        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            dtb3.DefaultView.RowFilter = string.Format("[dim] LIKE '%{0}%'", metroTextBox2.Text);




        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }
    }
}
