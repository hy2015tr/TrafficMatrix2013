using System;
using System.Linq;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Data.EntityClient;
using System.Collections.Generic;
using System.Data;


namespace TrafficMatrix2013
{

    #region //----------- AlfaDS -----------//

    //===============================================================================//

    public class alfaDS : IDisposable
    {
        // Context
        public Entities Context = null;

        // ConnStr
        public static string m_ConnStr = null;

        //--------------------------------------------------------------------//

        public alfaDS()
        {
            if (alfaDS.m_ConnStr == null)
            {
                // Get Connection
                alfaDS.m_ConnStr = alfaEntity.ConnStr_DeCrypt();

                if (alfaDS.m_ConnStr == null)
                {
                    // Message
                    alfaMsg.Error("ERROR = ORACLE ConnectionString is Not Valid ...!");

                    // Close Application
                    System.Environment.Exit(1);
                }
            }

            // Create Entity Context
            this.Context = new Entities();

            // Disable LazyLoading
            this.Context.Configuration.LazyLoadingEnabled = false;

            // Create Connection
            alfaConStr p_Connection = new alfaConStr(alfaDS.m_ConnStr);

            // Set Connection String 
            this.Context.Database.Connection.ConnectionString = p_Connection.sbDB.ConnectionString;
        }

        //--------------------------------------------------------------------//

        public alfaDS(string p_ConnStr)
        {
            // Create Entity Context
            this.Context = new Entities();

            // Disable LazyLoading
            this.Context.Configuration.LazyLoadingEnabled = false;

            // Create Connection
            alfaConStr p_Connection = new alfaConStr(p_ConnStr);

            // Set Connection String 
            this.Context.Database.Connection.ConnectionString = p_Connection.sbDB.ConnectionString;
        }

        //--------------------------------------------------------------------//

        public void Dispose()
        {
            // Dispose
            this.Context.Dispose();
        }

        //--------------------------------------------------------------------//
    }

    //===============================================================================//


    # endregion 



    #region //-----------alfaConStr---------//


    class alfaConStr
    {
        // SB SQLConnection
        public DbConnectionStringBuilder sbDB = new DbConnectionStringBuilder();
        
        // SB EntityConnection
        public EntityConnectionStringBuilder sbENT = new EntityConnectionStringBuilder();

