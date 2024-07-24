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

using Database = Microsoft.AnalysisServices.Database;
namespace WindowsFormsApp3
{
    public partial class Form11 : MetroFramework.Forms.MetroForm
    {
 
        Helper h;
        Form form5;
        public Form11(Helper h, Form form)
        {
            this.h = h;
            form5 = form;
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            groupBox3.Hide();
            pictureBox2.Hide();
            label1.Hide();
            metroTextBox1.Hide();
            metroButton3.Hide();
            label2.Hide();
            metroButton4.Hide();


            progressBar1.Hide();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (metroRadioButton1.Checked == false && metroRadioButton2.Checked == false)
            {
                MessageBox.Show(" Please Select Option ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;

            }


                if (metroRadioButton2.Checked == true)
            {
                Form12 f12 = new Form12(h, this);
                f12.Show();
                Form11 f11 = new Form11(h, this);
                this.Hide();
            }





            }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
         

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            form5.Show();
            this.Hide();
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                metroRadioButton2.Checked = false;
                label2.Hide();

                groupBox3.Show();
                pictureBox2.Show();
                label1.Show();
                metroTextBox1.Show();
                metroButton3.Show();
                metroButton1.Hide();
                metroButton4.Location = metroButton1.Location;
                metroButton4.Show();
               
            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (metroRadioButton2.Checked == true)
            {
                metroRadioButton1.Checked = false;
                groupBox3.Hide();
                pictureBox2.Hide();
                label1.Hide();
                metroTextBox1.Hide();
                metroButton3.Hide();
                metroButton4.Hide();
                label2.Show();
                metroButton1.Show();
                
    
            }

        }
        public bool verifcubeexist(string s, Microsoft.AnalysisServices.Server serv)
        {

            foreach (Database db in serv.Databases)
            {
                if (db.Name.ToLower().Contains(s.ToLower()))

                {
                   
                    return true;


                }



            }
            return false;


        }
        public static object ConnectAnalysisServices(string strDBServerName, string strProviderName, string password, string login)
        {
            try
            {
                // MessageBox.Show("Connecting----> to the Analysis Services started...!!!");

                Server objServer = new Server();

                string strConnection = "Data Source=" + strDBServerName + ";Provider=" + strProviderName + ";Persist Security Info=True;Password=" + password + ";User ID=" + login;
                //Disconnect from current connection if it's currently connected.
                if (objServer.Connected)
                    objServer.Disconnect();
                else
                    objServer.Connect(strConnection);

                return objServer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connecting to the Analysis Services(). Error Message -> " + ex.Message);
                return null;
            }
        }
        private static object CreateDatabase(Server objServer, string strCubeDBName)
        {
            try
            {
                // MessageBox.Show("Creating ---->Database started!...");

                Database objDatabase = new Database();
                //Add Database to the Analysis Services.
                objDatabase = objServer.Databases.Add(objServer.Databases.GetNewName(strCubeDBName));
                //Save Database to the Analysis Services.

                objDatabase.Update();

                return objDatabase;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Creating a Database(). Error Message -> " + ex.ToString());
                return null;
            }
        }

        private static object CreateDataSource(Server objServer, Database objDatabase, string strCubeDataSourceName, string strDBServerName, string strDBName, string strProviderName, string password, string login)
        {
            try
            {
                // MessageBox.Show("Creating ---->DataSource started! ...");
                RelationalDataSource objDataSource = new RelationalDataSource();
                //Add Data Source to the Database.
                objDataSource = objDatabase.DataSources.Add(objServer.Databases.GetNewName(strCubeDataSourceName));
                objDataSource.ConnectionString = "Provider=" + strProviderName + ";Data Source=" + strDBServerName + "; Initial Catalog=" + strDBName + ";Persist Security Info=True;Password=" + password + ";User ID=" + login;

                objDataSource.Update();

                return objDataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Creating a DataSource.() Error Message -> " + ex.ToString());
                return null;
            }
        }
        private static object FillDataSet(SqlConnection objConnection, DataSet objDataSet, string strTableName)
        {
            try
            {
                string strCommand = "Select * from " + strTableName;
                SqlDataAdapter objEmpData = new SqlDataAdapter(strCommand, objConnection);
                objEmpData.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                objEmpData.FillSchema(objDataSet, SchemaType.Source, strTableName);

                return objDataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Creating  FillDataSet(). Error Message -> " + ex.ToString());
                return null;
            }
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter you Cube Database Name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

                string za = h.analysiserveursipatched.Databases[0].Cubes[0].DataSource.ConnectionString.ToString();
                int pos = za.IndexOf(";") + 1;
                za = za.Substring(pos, za.Length - pos);
                int pos1 = za.IndexOf(";") + 1;
                za = za.Substring(pos1, za.Length - pos1);
                int pos2 = za.IndexOf("=") + 1;
                za = za.Substring(pos2, za.Length - pos2);
                int pos3 = za.IndexOf(";");
                za = za.Substring(0, pos3);

                foreach (Microsoft.SqlServer.Management.Smo.Database dtfb in h.sqlserveurdispatched.Databases)
                {
                    if (dtfb.Name == za)
                    {
                        h.datawarehousedispatched = dtfb;
                    }

                }

