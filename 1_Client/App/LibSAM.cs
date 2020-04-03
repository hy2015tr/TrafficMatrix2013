using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TrafficMatrix2013
{
    class alfaSAM
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string m_SamUser = "pbndata";                                 // SAM User
        public static string m_SamPass = "89a37cbff1d93fed3850a9d02874b952";        // SAM Pass
        public static string m_SamAdd1 = "http://10.19.43.72:8080/xmlapi/invoke";   // SAM Address
        public static string m_SamAdd2 = "http://172.28.138.72:8080/xmlapi/invoke"; // SAM Address
        public static string m_FtpUser = "pbn";                                     // FTP User
        public static string m_FtpPass = "pbn";                                     // FTP Pass
        public static string m_FtpAdd1 = "10.19.43.72";                             // FTP Address
        public static string m_FtpAdd2 = "172.28.138.72";                           // FTP Address
        public static string m_FtpPath = "/opt/5620sam/server/xml_output/PBNDATA/"; // FTP Path
        public static string m_LocPath = "D:\\SAM\\";                               // Local Path
        public static string FileName { get; set; }                                 // Processing FileName
        public static string FileNameRem { get; set; }                              // Processing FileName Remote
        public static string FileNameLoc { get; set; }                              // Processing FileName Local
        public static FrmMain FrmMain { get; set; }                                 // Application Main Form
        public static bool IsRunning { get; set; }                                  // Runnig Process
        public static string BreakMessage = "AutoRun is Stopped by";                // Break Message
        public static string BreakUser { get; set; }                                // Break User
        public static int PageAuto = 0;                                             // PageAuto
        public static int PageManual = 1;                                           // PageManual
        public static int PagePorts = 2;                                            // PagePorts
        public static int PageReport = 3;                                           // PageReport
        public static int PageSettings = 4;                                         // PageSettings

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> CallService_PortData()
        { 
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // XML Query
                    string p_XmlQry = @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        <SOAP:Header>
                                               <header xmlns=""xmlapi_1.0"">
                                                       <security> <user>{0}</user> <password>{1}</password> </security>
                                                       <requestID>clientName@requestId</requestID>
                                               </header>
                                        </SOAP:Header>
                                        <SOAP:Body>
                                            <findToFile xmlns=""xmlapi_1.0"">
                                            <timeStamp>true</timeStamp>
                                            <fullClassName>equipment.Port</fullClassName>
                                              <resultFilter>
                                                <attribute>siteId</attribute>
                                                <attribute>siteName</attribute>
                                                <attribute>administrativeState</attribute>
                                                <attribute>operationalState</attribute>
                                                <attribute>displayedName</attribute>
                                                <attribute>portName</attribute>
                                                <attribute>portClass</attribute>
                                                <attribute>description</attribute>
                                                <attribute>hwMacAddress</attribute>
                                                <attribute>macAddress</attribute>
                                                <attribute>mode</attribute>
                                                <attribute>encapType</attribute>
                                                <children/>
                                              </resultFilter>
                                            <fileName>PBNDATA/{2}.xml</fileName>
                                            </findToFile>
                                        </SOAP:Body>
                                </SOAP:Envelope>";

                    // Set FileName             
                    string p_FileName = string.Format("FILE_{0}", alfaDate.GetDate_V4(DateTime.Now));  

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ... [ Start ]");
                    alfaLog.Add("(XML) Server = " + alfaSAM.m_SamAdd1);
                    alfaLog.Add("(XML) FileName = " + p_FileName);

                    // Query
                    p_XmlQry = string.Format(p_XmlQry, alfaSAM.m_SamUser, alfaSAM.m_SamPass, p_FileName);

                    // Result
                    var p_Result = alfaWeb.GetWebRequest(p_XmlQry);

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_FileName;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> Step01_CallService_TrafficData(DateTime p_DT1, DateTime p_DT2)
        {
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // XML Query
                    string p_XmlQry = @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        <SOAP:Header>
                                               <header xmlns=""xmlapi_1.0"">
                                                       <security> <user>{0}</user> <password>{1}</password> </security>
                                                       <requestID>clientName@requestId</requestID>
                                               </header>
                                        </SOAP:Header>
                                        <SOAP:Body>
                                            <findToFile xmlns=""xmlapi_1.0"">
                                            <timeStamp>true</timeStamp>
                                            <fullClassName>service.CombinedMplsLspEgressLogRecord</fullClassName>
                                            <filter><and><between name=""timeRecorded"" first=""{2}"" second=""{3}""/></and></filter>
                                            <fileName>PBNDATA/{4}.xml</fileName>
                                            </findToFile>
                                        </SOAP:Body>
                                </SOAP:Envelope>";

                    // Set FileName             
                    alfaSAM.FileName = string.Format("FILE_{0}", alfaDate.GetDate_V4(DateTime.Now));

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ... [ Start ]");
                    alfaLog.Add("(XML) Server = " + alfaSAM.m_SamAdd1);
                    alfaLog.Add("(XML) FileName = " + alfaSAM.FileName);

                    // Query
                    p_XmlQry = string.Format(p_XmlQry, alfaSAM.m_SamUser, alfaSAM.m_SamPass, alfaDate.ToUnixDT(p_DT1), alfaDate.ToUnixDT(p_DT2), alfaSAM.FileName);

                    // Result
                    var p_Result = alfaWeb.GetWebRequest(p_XmlQry);

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Result;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<alfaItem> Step02_FTP_GetFileNames()
        {
            // Break
            if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

            // Start
            DateTime p_Start = DateTime.Now;

            // Log
            alfaLog.Add("(FTP) Server = " + alfaSAM.m_FtpAdd1 + alfaSAM.m_FtpPath);
            alfaLog.Add("(FTP) Getting FileNames ... [ Start ]");

            // FTP
            Rebex.Net.Ftp ftp = alfaFtp.Get();

            // File Names
            string[] p_FileList = ftp.GetNameList();

            // Create List
            List<alfaItem> p_ItemList = new List<alfaItem>();

            // Index
            int p_Index = 0;

            foreach (string p_File in p_FileList)
            {
                // Inc Index
                p_Index = p_Index + 1;

                // FileName
                string p_FileName = string.Format("[{0:000}]  {1}  ( {2} Bytes )", p_Index, p_File, ftp.GetFileLength(p_File));

                // Add to List
                p_ItemList.Add(new alfaItem(p_FileName, p_File));
            }

            // Log
            alfaLog.Add("(FTP) Getting FileNames ...", alfaDate.GetSec(p_Start));

            // Return
            return p_ItemList;
        }        

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> Step03_FTP_DownloadFile(string p_FileName)
        {
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(FTP) Server = " + alfaSAM.m_FtpAdd1 + alfaSAM.m_FtpPath);
                    alfaLog.Add("(FTP) Downloading File ... [ Start ]");

                    // FTP
                    var p_ftp = alfaFtp.Get();

                    // Remote FileName
                    alfaSAM.FileNameRem = alfaSAM.m_FtpPath + p_FileName;

                    // Local FileName
                    alfaSAM.FileNameLoc = alfaSAM.m_LocPath + p_FileName;

                    // Check Directory Local
                    if (!Directory.Exists(alfaSAM.m_LocPath)) Directory.CreateDirectory(alfaSAM.m_LocPath);

                    // Download File
                    p_ftp.GetFile(alfaSAM.FileNameRem, alfaSAM.FileNameLoc);

                    // FileName
                    string p_FileWithSize = string.Format("(FTP) {0} ( {1} Bytes )", p_FileName, p_ftp.GetFileLength(alfaSAM.FileNameRem));

                    // Log
                    alfaLog.Add(p_FileWithSize);
                    alfaLog.Add("(FTP) Downloading File ...", alfaDate.GetSec(p_Start));

                    // Return
                    return alfaSAM.FileNameLoc;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<DataTable> Step04_ProcessFile(string p_FileName, bool p_UnixTime)
        {
            // Return Async Result
            return Task.Run<DataTable>(() =>
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(APP) Processing File (Generating RawData) ... [ Start ]");

                    // DataSet
                    DataSet ds = new DataSet();

                    // Read XML
                    ds.ReadXml(p_FileName);

                    // Check
                    if (ds.Tables.Count == 0)
                    {
                        // Log
                        alfaLog.Add("(APP) No Data Found ... !"); return null;
                    }

                    // Get Table
                    DataTable dt = new DataTable();

                    foreach (DataTable p_Table in ds.Tables)
                    {
                        // Merge
                        dt.Merge(p_Table);
                    }

                    if (p_UnixTime)
                    {
                        // Add Custom Field
                        dt.Columns.Add(new DataColumn("timeRecordedNET"));

                        // Convert Unix TimeStamp
                        foreach (DataRow row in dt.Rows)
                        {
                            // Break
                            if (!alfaSAM.IsRunning) break;

                            // Set DateTime
                            row["timeRecordedNET"] = alfaDate.ToWinDT(Convert.ToDouble(row["timeRecorded"].ToString()));
                        }
                    }

                    // Log
                    alfaLog.Add("(APP) Processing File (Generating RawData) ...", alfaDate.GetSec(p_Start));
                    alfaLog.Add("(APP) RawData = " + dt.Rows.Count.ToString() + " Rows");

                    // Return
                    return dt;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<List<SAM_DATA_C>> Step05_ProcessData(DataTable p_DataTable)
        {
            // Return Async Result
            return Task.Run<List<SAM_DATA_C>>(() =>
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(APP) Getting Processed Data ... [ Start ]");

                    // Query
                    var qry = from tt in p_DataTable.AsEnumerable()

                              group tt by new
                              {
                                  DT_WIN = tt.Field<string>("timeRecordedNET"),
                                  DT_UNX = tt.Field<string>("timeRecorded"),
                                  ADR_SOURCE = tt.Field<string>("lspName"),
                                  ADR_TARGET = tt.Field<string>("monitoredObjectSiteName")
                              }
                                  into gg

                                  select new SAM_DATA_C()
                                   {
                                       DT_WIN = Convert.ToDateTime(gg.Key.DT_WIN),
                                       DT_UNX = Convert.ToDecimal(gg.Key.DT_UNX),
                                       ADR_SOURCE = gg.Key.ADR_SOURCE,
                                       ADR_TARGET = gg.Key.ADR_TARGET,
                                       TRF_TOTAL = gg.Sum(xx => Convert.ToInt64(xx.Field<string>("inProfileOctetsForwarded"))    +
                                                                Convert.ToInt64(xx.Field<string>("outOfProfileOctetsForwarded")) )
                                   };

                    // Log
                    alfaLog.Add("(APP) Getting Processed Data ...", alfaDate.GetSec(p_Start));
                    alfaLog.Add("(APP) CalcData = " + qry.Count().ToString() + " Rows");

                    // Return
                    return qry.ToList();
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step06_Transfer_Data_C(List<SAM_DATA_C> p_ListData)
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                // Break
                if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                using (alfaDS DS = new alfaDS())
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_C ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in p_ListData.Where(tt => tt.ADR_SOURCE.EndsWith("c")).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Check Double Record
                        if (alfaEntity.SAM_Check_CC(p_RowCurrent) != null) continue;

                        // Create
                        SAM_DATA_C p_Row = new SAM_DATA_C();

                        // SetDelta
                        alfaSAM.SetDelta(p_ListData, p_RowCurrent, "c");

                        // Assign
                        p_Row.ADR_SOURCE = p_RowCurrent.ADR_SOURCE;
                        p_Row.ADR_TARGET = p_RowCurrent.ADR_TARGET;
                        p_Row.DT_UNX = p_RowCurrent.DT_UNX;
                        p_Row.DT_WIN = p_RowCurrent.DT_WIN;
                        p_Row.TRF_DELTA = p_RowCurrent.TRF_DELTA;
                        p_Row.TRF_TOTAL = p_RowCurrent.TRF_TOTAL;

                        // Add
                        DS.Context.SAM_DATA_C.Add(p_Row);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }

                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_C ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step06_Transfer_Data_D(List<SAM_DATA_C> p_ListData)
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                // Break
                if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                using (alfaDS DS = new alfaDS())
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_D ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in p_ListData.Where(tt => tt.ADR_SOURCE.EndsWith("d")).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Check Double Record
                        if (alfaEntity.SAM_Check_DD(p_RowCurrent) != null) continue;

                        // Create
                        SAM_DATA_D p_Row = new SAM_DATA_D();

                        // SetDelta
                        alfaSAM.SetDelta(p_ListData, p_RowCurrent, "d");

                        // Assign
                        p_Row.ADR_SOURCE = p_RowCurrent.ADR_SOURCE;
                        p_Row.ADR_TARGET = p_RowCurrent.ADR_TARGET;
                        p_Row.DT_UNX = p_RowCurrent.DT_UNX;
                        p_Row.DT_WIN = p_RowCurrent.DT_WIN;
                        p_Row.TRF_DELTA = p_RowCurrent.TRF_DELTA;
                        p_Row.TRF_TOTAL = p_RowCurrent.TRF_TOTAL;

                        // Add
                        DS.Context.SAM_DATA_D.Add(p_Row);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }

                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_D ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Status
                    alfaSAM.Status_OK();

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step06_Transfer_Data_S(List<SAM_DATA_C> p_ListData)
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Break
                    if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_S ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in p_ListData.Where(tt => tt.ADR_SOURCE.EndsWith("s")).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Check Double Record
                        if (alfaEntity.SAM_Check_SS(p_RowCurrent) != null) continue;

                        // Create
                        SAM_DATA_S p_Row = new SAM_DATA_S();

                        // SetDelta
                        alfaSAM.SetDelta(p_ListData, p_RowCurrent, "s");

                        // Assign
                        p_Row.ADR_SOURCE = p_RowCurrent.ADR_SOURCE;
                        p_Row.ADR_TARGET = p_RowCurrent.ADR_TARGET;
                        p_Row.DT_UNX = p_RowCurrent.DT_UNX;
                        p_Row.DT_WIN = p_RowCurrent.DT_WIN;
                        p_Row.TRF_DELTA = p_RowCurrent.TRF_DELTA;
                        p_Row.TRF_TOTAL = p_RowCurrent.TRF_TOTAL;

                        // Add
                        DS.Context.SAM_DATA_S.Add(p_Row);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }
                    
                    // Log
                    alfaLog.Add("(ORA) Parallel Transfering DATA_S ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step07_Calculate_Delta_C()
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                // Break
                if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                using (alfaDS DS = new alfaDS())
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_C ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in DS.Context.SAM_DATA_C.Where(tt => tt.TRF_DELTA == null).OrderByDescending(tt => tt.DT_UNX).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Set Delta
                        p_RowCurrent.TRF_DELTA = alfaEntity.SAM_Get_Delta_CC(p_RowCurrent);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_C ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step07_Calculate_Delta_D()
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                // Break
                if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                using (alfaDS DS = new alfaDS())
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_D ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in DS.Context.SAM_DATA_D.Where(tt => tt.TRF_DELTA == null).OrderByDescending(tt => tt.DT_UNX).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Set Delta
                        p_RowCurrent.TRF_DELTA = alfaEntity.SAM_Get_Delta_DD(p_RowCurrent);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_D ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<int> Step07_Calculate_Delta_S()
        {
            // Return Async Result
            return Task.Run<int>(() =>
            {
                // Break
                if (!alfaSAM.IsRunning) throw new Exception(alfaSAM.BreakMessage);

                using (alfaDS DS = new alfaDS())
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_S ... [ Start ]");

                    // Count
                    int p_Count = 0;

                    foreach (var p_RowCurrent in DS.Context.SAM_DATA_S.Where(tt => tt.TRF_DELTA == null).OrderByDescending(tt => tt.DT_UNX).ToList())
                    {
                        // Break
                        if (!alfaSAM.IsRunning) break;

                        // Set Delta
                        p_RowCurrent.TRF_DELTA = alfaEntity.SAM_Get_Delta_SS(p_RowCurrent);

                        // Save
                        DS.Context.SaveChanges();

                        // Count
                        p_Count++;
                    }

                    // Log
                    alfaLog.Add("(ORA) Parallel Calculating Delta DATA_S ( " + p_Count.ToString() + " Rows ) ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_Count;
                }
            });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Step08_Delete_LocalFile()
        {
            try
            {
                if (File.Exists(alfaSAM.FileNameLoc))
                {
                    // Delete Local File
                    File.Delete(alfaSAM.FileNameLoc);

                    // Log
                    alfaLog.Add("(APP) Local File Removed ... [ OK ]");
                }
            }
            catch (Exception ex)
            {
                // Log
                alfaLog.Add("(APP) " + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetDelta(List<SAM_DATA_C> p_ListData, SAM_DATA_C p_RowCurrent, string p_Type)
        {
            // Get Previous Record
            var qry = from tt in p_ListData
                      where tt.ADR_SOURCE.EndsWith(p_Type)
                         && tt.ADR_SOURCE == p_RowCurrent.ADR_SOURCE
                         && tt.ADR_TARGET == p_RowCurrent.ADR_TARGET
                         && tt.DT_UNX < p_RowCurrent.DT_UNX
                      orderby tt.DT_UNX descending
                      select tt;

            // Set Delta
            if (qry.Count() > 0)
            {
                // Get Previous
                var p_RowPrevious = qry.First();

                // Get Delta Total
                Int64 p_Total = Convert.ToInt64(p_RowCurrent.TRF_TOTAL - p_RowPrevious.TRF_TOTAL);

                // Get Delta Second
                Int64 p_Second = Convert.ToInt64(p_RowCurrent.DT_WIN.Value.Subtract(p_RowPrevious.DT_WIN.Value).TotalSeconds);

                // Set Delta Value
                p_RowCurrent.TRF_DELTA = Convert.ToDecimal((p_Total / p_Second) * 8);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void FTP_DeleteFiles()
        {
            // FTP
            Rebex.Net.Ftp ftp = alfaFtp.Get();

            // File Names
            string[] p_FileList = ftp.GetNameList();

            // Create List
            List<alfaItem> p_ItemList = new List<alfaItem>();

            foreach (string p_File in p_FileList)
            {
                // DeleteFile
                ftp.DeleteFile(p_File);
            }
        }   

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Start(int p_PageNo)
        {
            // Start
            alfaSAM.IsRunning = true;

            // Set TabPage
            alfaSAM.SetTabPage(p_PageNo);

            // Parameters
            alfaSAM.Set_Parameters_FromDB();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Start(Timer p_Timer, int p_PageNo)
        {
            // Start
            alfaSAM.IsRunning = true;

            // Set TabPage
            alfaSAM.SetTabPage(p_PageNo);

            // Start Timer
            p_Timer.Start();

            // Parameters
            alfaSAM.Set_Parameters_FromDB();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetTabPage(int p_PageNo)
        {
            foreach (var p_Page in alfaSAM.FrmMain.tabMain.TabPages.ToList())
            {
                // Disable All Pages
                if (alfaSAM.FrmMain.tabMain.TabPages[p_PageNo] != p_Page) p_Page.PageEnabled = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Stop()
        {
            // Start
            alfaSAM.IsRunning = false;

            // Enable Pages
            alfaSAM.FrmMain.tabMain.TabPages.ToList().ForEach(tt => tt.PageEnabled = true);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private static void Set_Parameters_FromDB()
        {
            // Set Parameters
            alfaEntity.TablePrms_SetAppValue("SamUser", ref alfaSAM.m_SamUser);
            alfaEntity.TablePrms_SetAppValue("SamPass", ref alfaSAM.m_SamPass);
            alfaEntity.TablePrms_SetAppValue("SamAdd1", ref alfaSAM.m_SamAdd1);
            alfaEntity.TablePrms_SetAppValue("SamAdd2", ref alfaSAM.m_SamAdd2);
            alfaEntity.TablePrms_SetAppValue("FtpUser", ref alfaSAM.m_FtpUser);
            alfaEntity.TablePrms_SetAppValue("FtpPass", ref alfaSAM.m_FtpPass);
            alfaEntity.TablePrms_SetAppValue("FtpPath", ref alfaSAM.m_FtpPath);
            alfaEntity.TablePrms_SetAppValue("FtpAdd1", ref alfaSAM.m_FtpAdd1);
            alfaEntity.TablePrms_SetAppValue("FtpAdd2", ref alfaSAM.m_FtpAdd2);
            alfaEntity.TablePrms_SetAppValue("LocPath", ref alfaSAM.m_LocPath);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_OK()
        {
            if (alfaSAM.FrmMain !=null)
            {
                // Status
                alfaCtrl.SetText(alfaSAM.FrmMain.statusResult, " OK ", Color.Green);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_ERROR(string p_Message)
        {
            // Status
            alfaCtrl.SetText(alfaSAM.FrmMain.statusResult, p_Message, Color.Red);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_STOPPED()
        {
            // Status
            alfaCtrl.SetText(alfaSAM.FrmMain.statusResult, " STOPPED ", Color.Red);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_RUNNING()
        {
            // Status
            alfaCtrl.SetText(alfaSAM.FrmMain.statusResult, " RUNNING ... ! ", Color.Blue);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}