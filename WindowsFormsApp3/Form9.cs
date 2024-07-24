using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// lel mesures
using Microsoft.AnalysisServices;

// lel mesures
using Server = Microsoft.AnalysisServices.Server;
using Database = Microsoft.AnalysisServices.Database;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.VisualBasic;



namespace WindowsFormsApp3
{
    public partial class Form9 : MetroFramework.Forms.MetroForm
         
    {
        Helper h;
       // Form form5;
     
        



        public Form9(Helper h)
        {
            InitializeComponent();
            this.h = h;
           // form5 = form;
           
        }
        int selectedRowIndex;



        private void Form9_Load(object sender, EventArgs e)
        {
            metroComboBox1.Items.Add(@"""Percent""");
            metroComboBox1.Items.Add("Standard");
            metroComboBox1.Items.Add("Currency");
          
            foreach (Measure m in h.chosmeasures)
            {
                metroComboBox2.Items.Add(m.Name);

            }
            foreach (Measure m in h.chosmeasures)
            {
                metroComboBox3.Items.Add(m.Name);
            }


          


            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton4);

            h.tabcalculations = new DataTable();

            h.tabcalculations.Columns.Add(new DataColumn("calculationname", typeof(string)));
            h.tabcalculations.Columns.Add(new DataColumn("measure1", typeof(string)));

            h.tabcalculations.Columns.Add(new DataColumn("operation", typeof(string)));
            h.tabcalculations.Columns.Add(new DataColumn("measure2", typeof(string)));
            h.tabcalculations.Columns.Add(new DataColumn("formstring", typeof(string)));




            /* foreach (DataColumn dc in h.tabcalculations.Columns)
              {
                  var c = new DataGridViewTextBoxColumn() { HeaderText = dc.ColumnName }; //Let say that the default column template of DataGridView is DataGridViewTextBoxColumn

                  //metroGrid2.Columns.Add(new DataGridViewTextBoxColumn());
                  metroGrid1.Columns.Add(c);
              }*/


            metroTextBox2.Text = h.datacubename;
            metroTextBox2.ReadOnly = true;
            metroTextBox2.Enabled = false;


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();

            //  form5.Show();

            Form5 f = new Form5(h, this);
            f.Show();
            
           


        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
        
