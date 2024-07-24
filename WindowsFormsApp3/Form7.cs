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

using Microsoft.AnalysisServices;
using System.Data.SqlClient;
using System.Data.OleDb;
using Server = Microsoft.AnalysisServices.Server;
using Database = Microsoft.AnalysisServices.Database;

namespace WindowsFormsApp3
{
    public partial class Form7 : MetroFramework.Forms.MetroForm
    {
       


        Helper h;
        Form form8;
    
     
        public Form7(Helper h, Form form)
        {
            InitializeComponent();
            this.h = h;
            form8 = form;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            label2.Hide();
            progressBar1.Hide();
        }
    

        private void metroButton1_Click(object sender, EventArgs e)
        {
          
            if (txtbox3.Text =="") { MessageBox.Show("Please enter your cube DataBase name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
           


            try
            {
                progressBar1.Show();
                label2.Show();
                
               label2.Text = "Cube Creation proccessed started.";
                // MessageBox.Show("Cube creation process started.");
                                                                string strDBServerName = h.serv.Name;
                                                               string strProviderName = "SQLNCLI11.1";
                                                                // string strProviderName = h.ProviderName;
                                                                 string strFactTableName = h.factname;
                                                               
                                                                  string strDBName = h.datab.Name;
                                                                  string strCubeDBName = txtbox3.Text;
                                                                  string strCubeDataSourceName = "OLAPDS";
                                                                  string strCubeDataSourceViewName = "OLAPDSView";
                                                                    DataTable dtb1 = h.rela;
                                                                    int intDimensionTableCount = h.dim.Count;
                                                                    

                                                                    string[,] strTableNamesAndKeys = new string[dtb1.Rows.Count, dtb1.Columns.Count];
                                                                     string password = h.password;
                                                                     string login=h.user;

                                        for (int row = 0; row < dtb1.Rows.Count; row++)
                                        {
                                               for (int column = 0; column < dtb1.Columns.Count; column++)
                                               {strTableNamesAndKeys[row, column] = dtb1.Rows[row][column].ToString(); }
                                        }

                                                                             Server objServer = new Server();
                                                                            Database objDatabase = new Database();
                                                                            RelationalDataSource objDataSource = new RelationalDataSource();
                                                                            DataSourceView objDataSourceView = new DataSourceView();
                                                                            DataSet objDataSet = new DataSet();
                                                                            Dimension[] objDimensions = new Dimension[intDimensionTableCount];

                                        /* List<Column>listemes= new List<Column>();
                                         foreach(Column i in h.meas)
                                         { listemes.Add(i); }*/
                                         List<Measure>listemes= new List<Measure>();
                                            foreach ( Measure i in h.chosmeasures)
                                            { listemes.Add(i); }

                List<Table> listdim = new List<Table>();
                foreach (Table t  in h.dim)
                { listdim.Add(t); }


               progressBar1.Value = progressBar1.Value + 25;
                this.Update();
           
              // metroProgressBar1.Value = metroProgressBar1.Value + 25;
              // this.Update();
              //Connecting to the Analysis Services.
                objServer = (Server) ConnectAnalysisServices(strDBServerName, strProviderName, password, login);
              if (objServer != null)
                {

                    
                    label2.Text = "connecting succefully to the analysis services."; 
                    //MessageBox.Show("_***Connecting  succefully to the Analysis Services oooo"); 
                }
           
                  bool hgf = verifcubeexist(txtbox3.Text.ToString(), objServer);
                bool fff = exist(txtbox3.Text.ToString(), objServer);
               if(hgf== false && fff==true)

                {
                    progressBar1.Value = 0;
                    progressBar1.Hide();
                    label2.Hide();
                    return;
                
                }





                //Creating a Database.
                objDatabase = (Database)CreateDatabase(objServer, strCubeDBName);
                if (objDatabase != null) { //MessageBox.Show("_***creating   succefully my database  oooo");

                    h.dbanalysi = objDatabase;
                    label2.Text = "creating succefully database.";
                }
            

                //Creating a DataSource.
                objDataSource = (RelationalDataSource)CreateDataSource(objServer, objDatabase, strCubeDataSourceName, strDBServerName, strDBName,strProviderName, password, login);
                   if (objDataSource != null) { 
                  //  MessageBox.Show("_***creating  succefully my datasource oooo");

                    label2.Text = "creating succefully datasource.";
                }
            
                //Creating a DataSourceView
                objDataSet = (DataSet)GenerateDWSchema(strDBServerName, strDBName, strFactTableName, strTableNamesAndKeys, intDimensionTableCount, password, login);
                 if (objDataSet != null) {
                    //  MessageBox.Show("_***generating succefully my datasourceviewshema  oooo");
                    progressBar1.Value = progressBar1.Value + 25;
                    this.Update();
                    label2.Text = "generating succefully  datasourceviewshema.";
                }
               
             
              //  metroProgressBar1.Value = metroProgressBar1.Value + 25;
               // this.Update();
                objDataSourceView = (DataSourceView)CreateDataSourceView(objDatabase, objDataSource, objDataSet, strCubeDataSourceViewName);
                  if (objDataSourceView != null) { //MessageBox.Show("_***creating  succefully my datasourceview oooo"); 
                    progressBar1.Value = progressBar1.Value + 25;
                    this.Update();
                    label2.Text = "creating succefully datasourceview.";

                }
             
             
              //  metroProgressBar1.Value = metroProgressBar1.Value + 25;
               // this.Update();
                //creating the Dimension, Attribute, Hierarchy, and MemberProperty Objects.                
                objDimensions = (Dimension[])CreateDimension(objDatabase, objDataSourceView, strTableNamesAndKeys, intDimensionTableCount, listdim);
             if (objDimensions != null) {// MessageBox.Show("_***creating  succefully my dimensions oooo");
                    label2.Text = "creating succefully dimensions.";

                }

                
                //Creating the Cube, MeasureGroup, Measure, and Partition Objects.

                CreateCube(objDatabase, objDataSourceView, objDataSource, objDimensions, strFactTableName, strTableNamesAndKeys, intDimensionTableCount, listemes);//jdid******************************
               progressBar1.Value = progressBar1.Value + 25;
                this.Update();
               // metroProgressBar1.Value = metroProgressBar1.Value + 25;
               // this.Update();
                objDatabase.Process(ProcessType.ProcessFull);
                label2.Text = "creating succefully cube.";
                MessageBox.Show("_***creating  succefully my cube oooo");
             
                h.datacubename = txtbox3.Text;
                metroButton3.Hide();
                DialogResult res = MessageBox.Show("Do you want to add calculation to this olap cube press OK or Press cancel to return to the option area", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    this.Hide();
                    Form9 f = new Form9(h);
                    f.Show();
                }
                else
                if (res == DialogResult.Cancel)
                {

                    this.Hide();
                    Form5 f = new Form5(h, this);
                    f.Show();
                }


               
            }
            catch (Exception ex)
            { { MessageBox.Show("Error in buildcube() -> " + ex.ToString()); } }
          
           
        }



   //connecting to the analysis services 
                 public static object ConnectAnalysisServices(string strDBServerName, string strProviderName,string password, string login)
                 {
                     try
                     {
                        // MessageBox.Show("Connecting----> to the Analysis Services started...!!!");

                          Server objServer = new Server();

                          string strConnection = "Data Source=" + strDBServerName + ";Provider=" + strProviderName+";Persist Security Info=True;Password=" +password+ ";User ID="+login;
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

        public bool verifcubeexist(string s, Server objServer)
        {

            foreach (Database db in objServer.Databases)
            {
                    if (db.Name.ToLower().Contains(s.ToLower()))

                    {
                             DialogResult res = MessageBox.Show(" cube database name  " + txtbox3.Text + "  exists are you sure to delete it press OK or press cancel to rename your cube ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    if (res == DialogResult.OK)
                                    {
                       
                                        MessageBox.Show("You have clicked Ok , your cube  " + txtbox3.Text + "   is removed");
                                        db.Drop();
                                        return true;
                                    }
                                    if (res == DialogResult.Cancel)
                                    {
                                                    MessageBox.Show("You have clicked cancel , you must rename your cube data base name");
                                                   return false;
                                         
                                                 
                                          
                                    }
                   
                    }               


            }

        return false;


        }
        public bool exist(string s, Server objServer)
        {
            foreach (Database db in objServer.Databases)
            {
                if (db.Name.ToLower().Contains(s.ToLower()))
                {
                    return true;
                }


            }

            return false;
        }


            // creating database
            private static object CreateDatabase(Server objServer, string strCubeDBName)
                {
                    try
                    { 
                      //  MessageBox.Show("Creating ---->Database started!...");

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




  //creating datasource 
                private static object CreateDataSource(Server objServer, Database objDatabase, string strCubeDataSourceName, string strDBServerName, string strDBName, string strProviderName,string password, string login)
                {
                    try
                    {
                       // MessageBox.Show("Creating ---->DataSource started! ...");
                        RelationalDataSource objDataSource = new RelationalDataSource();
                        //Add Data Source to the Database.
                        objDataSource = objDatabase.DataSources.Add(objServer.Databases.GetNewName(strCubeDataSourceName));
                       objDataSource.ConnectionString = "Provider=" + strProviderName+ ";Data Source=" + strDBServerName + "; Initial Catalog=" + strDBName + ";Persist Security Info=True;Password="+password+ ";User ID="+login;
              
                        objDataSource.Update();

                        return objDataSource;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Creating a DataSource.() Error Message -> " + ex.ToString());
                        return null;
                    }
                }


   //generating datasource view
                private static object GenerateDWSchema(string strDBServerName, string strDBName, string strFactTableName, string[,] strTableNamesAndKeys, int intDimensionTableCount, string password, string login)
                {
                    try
                    {
                       // MessageBox.Show("generating ---->DataSourceView started!...");
                        //Create the connection string.
                        string conxString = "Data Source=" + strDBServerName + "; Initial Catalog=" + strDBName + ";Persist Security Info=True;Password="+password+ ";User ID="+login;
                        //Create the SqlConnection.
                        SqlConnection objConnection = new SqlConnection(conxString);
                        DataSet objDataSet = new DataSet();
                        //Add FactTable in DataSet.
                        objDataSet = (DataSet)FillDataSet(objConnection, objDataSet, strFactTableName);
                        //Add table in DataSet and Relation between them.
                        for (int i = 0; i < intDimensionTableCount; i++)
                        {
                            //Retrieve table's schema and assign the table's schema to the DataSet.
                            //Add primary key to the schema according to the primary key in the tables.
                            objDataSet = (DataSet)FillDataSet(objConnection, objDataSet, strTableNamesAndKeys[i, 0]);
                            objDataSet = (DataSet)AddDataTableRelation(objDataSet, strTableNamesAndKeys[i, 0], strTableNamesAndKeys[i, 1], strTableNamesAndKeys[i, 2], strTableNamesAndKeys[i, 3]);
                        }

                        return objDataSet;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Creating  GenerateDWSchema(). Error Message -> " + ex.ToString());
                        return null;
                    }
                }



   //appel du methode filldataset et adddatatablerelation du methode generatedatasourceview

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
                        private static object AddDataTableRelation(DataSet objDataSet, string strParentTableName, string strParentTableKey, string strChildTableName, string strChildTableKey)
                        {
                            try
                            {
                                objDataSet.Relations.Add(strChildTableName + "_" + strParentTableName + "_FK", objDataSet.Tables[strParentTableName].Columns[strParentTableKey], objDataSet.Tables[strChildTableName].Columns[strChildTableKey]);

                                return objDataSet;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error in Creating a DataSourceView - AddDataTableRelation(). Error Message -> " + ex.ToString());
                                return null;
                            }
                        }


   //creating datasourceview
                    private static object CreateDataSourceView(Database objDatabase, RelationalDataSource objDataSource, DataSet objDataSet, string strCubeDataSourceViewName)
                    {
                        try
                        {
                          //  MessageBox.Show("creating ---->DataSourceview is  started! ...");
                            DataSourceView objDataSourceView = new DataSourceView();
                            //Add Data Source View to the Database.
                            objDataSourceView = objDatabase.DataSourceViews.Add(objDatabase.DataSourceViews.GetNewName(strCubeDataSourceViewName));
                            objDataSourceView.DataSourceID = objDataSource.ID;
                            objDataSourceView.Schema = objDataSet;
                            objDataSourceView.Update();

                            return objDataSourceView;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in Creating a DataSourceView - CreateDataSourceView. Error Message -> " + ex.Message);
                            return null;
                        }
                    }

    //creting dimensions  
    
                    public static object[] CreateDimension(Database objDatabase, DataSourceView objDataSourceView, string[,] strTableNamesAndKeys, int intDimensionTableCount,List<Table> listdim)
                    {
                        try
                        {   
                           // MessageBox.Show("Creating ----> Dimension, Attribute, Hierarchy, and MemberProperty Objects started!...");

                            Dimension[] objDimensions = new Dimension[intDimensionTableCount];
                            for (int i = 0; i < intDimensionTableCount; i++)
                            {
                                objDimensions[i] = (Dimension)GenerateDimension(objDatabase, objDataSourceView, strTableNamesAndKeys[i, 0], strTableNamesAndKeys[i, 1],listdim);
                            }
                            


                            return objDimensions;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in Creating the Dimension(), Attribute, Hierarchy, and MemberProperty Objects. Error Message -> " + ex.ToString());
                            return null;
                        }
                    }
   //appel du methode generate dimensions dans la methode creating dimensions
                        private  static object GenerateDimension(Database objDatabase, DataSourceView objDataSourceView, string strTableName, string strTableKeyName, List<Table> listdim)
                        {
                            try
                            {
                                Dimension objDimension = new Dimension();

                                //Add Dimension to the Database
                                objDimension = objDatabase.Dimensions.Add(strTableName);
                                objDimension.Source = new DataSourceViewBinding(objDataSourceView.ID);
                                DimensionAttributeCollection objDimensionAttributesColl = objDimension.Attributes;

                //Add Dimension Attributes


                DimensionAttribute objAttribute = objDimensionAttributesColl.Add(strTableKeyName);


                //jdid*************************************************************
              

                //jdid*************************************************************


                //Set Attribute usage and source
                objAttribute.Usage = AttributeUsage.Key;

                    
                                        
                                                     if (strTableName.Contains("Calendar"))
                                                     {   
                                                         objAttribute.KeyColumns.Add(strTableName, strTableKeyName, OleDbType.Date);
                                                            objDimension.Type = Microsoft.AnalysisServices.DimensionType.Time;
                                                             
                                                     }
                                                         else
                                                         { objAttribute.KeyColumns.Add(strTableName, strTableKeyName, OleDbType.Integer);

                                                             
                                                         }

                foreach (Microsoft.SqlServer.Management.Smo.Table table in listdim )
                    if (table.Name == strTableName)
                    {
                        foreach (Microsoft.SqlServer.Management.Smo.Column column in table.Columns)
                            if (column.Name != strTableKeyName)
                            {
                                DimensionAttribute attr;
                                attr = objDimension.Attributes.Add(column.Name);
                                attr.KeyColumns.Add(CreateDataItem(objDatabase.DataSourceViews[0], strTableName, column.Name));
                                attr.NameColumn = CreateDataItem(objDatabase.DataSourceViews[0], strTableName, column.Name);

                            }
                    }



                objDimension.Update();
                                return objDimension;

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error in Creating the Dimension Attribute, Hierarchy, and MemberProperty Objects - GenerateDimension(). Error Message -> " + ex.ToString());
                                return null;
                            }
                        }
        static DataItem CreateDataItem(DataSourceView dsv, string tableName, string columnName)
        {
            DataTable dataTable = ((DataSourceView)dsv).Schema.Tables[tableName];
            DataColumn dataColumn = new DataColumn();
            dataColumn = dataTable.Columns[columnName];
            return new DataItem(tableName, columnName);
            // , OleDbTypeConverter.GetRestrictedOleDbType(dataColumn.DataType)
        }

        //create cube
        private  static void CreateCube(Database objDatabase, DataSourceView objDataSourceView, RelationalDataSource objDataSource, Dimension[] objDimensions, string strFactTableName, string[,] strTableNamesAndKeys, int intDimensionTableCount, List<Measure> listemes) //jdid************************************************
                        {
                            try
                            {
                               // MessageBox.Show("Creating ----> Cube, MeasureGroup, Measure, and Partition Objects is started!...");
                                Cube objCube = new Cube();

                                Measure obj1 = new Measure();

               

                                MdxScript objTotal = new MdxScript();
                               String strScript;

                                Partition objPartition = new Partition();
                                Command objCommand = new Command();
                                //Add Cube to the Database and set Cube source to the Data Source View
                                objCube = objDatabase.Cubes.Add("SampleCube");
                                objCube.Source = new DataSourceViewBinding(objDataSourceView.ID);
                                //Add Measure Group to the Cube

                                MeasureGroup objMeasureGroup = objCube.MeasureGroups.Add(strFactTableName);
                                foreach (Measure sss in listemes)
                                { 
                                    obj1 = objMeasureGroup.Measures.Add(sss.Name);
                                    if (sss.DataType.ToString() == "int")
                                    { obj1.Source = new DataItem(strFactTableName, sss.ID, OleDbType.Integer); }
                                    else
                                    { obj1.Source = new DataItem(strFactTableName, sss.ID, OleDbType.Double); }


                                }
                                //Add Measure to the Measure Group and set Measure source
                                      ////Calculated Member Definition
                          


                for (int i = 0; i < intDimensionTableCount; i++)
                                {
                                    GenerateCube(objCube, objDimensions[i], objMeasureGroup, strFactTableName, strTableNamesAndKeys[i, 3]);
                                }


                                objPartition = objMeasureGroup.Partitions.Add(strFactTableName);
                                objPartition.Source = new TableBinding(objDataSource.ID, "dbo", strFactTableName);

                                objPartition.ProcessingMode = ProcessingMode.Regular;
                                objPartition.StorageMode = StorageMode.Molap;
                                //Save Cube and all major objects to the Analysis Services
                                objCube.Update(UpdateOptions.ExpandFull);

                              //jdid*****************************
                               // chainecube=objCube;
                           //jdid**************************************************
                                  
                              
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error in Creating the Cube(), MeasureGroup, Measure, and Partition Objects. Error Message -> " + ex.ToString());
                            }
                        }

    // appel du methode generate cube
                        private static void GenerateCube(Cube objCube, Dimension objDimension, MeasureGroup objMeasureGroup, string strFactTableName, string strTableKey)
                        {
                            try
                            {
                                CubeDimension objCubeDim = new CubeDimension();
                                RegularMeasureGroupDimension objRegMGDim = new RegularMeasureGroupDimension();
                                MeasureGroupAttribute objMGA = new MeasureGroupAttribute();
                                //Add Dimension to the Cube
                                
                                objCubeDim = objCube.Dimensions.Add(objDimension.ID);
               
                                //Use Regular Relationship Between Dimension and FactTable Measure Group
                                objRegMGDim = objMeasureGroup.Dimensions.Add(objCubeDim.ID);
                                //Link TableKey in DimensionTable with TableKey in FactTable Measure Group
                                objMGA = objRegMGDim.Attributes.Add(objDimension.KeyAttribute.ID);

                                objMGA.Type = MeasureGroupAttributeType.Granularity;
                                if (strTableKey.Contains("Date"))
                                {
                                    objMGA.KeyColumns.Add(strFactTableName, strTableKey, OleDbType.Date);
                                }
                                else
                                { objMGA.KeyColumns.Add(strFactTableName, strTableKey, OleDbType.Integer); }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error in Creating the Cube, MeasureGroup, Measure, and Partition Objects - GenerateCube(). Error Message -> " + ex.ToString());
                            }
                        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            form8.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e, string strDBServerName, string strProviderName)
        {

          /*  if (txtbox1.Text == "") { MessageBox.Show("Please enter your Cube Datasource  Name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtbox2.Text == "") { MessageBox.Show("Please enter your Cube Datasource View  Name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (txtbox3.Text == "") { MessageBox.Show("Please enter your Cube Data Base Name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
           


                this.Hide();
            Form8 f = new Form8();
            f.Show();*/

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
          
          
           // if (txtbox3.Text == "") { MessageBox.Show("Please enter your Cube Data Base Name ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

          /*  h.datacubename = txtbox3.Text;
          
       
           

            this.Hide();
            Form9 f = new Form9(h,this);
            f.Show();*/
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.progressBar1.Increment(1);
        }

        private void metroButton1_MouseHover(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.LightGray;
        }

        private void metroButton1_MouseLeave(object sender, EventArgs e)
        {
            metroButton1.BackColor = Color.Gainsboro;
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to close your program", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            { Environment.Exit(0); }
            else
            if (res == DialogResult.Cancel)
            { e.Cancel = true; }
        }

        private void metroButton2_MouseHover(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.LightGray;
        }

        private void metroButton2_MouseLeave(object sender, EventArgs e)
        {
            metroButton3.BackColor = Color.Gainsboro;
        }

        private void metroButton2_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///C:/Users/mednour/Desktop/test/html/en/dark/index.html");
        }
    }
}
