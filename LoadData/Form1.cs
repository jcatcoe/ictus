using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoadData.Tools;
using LoadData.DataBase;

namespace LoadData
{
    public partial class Home : Form
    {
        
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ncLog.SetMyHome(this);

            Util.LoadTemporalData();
        }

        private void btLoadZBS_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;
                        txtZBSPath.Text = filePath;

                        ncLog.Message("ExcelPath:" + filePath);

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                        Worksheet sheet = (Worksheet)wb.Sheets["ZBS"];

                        Range excelRange = sheet.UsedRange;

                        int nRows = excelRange.Rows.Count;

                        ncLog.Message("Nº Rows:" + nRows);

                        foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                        {
                            int rowNumber = row.Row;

                            if (rowNumber != 1) //Headers
                            {
                                string[] arrayAG = Util.GetRange("A" + rowNumber + ":G" + rowNumber + "", sheet);

                                zbs newZBS = new zbs(arrayAG);

                                if (!newZBS.IsOk())
                                {
                                    ncLog.Error("LoadZBS::Unable to create ZBS object row number:" + rowNumber);
                                    continue;
                                }

                                if(IctusDBManager.NewZBS(newZBS))
                                {
                                    ncLog.Message("LoadZBS::Inserted row number:" + rowNumber);
                                }
                                else
                                {
                                    ncLog.Message("LoadZBS::Unable to insert row number:" + rowNumber);
                                }                                
                            }

                        }
                    }
                }
            }
            catch(Exception exp)
            {
                ncLog.Exception("LoadZBS::" + exp.Message);
            }
        }

       

        public void MyInvokeLog(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtLog.AppendText("\r\n" + text); // runs on UI thread
            });
        }

        private void btLoadUSVB_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;
                        txtUSVBPath.Text = filePath;

                        ncLog.Message("ExcelPath:" + filePath);

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                        Worksheet sheet = (Worksheet)wb.Sheets["USVB"];

                        Range excelRange = sheet.UsedRange;

                        int nRows = excelRange.Rows.Count;

                        ncLog.Message("Nº Rows:" + nRows);

                        foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                        {
                            int rowNumber = row.Row;

                            if (rowNumber != 1) //Headers
                            {
                                string[] arrayAF = Util.GetRange("A" + rowNumber + ":F" + rowNumber + "", sheet);

                                usvb newUSVB = new usvb(arrayAF);

                                if (!newUSVB.IsOk())
                                {
                                    ncLog.Error("LoadUSVB::Unable to create USVB object row number:" + rowNumber);
                                    continue;
                                }

                                if (IctusDBManager.NewUSVB(newUSVB))
                                {
                                    ncLog.Message("LoadUSVB::Inserted row number:" + rowNumber);
                                }
                                else
                                {
                                    ncLog.Message("LoadUSVB::Unable to insert row number:" + rowNumber);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadUSVB::" + exp.Message);
            }
        }

        private void btLoadHospitales_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;
                        txtHospitales.Text = filePath;

                        ncLog.Message("ExcelPath:" + filePath);

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);

                        Worksheet sheet = (Worksheet)wb.Sheets["HOSPITALES"];

                        Range excelRange = sheet.UsedRange;

                        int nRows = excelRange.Rows.Count;

                        ncLog.Message("Nº Rows:" + nRows);

                        foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                        {
                            int rowNumber = row.Row;

                            if (rowNumber != 1) //Headers
                            {
                                string[] arrayAG = Util.GetRange("A" + rowNumber + ":G" + rowNumber + "", sheet);

                                hospital newHospital = new hospital(arrayAG);

                                if (!newHospital.IsOk())
                                {
                                    ncLog.Error("LoadHospitales::Unable to create USVB object row number:" + rowNumber);
                                    continue;
                                }

                                if (IctusDBManager.NewHospital(newHospital))
                                {
                                    ncLog.Message("LoadHospitales::Inserted row number:" + rowNumber);
                                }
                                else
                                {
                                    ncLog.Message("LoadHospitales::Unable to insert row number:" + rowNumber);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadHospitales::" + exp.Message);
            }
        }

        //private void btLoadDatosUME_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(!Util.LoadDataMasterList())
        //        {
        //            ncLog.Error("LoadDatosUME::Unable to load data master in memory. We can NOT continue!!!");
        //            return;
        //        }


        //        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //        {
        //            //openFileDialog.InitialDirectory = "c:\\";
        //            openFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
        //            openFileDialog.FilterIndex = 2;
        //            openFileDialog.RestoreDirectory = true;

        //            if (openFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                //Get the path of specified file
        //                string filePath = openFileDialog.FileName;
        //                txtDatosUME.Text = filePath;

        //                ncLog.Message("ExcelPath:" + filePath);

        //                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

        //                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                        Type.Missing, Type.Missing);


        //                int sheetsNumber = wb.Sheets.Count; //11 => from 11 to 1

        //                //From sheetsNumber to 1 => From 2008 to 2018
        //                for (int iter = sheetsNumber; iter >= 1; --iter)
        //                {
        //                    Worksheet sheet = (Worksheet)wb.Sheets[iter];

        //                    Range excelRange = sheet.UsedRange;

        //                    int nRows = excelRange.Rows.Count;

        //                    ncLog.Message("Sheet:[" + sheet.Name + "] - Nº Rows:" + nRows);

        //                    foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
        //                    {
        //                        int rowNumber = row.Row;

        //                        if (rowNumber != 1) //Headers
        //                        {

        //                            string[] arrayAO = GetRange("A" + rowNumber + ":O" + rowNumber + "", sheet);

        //                            umeData newUmeData = new umeData(arrayAO);

        //                            if (!newUmeData.IsOk())
        //                            {
        //                                ncLog.Error("LoadUMEData::Unable to create USVB object row number:" + rowNumber);
        //                                continue;
        //                            }

        //                            if (IctusDBManager.NewUmeData(newUmeData))
        //                            {
        //                                ncLog.Message("LoadUMEData::Inserted row number:" + rowNumber);
        //                            }
        //                            else
        //                            {
        //                                ncLog.Message("LoadUMEData::Unable to insert row number:" + rowNumber);
        //                            }
        //                        }

        //                    }

        //                }

        //            }
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        ncLog.Exception("LoadHospitales::" + exp.Message);
        //    }
        //}

        private void btLoadDatosUME_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Util.LoadDataMasterList())
                {
                    ncLog.Error("LoadDatosUME::Unable to load data master in memory. We can NOT continue!!!");
                    return;
                }


                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    //openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        string filePath = openFileDialog.FileName;
                        txtDatosUME.Text = filePath;

                        ncLog.Message("ExcelPath:" + filePath);

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing);


                        int sheetsNumber = wb.Sheets.Count; //11 => from 11 to 1

                        sheetsNumber = sheetsNumber - 2; //Because 2008 and 2009 are inserted yet

                        //From sheetsNumber to 1 => From 2008 to 2018
                        for (int iter = sheetsNumber; iter >= 1; --iter)
                        {
                            Worksheet sheet = (Worksheet)wb.Sheets[iter];

                            Range excelRange = sheet.UsedRange;

                            int nRows = excelRange.Rows.Count;

                            ncLog.Message("Sheet:[" + sheet.Name + "] - Nº Rows:" + nRows);

                            foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                            {
                                int rowNumber = row.Row;

                                if (rowNumber != 1) //Headers
                                {

                                    string[] arrayAO = Util.GetRange("A" + rowNumber + ":O" + rowNumber + "", sheet);

                                    umeDataTMP newUmeData = new umeDataTMP(arrayAO);

                                    if(newUmeData.inc_id == Int64.MinValue)
                                    {
                                        ncLog.Error("LoadUMEDataTMP::Unable to create umeDataTMP document for id:" + arrayAO[0]);
                                        continue;
                                    }

                                    if (IctusDBManager.NewUmeDataTMP(newUmeData))
                                    {
                                        ncLog.Message("LoadUMEDataTMP::Inserted row number:" + rowNumber);
                                    }
                                    else
                                    {
                                        ncLog.Message("LoadUMEDataTMP::Unable to insert row number:" + rowNumber);
                                    }
                                }

                            }

                            //iter = 1; //For only year 2008

                        }

                    }
                }
            }
            catch (Exception exp)
            {
                ncLog.Exception("LoadHospitales::" + exp.Message);
            }
        }

        private void btLoadDB_Click(object sender, EventArgs e)
        {
            List<ictusData> ictusDataColletion = IctusDBManager.GetAllictusData();

            if(ictusDataColletion != null && ictusDataColletion.Count() > 0)
            {
                ncLog.Warning("LoadDB::ictusData collections is not empty. You must remove it!! Nº documents:" + ictusDataColletion.Count());
                return;
            }

            ictusDataColletion.Clear();

            foreach (KeyValuePair<long, List<umeDataTMP>> iter in Util.ictusDataMap)
            {
                ictusData newIctusdata = new ictusData(iter.Key, iter.Value);
                if (newIctusdata.IsOk())
                {
                    ictusDataColletion.Add(newIctusdata);
                }
            }

            ncLog.Message("LoadDB::Nº rows ictusDataColletion:[" + ictusDataColletion.Count() + "]");

            

            foreach(ictusData iter in ictusDataColletion)
            {
                if(!IctusDBManager.NewIctusData(iter))
                {
                    ncLog.Error("LoadDB::Unable to insert new ictusData for pacienteID:" + iter.pacienteID);
                }
            }

            List<ictusData> ictusDataInDB = IctusDBManager.GetAllictusData();

            ncLog.Message("LoadDB::Nº rows inserted:[" + ictusDataInDB.Count() + "]");

        }
    }
}
