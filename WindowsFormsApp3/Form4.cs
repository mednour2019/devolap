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
using System.Data.OleDb;

namespace WindowsFormsApp3
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
        List<object> j = new List<object>();
        Form form3;
        public Form4(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form3 = form;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Table t in h.tab)
            { listBox1.Items.Add(t); }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Items ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (listBox1.SelectedItems.Count != 0)
                {
                    listBox2.Items.Add(listBox1.SelectedItems[0]);
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }



        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {




                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch (Exception ex) { MessageBox.Show("Please select an Item ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            try

            {



                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            catch (Exception ex) { MessageBox.Show("Please select an Item ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            try
            {




                listBox3.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch (Exception ex) { MessageBox.Show("Please select an Item ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Items ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (listBox2.SelectedItems.Count != 0)
                {
                    listBox1.Items.Add(listBox2.SelectedItems[0]);
                    listBox2.Items.Remove(listBox2.SelectedItems[0]);
                }
            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            try

            {



                listBox1.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
            catch (Exception ex) { MessageBox.Show("Please select an Item ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Items ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (listBox1.SelectedItems.Count != 0)
                {
                    listBox3.Items.Add(listBox1.SelectedItems[0]);
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Items ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (listBox3.SelectedItems.Count != 0)
                {
                    listBox1.Items.Add(listBox3.SelectedItems[0]);
                    listBox3.Items.Remove(listBox3.SelectedItems[0]);
                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {



            if (listBox2.Items.Count == 0)
            { MessageBox.Show("Please select fact", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (listBox3.Items.Count == 0)
            { MessageBox.Show("Please select dimension(s) ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            foreach (Table t2 in listBox2.Items)
            {  if(h.verifact(t2)==false )
               {  return; }

            }
                //add fat table to object
                h.fact= new List<Table>();
                foreach (Table t in listBox2.Items)
                { h.fact.Add(t);
                    h.factname = t.Name;
                   // MessageBox.Show(h.factname.ToString());
                }
                // add dim table to object
                h.dim = new List<Table>();
                foreach (Table s in listBox3.Items)
                { h.dim.Add(s); }

                this.Hide();
                Form6 f = new Form6(h,this);
                f.Show();
            


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            form3.Show();
            this.Hide();

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
          


            List<Table> ll = new List<Table>();
            listBox1.Items.Clear();


          

            foreach (Table t  in h.tab)
            {
                listBox1.Items.Add(t);
            }

            foreach (Table ty in h.tab)
               // for(int i=0;i<listBox1.Items.Count;i++)
                {
               // Microsoft.SqlServer.Management.Smo.Table ter = (Microsoft.SqlServer.Management.Smo.Table)listBox1.Items[i];

                foreach (Table t2 in listBox2.Items)

                {
                    if(t2.Name == ty.Name)

                    {


                        listBox1.Items.Remove(t2);
                    }
                }
                }

            foreach (Table tyy in h.tab)
               // for(int j =0;j <listBox1.Items.Count;j++)
                {
               // Microsoft.SqlServer.Management.Smo.Table teri = (Microsoft.SqlServer.Management.Smo.Table)listBox1.Items[j];

                foreach (Table t3 in listBox3.Items)

                {
                    if (t3.Name == tyy.Name)

                    {

                      
                        listBox1.Items.Remove(t3);
                    }
                }
              }
        

            if (metroTextBox1.Text != "")
            {

                foreach (Table k in listBox1.Items)
                {


                    if (k.Name.ToString().ToUpper().Contains(metroTextBox1.Text.ToUpper()) == true)
                    {
                        // MessageBox.Show(k.ToString());
                        ll.Add(k);
                    }


                }

                listBox1.Items.Clear();
                foreach (Table aa in ll)
                {
                    listBox1.Items.Add(aa);
                }

            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your Program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton11_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton11_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
}
