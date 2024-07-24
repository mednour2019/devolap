using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// lel measure nour
//using Microsoft.AnalysisServices.AdomdClient;
// lel measure nour

//using Server = Microsoft.AnalysisServices.Server;
using Microsoft.AnalysisServices;
using Server = Microsoft.SqlServer.Management.Smo.Server;
using Database = Microsoft.SqlServer.Management.Smo.Database;
using Microsoft.AnalysisServices;




namespace WindowsFormsApp3
{
    public  class Helper
    {     // identifier les attributs utilises  
        public SqlConnection cnx{ get; set; }
        public Server serv { get; set; }

        public string user { get; set; }
        public string password { get; set; }
        public Database  datab { get; set; }
        public List<Table> tab { get; set; }
        public List<Table> fact { get; set; }
        public List<Table> dim { get; set; }
        public DataTable rela { get; set; }
        public string factname { get; set; }
        public string datacubename { get; set; }
   
        public DataTable tabmesure { get; set; }
        public DataTable tabcalculations { get; set; }
        // annalysis services 
        public Microsoft.AnalysisServices.Database dbanalysi;
      
        // annalysis services 

        //public List<Column>meas { get; set; }
        public string ProviderName { get; set; }
        public List<Measure> measures { get; set; }
        public List<Measure> chosmeasures { get; set; }
        //   public List<String> chaine { get; set; }
        public Cube resultcube { get; set; }

        // cube li besh nmodifi fih parametres mta3 calculation
        public string  cubemodif { get; set; }
        public Microsoft.AnalysisServices.Server serrr { get; set; }
        public Microsoft.AnalysisServices.Database dbmodcube { get; set; }
        //cube li besh nmodifi fih parametres mta3 calculation

        //cubedispatched

        public string namecubedispatched { get; set; }
        public Microsoft.SqlServer.Management.Smo.Server sqlserveurdispatched { get; set; }
        public Microsoft.AnalysisServices.Server analysiserveursipatched { get; set; }
        public Microsoft.SqlServer.Management.Smo.Server sqlserverdispatching { get; set; }
        public Microsoft.AnalysisServices.Server analysiserveurdispatching { get; set; }
        public string userdispatching { get; set; }
        public string passwordispatching { get; set; }

        public Microsoft.SqlServer.Management.Smo.Database datawarehousedispatching { get; set; }
        public Microsoft.SqlServer.Management.Smo.Database datawarehousedispatched { get; set; }



        //cubedispatched

        // Constructeur
        public Helper(SqlConnection cnx, Server serv, Database datb, List<Table> tab,string user,string password, List<Table> fact, List<Table>dim , DataTable rela)
         { this.cnx = cnx;
            this.serv = serv;
            this.datab = datab;
            this.user = user;
            this.password = password;
            this.fact = fact;
            this.dim = dim;
            this.rela = rela;
            
        }
        //constructeu vide
        public Helper()
        {
        }

        // methode pour identifier ma connexion :----> avec serveur+login+password
        public bool testconnc(string cn)
        {
            cnx = new SqlConnection(cn);
            this.cnx = cnx;
            if (cnx.State == System.Data.ConnectionState.Closed)
                cnx.Open();
            return true;


        }


        // methode pour verifier les measures
        public bool exist(Column cc)
        {
            
          
            foreach ( Table st in tab)
            {
                        
                if (st.Columns[0].Name == cc.Name)
               // if(st.Columns[0].InPrimaryKey==cc.IsForeignKey)
                { return true;}
                        
      
            }
            return false;
        }

        // methode pour verifier le vrai fac
        public bool verifmodeldat()
        {
            int yu = 0;
            foreach (Table t in datab.Tables)
            {

             /*   foreach (ForeignKey i in t.ForeignKeys)
                {

                    MessageBox.Show(i.ToString());
                }*/

                foreach (Column ta in t.Columns)
                {
                    if (ta.IsForeignKey == true )
                        //  MessageBox.Show(ta+"---- yes");
                        yu++;
                
                }

            }


            string conx = string.Format("Data Source={0};Initial Catalog={1}; User ID={2};Password={3};", serv.Name, datab.Name, user, password);


            using (SqlConnection k = new SqlConnection(conx))
            {
                SqlDataAdapter sqlda3 = new SqlDataAdapter(
                           "  SELECT tab2.name as Dim_Table," +
                           " col2.name as Prim_Key," +
                           " tab1.name as Fact_Tab," +
                           " col1.name as Forei_Key" +
                           " from sys.foreign_key_columns fkc" +
                            " INNER JOIN sys.tables tab1" +
                             " ON tab1.object_id = fkc.parent_object_id" +
                             " INNER JOIN sys.columns col1" +
                             " ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id" +
                             " INNER JOIN sys.tables tab2" +
                              " ON tab2.object_id = fkc.referenced_object_id" +
                               " INNER JOIN sys.columns col2" +
                                " ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id", k);

                DataTable dtb2 = new DataTable();
                sqlda3.Fill(dtb2);
                  if (dtb2.Rows.Count == 0)
                  {
                      return false; 
                  }
                foreach (DataRow row2 in dtb2.Rows)
                {
              //  if (row2["Fact_Tab"].ToString() == null && row2["Prim_Key"].ToString() != row2["Forei_Key"].ToString())

              //  { return false; }

                if ((yu == dtb2.Rows.Count) && memefact(row2["Fact_Tab"].ToString(),dtb2)==true )
                { return true; }

                }

            }
            return false; 
           


        }
        public bool memefact(string fact, DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r["Fact_Tab"].ToString()!= fact.ToString())
                    return false ;
            }

