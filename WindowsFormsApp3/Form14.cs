using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server = Microsoft.AnalysisServices.Server;
using Database = Microsoft.AnalysisServices.Database;
using Microsoft.VisualBasic;
namespace WindowsFormsApp3
{
    public partial class Form14 : MetroFramework.Forms.MetroForm
    {
        Helper h;
        Form form5;
        public Form14(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form5 = form;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            Microsoft.AnalysisServices.Server s = h.ConnectAnalysisServices2();
            foreach (Microsoft.AnalysisServices.Database fb in s.Databases)
            {

                listBox1.Items.Add(fb.Name);
            }






            }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Microsoft.AnalysisServices.Server s = h.ConnectAnalysisServices2();
            foreach (string d in listBox1.SelectedItems.OfType<string>().ToList())
            {


                    for(int i=0;i <s.Databases.Count;i++)
                    {
                    if (d.ToString() == s.Databases[i].Name)
                    {
                        listBox1.Items.Remove(d);
                        s.Databases[i].Drop();
                     
                    }

                    }
               

            
           }

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Microsoft.AnalysisServices.Server s = h.ConnectAnalysisServices2();
            string name2 = Interaction.InputBox("Enter New Measure Name ", "Update Measure Data ", listBox1.SelectedItem.ToString(), -1, -1);
          
                for (int i = 0; i < s.Databases.Count; i++)
                {
                    if (listBox1.SelectedItem.ToString() == s.Databases[i].Name)
                 
                    {

                        s.Databases[i].Name = name2;
                    s.Databases[i].Update();

                    
                  
                    }
                      


                }
            listBox1.Items.Clear();
            foreach (Microsoft.AnalysisServices.Database k in s.Databases)
            {
                listBox1.Items.Add(k.Name.ToString());
            }







            }

        private void metroButton1_MouseHover(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.LightGray;
        }

        private void metroButton1_MouseLeave(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.Gainsboro;
        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }
    }
}
