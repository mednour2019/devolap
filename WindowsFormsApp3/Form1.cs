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
using Server = Microsoft.AnalysisServices.Server;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Management;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk;
using Microsoft.SqlServer.Management.Smo;
using MetroFramework;


namespace WindowsFormsApp3
{    
    public partial class Form1 : MetroFramework.Forms.MetroForm    {
        
        Microsoft.SqlServer.Management.Smo.Server serveur;
      
        
      
     
        Helper help;
    
        public Form1(Helper h)
        {
            InitializeComponent();
            help = h;
        }
        // event load
        private void Form1_Load(object sender, EventArgs e)
        {
           
            serveur = new Microsoft.SqlServer.Management.Smo.Server();
         
            cbxserver.Items.Add(serveur);

       

        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           

        }
        // event click sur le bouton next
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (cbxserver.SelectedIndex == -1)
            {
                { MessageBox.Show("Please select your server ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return;
            }
            if (txtus.Text == "")
            {
                MessageBox.Show("Please enter  your sql login ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (txtpas.Text == "")
            {
                MessageBox.Show("Please enter your sql password ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MetroFramework.MetroMessageBox.Show(this, "Please Select Sql Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string conx = string.Format("Data Source={0}; User ID={1};Password={2};", help.serv.Name, txtus.Text, txtpas.Text);

            try
            {


                if (help.testconnc(conx))
                {
                    // MessageBox.Show("test connexon succed!!! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // MetroMessageBox.Show(this, "Test Connexion Succed!!!", "Sql Connexion");

                    Form5 f5 = new Form5(help, this);
                    f5.Show();
                    Form1 f1 = new Form1(help);
                    this.Hide();



                    help.user = txtus.Text;
                    help.password = txtpas.Text;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
               // MetroFramework.MetroMessageBox.Show(this, ex.Message,"Error Sql Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }


        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtus_Click(object sender, EventArgs e)
        {
          
          
        }

        private void cbxserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            help = new Helper();
        serveur = (Microsoft.SqlServer.Management.Smo.Server)cbxserver.SelectedItem; 
            
         help.serv = serveur;

         
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpas_Click(object sender, EventArgs e)
        {
          
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
         
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
 
        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void metroButton4_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");


        }

        private void metroButton1_MouseHover(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.LightGray;
        }

        private void metroButton1_MouseLeave(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.Gainsboro;
        }
    }
}
