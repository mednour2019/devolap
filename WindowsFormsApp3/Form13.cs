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
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        Microsoft.SqlServer.Management.Smo.Server serveur;

        Helper h;
        Form form5;
        public Form13(Helper h, Form form)
        {
            this.h = h;
            form5 = form;
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            serveur = new Microsoft.SqlServer.Management.Smo.Server();
            metroComboBox1.Items.Add(serveur);

            metroTextBox3.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            metroComboBox1.Hide();
            label1.Hide();
            metroTextBox1.Hide();
            label2.Hide();
            metroTextBox2.Hide();
            label3.Hide();
            label4.Hide();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {

                { MessageBox.Show("Please select option ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return;
            }
                if (radioButton1.Checked == true)
            {
                h.sqlserverdispatching = h.serv;
              //  MessageBox.Show(" serveur local" + h.sqlserverdispatching.Name);
                h.userdispatching = h.user;
                h.passwordispatching = h.password;
              //  MessageBox.Show("user local est "  +    h.userdispatching);
               // MessageBox.Show("password local est "  +   h.passwordispatching);
              Form12 f12 = new Form12(h, this);
            f12.Show();
            Form11 f11 = new Form11(h, this);
            this.Hide();

            }

            else
              if (radioButton2.Checked == true)
              {   

                  if (metroComboBox1.SelectedIndex == -1)
                  {
                    { MessageBox.Show("Please select server ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    return;
                  }
                  if (metroTextBox1.Text == "")
                  {
                    MessageBox.Show("Please select sql login ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                  }

                 if (metroTextBox2.Text == "")
                 {
                    MessageBox.Show("Please select sql password ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // MetroFramework.MetroMessageBox.Show(this, "Please Select Sql Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                  }
                h.sqlserverdispatching = serveur;
               // MessageBox.Show(" serveur distant" + h.sqlserverdispatching.Name);
                string conx = string.Format("Data Source={0}; User ID={1};Password={2};", h.sqlserverdispatching.Name, metroTextBox1.Text, metroTextBox2.Text);
                try
                {


                    if (h.testconnc(conx))
                    {
                        //  MessageBox.Show("test connexon succed!!! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MetroMessageBox.Show(this, "Test Connexion Succed!!!", "Sql Connexion");





                        h.userdispatching = metroTextBox1.Text;


                        h.passwordispatching = metroTextBox2.Text;
                     //   MessageBox.Show("userdispatching" + h.userdispatching);
                      //  MessageBox.Show("passworddispatching" + h.passwordispatching);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                    // MetroFramework.MetroMessageBox.Show(this, ex.Message,"Error Sql Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Form12 f12 = new Form12(h, this);
                
                Form11 f11 = new Form11(h, this);
                f12.Show();
                this.Hide();
            }

       




        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                groupBox2.Hide();
                label4.Hide();
              
            
                groupBox1.Show();
                metroComboBox1.Show();
                metroTextBox1.Show();
                metroTextBox2.Show();
                label1.Show();
                label2.Show();
                label3.Show();



            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                groupBox1.Hide();

                metroTextBox3.Show();
                groupBox2.Show();
                label4.Show();
                metroTextBox3.Text = h.serv.Name;
             
            }

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serveur = (Microsoft.SqlServer.Management.Smo.Server)metroComboBox1.SelectedItem;

           // h.sqlserverdispatching = serveur;
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
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
