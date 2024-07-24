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
using System.Data.Common;
// lel mesures
using Microsoft.AnalysisServices;

// lel mesures
using System.Diagnostics;
using System.IO;
namespace WindowsFormsApp3
{
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
        Form form1;
        public Microsoft.AnalysisServices.Database dbanalysi;
        public Microsoft.AnalysisServices.Server servanalysi;

        public Form5(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form1 = form;
         
        }
     

            private void Form5_Load(object sender, EventArgs e)
        {
                
            /* try
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
                                          DataTable dtb1 = new DataTable();
                                           sqlda2.Fill(dtb1);


                                                                 foreach (DataRow row in dtb1.Rows)
                                                                 {

                                                                                    foreach (Table t in h.dim)
                                                                                    {
                                                                                        if (row["Dim_Table"].ToString() == t.Name)
                                                                                            metroGrid1.Rows.Add(row.ItemArray);

                                                                                    }
                                                                 }
                                       }


                        }       
                } catch (Exception ex) { MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                */


            /*  h.meas = new List<Column>();
              foreach (Table t in h.fact)
              {
                  foreach (Column k in t.Columns)
                  {
                      //foreach (Table t2 in h.tab)
                      //{


                          //if (k.DataType.IsStringType == false && h.exist(k,t2)== false && k.DataType is DateTime==false)
                          if ( h.exist(k) == false && (k.DataType.IsStringType) == false && (k.DataType is DateTime) == false)
                          {

                              h.meas.Add(k);

                          }
                      //}
                  } 
              }

                                  foreach (Column r in h.meas)
                                  { //MessageBox.Show(h.meas.Count.ToString());
                                      MessageBox.Show(r.DataType.ToString());

                                  }*/


            /* if (metroRadioButton2.Checked == true)
             {
                 metroComboBox1.Show();

             }
             else
             { metroComboBox1.Hide(); }*/


            groupBox1.Hide();
            groupBox3.Hide();
           
      
            label2.Hide();
            // metroComboBox1.Hide();
            // label1.Hide();

            // metroComboBox2.Hide();

            listBox1.Hide();
            listBox2.Hide();
            metroTextBox1.Hide();
            pictureBox2.Hide();
            metroTextBox2.Hide();
            pictureBox3.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
        /* h.rela = new DataTable();
            h.rela.Columns.Add(new DataColumn("dimtab", typeof(string)));
            h.rela.Columns.Add(new DataColumn("primkey", typeof(string)));
            h.rela.Columns.Add(new DataColumn("facttable", typeof(string)));
            h.rela.Columns.Add(new DataColumn("forkey", typeof(string)));

            DataRow drLocal = null;

            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                drLocal = h.rela.NewRow();
                drLocal["dimtab"] = row.Cells["Column1"].Value;
                drLocal["primkey"] = row.Cells["Column2"].Value;
                drLocal["facttable"] = row.Cells["Column3"].Value;
                drLocal["forkey"] = row.Cells["Column4"].Value;
                h.rela.Rows.Add(drLocal);
             
               
            }*/
            

                this.Hide();
            Form6 f = new Form6(h,this);
            f.Show();


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //form4.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                this.Hide();
                Form2 f = new Form2(h, this);
                f.Show();
            }

            else
           if (metroRadioButton2.Checked == true && listBox1.SelectedIndex > -1)
            {
               // h.cubemodif = metroComboBox1.SelectedItem.ToString();
                h.cubemodif = listBox1.SelectedItem.ToString();

                h.serrr = h.ConnectAnalysisServices2();
               
                this.Hide();
                Form10 f10 = new Form10(h, this);
                f10.Show();



            }

            else  if ( metroRadioButton3.Checked==true && listBox2.SelectedIndex > -1)
            {
               
                h.namecubedispatched= listBox2.SelectedItem.ToString();

                h.sqlserveurdispatched = h.serv;
                h.analysiserveursipatched = h.ConnectAnalysisServices2();
            
                this.Hide();
                Form13 f13 = new Form13(h, this);
                f13.Show();
            }
       