                try
                {
                progressBar1.Show();
                Server objServer = new Server();
                progressBar1.Value = progressBar1.Value + 25;
                string strDBServerName = h.sqlserverdispatching.Name;
                        string strProviderName = "SQLNCLI11.1";
                        string password = h.passwordispatching;

                        string login = h.userdispatching;
                        RelationalDataSource objDataSource = new RelationalDataSource();

                        Database objDatabase = new Database();
                        string strDBName = h.datawarehousedispatched.Name;
                        string strCubeDataSourceName = "OLAPDS";
                        string strCubeDBName = metroTextBox1.Text;
                        DataSourceView objDataSourceView;

                        string strCubeDataSourceViewName = "oapdsw";
                        bool processed = false;
                        objServer = (Server)ConnectAnalysisServices(strDBServerName, strProviderName, password, login);
                        h.analysiserveurdispatching = objServer;

                bool hgf = verifcubeexist(metroTextBox1.Text, h.analysiserveurdispatching);
                if (hgf == true)
                {
                    progressBar1.Value = 0;
                    progressBar1.Hide();
                    MessageBox.Show("This Cube NAME IS ALREADY EXIST TRY TO CHANGE iT ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                objDatabase = (Database)CreateDatabase(objServer, strCubeDBName);
                        Cube newcube;
                        Cube oldcube;
                        Database kn;
                        kn = h.analysiserveursipatched.Databases.FindByName(h.namecubedispatched);
                        oldcube = kn.Cubes[0];
                        objDataSource = (RelationalDataSource)CreateDataSource(objServer, objDatabase, strCubeDataSourceName, strDBServerName, strDBName, strProviderName, password, login);
                progressBar1.Value = progressBar1.Value + 25;
                DataSet newDataSet = new DataSet("NDS");
                        string strFactTableName = oldcube.MeasureGroups[0].Name;
                        string conxString = "Data Source=" + strDBServerName + "; Initial Catalog=" + strDBName + ";Persist Security Info=True;Password=" + password + ";User ID=" + login;
                        SqlConnection objConnection = new SqlConnection(conxString);
                        objConnection.Open();
                        newDataSet = (DataSet)FillDataSet(objConnection, newDataSet, strFactTableName);
                        int intDimensionTableCount = oldcube.Dimensions.Count;

                        for (int i = 0; i < intDimensionTableCount; i++)
                        {
                            newDataSet = (DataSet)FillDataSet(objConnection, newDataSet, oldcube.MeasureGroups[0].Dimensions[i].Dimension.Name);
                        }
                        foreach (DataRelation r in oldcube.DataSourceView.Schema.Relations)
                        {
                            newDataSet.Relations.Add(r.ChildTable.TableName + "_" + r.ParentTable.TableName + "_FK", newDataSet.Tables[r.ParentTable.TableName].Columns[r.ParentColumns[0].ColumnName], newDataSet.Tables[r.ChildTable.TableName].Columns[r.ChildColumns[0].ColumnName]);

                        }
                        objDataSourceView = new DataSourceView();
                        oldcube.DataSourceView.CopyTo(objDataSourceView);
                        objDataSourceView = objDatabase.DataSourceViews.Add(objDatabase.DataSourceViews.GetNewName(strCubeDataSourceViewName));
                        objDataSourceView.DataSourceID = objDataSource.ID;
                        objDataSourceView.Schema = newDataSet;
                        objDataSourceView.Update();
                        Dimension objdimension = new Dimension();
                        for (int i = 0; i < oldcube.Parent.Dimensions.Count; i++)

                        {
                            objdimension = new Dimension();

                            objdimension = objDatabase.Dimensions.Add(oldcube.Parent.Dimensions[i].Name);
                            oldcube.Parent.Dimensions[i].CopyTo(objdimension);

                            objdimension.Source = new DataSourceViewBinding(objDataSourceView.ID);
                            DimensionAttributeCollection objDimensionAttributesColl = oldcube.Parent.Dimensions[i].Attributes;
                            //Add Dimension Attributes
                            DimensionAttribute objAttribute = oldcube.Parent.Dimensions[i].Attributes[0];
                            ////Set Attribute usage and source
                            objAttribute.Usage = AttributeUsage.Key;
                            objdimension.Update();
                        }
                progressBar1.Value = progressBar1.Value + 25;

                newcube = new Cube();

                        newcube = objDatabase.Cubes.Add(metroTextBox1.Text.ToString());
                        oldcube.CopyTo(newcube);
                        newcube.Source = new DataSourceViewBinding(objDataSourceView.ID);



                        newcube.MeasureGroups[0].Partitions[0].Source = new TableBinding(objDataSource.ID, "dbo", newcube.MeasureGroups[0].Name);

                        newcube.Update(UpdateOptions.ExpandFull);

                        objDatabase.Process(ProcessType.ProcessFull);
                        if (objDatabase.State == AnalysisState.Processed)
                        {
                            processed = true;
                    progressBar1.Value = progressBar1.Value + 25;
                    MessageBox.Show("Cube" + metroTextBox1.Text + " dispatching successfully.");
                        }




                }
                catch (Exception ex)
                { MessageBox.Show("Error in delivering cube -> " + ex.ToString()); }
            progressBar1.Value = 0;
            progressBar1.Hide();

        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
           metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton5_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton5_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
}
