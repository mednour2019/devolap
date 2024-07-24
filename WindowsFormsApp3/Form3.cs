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




namespace WindowsFormsApp3
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Server s;

        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
       Microsoft.SqlServer.Management.Smo.Database k;
        Form form2;
  

        public Form3(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form2 = form;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

           

            //s = new Microsoft.SqlServer.Management.Smo.Server();
        
       
         
            foreach (Table t in h.datab.Tables)
            { 
                CheckedListBox.Items.Add(t); }

            }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
          /*  for (int i = 0; i < CheckedListBox.Items.Count; i++)
            {
                if (CheckedListBox.GetItemCheckState(i) == CheckState.Unchecked)
                {

                   // CheckedListBox.SetItemChecked(i, false);

                    metroCheckBox1.Checked = false;



                }


               
            }*/

            

                    



                




        }

        private void metroButton1_Click(object sender, EventArgs e)
        { if (CheckedListBox.CheckedItems.Count == 0)

            { MessageBox.Show("Please select table(s) ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                if (h.verifchoixutlsateu(CheckedListBox.CheckedItems) == false)
                { return; }
                    h.tab = new List<Table>();
                foreach (Table t in CheckedListBox.CheckedItems)
                { h.tab.Add(t); }

                // MessageBox.Show(h.tab.Name);
                this.Hide();
                Form4 f4 = new Form4(h,this);
                f4.Show();
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckedListBox.Items.Count; i++)
            {
                if (metroCheckBox1.Checked)
                {
                    CheckedListBox.SetItemChecked(i, true);
                }
                else 
                {
                   
                 CheckedListBox.SetItemChecked(i, false);
                
                }
            }
         }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            { metroCheckBox1.Checked = false; }


                List<Table> ll = new List<Table>();
            CheckedListBox.Items.Clear();
         

            foreach (Table t   in h.datab.Tables)
            {
                CheckedListBox.Items.Add(t);
            }

            if (metroTextBox1.Text != "")
            {

                foreach (Table k in CheckedListBox.Items)
                {


                    if (k.Name.ToString().ToUpper().Contains(metroTextBox1.Text.ToUpper()) == true)
                    {
                     
                        ll.Add(k);
                    }


                }

                CheckedListBox.Items.Clear();
                foreach (Table aa in ll)
                {
                    CheckedListBox.Items.Add(aa);
                }

            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your Program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