            return true; 
        }

        public bool verifchoixutlsateu( CheckedListBox.CheckedItemCollection listechoix)
        {
            string conx = string.Format("Data Source={0};Initial Catalog={1}; User ID={2};Password={3};", serv.Name, datab.Name, user, password);
            DataTable dtb2 = new DataTable();

            using (SqlConnection k = new SqlConnection(conx))
            {
                SqlDataAdapter sqlda3 = new SqlDataAdapter(
                           "  SELECT tab2.name as Dim_Table," +
                           " col2.name as Prim_Key," +
                           " tab1.name as Fact_Tab," +
                           " col1.name as Forei_Key" +
                           " from sys.foreign_key_columns fkc" +
                            " INNER JOIN sys.tables tab1" +
                             " ON tab1.object_id = fkc.parent_object_id" +
                             " INNER JOIN sys.columns col1" +
                             " ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id" +
                             " INNER JOIN sys.tables tab2" +
                              " ON tab2.object_id = fkc.referenced_object_id" +
                               " INNER JOIN sys.columns col2" +
                                " ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id", k);

            
                sqlda3.Fill(dtb2);
                foreach (DataRow row2 in dtb2.Rows)
                {
                    foreach (Table t in listechoix)
                    {
                        if (row2["Fact_Tab"].ToString() ==t.Name )
                        { return true; }
                    }
                

                }
            
            }
       

            for (int oi=0;oi <dtb2.Rows.Count;oi++)
            {
               
                MessageBox.Show("Please your forgot to choice your fact table  " + dtb2.Rows[oi]["Fact_Tab"].ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
            return false;
        }

            public bool verifact(Table t)
        {
           
            string conx = string.Format("Data Source={0};Initial Catalog={1}; User ID={2};Password={3};", serv.Name, datab.Name, user, password);
          

                


                        using (SqlConnection k = new SqlConnection(conx))
                        {
                            SqlDataAdapter sqlda2 = new SqlDataAdapter(
                            "  SELECT tab2.name as Dim_Table," +
                            " col2.name as Prim_Key," +
                            " tab1.name as Fact_Tab," +
                            " col1.name as Forei_Key" +
                            " from sys.foreign_key_columns fkc" +
                             " INNER JOIN sys.tables tab1" +
                              " ON tab1.object_id = fkc.parent_object_id" +
                              " INNER JOIN sys.columns col1" +
                              " ON col1.column_id = parent_column_id AND col1.object_id = tab1.object_id" +
                              " INNER JOIN sys.tables tab2" +
                               " ON tab2.object_id = fkc.referenced_object_id" +
                                " INNER JOIN sys.columns col2" +
                                 " ON col2.column_id = referenced_column_id AND col2.object_id = tab2.object_id", k);
                            DataTable dtb1 = new DataTable();
                            sqlda2.Fill(dtb1);

                            foreach (DataRow row in dtb1.Rows)
                            {
                                if (row["Fact_Tab"].ToString() != t.Name)
                                {
                        MessageBox.Show(t.Name + "  is not real fact! please you must check your fact table  " + row["Fact_Tab"].ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    
                                }

                            }
                              
                        }

              


            
        return true ;


        }


        //connect to the analysis services

       
        public Microsoft.AnalysisServices.Server ConnectAnalysisServices2()
        {
            try
            {


                Microsoft.AnalysisServices.Server  servanalysi = new Microsoft.AnalysisServices.Server();
                ProviderName = "SQLNCLI11.1";
                string strConnection = "Data Source=" + serv.Name + ";Provider=" + ProviderName + ";Persist Security Info=True;Password=" + password + ";User ID=" + user;
                //Disconnect from current connection if it's currently connected.
                if (servanalysi.Connected)
                    servanalysi.Disconnect();
                else
                    servanalysi.Connect(strConnection);

                return servanalysi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connecting to the Analysis Services(). Error Message -> " + ex.Message);
                return null;
            }
        }
        // tester if calcul existe doccurence superieur a 2 ou non dans from10 et form9
        public bool existcalcul(string ch,DataTable tab1)
        { 
            int n = 0;
            foreach (DataRow r in tab1.Rows)
            {
                if (ch.ToLower() ==r["calculationname"].ToString().ToLower())
                {
                    n++;
                }
            }
            if (n > 1)
            { return true; }
            else
            {
                return false;
            }


            }
        public bool exist2cal(string ch, DataTable tab1)
        {
           
            foreach (DataRow r in tab1.Rows)
            {
                if (ch.ToLower() == r["calculationname"].ToString().ToLower())
                {
                    return true;
                }
            }
            return false;


        }





    }
}
