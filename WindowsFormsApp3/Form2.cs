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
   
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Server s;

        Microsoft.SqlServer.Management.Smo.Table t;
        Helper h;
        Form form5;
        Microsoft.SqlServer.Management.Smo.Database k;
        public Form2(Helper h,Form form)
        {
            InitializeComponent();
           this.h = h;
            form5 = form;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            s = h.serv;
          
          
           
            foreach (Database db in s.Databases )
           { cbxdb.Items.Add(db); }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(h);
            f1.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (cbxdb.SelectedIndex == -1)
            {
                MessageBox.Show("Please select DataBase ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         if(h.verifmodeldat()==false)
            {
                MessageBox.Show( cbxdb.SelectedItem+ " is not a star model dataWareHouse!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            this.Hide();
            Form3 f3 = new Form3(h,this);
            f3.Show();
          
            

        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void cbxdb_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            k = (Microsoft.SqlServer.Management.Smo.Database)cbxdb.SelectedItem;
            h.datab = k;
          // MessageBox.Show(h.datab.Name);
       
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