        // Password
        public string Password
        {
            get
            {
                return sbDB["Password"].ToString();
            }
            set
            {
                this.sbDB["Password"] = value;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public alfaConStr(string p_ConStr)
        {
            // ENT Connection
            this.sbENT.ConnectionString = p_ConStr;

            // DB Connection
            this.sbDB.ConnectionString = this.sbENT.ProviderConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetPassword(string p_Password)
        {
            // Set Password
            this.sbDB["Password"] = p_Password;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetTimeOut(string p_TimeOut)
        {
            // Set DataSourxe
            this.sbDB["Connection Timeout"] = p_TimeOut;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetDataSource(string p_DataSource)
        {
            // Set DataSourxe
            this.sbDB["Data Source"] = p_DataSource;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetClearPassword()
        {
            // Set Clear Password
            this.Password = alfaSec.DeCrypt(this.Password);

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetEncryptedPassword()
        {
            // Set Encrypted Password
            this.Password = alfaSec.EnCrypt(this.Password);

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public string GetClearPassword()
        {
            // Get Encrypted Password
            string p_Password = this.sbDB["Password"].ToString();

            // Return Decrypted Password
            return alfaSec.DeCrypt(p_Password);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public string GetPassword()
        {
            // Return Password
            return this.sbDB["Password"].ToString();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }

    # endregion 


       
    #region //-----------alfaEntity---------//

    class alfaEntity
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_CONFIG> m_SamConfigList = null;
        
        public static string EntityObjectName = "Entities";

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool UpdateUserPassword(string p_User, string p_PassOld, string p_PassNew)
        {
            try
            {
                using (alfaDS ent = new alfaDS())
                {
                    // CursorWait
                    alfaMsg.CursorWait();

                    // Query
                    var qry = from tt in ent.Context.SAM_USER
                              where tt.USERNAME == p_User
                                 && tt.PASSWORD == p_PassOld
                              select tt;

                    List<SAM_USER> tbUser = qry.ToList();

                    // CursorDefult
                    alfaMsg.CursorDefult();

                    // Check User
                    if (tbUser.Count == 0)
                    {
                        alfaMsg.Error("Old Password is Incorrect ...!"); return false;
                    }

                    // Set New Password
                    tbUser[0].PASSWORD = p_PassNew;

                    // Save
                    ent.Context.SaveChanges();

                    // Sucess
                    alfaMsg.Info("Yave have Successfully Changed Your Password ...!");  return true;
                }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool CheckUserLogin(string p_User, string p_Pass)
        {
            using (alfaDS DS = new alfaDS())
            {
                // CursorWait
                alfaMsg.CursorWait();

                // Query
                var qry = from tt in DS.Context.SAM_USER
                          where tt.USERNAME == p_User
                             && tt.ACTIVE == "Y"
                          select new { tt.SAM_GROUP, tt.ADMIN, tt.EMAIL, tt.FULLNAME, tt.PASSWORD };

                var tbUser = qry.ToList();

                // CursorDefult
                alfaMsg.CursorDefult();

                // Check User
                if (tbUser.Count == 0)
                {
                    alfaMsg.Error("User Name Could not be Found  ...!"); return false;
                }

                // Check Pass
                else if (tbUser[0].PASSWORD != p_Pass)
                {
                    alfaMsg.Error("You Entered Wrong Password ...!"); return false;
                }

                // Set GroupName
                alfaSession.Group = tbUser[0].SAM_GROUP.NAME;
                alfaSession.Admin = (tbUser[0].ADMIN == "Y");
                alfaSession.FullName = tbUser[0].FULLNAME;
                alfaSession.Email = tbUser[0].EMAIL;

                // Return
                return true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string GetUserEmail(string p_UserName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_USER
                          where tt.USERNAME == p_UserName
                          select tt;

                if (qry.Count() != 1) return null; else return qry.First().EMAIL;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static dynamic TableUser_GetList(int? p_ID, string p_Active)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_USER
                          select new
                          {
                              tt.ID,
                              tt.USERNAME,
                              tt.PASSWORD,
                              tt.FULLNAME,
                              tt.EMAIL,
                              GROUP = tt.SAM_GROUP.NAME,
                              tt.ADMIN,
                              tt.ACTIVE,
                          };

                // Optional Prm1
                if (p_ID != null) qry = qry.Where(tt => tt.ID == p_ID);

                // Optional Prm2
                if (p_Active != null) qry = qry.Where(tt => tt.ACTIVE == p_Active);

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static SAM_GROUP TableGroup_Get(string p_Name)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_GROUP
                          where tt.NAME == p_Name
                          select tt;

                // Return
                return qry.First();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_GROUP> TableGroup_GetList(int? p_ID, string p_Active)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_GROUP select tt;

                // Optional Prm1
                if (p_ID != null) qry = qry.Where(tt => tt.ID == p_ID);

                // Optional Prm2
                if (p_Active != null) qry = qry.Where(tt => tt.ACTIVE == p_Active);

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_PRMS> TablePrms_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_PRMS select tt;

                // Return
                return qry.OrderBy(tt => tt.NAME).ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_CONFIG> TableConfig_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_CONFIG select tt;

                // Return
                return qry.OrderBy(tt => tt.NAME).ThenBy(tt => tt.LOCATION).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TablePrms_SetAppValue(string p_Name, ref string p_Variable)
        { 
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_PRMS 
                          where tt.NAME == p_Name
                          select tt;

                // Set Variable
                if (qry.Count() == 1) p_Variable = qry.First().VALUE;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TablePrms_SetDBValue(string p_Name, string p_Value)
        { 
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_PRMS 
                          where tt.NAME == p_Name
                          select tt;

                // Set Variable
                if (qry.Count() == 1) qry.First().VALUE = p_Value;

                // Save
                DS.Context.SaveChanges();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_LOG> TableLog_GetList(DateTime p_Start, DateTime p_Finish)
        {
            // Get Dates
            string p_Date1 = alfaDate.GetDate_V5(p_Start);
            string p_Date2 = alfaDate.GetDate_V5(p_Finish);

            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_LOG
                          where tt.DT_PERIOD1.CompareTo(p_Date1) >= 0
                             && tt.DT_PERIOD2.CompareTo(p_Date2) <= 0
                          select tt;

                // Return
                return qry.OrderByDescending(tt => tt.ID).ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_DATA_C> SAM_GetList_CC(DateTime p_Start, DateTime p_Finish)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_C
                          where tt.DT_WIN >= p_Start
                             && tt.DT_WIN <= p_Finish
                          orderby tt.ADR_SOURCE ascending, tt.ADR_TARGET ascending, tt.DT_WIN ascending
                          select tt;

                // Return
                return qry.ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_DATA_D> SAM_GetList_DD(DateTime p_Start, DateTime p_Finish)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_D
                          where tt.DT_WIN >= p_Start
                             && tt.DT_WIN <= p_Finish
                          orderby tt.ADR_SOURCE ascending, tt.ADR_TARGET ascending, tt.DT_WIN ascending
                          select tt;

                // Return
                return qry.ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<SAM_DATA_S> SAM_GetList_SS(DateTime p_Start, DateTime p_Finish)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_S
                          where tt.DT_WIN >= p_Start
                             && tt.DT_WIN <= p_Finish
                          orderby tt.ADR_SOURCE ascending, tt.ADR_TARGET ascending, tt.DT_WIN ascending
                          select tt;

                // Return
                return qry.ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string SAM_Get_Name(string p_Location)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in alfaEntity.m_SamConfigList
                          where  p_Location.ToUpper(new System.Globalization.CultureInfo("en-US")).Contains(tt.LOCATION)
                          select tt;

                // Return
                if (qry.Count() == 0) return p_Location.ToUpper(new System.Globalization.CultureInfo("en-US")); else return qry.First().NAME;
            }            
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable SAM_Matrix_CC(List<SAM_DATA_C> p_List)
        {
            // Create List
            List<SAM_DATA_C> p_ListNew = new List<SAM_DATA_C>();

            // Modify List
            foreach (var p_Item in p_List)
            {
                // Create
                SAM_DATA_C p_New = new SAM_DATA_C();

                // Set Item
                p_New.ADR_SOURCE = alfaEntity.SAM_Get_Name(p_Item.ADR_SOURCE);
                p_New.ADR_TARGET = alfaEntity.SAM_Get_Name(p_Item.ADR_TARGET);
                p_New.DT_UNX = p_Item.DT_UNX;
                p_New.DT_WIN = p_Item.DT_WIN;
                p_New.TRF_DELTA = p_Item.TRF_DELTA / (1024 * 1024);
                p_New.TRF_TOTAL = p_Item.TRF_TOTAL;

                // Add Item
                p_ListNew.Add(p_New);
            }

            // OrderBy
            p_ListNew = p_ListNew.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();

            // Query SUM
            var qryResultSUM = from tt in p_ListNew
                               group tt by new { tt.DT_UNX, tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, SUM_VALUE = gg.Sum(tt => tt.TRF_DELTA) };

            // Query AVG
            var qryResultAVG = from tt in qryResultSUM
                               where tt.SUM_VALUE != 0
                               group tt by new { tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, AVG_VALUE = gg.Average(tt => tt.SUM_VALUE) };

            // OrderBy
            var qryResult = qryResultAVG.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();
            
            // Columns
            var cols = qryResultAVG.OrderBy(tt=> tt.ADR_TARGET).Select(tt => tt.ADR_TARGET).Distinct().ToList();

            // Check
            if (cols.Count == 0) return null;

            // Create Table
            DataTable dtMatrix = new DataTable();

            // Add First Column
            dtMatrix.Columns.Add(new DataColumn("Source"));

            // Add Columns
            foreach (string colName in cols) dtMatrix.Columns.Add(new DataColumn(colName));

            // DataRow
            DataRow p_rowTable = dtMatrix.NewRow();

            // Source
            string p_Source = qryResult.First().ADR_SOURCE;

            foreach (var p_RowList in qryResult)
            {
                if (p_Source == p_RowList.ADR_SOURCE)
                {
                    p_rowTable["Source"] = p_Source;
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
                else
                {
                    // Add Row
                    dtMatrix.Rows.Add(p_rowTable);

                    // Create NewRow
                    p_rowTable = dtMatrix.NewRow();

                    // Set Source
                    p_Source = p_RowList.ADR_SOURCE;

                    // Set Value
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
            }

            // Add Row
            dtMatrix.Rows.Add(p_rowTable);

            // Return
            return dtMatrix;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable SAM_Matrix_DD(List<SAM_DATA_D> p_List)
        { 
            // Create List
            List<SAM_DATA_C> p_ListNew = new List<SAM_DATA_C>();

            // Modify List
            foreach (var p_Item in p_List)
            {
                // Create
                SAM_DATA_C p_New = new SAM_DATA_C();

                // Set Item
                p_New.ADR_SOURCE = alfaEntity.SAM_Get_Name(p_Item.ADR_SOURCE);
                p_New.ADR_TARGET = alfaEntity.SAM_Get_Name(p_Item.ADR_TARGET);
                p_New.DT_UNX = p_Item.DT_UNX;
                p_New.DT_WIN = p_Item.DT_WIN;
                p_New.TRF_DELTA = p_Item.TRF_DELTA / (1024 * 1024);
                p_New.TRF_TOTAL = p_Item.TRF_TOTAL;

                // Add Item
                p_ListNew.Add(p_New);
            }

            // OrderBy
            p_ListNew = p_ListNew.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();

            // Query SUM
            var qryResultSUM = from tt in p_ListNew
                               group tt by new { tt.DT_UNX, tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, SUM_VALUE = gg.Sum(tt => tt.TRF_DELTA) };

            // Query AVG
            var qryResultAVG = from tt in qryResultSUM
                               where tt.SUM_VALUE != 0
                               group tt by new { tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, AVG_VALUE = gg.Average(tt => tt.SUM_VALUE) };

            // OrderBy
            var qryResult = qryResultAVG.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();
            
            // Columns
            var cols = qryResultAVG.OrderBy(tt=> tt.ADR_TARGET).Select(tt => tt.ADR_TARGET).Distinct().ToList();

            // Check
            if (cols.Count == 0) return null;

            // Create Table
            DataTable dtMatrix = new DataTable();

            // Add First Column
            dtMatrix.Columns.Add(new DataColumn("Source"));

            // Add Columns
            foreach (string colName in cols) dtMatrix.Columns.Add(new DataColumn(colName));

            // DataRow
            DataRow p_rowTable = dtMatrix.NewRow();

            // Source
            string p_Source = qryResult.First().ADR_SOURCE;

            foreach (var p_RowList in qryResult)
            {
                if (p_Source == p_RowList.ADR_SOURCE)
                {
                    p_rowTable["Source"] = p_Source;
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
                else
                {
                    // Add Row
                    dtMatrix.Rows.Add(p_rowTable);

                    // Create NewRow
                    p_rowTable = dtMatrix.NewRow();

                    // Set Source
                    p_Source = p_RowList.ADR_SOURCE;

                    // Set Value
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
            }

            // Add Row
            dtMatrix.Rows.Add(p_rowTable);

            // Return
            return dtMatrix;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable SAM_Matrix_SS(List<SAM_DATA_S> p_List)
        { 
            // Create List
            List<SAM_DATA_C> p_ListNew = new List<SAM_DATA_C>();

            // Modify List
            foreach (var p_Item in p_List)
            {
                // Create
                SAM_DATA_C p_New = new SAM_DATA_C();

                // Set Item
                p_New.ADR_SOURCE = alfaEntity.SAM_Get_Name(p_Item.ADR_SOURCE);
                p_New.ADR_TARGET = alfaEntity.SAM_Get_Name(p_Item.ADR_TARGET);
                p_New.DT_UNX = p_Item.DT_UNX;
                p_New.DT_WIN = p_Item.DT_WIN;
                p_New.TRF_DELTA = p_Item.TRF_DELTA / (1024 * 1024);
                p_New.TRF_TOTAL = p_Item.TRF_TOTAL;

                // Add Item
                p_ListNew.Add(p_New);
            }

            // OrderBy
            p_ListNew = p_ListNew.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();

            // Query SUM
            var qryResultSUM = from tt in p_ListNew
                               group tt by new { tt.DT_UNX, tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, SUM_VALUE = gg.Sum(tt => tt.TRF_DELTA) };

            // Query AVG
            var qryResultAVG = from tt in qryResultSUM
                               where tt.SUM_VALUE != 0
                               group tt by new { tt.ADR_SOURCE, tt.ADR_TARGET } into gg
                               select new { gg.Key.ADR_SOURCE, gg.Key.ADR_TARGET, AVG_VALUE = gg.Average(tt => tt.SUM_VALUE) };

            // OrderBy
            var qryResult = qryResultAVG.OrderBy(tt => tt.ADR_SOURCE).ThenBy(tt => tt.ADR_TARGET).ToList();
            
            // Columns
            var cols = qryResultAVG.OrderBy(tt=> tt.ADR_TARGET).Select(tt => tt.ADR_TARGET).Distinct().ToList();

            // Check
            if (cols.Count == 0) return null;

            // Create Table
            DataTable dtMatrix = new DataTable();

            // Add First Column
            dtMatrix.Columns.Add(new DataColumn("Source"));

            // Add Columns
            foreach (string colName in cols) dtMatrix.Columns.Add(new DataColumn(colName));

            // DataRow
            DataRow p_rowTable = dtMatrix.NewRow();

            // Source
            string p_Source = qryResult.First().ADR_SOURCE;

            foreach (var p_RowList in qryResult)
            {
                if (p_Source == p_RowList.ADR_SOURCE)
                {
                    p_rowTable["Source"] = p_Source;
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
                else
                {
                    // Add Row
                    dtMatrix.Rows.Add(p_rowTable);

                    // Create NewRow
                    p_rowTable = dtMatrix.NewRow();

                    // Set Source
                    p_Source = p_RowList.ADR_SOURCE;

                    // Set Value
                    p_rowTable[p_RowList.ADR_TARGET] = Math.Round(Convert.ToDecimal(p_RowList.AVG_VALUE), 2);
                }
            }

            // Add Row
            dtMatrix.Rows.Add(p_rowTable);

            // Return
            return dtMatrix;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static SAM_LOG TableLog_Add()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Create Log
                SAM_LOG p_Log = new SAM_LOG();

                // Assign
                p_Log.LOG_DATETIME = alfaDate.GetDate_V6(DateTime.Now);
                p_Log.LOG_USERNAME = alfaSession.UserGroup();

                // Add
                DS.Context.SAM_LOG.Add(p_Log);

                // Save
                DS.Context.SaveChanges();

                // return
                return p_Log;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static SAM_DATA_C SAM_Check_CC(SAM_DATA_C p_Row)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_C
                          where tt.ADR_SOURCE == p_Row.ADR_SOURCE
                             && tt.ADR_TARGET == p_Row.ADR_TARGET
                             && tt.DT_UNX == p_Row.DT_UNX
                          select tt;

                // return
                if (qry.Count() == 1) return qry.First(); else return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static SAM_DATA_D SAM_Check_DD(SAM_DATA_C p_Row)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_D
                          where tt.ADR_SOURCE == p_Row.ADR_SOURCE
                             && tt.ADR_TARGET == p_Row.ADR_TARGET
                             && tt.DT_UNX == p_Row.DT_UNX
                          select tt;

                // return
                if (qry.Count() == 1) return qry.First(); else return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static SAM_DATA_S SAM_Check_SS(SAM_DATA_C p_Row)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_S
                          where tt.ADR_SOURCE == p_Row.ADR_SOURCE
                             && tt.ADR_TARGET == p_Row.ADR_TARGET
                             && tt.DT_UNX == p_Row.DT_UNX
                          select tt;

                // return
                if (qry.Count() == 1) return qry.First(); else return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static decimal? SAM_Get_Delta_CC(SAM_DATA_C p_RowCurrent)
        {
            // Delta
            decimal? p_Delta = null;

            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_C
                          where tt.ADR_SOURCE == p_RowCurrent.ADR_SOURCE
                             && tt.ADR_TARGET == p_RowCurrent.ADR_TARGET
                             && tt.DT_UNX < p_RowCurrent.DT_UNX
                          orderby tt.DT_UNX descending
                          select tt;

                // Set Delta
                if (qry.Count() > 0)
                {
                    // Previous Record
                    var p_RowPrevious = qry.First();

                    // Get Delta Total
                    Int64 p_Total = Convert.ToInt64(p_RowCurrent.TRF_TOTAL - p_RowPrevious.TRF_TOTAL);

                    // Get Delta Second
                    Int64 p_Second = Convert.ToInt64(p_RowCurrent.DT_WIN.Value.Subtract(p_RowPrevious.DT_WIN.Value).TotalSeconds);

                    // Set Delta Value
                    p_Delta = Convert.ToDecimal((p_Total / p_Second) * 8);
                }

                // return
                return p_Delta;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static decimal? SAM_Get_Delta_DD(SAM_DATA_D p_RowCurrent)
        {
            // Delta
            decimal? p_Delta = null;

            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_D
                          where tt.ADR_SOURCE == p_RowCurrent.ADR_SOURCE
                             && tt.ADR_TARGET == p_RowCurrent.ADR_TARGET
                             && tt.DT_UNX < p_RowCurrent.DT_UNX
                          orderby tt.DT_UNX descending
                          select tt;

                // Set Delta
                if (qry.Count() > 0)
                {
                    // Previous Record
                    var p_RowPrevious = qry.First();

                    // Get Delta Total
                    Int64 p_Total = Convert.ToInt64(p_RowCurrent.TRF_TOTAL - p_RowPrevious.TRF_TOTAL);

                    // Get Delta Second
                    Int64 p_Second = Convert.ToInt64(p_RowCurrent.DT_WIN.Value.Subtract(p_RowPrevious.DT_WIN.Value).TotalSeconds);

                    // Set Delta Value
                    p_Delta = Convert.ToDecimal((p_Total / p_Second) * 8);
                }

                // return
                return p_Delta;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static decimal? SAM_Get_Delta_SS(SAM_DATA_S p_RowCurrent)
        {
            // Delta
            decimal? p_Delta = null;

            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.SAM_DATA_S
                          where tt.ADR_SOURCE == p_RowCurrent.ADR_SOURCE
                             && tt.ADR_TARGET == p_RowCurrent.ADR_TARGET
                             && tt.DT_UNX < p_RowCurrent.DT_UNX
                          orderby tt.DT_UNX descending
                          select tt;

                // Set Delta
                if (qry.Count() > 0)
                {
                    // Previous Record
                    var p_RowPrevious = qry.First();

                    // Get Delta Total
                    Int64 p_Total = Convert.ToInt64(p_RowCurrent.TRF_TOTAL - p_RowPrevious.TRF_TOTAL);

                    // Get Delta Second
                    Int64 p_Second = Convert.ToInt64(p_RowCurrent.DT_WIN.Value.Subtract(p_RowPrevious.DT_WIN.Value).TotalSeconds);

                    // Set Delta Value
                    p_Delta = Convert.ToDecimal((p_Total / p_Second) * 8);
                }

                // return
                return p_Delta;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static object SAM_Chart_CC(List<SAM_DATA_C> p_List, string p_SourceName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in p_List
                          where tt.ADR_SOURCE.ToUpper().StartsWith(p_SourceName)
                          orderby tt.ADR_TARGET
                          group tt by new { tt.ADR_TARGET, tt.TRF_DELTA } into gg
                          select new { gg.Key.ADR_TARGET, TOPLAM = gg.Sum(tt => tt.TRF_DELTA) };

                // return
                return qry.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static object SAM_Chart_DD(List<SAM_DATA_D> p_List, string p_SourceName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in p_List
                          where tt.ADR_SOURCE.ToUpper().StartsWith(p_SourceName)
                          orderby tt.ADR_TARGET
                          group tt by new { tt.ADR_TARGET, tt.TRF_DELTA } into gg
                          select new { gg.Key.ADR_TARGET, TOPLAM = gg.Sum(tt => tt.TRF_DELTA) };

                // return
                return qry.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static object SAM_Chart_SS(List<SAM_DATA_S> p_List, string p_SourceName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in p_List
                          where tt.ADR_SOURCE.ToUpper().StartsWith(p_SourceName)
                          orderby tt.ADR_TARGET
                          group tt by new { tt.ADR_TARGET, tt.TRF_DELTA } into gg
                          select new { gg.Key.ADR_TARGET, TOPLAM = gg.Sum(tt => tt.TRF_DELTA) };

                // return
                return qry.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableLog_Update(SAM_LOG p_Log)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Set Text
                p_Log.LOG_FULLTEXT = alfaLog.LogText;

                // Get Log
                var qryLog = DS.Context.SAM_LOG.Where(tt => tt.ID == p_Log.ID).First();

                // Copy Log
                alfaEntity.Copy(p_Log, qryLog);

                // Save
                DS.Context.SaveChanges();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static dynamic Entity_Get(string p_DataSource)
        {
            using (alfaDS DS = new alfaDS())
            {
                switch (p_DataSource)
                {
                    case "SAM_GROUP" : return DS.Context.SAM_GROUP.Select(tt => new { tt.ID, tt.NAME }).OrderBy(tt=> tt.ID).ToList();
                    case "NMS_USERS" : return DS.Context.SAM_USER.Where(tt => tt.SAM_GROUP.NAME == "NMS").Select(tt => new { tt.FULLNAME }).OrderBy(tt => tt.FULLNAME).ToList();

                    default: return null;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string ConnStr_DeCrypt()
        {
            try
            {
                // Config File
                Configuration cfgFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Get ConnStr
                string p_ConnStr = cfgFile.ConnectionStrings.ConnectionStrings[alfaEntity.EntityObjectName].ConnectionString;

                // alfaConStr
                alfaConStr p_Connection = new alfaConStr(p_ConnStr);

                // Clear Password
                p_Connection.SetClearPassword();

                // Return
                return p_Connection.sbENT.ConnectionString;
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void ConnStr_EnCrypt(string p_ConnStr)
        {
            try
            {
                // alfaConStr
                alfaConStr p_Connection = new alfaConStr(p_ConnStr);

                // Encrypt Password
                p_Connection.SetEncryptedPassword();

                // Config File
                Configuration cfgFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Set Properties
                cfgFile.ConnectionStrings.ConnectionStrings[alfaEntity.EntityObjectName].ConnectionString = p_Connection.sbENT.ConnectionString;

                // Save Changes to File
                cfgFile.Save(ConfigurationSaveMode.Modified);

                // Force Reload
                ConfigurationManager.RefreshSection("connectionStrings");

                // Refresh
                alfaDS.m_ConnStr = null;

            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); 
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string ConnStr_Test(string p_DataSource, out string p_Result)
        {
            try
            {
                // alfa ConStr
                alfaConStr p_Connection = new alfaConStr(alfaEntity.ConnStr_DeCrypt());

                // Set Datasource
                p_Connection.SetDataSource(p_DataSource);

                // Set TimeOut
                p_Connection.SetTimeOut("5");

                // Test Connection
                using (alfaDS ent = new alfaDS(p_Connection.sbENT.ConnectionString))
                {
                    // Wait
                    alfaMsg.CursorWait();

                    // Test
                    var qry = ent.Context.SAM_USER.ToList();

                    // Default
                    alfaMsg.CursorDefult();

                    // Message
                    p_Result = " ORACLE Server was Successfully Tested ...!";

                    // Pass
                    return p_Connection.sbENT.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                // Set Message
                p_Result = ex.Message;

                // Return
                return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Copy(Object p_Source, Object p_Target)
        {
            try
            {
                // Copy Properties
                foreach (var prop in p_Source.GetType().GetProperties() )
	            {
                    // Check Name
                    if (prop.Name == "EntityState" || prop.Name == "EntityKey") continue;

                    // Get Value
                    var newValue = prop.GetValue(p_Source, null);

                    // Check
                    if (p_Target.GetType().GetProperty(prop.Name) != null)
                    {
                        // Set Value
                        p_Target.GetType().GetProperty(prop.Name).SetValue(p_Target, newValue, null);
                    }
	            }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Check(Object p_Source, Object p_Target)
        {
            try
            { 
                // Copy Properties
                foreach (var prop in p_Source.GetType().GetProperties())
	            {
                    // Check
                    if (prop.Name == "EntityState" || prop.Name == "EntityKey") continue;

                    // Get Value Source
                    var p_ValueSource = prop.GetValue(p_Source, null);

                    // Get Value Target
                    var p_ValueTarget = p_Target.GetType().GetProperty(prop.Name).GetValue(p_Target, null);

                    // Check1
                    if (p_ValueTarget == null && p_ValueSource == null) continue;

                    // Check2
                    else if (p_ValueTarget == null && p_ValueSource != null) return false;

                    // Check3
                    else if (p_ValueTarget != null && p_ValueSource == null) return false;

                    // Check4
                    if (!p_ValueSource.Equals(p_ValueTarget)) return false;
	            }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return false;
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }

    # endregion 

}