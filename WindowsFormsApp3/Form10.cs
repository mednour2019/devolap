using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AnalysisServices;



namespace WindowsFormsApp3
{
    public partial class Form10 : MetroFramework.Forms.MetroForm
    {
        Helper h;
        Form form5;
        public Microsoft.AnalysisServices.Database db;

        public Form10(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form5 = form;
        }
        int selectedRowIndex;
        DataTable mydtb = new DataTable();
    

        private void Form10_Load(object sender, EventArgs e)
        {
            metroTextBox2.Text = h.cubemodif;
            metroTextBox2.Enabled = false;

            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton4);
           

            mydtb.Columns.Add(new DataColumn("calculationname", typeof(string)));
            mydtb.Columns.Add(new DataColumn("measure1", typeof(string)));

            mydtb.Columns.Add(new DataColumn("operation", typeof(string)));
           mydtb.Columns.Add(new DataColumn("measure2", typeof(string)));
            mydtb.Columns.Add(new DataColumn("formstring", typeof(string)));

         

            foreach (Microsoft.AnalysisServices.Database db in h.serrr.Databases)
            {
                if (db.Name.ToLower().Equals(h.cubemodif.ToLower()) )
                {
                    h.dbmodcube = db;
                    foreach (MdxScript m in db.Cubes[0].MdxScripts)
                    {
                        //MessageBox.Show(m.LastSchemaUpdate.ToString());
                        string caln = m.ToString();
          String k = m.Commands[0].Text;// Calculate; Create Member CurrentCube.[Measures].[c1] As" + " [Measures].[" opcode "] " + - + " [Measures].[" + ecastemitemid+ "]," + "FORMAT_STRING = " + Standard + ",VISIBLE = 1 ;";

             string s=k;
                       s = k.Substring(48,k.Length-48);
                      //  MessageBox.Show(s);//[c1] As" + " [Measures].[" opcode "] " + - + " [Measures].[" + ecastemitemid+ "]," + "FORMAT_STRING = " + Standard + ",VISIBLE = 1 ;";


                        int h = s.IndexOf(']')+17;
                        
                        s = s.Substring(h,s.Length-h);
                        int l = s.IndexOf(']');

                        string mes1 = s.Substring(0, l);//opcode
         // MessageBox.Show(mes1);

                                //  MessageBox.Show(mes1.Length.ToString());//6
                        int ll= s.IndexOf(']')+1;
                        s = s.Substring(ll, s.Length-ll);
                        int lll = s.IndexOf('[') -1;

                                string op = s.Substring(0,lll);
                                // MessageBox.Show(op);//-
                              

                             //  MessageBox.Show(op.Length.ToString());//2
                        int index = op.IndexOf(' ');
                       // MessageBox.Show("index espace est " + index);//0
                        op = op.Remove(0, 1) ;
                        char oper = Convert.ToChar(op);
         //   MessageBox.Show(oper);//-
                      //  MessageBox.Show(" taille de op apres quup espaces est " + op.Length.ToString());//1

                        int kkk = s.IndexOf('.')+2;
                        s = s.Substring(kkk, s.Length - kkk);
                        int z = s.IndexOf(']');

                                 string mes2 = s.Substring(0,z);
           //  MessageBox.Show(mes2);//ecastemitemid
                                //  MessageBox.Show(mes2.Length.ToString());//11



                        int yy = s.IndexOf(',')+1;
                        s = s.Substring(yy, s.Length - yy);
                        int qq = s.IndexOf('=')+1;
                        s = s.Substring(qq, s.Length - qq);
                        int wx = s.IndexOf(',');



                         string forms = s.Substring(0, wx);
                                 //  MessageBox.Show(forms);//standard
                                  // MessageBox.Show(forms.Length.ToString());//9
                        int index22 = forms.IndexOf(' ');
                       // MessageBox.Show("index espace formstring est " + index);//0
                        forms = forms.Remove(0, 1);
        //   MessageBox.Show(forms);
                        // MessageBox.Show(" taille de fomrstringespaces est " + forms.Length.ToString());//1

                        // MessageBox.Show(s);

                        DataRow drLocal = null;
                        drLocal = mydtb.NewRow();
                        drLocal["calculationname"] =caln;
                        drLocal["measure1"] = mes1;
                        drLocal["operation"] =oper;
                        drLocal["measure2"] = mes2;
                        drLocal["formstring"] = forms;
                        mydtb.Rows.Add(drLocal);
                        metroGrid1.DataSource = mydtb;



                    }
                   
                    foreach (Measure m in db.Cubes[0].AllMeasures)
                    {
                        metroComboBox1.Items.Add(m.Name.ToString());
                        metroComboBox2.Items.Add(m.Name.ToString());
                    }

                }

            }
            metroComboBox3.Items.Add(@"""Percent""");
            metroComboBox3.Items.Add("Standard");
            metroComboBox3.Items.Add("Currency");

        
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            { { MessageBox.Show("Please enter your calculation name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox1.SelectedIndex == -1)
            { { MessageBox.Show("Please select your Measure1", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }




            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                { { MessageBox.Show("Please select your operation", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }

            }


            if (metroComboBox2.SelectedIndex == -1)
            { { MessageBox.Show("Please select your Measure2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox3.SelectedIndex == -1)
            { { MessageBox.Show("Please select your form string", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }




            foreach (DataRow r in mydtb.Rows)
            {
                if (r["calculationname"].ToString() == metroTextBox1.Text.ToString())

                { MessageBox.Show("your calculation name  " + metroTextBox1.Text + " is already exist!! try to change it", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            }

            DataRow drLocal2 = null;
            drLocal2 =mydtb.NewRow();
            drLocal2["calculationname"] = metroTextBox1.Text.ToString();
            drLocal2["measure1"] = metroComboBox1.SelectedItem.ToString();
            string operation;
            foreach (RadioButton rb in groupBox1.Controls)

            {
                if (rb.Checked == true)
                {
                    operation = rb.Text;
                    drLocal2["operation"] = operation.ToString();
                }
            }
            drLocal2["measure2"] = metroComboBox2.SelectedItem.ToString();
            drLocal2["formstring"] = metroComboBox3.SelectedItem.ToString();

            mydtb.Rows.Add(drLocal2);
            metroGrid1.DataSource =mydtb;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count == 0)
            { MessageBox.Show("Please select your calculation ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            DialogResult res = MessageBox.Show("Are you sure to remove calculation(s) ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.Cancel)
            { return; }
            else

            {

                selectedRowIndex = metroGrid1.CurrentCell.RowIndex;
                metroGrid1.Rows.RemoveAt(selectedRowIndex);
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count == 0)
            { MessageBox.Show("Please select your calculation ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            // nezel 3la barsha lignet 

            if (metroGrid1.SelectedRows.Count > 1)
            { MessageBox.Show("Please select one item  you can not update " + metroGrid1.SelectedRows.Count + "  items in the same time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            if (metroTextBox1.Text == "")
            { { MessageBox.Show("Please enter your calculation name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox1.SelectedIndex == -1)
            { { MessageBox.Show("Please select your Measure1", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }




            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                { { MessageBox.Show("Please select your operation", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }

            }


            if (metroComboBox2.SelectedIndex == -1)
            { { MessageBox.Show("Please select your Measure2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }


            if (metroComboBox3.SelectedIndex == -1)
            { { MessageBox.Show("Please select your form string", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; } }

            DataGridViewRow row = metroGrid1.Rows[selectedRowIndex];
            if (row.Cells[0].Value.ToString().ToLower() == metroTextBox1.Text.ToString().ToLower())
            {

                row.Cells[0].Value = metroTextBox1.Text;
                row.Cells[1].Value = metroComboBox1.SelectedItem.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Checked == true)
                    {
                        string operation = rb.Text;
                        row.Cells[2].Value = operation;
                    }
                }

                row.Cells[3].Value = metroComboBox2.SelectedItem.ToString();
                row.Cells[4].Value = metroComboBox3.SelectedItem.ToString();
            }

            else if (h.exist2cal(metroTextBox1.Text.ToString().ToLower(),mydtb) == true)
            { MessageBox.Show("your calculation name  " + metroTextBox1.Text + " is already exist!! try to change it", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            else

            {
                row.Cells[0].Value = metroTextBox1.Text;
                row.Cells[1].Value = metroComboBox1.SelectedItem.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Checked == true)
                    {
                        string operation = rb.Text;
                        row.Cells[2].Value = operation;
                    }
                }

                row.Cells[3].Value = metroComboBox2.SelectedItem.ToString();
                row.Cells[4].Value = metroComboBox3.SelectedItem.ToString();
            }

         /*   foreach (DataRow r in mydtb.Rows)
            {
                if (r["calculationname"].ToString() == metroTextBox1.Text.ToString() &&h.existcalcul(metroTextBox1.Text.ToString(),mydtb)==true)

                { MessageBox.Show("your calculation name  " + metroTextBox1.Text + " is already exist!! try to change it", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            }
       
            row.Cells[0].Value = metroTextBox1.Text;
            row.Cells[1].Value = metroComboBox1.SelectedItem.ToString();
            foreach (RadioButton rb in groupBox1.Controls)
            {
                if (rb.Checked == true)
                {
                    string operation = rb.Text;
                    row.Cells[2].Value = operation;
                }
            }
            row.Cells[3].Value = metroComboBox2.SelectedItem.ToString();
            row.Cells[4].Value = metroComboBox3.SelectedItem.ToString();*/



        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* int f = e.ColumnIndex;

            DataGridViewColumn col = metroGrid1.Columns[f];
            if (col.Selected == true)
            { return; }*/


            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex > -1)
            {


                DataGridViewRow row = metroGrid1.Rows[selectedRowIndex];
                metroTextBox1.Text = row.Cells[0].Value.ToString();
                metroComboBox1.SelectedItem = row.Cells[1].Value.ToString();
                foreach (RadioButton rb in groupBox1.Controls)
                {
                    if (rb.Text == row.Cells[2].Value.ToString())

                    {
                        rb.Checked = true;
                    }
                }


                metroComboBox2.SelectedItem = row.Cells[3].Value.ToString();
                metroComboBox3.SelectedItem = row.Cells[4].Value.ToString();
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
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

        private void metroButton7_Click(object sender, EventArgs e)
        {
           
      
          
     
            try
            {



                if (mydtb.Rows.Count == 0)

                {
                 
                  
                    h.dbmodcube.Cubes[0].MdxScripts.Clear();
                    // foreach(MdxScript m in h.dbmodcube.Cubes[0].MdxScripts)
                    for (int i = 0; i < h.dbmodcube.Cubes[0].MdxScripts.Count; i++)
                    {
                        h.dbmodcube.Cubes[0].MdxScripts.Remove(h.dbmodcube.Cubes[0].MdxScripts[i]);
                        h.dbmodcube.Cubes[0].MdxScripts.Remove(h.dbmodcube.Cubes[0].MdxScripts[i].Commands[0].Text);
                 
                    }

                    h.dbmodcube.Cubes[0].Update(UpdateOptions.ExpandFull);

                

                    if (h.dbmodcube.State != AnalysisState.Processed)
                        h.dbmodcube.Process(ProcessType.ProcessFull);
             
                    MessageBox.Show("Cube Process Succsefully");
                
                }
                else
                  
             
                {
                   
                    h.dbmodcube.Cubes[0].MdxScripts.Clear();
                    foreach (DataRow r in mydtb.Rows)
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


                        //  h.dbmodcube.Cubes[0].DefaultMdxScript.Commands.Clear();
                        // h.dbmodcube.Cubes[0].MdxScripts.Clear();

                        MdxCalculation.Name = r["calculationname"].ToString();
                        objCommand.Text = strScript;


                        MdxCalculation.Commands.Add(objCommand);



                        h.dbmodcube.Cubes[0].MdxScripts.Add(MdxCalculation);



                        if (!(h.dbmodcube.Cubes[0].DefaultMdxScript.Commands.Contains(objCommand)))
                            h.dbmodcube.Cubes[0].DefaultMdxScript.Commands.Add(objCommand);


                     

                        h.dbmodcube.Cubes[0].Update(UpdateOptions.ExpandFull);



                        if (h.dbmodcube.State != AnalysisState.Processed)
                            h.dbmodcube.Process(ProcessType.ProcessFull);


                    }




                    //  h.dbmodcube.Cubes[0].DefaultMdxScript.Commands.Clear();
                    // h.dbmodcube.Cubes[0].MdxScripts.Clear();


             
                    MessageBox.Show("Cube Process Succsefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                } 

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton4_MouseHover(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.LightGray;
        }

        private void metroButton5_MouseHover(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.LightGray;
        }

        private void metroButton6_MouseHover(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.LightGray;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton4_MouseLeave(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.Gainsboro;
        }

        private void metroButton5_MouseLeave(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.Gainsboro;
        }

        private void metroButton6_MouseLeave(object sender, EventArgs e)
        {
            metroButton6.BackColor = Color.Gainsboro;
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
           /* string fileExcel;
            fileExcel = @"C:\Users\mednour\Desktop\Excel.lnk";
            Microsoft.Office.Interop.Excel.Application xlapp;
            Microsoft.Office.Interop.Excel.Workbook xlworkbook;
            xlapp = new Microsoft.Office.Interop.Excel.Application();

            xlworkbook = xlapp.Workbooks.Open(fileExcel);
            xlapp.Workbooks.Open(fileExcel);
        
           

            xlapp.Visible = true;*/
           
        }
      

        private void metroButton8_MouseHover(object sender, EventArgs e)
        {
          //  metroButton8.BackColor = Color.LightGray;
        }

        private void metroButton8_MouseLeave(object sender, EventArgs e)
        {
            //metroButton8.BackColor = Color.Gainsboro;
        }

        private void metroButton1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(metroButton1, "Return to Option area");
        }

        private void metroButton8_MouseHover_1(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton8_MouseLeave_1(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you Sure to close your Program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
}
