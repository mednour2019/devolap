using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.SqlServer.Management.Smo;
using Microsoft.AnalysisServices;
using System.Data.SqlClient;
using System.Data.OleDb;
using Server = Microsoft.AnalysisServices.Server;
using Database = Microsoft.AnalysisServices.Database;
using System.Collections.ObjectModel;

namespace WindowsFormsApp3
{
    public partial class Form12 : MetroFramework.Forms.MetroForm
    {
        Helper h;
        Form form11;
        DataGridViewComboBoxColumn cbx; 
        DataGridViewTextBoxColumn txt;
       List<Microsoft.SqlServer.Management.Smo.Database> Listdatabases= new List<Microsoft.SqlServer.Management.Smo.Database>();

        public Form12(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form11 = form;

        }


        private void Form12_Load(object sender, EventArgs e)
        {
            h.sqlserveurdispatched = h.serv;

            metroTextBox2.Text = h.namecubedispatched;
            foreach (Microsoft.AnalysisServices.Database dba in h.analysiserveursipatched.Databases)
            {
                foreach (Cube cer in dba.Cubes)

                {
                    metroTextBox3.Text = cer.Name.ToString() ;
                }
                
            }


            foreach (Microsoft.SqlServer.Management.Smo.Database k in h.sqlserverdispatching.Databases)
            {

                Listdatabases.Add(k);
            }
            cbx = new DataGridViewComboBoxColumn();
            cbx.DataSource = Listdatabases;
          

            cbx.ValueMember = "Name";
            cbx.DisplayMember = "Name";





            cbx.HeaderText = "datawarehouse";
            cbx.Name = "combo";


           // cbx.MaxDropDownItems = 4;
          

            dataGridView1.Columns.Add(cbx);



            txt = new DataGridViewTextBoxColumn();
            txt.HeaderText = "cubename";
            txt.Name = "txtcom";
            dataGridView1.Columns.Add(txt);

            DataGridViewButtonColumn dbtn = new DataGridViewButtonColumn();
            dbtn.HeaderText = "Action";
            dbtn.Name = "Action";
            dbtn.UseColumnTextForButtonValue = true;
            dbtn.Text ="CopyCube";
            
           
          
            dataGridView1.Columns.Add(dbtn);

            progressBar1.Hide();
            

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            form11.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           // foreach (DataGridViewRow row in dataGridView1.Rows)
           // {
              /*  if (row.Cells[0].Value==null)
                {
                    MessageBox.Show("Choose your dtawarehouse", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

                }

                if (row.Cells[1].Value==null)
                {
                    MessageBox.Show("Enter your cube database name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

                }*/


              /*  string za= h.analysiserveursipatched.Databases[0].Cubes[0].DataSource.ConnectionString.ToString();
                int pos = za.IndexOf(";")+1;
                za = za.Substring(pos, za.Length - pos);
                int pos1 = za.IndexOf(";") + 1;
                za = za.Substring(pos1, za.Length - pos1);
                int pos2 = za.IndexOf("=") + 1;
                za = za.Substring(pos2, za.Length - pos2);
                int pos3 = za.IndexOf(";");
                za = za.Substring(0,pos3);
              

                foreach (Microsoft.SqlServer.Management.Smo.Database dtfb in h.sqlserveurdispatched.Databases)
                {      if (dtfb.Name == za)
                        {
                        h.datawarehousedispatched = dtfb;
                        }

                }

                foreach (Microsoft.SqlServer.Management.Smo.Database kk in h.sqlserverdispatching.Databases)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        if (kk.Name == row.Cells["combo"].Value.ToString())
                        {

                            h.datawarehousedispatching = kk;
                        }
                    }

                }



                // int somme = dataGridView1.Rows.Count-2;



                /* foreach (Microsoft.SqlServer.Management.Smo.Table t2 in h.datawarehousedispatched.Tables)
                  {


                      if((verifexist(t2, h.datawarehousedispatching.Tables) == false)) //&& (row.Index==somme))
                      {
                          MessageBox.Show(h.datawarehousedispatching.Name + " et " + h.datawarehousedispatched.Name + " dont have the same relationnal model ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                      }
                     if ((verifexist(t2, h.datawarehousedispatching.Tables) == false) && (row.Index != somme))
                      {
                          MessageBox.Show(h.datawarehousedispatching.Name + " et " + h.datawarehousedispatched.Name + " dont have the same relationnal model  *****222", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                          break;


                      }
                  }*/

               /* if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {

                    bool dfer = exitver(h.datawarehousedispatched.Tables, h.datawarehousedispatching.Tables);
                    if (dfer == false)
                    { MessageBox.Show(h.datawarehousedispatching.Name + " et " + h.datawarehousedispatched.Name + " dont have the same relationnal model ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                    
                }
                
                var cell = row.Cells[1].Value;
                var cel0 = row.Cells[0].Value;
               


                    if (cell != null && cel0 != null && exitver(h.datawarehousedispatched.Tables, h.datawarehousedispatching.Tables)==true)
                    {


                        // Microsoft.SqlServer.Management.Smo.Database k = (Microsoft.SqlServer.Management.Smo.Database)row.Cells[0].Value;





                        try
                        {
                            MessageBox.Show("dispatching  cube" + row.Cells["txtcom"].Value.ToString() + " is  started.");

                            Server objServer = new Server();

                            string strDBServerName = h.sqlserverdispatching.Name;

                            string strProviderName = "SQLNCLI11.1";

                            string password = h.passwordispatching;

                            string login = h.userdispatching;

                            RelationalDataSource objDataSource = new RelationalDataSource();

                            Database objDatabase = new Database();

                            string strDBName = h.datawarehousedispatching.Name;

                            string strCubeDataSourceName = "OLAPDS";

                            string strCubeDBName = row.Cells["txtcom"].Value.ToString();
                            // string strCubeDataSourceViewName = "OLAPDSv";
                            DataSourceView objDataSourceView;
                            // string strFactTableName = h.factname;
                            string strCubeDataSourceViewName = "oapdsw";
                            bool processed = false;



                            objServer = (Server)ConnectAnalysisServices(strDBServerName, strProviderName, password, login);

                            //  if (objServer != null)
                            // {// MessageBox.Show("_***Connecting  succefully to the Analysis Services oooo");
                            h.analysiserveurdispatching = objServer;

                            // }


                            objDatabase = (Database)CreateDatabase(objServer, strCubeDBName);
                            // if (objDatabase != null)
                            // {MessageBox.Show("_***creating   succefully my database  oooo");}


                            Cube newcube;

                            Cube oldcube;


                            // newcube = objDatabase.Cubes.Add(metroTextBox1.Text.ToString());

                            Database kn;




                            kn = h.analysiserveursipatched.Databases.FindByName(h.namecubedispatched);

                            oldcube = kn.Cubes[0];
                            //  oldcube.CopyTo(newcube);


                            objDataSource = (RelationalDataSource)CreateDataSource(objServer, objDatabase, strCubeDataSourceName, strDBServerName, strDBName, strProviderName, password, login);
                            //if (objDataSource != null) { MessageBox.Show("_***creating  succefully my datasource oooo"); }


                            DataSet newDataSet = new DataSet("NDS");

                            string strFactTableName = oldcube.MeasureGroups[0].Name;
                            //newcube.DataSourceView.DataSourceID = newcube.DataSource.ID;

                            // List<object> j = new List<object>();
                            // List <DataRelation> l = new List <DataRelation>();
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

                            // objDataSourceView = oldcube.DataSourceView;
                            objDataSourceView = new DataSourceView();
                            oldcube.DataSourceView.CopyTo(objDataSourceView);
                            objDataSourceView = objDatabase.DataSourceViews.Add(objDatabase.DataSourceViews.GetNewName(strCubeDataSourceViewName));
                            objDataSourceView.DataSourceID = objDataSource.ID;
                            objDataSourceView.Schema = newDataSet;
                            objDataSourceView.Update();

                            Dimension objdimension = new Dimension();

                            for (int i = 0; i < oldcube.Parent.Dimensions.Count; i++)
                            // foreach (Dimension d in oldcube.Parent.Dimensions)
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




                            newcube = new Cube();

                            newcube = objDatabase.Cubes.Add(row.Cells["txtcom"].Value.ToString());
                            oldcube.CopyTo(newcube);
                            newcube.Source = new DataSourceViewBinding(objDataSourceView.ID);



                            newcube.MeasureGroups[0].Partitions[0].Source = new TableBinding(objDataSource.ID, "dbo", newcube.MeasureGroups[0].Name);

                            newcube.Update(UpdateOptions.ExpandFull);

                            objDatabase.Process(ProcessType.ProcessFull);
                            if (objDatabase.State == AnalysisState.Processed)
                            {
                                processed = true;

                                MessageBox.Show("Cube" + row.Cells["txtcom"].Value.ToString() + " dispatching successfully.");
                            }


                        }
                        catch (Exception ex)
                        {
                            { MessageBox.Show("Error in delivering cube -> " + ex.ToString()); }
                        }
                    }*/
                

            //}
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
        private static bool verifexist(Microsoft.SqlServer.Management.Smo.Table tab,Microsoft.SqlServer.Management.Smo.TableCollection mestables)
        {
            foreach (Microsoft.SqlServer.Management.Smo.Table tt in mestables)
            {

                if (tt.Name.ToLower() == tab.Name.ToLower())
                {
                    return true;
                }


            }

                return false;
        }
        private static bool exitver(Microsoft.SqlServer.Management.Smo.TableCollection mestablesdispatched, Microsoft.SqlServer.Management.Smo.TableCollection mestablesdispatching)
        {

            int i = 0;
            int somme = mestablesdispatched.Count - 1;
            foreach (Microsoft.SqlServer.Management.Smo.Table tabed in mestablesdispatched)
            {
            
                if ((mestablesdispatching[i].Name == tabed.Name))   // &&(i > mestablesdispatched.Count-1) )
                {
                    i++;
                    if (i >= somme)


                    {
                        return true;
                    }

                  
                }

                
            }

            return false;
            
        }

        public bool verifcubeexist(string s, Microsoft.AnalysisServices.Server serv)
        {

            foreach (Database db in serv.Databases)
            {
                if (db.Name.ToLower().Equals(s.ToLower()))

                {
                    /*  DialogResult res = MessageBox.Show(" cube database name  " + s+ "  exists Are you sure you want to Delete press OK or  press CANCEL to rename your cube ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                      if (res == DialogResult.OK)
                      {

                          MessageBox.Show("You have clicked Ok Button, your cube  " + s+ "   is removed");
                       //   db.Drop();
                          return true;
                      }
                       if (res == DialogResult.Cancel)
                        {
                            MessageBox.Show("You have clicked Cancel Button, you must rename your cube data base name");
                            return false;



                        }*/
                    return true;
                 

                }
             


            }
            return false;
         

        }
        public bool existe2(string s, Microsoft.AnalysisServices.Server serv2)
        {
            foreach (Database db in serv2.Databases)
            {
                if (db.Name.ToLower().Contains(s))
                {
                    return true;
                }


            }

            return false;
        }



        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
          
           /* foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[1].Value;
                var cel0 = row.Cells[0].Value;
                string k;
                if (cell != null &&cel0!=null)
                { 
                    MessageBox.Show(row.Cells["combo"].Value.ToString());
                   // k = row.Cells["combo"].Value.ToString();

                    /* int h = k.IndexOf('[')+1;

                     k = k.Substring(h,k.Length-h);
                    int l = k.IndexOf(']');
                    k = k.Substring(0, l);
              
                    MessageBox.Show(k);


                    MessageBox.Show(row.Cells["txtcom"].Value.ToString());
                }
            }*/
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            

        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
          
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {

                        int selectedRowIndex = e.RowIndex;

                        DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Choose your datawarehouse", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

                }
                if (row.Cells[1].Value == null)
                {
                    MessageBox.Show("Enter your cube database name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

                }

               

                //  MessageBox.Show("you have clicked button  "+ e.RowIndex.ToString());
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

                        foreach (Microsoft.SqlServer.Management.Smo.Database kk in h.sqlserverdispatching.Databases)
                        {
                           if (kk.Name == row.Cells["combo"].Value.ToString())
                           {  h.datawarehousedispatching = kk;}
                        }
                    foreach (Microsoft.SqlServer.Management.Smo.Table t2 in h.datawarehousedispatched.Tables)
                    {


                        if ((verifexist(t2, h.datawarehousedispatching.Tables) == false))
                        {
                            MessageBox.Show(h.datawarehousedispatching.Name + " et " + h.datawarehousedispatched.Name + " dont have the same relationnal model ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                        }
                    }
             

                try
                        {
                    progressBar1.Show();

                    //   MessageBox.Show("dispatching  cube   " +  row.Cells["txtcom"].Value.ToString() + "    is  started.");

                    Server objServer = new Server();

                                string strDBServerName = h.sqlserverdispatching.Name;

                                string strProviderName = "SQLNCLI11.1";

                                string password = h.passwordispatching;

                                string login = h.userdispatching;

                                RelationalDataSource objDataSource = new RelationalDataSource();

                                Database objDatabase = new Database();

                                string strDBName = h.datawarehousedispatching.Name;

                                string strCubeDataSourceName = "OLAPDS";

                                string strCubeDBName = row.Cells["txtcom"].Value.ToString();
                                
                                DataSourceView objDataSourceView;
                                
                                string strCubeDataSourceViewName = "oapdsw";
                                bool processed = false;


                                objServer = (Server)ConnectAnalysisServices(strDBServerName, strProviderName, password, login);
                                h.analysiserveurdispatching = objServer;
                    progressBar1.Value = progressBar1.Value + 25;

                    bool hgf = verifcubeexist(row.Cells["txtcom"].Value.ToString(), h.analysiserveurdispatching);
                               // bool fff = existe2(row.Cells["txtcom"].Value.ToString(), h.analysiserveurdispatching);
                                if (hgf == true)
                                {
                        progressBar1.Value = 0;
                        progressBar1.Hide();
                        MessageBox.Show("This cube name is already exist!!try to change it  ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
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

                                    newcube = objDatabase.Cubes.Add(row.Cells["txtcom"].Value.ToString());
                                    oldcube.CopyTo(newcube);
                                    newcube.Source = new DataSourceViewBinding(objDataSourceView.ID);



                                    newcube.MeasureGroups[0].Partitions[0].Source = new TableBinding(objDataSource.ID, "dbo", newcube.MeasureGroups[0].Name);

                                    newcube.Update(UpdateOptions.ExpandFull);

                                    objDatabase.Process(ProcessType.ProcessFull);
                                    if (objDatabase.State == AnalysisState.Processed)
                                    {
                                        processed = true;
                        progressBar1.Value = progressBar1.Value + 25;
                       // label1.Text = "Cube" + row.Cells["txtcom"].Value.ToString() + " dispatching successfully.";
                        MessageBox.Show("Cube" + row.Cells["txtcom"].Value.ToString() + " dispatched  successfully.");
                        row.ReadOnly = true;
                        
                

                        //  row.ReadOnly = true;













                    }
 


                        }
                        catch (Exception ex)
                        { MessageBox.Show("Error in delivering cube -> " + ex.ToString()); } 




            }
            progressBar1.Value = 0;
            progressBar1.Hide();
            
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton2_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton2_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
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