            else if ((metroRadioButton1.Checked == false) && (metroRadioButton2.Checked == false) && (metroRadioButton3.Checked == false))
            {
                MessageBox.Show("Please select option ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (metroRadioButton2.Checked == true && listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your olap cube  ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (metroRadioButton3.Checked == true && listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your olap cube  ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked == true)
            {
                
                metroRadioButton3.Checked = false;
                metroRadioButton1.Checked = false;

       
                label2.Hide();
                groupBox3.Hide();
                metroTextBox2.Hide();
                pictureBox3.Hide();
                groupBox1.Show();
                metroTextBox1.Show();
                pictureBox2.Show();
                listBox1.Show();
                listBox1.Items.Clear();
                servanalysi = h.ConnectAnalysisServices2();
             
          

                foreach (Microsoft.AnalysisServices.Database dbanalysi in servanalysi.Databases)
                {
                 

                    listBox1.Items.Add(dbanalysi.Name.ToString());
                }
          
                  

            }
        
          
           
           


        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                metroRadioButton2.Checked = false;
                metroRadioButton3.Checked = false;
                

        
                groupBox1.Hide();
                //  metroComboBox1.Hide();

                //  metroComboBox2.Hide();
                groupBox3.Hide();
                metroTextBox1.Hide();
                pictureBox2.Hide();
                metroTextBox2.Hide();
                pictureBox3.Hide();
          
                label2.Show();
            }
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton3.Checked == true)
            {
                metroRadioButton2.Checked = false;
                
                metroRadioButton1.Checked = false;


                label2.Hide();
                groupBox1.Hide();
                metroTextBox1.Hide();
                pictureBox2.Hide();
                groupBox3.Show();
                listBox2.Show();
                metroTextBox2.Show();
                pictureBox3.Show();
                listBox2.Items.Clear();
                servanalysi = h.ConnectAnalysisServices2();

                foreach (Microsoft.AnalysisServices.Database dbanalysi in servanalysi.Databases)
                {
                   listBox2.Items.Add(dbanalysi.Name.ToString());
                }
             
              
            }

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
         

          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        
        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            /* DataTable dt = new DataTable();
             dt.Columns.Add(new DataColumn("cc", typeof(string)));

             DataRow drLocal = null;
             foreach (string iy in listBox1.Items)
             {
                 drLocal = dt.NewRow();
                 drLocal["cc"] = iy;
                 dt.Rows.Add(drLocal);

             }

             DataView dv = dt.DefaultView;
             dv.RowFilter = "cc LIKE '%" + metroTextBox1.Text + "%'";*/
            List<string> ll = new List<string>();
            listBox1.Items.Clear();
            servanalysi = h.ConnectAnalysisServices2();



            foreach (Microsoft.AnalysisServices.Database dbanalysi in servanalysi.Databases)
            {


                listBox1.Items.Add(dbanalysi.Name.ToString());
            }

            if (metroTextBox1.Text != "")
            {
             
                foreach (var k in listBox1.Items)
                {


                    if (k.ToString().ToUpper().Contains(metroTextBox1.Text.ToUpper()) == true)
                    {
                        // MessageBox.Show(k.ToString());
                        ll.Add(k.ToString());
                    }


                }

                listBox1.Items.Clear();
                foreach (string aa in ll)
                {
                    listBox1.Items.Add(aa.ToString());
                }

            }
           
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            List<string> ll = new List<string>();
            listBox2.Items.Clear();
            servanalysi = h.ConnectAnalysisServices2();

            foreach (Microsoft.AnalysisServices.Database dbanalysi in servanalysi.Databases)
            {
                listBox2.Items.Add(dbanalysi.Name.ToString());
            }

            if (metroTextBox2.Text != "")
            {

                foreach (var k in listBox2.Items)
                {


                    if (k.ToString().ToUpper().Contains(metroTextBox2.Text.ToUpper()) == true)
                    {
                        // MessageBox.Show(k.ToString());
                        ll.Add(k.ToString());
                    }


                }

                listBox2.Items.Clear();
                foreach (string aa in ll)
                {
                    listBox2.Items.Add(aa.ToString());
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

          


           

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
             DialogResult res = MessageBox.Show("Are you sure to close your Program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
           if (res == DialogResult.OK)
           {    Environment.Exit(0); }
           else
           if (res == DialogResult.Cancel)
           {  e.Cancel=true; }
        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