            try
            {

                if (h.tabcalculations.Rows.Count == 0)

                {

                    h.dbanalysi.Cubes[0].MdxScripts.Clear();
                    // foreach(MdxScript m in h.dbmodcube.Cubes[0].MdxScripts)
                    for (int i = 0; i < h.dbanalysi.Cubes[0].MdxScripts.Count; i++)
                    {
                        h.dbanalysi.Cubes[0].MdxScripts.Remove(h.dbanalysi.Cubes[0].MdxScripts[i]);
                        h.dbanalysi.Cubes[0].MdxScripts.Remove(h.dbanalysi.Cubes[0].MdxScripts[i].Commands[0].Text);

                    }

                    h.dbanalysi.Cubes[0].Update(UpdateOptions.ExpandFull);



                    if (h.dbanalysi.State != AnalysisState.Processed)
                        h.dbanalysi.Process(ProcessType.ProcessFull);
                    MessageBox.Show("Cube Process succefully");
                }

   
                else

                {
                    h.dbanalysi.Cubes[0].MdxScripts.Clear();

                    foreach (DataRow r in h.tabcalculations.Rows)
                    {


                        string CalcualionName = r["calculationname"].ToString();
                        Measure Measure1 = new Measure(r["measure1"].ToString());
                        char Operation = Convert.ToChar(r["Operation"].ToString());
                        Measure Measure2 = new Measure(r["measure2"].ToString());
                        string FormaString = r["formstring"].ToString();


                        MdxScript MdxCalculation = new MdxScript();
                        Command objCommand = new Command();
                        String strScript;
                        strScript = "Calculate; Create Member CurrentCube.[Measures].[" + CalcualionName + "] As" +
                        " [Measures].[" + Measure1 + "] " + Operation + " [Measures].[" + Measure2 + "]," +
                        "FORMAT_STRING = " + FormaString + ",VISIBLE = 1 ;";
                        ////// Add Calculated Member


                        MdxCalculation.Name = r["calculationname"].ToString();
                        objCommand.Text = strScript;


                        MdxCalculation.Commands.Add(objCommand);

                    

                        h.dbanalysi.Cubes[0].MdxScripts.Add(MdxCalculation);


                        if (!(h.dbanalysi.Cubes[0].DefaultMdxScript.Commands.Contains(objCommand)))
                            h.dbanalysi.Cubes[0].DefaultMdxScript.Commands.Add(objCommand);


                        //  h.dbanalysi.Cubes[0].DefaultMdxScript.Commands.Clear();
                        //  h.dbanalysi.Cubes[0].MdxScripts.Clear();

                        h.dbanalysi.Cubes[0].Update(UpdateOptions.ExpandFull);

                

                        if (h.dbanalysi.State != AnalysisState.Processed)
                            h.dbanalysi.Process(ProcessType.ProcessFull);


                    }




                    // h.dbanalysi.Cubes[0].DefaultMdxScript.Commands.Clear();
                    // h.dbanalysi.Cubes[0].MdxScripts.Clear();
       

                    MessageBox.Show("Cube Process succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
      /*  public char takeop(char k)
        {
            string operation;
            
            foreach (RadioButton rb in groupBox1.Controls)

            {
                if (rb.Checked == true)
                {
                    operation = rb.Text;
                    k = Convert.ToChar(operation);

                }
               
            }

            return k;
        }*/

        private void metroButton3_Click(object sender, EventArgs e)
        {
                        if (metroTextBox1.Text == "")
                        { { MessageBox.Show("Please enter your calculation name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


                        if (metroComboBox2.SelectedIndex==-1)
                        { { MessageBox.Show("Please select your measure1", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }



           
                            if ( radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false &&radioButton4.Checked == false )
                            {
                                { { MessageBox.Show("Please select your operation", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }
                
                            }


                        if (metroComboBox3.SelectedIndex == -1)
                        { { MessageBox.Show("Please select your measure2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


                        if (metroComboBox1.SelectedIndex == -1)
                        { { MessageBox.Show("Please select your form string", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }




                         foreach (DataRow r in h.tabcalculations.Rows)
                         {
                             if (r["calculationname"].ToString().ToLower() == metroTextBox1.Text.ToString().ToLower())

                             { MessageBox.Show("your calculation name  "+metroTextBox1.Text+ " is already exist!! try to change it", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                         }
          
         



              DataRow drLocal = null;
        drLocal = h.tabcalculations.NewRow();
         string hh = metroTextBox1.Text.ToString();


         drLocal["calculationname"] = hh;
         drLocal["measure1"] = metroComboBox2.SelectedItem.ToString();
         string operation;
        foreach (RadioButton rb in groupBox1.Controls)

        {
             if (rb.Checked == true)
             {
                 operation = rb.Text;
                 drLocal["operation"] = operation.ToString();
             }
        }


         drLocal["measure2"] = metroComboBox3.SelectedItem.ToString();

         drLocal["formstring"] = metroComboBox1.SelectedItem.ToString();


         h.tabcalculations.Rows.Add(drLocal);
            metroGrid1.DataSource = h.tabcalculations;
        // metroGrid1.Rows.Add(drLocal.ItemArray);

         




        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
          
           




      



        }

        private void metroComboBox1_TextChanged(object sender, EventArgs e)
        {
           
               
        }




        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void groupBox1_TextChanged(object sender, EventArgs e)
        {

            

        }

        private void metroComboBox3_TextChanged(object sender, EventArgs e)
        {
           




        }

        private void metroButton5_Click(object sender, EventArgs e)
        {



            if (metroGrid1.SelectedRows.Count == 0)
            { MessageBox.Show("Please select your calculation ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            // nezel 3la barsha lignet 

            if (metroGrid1.SelectedRows.Count > 1)
            { MessageBox.Show("Please select one item  you can not update "+ metroGrid1.SelectedRows.Count+ "  items in the same time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            if (metroTextBox1.Text == "")
            { { MessageBox.Show("Please enter your calculation name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox2.SelectedIndex == -1)
            { { MessageBox.Show("Please select your measure1", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }




            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                { { MessageBox.Show("Please select your operation", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }

            }


            if (metroComboBox3.SelectedIndex == -1)
            { { MessageBox.Show("Please select your measure2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox1.SelectedIndex == -1)
            { { MessageBox.Show("Please select your form string", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            DataGridViewRow row = metroGrid1.Rows[selectedRowIndex];

            if (row.Cells[0].Value.ToString().ToLower() == metroTextBox1.Text.ToString().ToLower())

            {
                row.Cells[0].Value = metroTextBox1.Text;
                row.Cells[1].Value = metroComboBox2.SelectedItem.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Checked == true)
                    {
                        string operation = rb.Text;
                        row.Cells[2].Value = operation;
                    }
                }

                row.Cells[3].Value = metroComboBox3.SelectedItem.ToString();
                row.Cells[4].Value = metroComboBox1.SelectedItem.ToString();
            }
            else if (h.exist2cal(metroTextBox1.Text.ToString().ToLower(), h.tabcalculations) == true)
            { MessageBox.Show("your calculation name  " + metroTextBox1.Text + " is already exist!! try to change it", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

         
            else

            {
                row.Cells[0].Value = metroTextBox1.Text;
                row.Cells[1].Value = metroComboBox2.SelectedItem.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Checked == true)
                    {
                        string operation = rb.Text;
                        row.Cells[2].Value = operation;
                    }
                }

                row.Cells[3].Value = metroComboBox3.SelectedItem.ToString();
                row.Cells[4].Value = metroComboBox1.SelectedItem.ToString();
            }

            /*   for (int i = 0; i < h.tabcalculations.Rows.Count; i++)
               {
                   DataRow r = h.tabcalculations.Rows[i];

                       r["calculationname"] = metroTextBox1.Text;
                       r["measure1"] = metroComboBox2.SelectedItem.ToString();
                       foreach (RadioButton rb in groupBox1.Controls)
                       {
                           if (rb.Checked == true)
                           {
                            string   operation = rb.Text;
                               r["operation"] = operation.ToString();
                           } 
                       }
                       r["measure2"]= metroComboBox3.SelectedItem.ToString();
                       r["formstring"]= metroComboBox1.SelectedItem.ToString();





               }*/

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count == 0)
            {MessageBox.Show("Please select your calculation ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            /*     foreach (DataGridViewRow row in metroGrid1.SelectedRows)
                 {
                 // metroGrid1.Rows.Remove(row);

                         for (int i = 0; i < h.tabcalculations.Rows.Count; i++)
                         {
                             DataRow r = h.tabcalculations.Rows[i];

                             if (r["calculationname"].ToString() == row.Cells["calculationname"].Value.ToString())
                             { h.tabcalculations.Rows.Remove(r);

                                 i -= 1;
                             }

                            // MessageBox.Show(row.Cells["Column1"].Value.ToString());


                         }
               //  metroGrid1.Rows.Remove(row);
                 }*/
            DialogResult res = MessageBox.Show("Are you sure to remove calculation(s) ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.Cancel)
            { return; }
            else

            {
                selectedRowIndex = metroGrid1.CurrentCell.RowIndex;
                metroGrid1.Rows.RemoveAt(selectedRowIndex);
            }

        }

        private void radioButton1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


           

            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex > -1)
            {
                DataGridViewRow row = metroGrid1.Rows[selectedRowIndex];
                metroTextBox1.Text = row.Cells[0].Value.ToString();
                metroComboBox2.SelectedItem = row.Cells[1].Value.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Text == row.Cells[2].Value.ToString())

                    {


                        rb.Checked = true;
                    }
                }


                metroComboBox3.SelectedItem = row.Cells[3].Value.ToString();
                metroComboBox1.SelectedItem = row.Cells[4].Value.ToString();


            }

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
           /* metroGrid2.Rows.Clear();
            metroGrid2.Refresh();
            for (int i = 0; i < h.tabcalculations.Rows.Count; i++)
            {
                DataRow r = h.tabcalculations.Rows[i];
                

                        metroGrid2.Rows.Add(r.ItemArray);
                
            }*/
        }

        private void metroButton7_Click_1(object sender, EventArgs e)
        {

            metroTextBox1.Text = string.Empty;
            metroComboBox1.SelectedIndex = -1;
            metroComboBox2.SelectedIndex = -1;
            metroComboBox3.SelectedIndex = -1;
            foreach (RadioButton rb in groupBox1.Controls)

            {
                if (rb.Checked == true)
                {
                    rb.Checked = false;
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton4_MouseHover(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.LightGray;
        }

        private void metroButton4_MouseLeave(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.Gainsboro;
        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton6_MouseHover(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.LightGray;
        }

        private void metroButton6_MouseLeave(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.Gainsboro;
        }

        private void metroButton5_MouseHover(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.LightGray;
        }

        private void metroButton5_MouseLeave(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.Gainsboro;
        }

        private void metroButton7_MouseHover(object sender, EventArgs e)
        {
            metroButton7.BackColor = Color.LightGray;
        }

        private void metroButton7_MouseLeave(object sender, EventArgs e)
        {
            metroButton7.BackColor = Color.Gainsboro;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
          
          




        }

        private void metroButton2_MouseHover(object sender, EventArgs e)
        {
          
            toolTip1.SetToolTip(metroButton2, "Return to Option area");
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton8_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton8_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
    }  




