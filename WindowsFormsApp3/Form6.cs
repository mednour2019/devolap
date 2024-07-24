
// lel mesures
using Microsoft.AnalysisServices;

// lel mesures
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace WindowsFormsApp3
{
    public partial class Form6 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
        Form form4;
        DataTable datanom;
        public Form6(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form4 = form;
        }
        int SelectedRowIndex;
        private void Form6_Load(object sender, EventArgs e)

        {













            h.measures = new List<Measure>();
            Measure ko;

            foreach (Table t in h.fact)
            {
                foreach (Column k in t.Columns)
                {

                    if (h.exist(k) == false && (k.DataType.IsStringType) == false && (k.DataType is DateTime) == false &&(k.IsForeignKey==false) )
                    {


                        ko = new Measure(k.Name);

                        h.measures.Add(ko);


                    }

                }
            }
            foreach (Measure i in h.measures)
            { listBox1.Items.Add(i.ToString()); }

            metroComboBox1.Items.Add("SUM");
            metroComboBox1.Items.Add("Count");
            metroComboBox1.Items.Add("Min");
            metroComboBox1.Items.Add("Max");
            metroComboBox1.Items.Add("DistinctCount");
            metroComboBox1.Items.Add("None");
            metroComboBox1.Items.Add("ByAccount");
            metroComboBox1.Items.Add("AVG");
            metroComboBox1.Items.Add("FirstChild");
            metroComboBox1.Items.Add("LastChild");
            metroComboBox1.Items.Add("FirstNonEmpty");
            metroComboBox1.Items.Add("LastNonEmpty");


            // h.chaine = new List<string>();
            h.chosmeasures = new List<Measure>();



            datanom = new DataTable();

            datanom.Columns.Add(new DataColumn("ancienom", typeof(string)));
            datanom.Columns.Add(new DataColumn("newnom", typeof(string)));
            datanom.Columns.Add(new DataColumn("numligne", typeof(string)));





            foreach (DataColumn dc in datanom.Columns)
            {
                var c = new DataGridViewTextBoxColumn() { HeaderText = dc.ColumnName }; //Let say that the default column template of DataGridView is DataGridViewTextBoxColumn

                //metroGrid2.Columns.Add(new DataGridViewTextBoxColumn());
                metroGrid2.Columns.Add(c);



            }
        }



        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
             
        {
            if(metroGrid1.Rows.Count == 0) { MessageBox.Show("Please add your measure && functions", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
          


            h.tabmesure = new DataTable();
            h.tabmesure.Columns.Add(new DataColumn("measure", typeof(string)));
            h.tabmesure.Columns.Add(new DataColumn("function", typeof(string)));

            DataRow drLocal = null;

            foreach (DataGridViewRow row in metroGrid1.Rows)
            {
                drLocal = h.tabmesure.NewRow();
                drLocal["measure"] = row.Cells["Column1"].Value;
                drLocal["function"] = row.Cells["Column2"].Value;
             
                h.tabmesure.Rows.Add(drLocal);


            }





            this.Hide();
            Form8 f = new Form8(h, this);
            f.Show();


        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
              { MessageBox.Show("Please select measure", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
              if (metroComboBox1.SelectedIndex < 0) { MessageBox.Show("Please select function", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

              Measure ab;
              foreach (var item in listBox1.SelectedItems)
              {


                      ab = new Measure(item.ToString());
                                  if (metroComboBox1.SelectedItem.ToString() == "SUM")
                                  {

                                    // MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                                     ab.AggregateFunction = AggregationFunction.Sum;
                                  }
                                  else if(metroComboBox1.SelectedItem.ToString() == "Count")
                                  {  //  MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                                          ab.AggregateFunction = AggregationFunction.Count;
                                  }
                                  else if (metroComboBox1.SelectedItem.ToString() == "Min")
                                  {
                     // MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                    ab.AggregateFunction = AggregationFunction.Min; }
                                  else if (metroComboBox1.SelectedItem.ToString() == "Max")
                                  {// MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                    ab.AggregateFunction = AggregationFunction.Max; }
                                  else   if (metroComboBox1.SelectedItem.ToString() == "DistinctCount")
                                  {// MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                    ab.AggregateFunction = AggregationFunction.DistinctCount; }
                                  else if (metroComboBox1.SelectedItem.ToString() == "None")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                    ab.AggregateFunction = AggregationFunction.None; }
                                  else  if (metroComboBox1.SelectedItem.ToString() == "ByAccount")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString()); 
                    ab.AggregateFunction = AggregationFunction.ByAccount; }
                                  else if (metroComboBox1.SelectedItem.ToString() == "AVG")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString());
                    ab.AggregateFunction = AggregationFunction.AverageOfChildren; }
                                  else if (metroComboBox1.SelectedItem.ToString() == "FirstChild")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString()); 
                    ab.AggregateFunction = AggregationFunction.FirstChild; }
                                  else  if (metroComboBox1.SelectedItem.ToString() == "LastChild")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString()); 
                    ab.AggregateFunction = AggregationFunction.LastChild; }
                                  else if (metroComboBox1.SelectedItem.ToString() == "FirstNonEmpty")
                                  {// MessageBox.Show(metroComboBox1.SelectedItem.ToString()); 
                    ab.AggregateFunction = AggregationFunction.FirstNonEmpty; }
                                  else if (metroComboBox1.SelectedItem.ToString()== "LastNonEmpty")
                                  { //MessageBox.Show(metroComboBox1.SelectedItem.ToString()); 
                    ab.AggregateFunction = AggregationFunction.LastNonEmpty; }



                     h.chosmeasures.Add(ab);
                  int index = metroGrid1.Rows.Add();
                  metroGrid1.Rows[index].Cells["Column1"].Value = item.ToString();
                  metroGrid1.Rows[index].Cells["Column2"].Value = metroComboBox1.SelectedItem;

                  // listBox1.Items.Remove(listBox1.SelectedItem);




              }

            /* for (int i = 0; i <= listBox1.SelectedItems.Count; i++)
             {
                 listBox1.Items.RemoveAt(listBox1.SelectedIndex);
             }*/
             foreach (string s in listBox1.SelectedItems.OfType<string>().ToList())
              {
                  listBox1.Items.Remove(s);
              }

        
                    if (metroCheckBox1.Checked == true)
                    { metroCheckBox1.Checked = false; }
              
        


        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count < 1)
            { MessageBox.Show("Please select measure", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            DialogResult res = MessageBox.Show("Are you sure to remove measure(s) ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.Cancel)
            { return; }
            else
            if (res == DialogResult.OK)
            {



                Measure iu;
                foreach (DataGridViewRow row in metroGrid1.SelectedRows)
                {


                    string k = row.Cells["Column1"].Value.ToString();
                    for (int ao = 0; ao < datanom.Rows.Count; ao++)
                    {
                        DataRow dr = datanom.Rows[ao];

                        if (k.ToString() == dr["newnom"].ToString())
                        {

                            datanom.Rows.Remove(dr);
                        }
                    }



                    iu = new Measure(k);


                    for (int index = 0; index < h.chosmeasures.Count(); index++)
                    {



                        if (iu.Name == h.chosmeasures[index].Name)

                        {

                            k = h.chosmeasures[index].ID;
                            h.chosmeasures.Remove(h.chosmeasures[index]);
                        }

                    }

                    listBox1.Items.Add(k);
                    metroGrid1.Rows.Remove(row);
                }
               
            }
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
           /* foreach (Measure mes in h.chosmeasures)
            { MessageBox.Show(mes.ToString()); }*/


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form4.Show();
            this.Hide();
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void metroButton5_Click_2(object sender, EventArgs e)
        {
           // foreach (Measure mes in h.chosmeasures)
         // { MessageBox.Show(mes.ToString()); }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            /*DataGridViewRow row = new DataGridViewRow();
        
            row = metroGrid1.Rows[SelectedRowIndex];
            string anc = row.Cells[0].Value.ToString();
            string name2 = Interaction.InputBox("Enter New Measure Name ", "Update Measure Data ", row.Cells[0].Value.ToString(), - 1, -1);
            row.Cells[0].Value = name2;
            Measure m1 = new Measure(name2);
     
             for (int k= 0; k< h.chosmeasures.Count;k++)
             { if (h.chosmeasures[k].ToString() == anc)
                 {
                    h.chosmeasures[k].ID=m1.ID;
                    h.chosmeasures[k].Name = m1.Name;
                                    
                
                }



             }*/
        

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
        }

        private void metroButton5_Click_3(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count < 1)
            { MessageBox.Show("Please select measures", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (metroGrid1.SelectedRows.Count > 1)
            { MessageBox.Show("Please select once measure! you can't update " +  metroGrid1.SelectedRows.Count  + " measures name in the same time", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            DataGridViewRow row = new DataGridViewRow();

           row = metroGrid1.Rows[SelectedRowIndex];
           string anc = row.Cells[0].Value.ToString();
         
           string name2 = Interaction.InputBox("Enter new measure name ", "Update Measure Data ", row.Cells[0].Value.ToString(), - 1, -1);
            if(name2.Contains(',')) { MessageBox.Show("you can not update measure with caracter  , in name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (name2.Contains('=')) { MessageBox.Show("you can not update measure with caracter = in name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (name2.Contains(']')) { MessageBox.Show("you can not update measure with caracter  ] in name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (name2.Contains('[')) { MessageBox.Show("you can not update measure with caracter  [ in name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

        if(existmeasurename(name2,metroGrid1)==true)
            { MessageBox.Show("This measure name  "+name2+ "  is already exist!please try to change it ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (name2 != "")
            {
                DataRow drlocal = null;

                if (datanom.Rows.Count ==0)
                {
                   // MessageBox.Show("noexist");
                
                    drlocal = datanom.NewRow();
                    drlocal["newnom"] = name2;
                    drlocal["ancienom"] = anc;
                    drlocal["numligne"] = SelectedRowIndex;
                    datanom.Rows.Add(drlocal);


                }

                // DataRow drlocal = null; // foreach (DataRow r in datanom.Rows)
                 for (int i=0;i <datanom.Rows.Count;i++)
                 {
            
              
                    drlocal = datanom.NewRow();
                    if (verification(SelectedRowIndex.ToString(), datanom.Rows[i]["numligne"].ToString(), datanom) == false)
                    {
                       // MessageBox.Show("noexist2");

                        drlocal["newnom"] = name2;
                        drlocal["ancienom"] = anc;
                        drlocal["numligne"] = SelectedRowIndex;
                        datanom.Rows.Add(drlocal);
                        
                    }
                    else
                    {

                        if (datanom.Rows[i]["newnom"].ToString() == metroGrid1.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            datanom.Rows[i]["newnom"] = name2;
                        }

                    }
               
                 }



                for (int k = 0; k < h.chosmeasures.Count; k++)
                {

                    if (h.chosmeasures[k].ToString() == anc)
                    {

                        row.Cells[0].Value = name2;
                        // h.chosmeasures[k].ID=m1.ID;
                        // h.chosmeasures[k].Name = m1.Name;
                        // h.chosmeasures[k].AggregateFunction = m1.AggregateFunction;
                        // m1.DataType = h.chosmeasures[k].DataType;


                        foreach (DataRow r in datanom.Rows)

                        {
                            if (row.Cells[0].Value.ToString() == r["newnom"].ToString())

                            {
                                h.chosmeasures[k].ID = r["ancienom"].ToString() ;
                            }
                        }
                
                        
                        h.chosmeasures[k].Name = name2;
                        // m1.AggregateFunction = h.chosmeasures[k].AggregateFunction;

                        //  h.chosmeasures[k].Name = m1.Name;

                    }
                }
            }
            else
            {
                return;
            }


            }

        public bool verification(string indice,string numligne,DataTable dbt  )

        {
            foreach (DataRow r in datanom.Rows)
            {
                if (r["numligne"].ToString() == indice.ToString())
                {
                    return true;
                }


            }


                return false;
        }
        public bool existmeasurename(string l, DataGridView metrogrid1)
        {
            foreach (DataGridViewRow r in metroGrid1.Rows)
            { if (r.Cells[0].Value.ToString().ToUpper() == l.ToString().ToUpper())
                    return true;
            }


            return false ; 
        
        }


            private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
           
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton4_MouseHover(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.LightGray;
        }

        private void metroButton4_MouseLeave(object sender, EventArgs e)
        {
            metroButton4.BackColor = Color.Gainsboro;
        }

        private void metroButton5_MouseHover(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.LightGray;
        }

        private void metroButton5_MouseLeave(object sender, EventArgs e)
        {
            metroButton5.BackColor = Color.Gainsboro;
        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            // MessageBox.Show(metroGrid1.SelectedRows[0].Cells[0].Value.ToString()) ;
            /* foreach (DataRow r in datanom.Rows)
             {

                 MessageBox.Show(r["ancienom"].ToString());
                 MessageBox.Show(r["newnom"].ToString());
                 MessageBox.Show(r["numligne"].ToString());
             }*/




                      /*  metroGrid2.Rows.Clear();
                        metroGrid2.Refresh();
                        for (int i = 0; i < datanom.Rows.Count; i++)
                        {
                            DataRow r = datanom.Rows[i];


                            metroGrid2.Rows.Add(r.ItemArray);

                        }*/
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
           /* metroGrid3.Rows.Clear();
            metroGrid3.Refresh();
             foreach (Measure mes in h.chosmeasures)

            { //MessageBox.Show(" id"+mes.ID.ToString());
              // MessageBox.Show(" name" + mes.Name.ToString());
                int index = metroGrid3.Rows.Add();
                metroGrid3.Rows[index].Cells["Column3"].Value = mes.ID;
                metroGrid3.Rows[index].Cells["Column4"].Value = mes.Name;

            }*/
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            { metroCheckBox1.Checked = false; }

            List<Measure> ll = new List<Measure>();
            listBox1.Items.Clear();

            foreach (Measure t in h.measures)
            {
                listBox1.Items.Add(t.ToString());
            }


            foreach (Measure m1 in h.chosmeasures)
     
            {

             
              foreach ( DataGridViewRow r in metroGrid1.Rows)

              {
                    if (r.Cells[0].Value.ToString() == m1.Name.ToString())

                    {


                        listBox1.Items.Remove(m1.ID);
                    }
              }
            }

            if (metroTextBox1.Text != "")
            {
                Measure yui;
                foreach (var k in listBox1.Items)
                {


                    if (k.ToString().ToUpper().Contains(metroTextBox1.Text.ToUpper()) == true)
                    {
                        // MessageBox.Show(k.ToString());
                        yui = new Measure(k.ToString());
                        ll.Add(yui);
                    }


                }

                listBox1.Items.Clear();
                foreach (Measure aa in ll)
                {
                    listBox1.Items.Add(aa.ToString());
                }

            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("are you sure to close your program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton6_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton6_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (metroCheckBox1.Checked == true)
                {
                    listBox1.SetSelected(i, true);

                }
                else
                     
                {
                    listBox1.SetSelected(i, false); }
               



            }
          


        }

        private void metroButton6_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
}
