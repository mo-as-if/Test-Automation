
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;



public class WebExcelHelper
{
    private static List<DataCollection> _dataCol = new List<DataCollection>();

    /// <summary>

    /// Storing all the excel values in to the in-memory collections

    /// </summary>

    /// <param name="fileName"></param>

    public static void PopulateInCollection(string fileName, string sheetName)

    {

        DataTable table = ExcelToDataTable(fileName, sheetName);

        //Iterate through the rows and columns of the Table

        for (int row = 1; row <= table.Rows.Count; row++)

        {

            for (int col = 0; col < table.Columns.Count; col++)

            {

                DataCollection dtTable = new DataCollection()

                {

                    rowNumber = row,

                    colName = table.Columns[col].ColumnName,

                    colValue = table.Rows[row - 1][col].ToString()

                };

                //Add all the details for each row

                _dataCol.Add(dtTable);

            }

        }

    }

    private static DataTable ExcelToDataTable(string fileName, string sheetName)

    {

        using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))

        {
             System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

               // return result.Tables;

                /*Get All tables*/

                DataTableCollection table = result.Tables;

                /*Store it in DataTable*/

                DataTable resultTable = table/*["MCHomePage"]*/[$"{sheetName}"];

                /*return*/

                return resultTable;



            }

        }

    }

    public static string ReadData(int rowNumber, string columnName)

    {

        try

        {

            //Retriving Data using LINQ to reduce much of iterations

            string data = (from colData in _dataCol

                           where colData.colName == columnName && colData.rowNumber == rowNumber

                           select colData.colValue).SingleOrDefault();

            //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;

            return data.ToString();

        }

        catch (Exception e)

        {
            //Console.WriteLine(e);
            return null;

        }



    }

    public static void cleanContentsFromExcelHelper()

    {

        _dataCol.Clear();

    }
    public class DataCollection
    {
        public int rowNumber { get; set; }

        public string colName { get; set; }

        public string colValue { get; set; }
    }

}


//public class UnderWorkExcelHelper

//{

//    private static List<DataCollection> _dataCol = new List<DataCollection>();



//    /*specific to testcase name and Any column name --might be obsoete, try not to use*/

//    public static List<string> loadTestData(string testCaseName, string ColumnName)

//    {

//        List<string> getData = new List<string>();

//        string data = readTestData(testCaseName, ColumnName);

//        if (!string.IsNullOrEmpty(data))

//        {

//            getData = splitTestData(data);

//        }

//        return getData;

//    }

//    /*specific to testcase name column*/

//    public static List<string> loadTestData(string xlsxFilePath, string sheetName, string testcase)

//    {

//        List<string> getData = new List<string>();

//        string data = readTestData(xlsxFilePath, sheetName, testcase);

//        if (!string.IsNullOrEmpty(data))

//        {

//            getData = splitTestData(data);

//        }

//        return getData;

//    }



//    /*specific column*/

//    public static List<string> loadTestData(string xlsxFilePath, string sheetName, string testcase, string columnName)

//    {

//        List<string> getData = new List<string>();

//        string data = readTestData(xlsxFilePath, sheetName, testcase, columnName);

//        if (!string.IsNullOrEmpty(data))

//        {

//            getData = splitTestData(data);

//        }

//        return getData;

//    }

//    /*Claim ID bases it will return data*/

//    public static List<string> loadTestData(string xlsxFilePath, string sheetName, string testcase, string claimID, string columnName)

//    {

//        List<string> getData = new List<string>();

//        string data = readTestData(xlsxFilePath, sheetName, testcase, claimID, columnName);

//        if (!string.IsNullOrEmpty(data))

//        {

//            getData = splitTestData(data);

//        }

//        return getData;

//    }



//    /*Any multiple Column*/

//    public static Dictionary<string, string> loadTestData(string xlsxFilePath, string sheetName, string testcase, string columnName, Boolean flag)

//    {

//        Dictionary<string, string> data = readTestData(xlsxFilePath, sheetName, testcase, columnName, flag);

//        return data;

//    }



//    public static string readTestData(string xlsxFilePath, string sheetName, string testcase, string columnName)

//    {

//        string testData = null;

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + xlsxFilePath;

//        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

//        Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets[sheetName];

//        int iColumn = 0;

//        for (iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//            if (columnName.Equals(getColumnName))

//            {

//                break;

//            }

//        }



//        for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//        {

//            string getTestcaseName = xlWorkSheet.Cells[iRow, 1].value;

//            if (testcase.Equals(getTestcaseName))

//            {

//                if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, iColumn].value))

//                {

//                    testData = xlWorkSheet.Cells[iRow, iColumn].value;

//                    break;

//                }

//            }

//        }

//        xlWorkBook.Close();

//        xlApp.Quit();

//        return testData;

//    }



//    public static Dictionary<string, string> readTestData(string xlsxFilePath, string sheetName, string testcase, string columnName, Boolean flag)

//    {

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + xlsxFilePath;

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[sheetName];

//        int iColumn = 0;

//        List<string> getColumnList = new List<string>();

//        Dictionary<string, int> getColumnWithPosition = new Dictionary<string, int>();

//        Dictionary<string, string> RowData = new Dictionary<string, string>();

//        if (columnName.IndexOf("|") != -1)

//        {

//            string[] splitDatas = columnName.Split('|');

//            foreach (string getData in splitDatas)

//            {

//                if (!string.IsNullOrEmpty(getData))

//                {

//                    getColumnList.Add(getData);

//                }

//            }

//        }

//        else

//        {

//            getColumnList.Add(columnName);

//        }

//        foreach (string cName in getColumnList)

//        {

//            for (iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//            {

//                string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//                if (cName.Equals(getColumnName))

//                {

//                    getColumnWithPosition.Add(cName, iColumn);

//                    break;

//                }

//            }

//        }



//        for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//        {

//            string getTestcaseName = xlWorkSheet.Cells[iRow, 1].value;

//            if (testcase.Equals(getTestcaseName))

//            {

//                foreach (var entry in getColumnWithPosition)

//                {

//                    RowData.Add(entry.Key, xlWorkSheet.Cells[iRow, entry.Value].value);

//                }

//                break;

//            }

//        }



//        xlWorkBook.Close();

//        xlApp.Quit();

//        return RowData;

//    }



//    public static string readTestData(string testCaseName, string ColumnName)

//    {

//        string testData = null;

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + "zelisPriZem\\xlsxTestDate\\priZemTestData.xlsx";

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets["TestData"];

//        int iColumn = 0;

//        for (iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//            if (ColumnName.Equals(getColumnName))

//            {

//                break;

//            }

//        }



//        for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//        {

//            string getTestcaseName = xlWorkSheet.Cells[iRow, 1].value;

//            if (testCaseName.Equals(getTestcaseName))

//            {

//                if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, iColumn].value))

//                {

//                    testData = xlWorkSheet.Cells[iRow, iColumn].value;

//                    break;

//                }

//            }

//        }

//        xlWorkBook.Close();

//        xlApp.Quit();

//        return testData;

//    }



//    public static List<string> readSheetTestData(string SheetName, string ColumnName)

//    {

//        List<string> testData = new List<string>();

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + "zelisPriZem\\xlsxTestDate\\priZemTestData.xlsx";

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[SheetName];

//        int iColumn = 0;

//        for (iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//            if (ColumnName.Equals(getColumnName))

//            {

//                break;

//            }

//        }



//        for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//        {

//            if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, iColumn].value))

//            {

//                testData.Add(xlWorkSheet.Cells[iRow, iColumn].value);

//                Console.WriteLine(iRow);

//            }

//        }

//        xlWorkBook.Close();

//        xlApp.Quit();

//        return testData;

//    }



//    public static List<string> splitTestData(string data)

//    {

//        List<string> getDataList = new List<string>();

//        if (data.IndexOf(",") != -1)

//        {

//            string[] splitDatas = data.Split(',');

//            foreach (string getData in splitDatas)

//            {

//                if (!string.IsNullOrEmpty(getData))

//                {

//                    getDataList.Add(getData);

//                }

//            }

//        }

//        else

//        {

//            getDataList.Add(data);

//        }

//        return getDataList;

//    }



//    public static void updateTergetClaimID(string testCaseName, string tergetClaimID)

//    {

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + "zelisPriZem\\xlsxTestDate\\priZemTestData.xlsx";

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        try

//        {

//            string tergetClaimIDColName = "TergetClaimID";

//            Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets["TestData"];

//            int TCIDColumn = 0;

//            for (int iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//            {

//                string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//                if (getColumnName.Contains(tergetClaimIDColName))

//                {

//                    TCIDColumn = iColumn;

//                    break;

//                }

//            }



//            for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//            {

//                string getTestcaseName = xlWorkSheet.Cells[iRow, 1].value;

//                if (testCaseName.Equals(getTestcaseName))

//                {

//                    if (string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, TCIDColumn].value) && !string.IsNullOrEmpty(tergetClaimID))

//                    {

//                        xlWorkSheet.Cells[iRow, TCIDColumn].value = "'" + tergetClaimID;

//                        break;

//                    }

//                    else if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, TCIDColumn].value) && !string.IsNullOrEmpty(tergetClaimID))

//                    {

//                        string getPreviousCID = xlWorkSheet.Cells[iRow, TCIDColumn].value;

//                        if (!getPreviousCID.Contains(tergetClaimID))

//                        {

//                            xlWorkSheet.Cells[iRow, TCIDColumn].value = getPreviousCID + ", " + tergetClaimID;

//                            break;

//                        }

//                    }

//                }

//            }

//            xlWorkBook.Close(true, Type.Missing, Type.Missing);

//            xlApp.Quit();

//        }

//        catch (Exception e)

//        {

//            xlWorkBook.Close(true, Type.Missing, Type.Missing);

//            xlApp.Quit();

//            Console.WriteLine(e.Message);

//            Debug.Write(e.Message);

//        }



//    }



//    public static string readTestData(string xlsxFilePath, string sheetName, string testcase)

//    {

//        string testData = null;

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + xlsxFilePath;

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[sheetName];

//        int iColumn = 0;

//        string ColumnName = "ClaimID";

//        for (iColumn = 1; iColumn <= xlWorkSheet.UsedRange.Columns.Count; iColumn++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iColumn].value;

//            if (ColumnName.Equals(getColumnName))

//            {

//                break;

//            }

//        }



//        for (int iRow = 2; iRow <= xlWorkSheet.UsedRange.Rows.Count; iRow++)

//        {

//            string getTestcaseName = xlWorkSheet.Cells[iRow, 1].value;

//            if (testcase.Equals(getTestcaseName))

//            {

//                if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iRow, iColumn].value))

//                {

//                    testData = testData + xlWorkSheet.Cells[iRow, iColumn].value + ",";

//                }

//            }

//        }

//        xlWorkBook.Close();

//        xlApp.Quit();

//        return testData;

//    }



//    public static string readTestData(string xlsxFilePath, string sheetName, string testcase, string claimID, String ColumnName)

//    {

//        string testData = null;

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + xlsxFilePath;

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[sheetName];

//        int iClaimCol = 0;

//        string claimColName = "ClaimID";

//        for (iClaimCol = 1; iClaimCol <= xlWorkSheet.UsedRange.Columns.Count; iClaimCol++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iClaimCol].value;

//            if (claimColName.Equals(getColumnName))

//            {

//                break;

//            }

//        }

//        int iSpcColumn = 0;

//        for (iSpcColumn = 1; iSpcColumn <= xlWorkSheet.UsedRange.Columns.Count; iSpcColumn++)

//        {

//            string getColumnName = xlWorkSheet.Cells[1, iSpcColumn].value;

//            if (getColumnName.Equals(ColumnName))

//            {

//                break;

//            }

//        }

//        int iTCRow = 0;

//        for (iTCRow = 2; iTCRow <= xlWorkSheet.UsedRange.Rows.Count; iTCRow++)

//        {

//            string getTestcaseName = xlWorkSheet.Cells[iTCRow, 1].value;

//            if (testcase.Equals(getTestcaseName))

//            {

//                if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iTCRow, iClaimCol].value))

//                {

//                    string getClaimID = xlWorkSheet.Cells[iTCRow, iClaimCol].value;

//                    if (getClaimID.Equals(claimID))

//                    {

//                        break;

//                    }

//                }

//            }

//        }



//        if (!string.IsNullOrEmpty(xlWorkSheet.Cells[iTCRow, iSpcColumn].value))

//        {

//            testData = xlWorkSheet.Cells[iTCRow, iSpcColumn].value;

//        }



//        xlWorkBook.Close();

//        xlApp.Quit();

//        return testData;

//    }



//    public static void updateRunStatus(string xlsxFilePath, string sheetName, string testcase, string claimID, string status)

//    {

//        string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));

//        String excelPath = projectPath + xlsxFilePath;

//        Excel.Application xlApp = new Excel.Application();

//        Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(excelPath);

//        try

//        {

//            string ClaimHeaderColName = "ClaimID";

//            Excel.Worksheet xlWorkSheet = xlWorkBook.Worksheets[sheetName];

//            int ClaimCol = 0;

//            for (ClaimCol = 1; ClaimCol <= xlWorkSheet.UsedRange.Columns.Count; ClaimCol++)

//            {

//                string getColumnName = xlWorkSheet.Cells[1, ClaimCol].value;

//                if (getColumnName.Equals(ClaimHeaderColName))

//                {

//                    break;

//                }

//            }

//            int statusCol = 0;

//            for (statusCol = 1; statusCol <= xlWorkSheet.UsedRange.Columns.Count; statusCol++)

//            {

//                string getColumnName = xlWorkSheet.Cells[1, statusCol].value;

//                if (getColumnName.Equals("TestStatus"))

//                {

//                    break;

//                }

//            }



//            int claimRowNum = 0;

//            for (claimRowNum = 2; claimRowNum <= xlWorkSheet.UsedRange.Rows.Count; claimRowNum++)

//            {

//                string getclaimID = xlWorkSheet.Cells[claimRowNum, ClaimCol].value;

//                if (getclaimID.Equals(claimID))

//                {

//                    string getTC = xlWorkSheet.Cells[claimRowNum, 1].value;

//                    if (getTC.Equals(testcase))

//                    {

//                        break;

//                    }

//                }

//            }



//            if (!string.IsNullOrEmpty(status))

//            {

//                if (status.ToLower().Contains("pass"))

//                {

//                    xlWorkSheet.Cells[claimRowNum, statusCol].value = "Passed";

//                }

//                else if (status.ToLower().Contains("fail"))

//                {

//                    xlWorkSheet.Cells[claimRowNum, statusCol].value = "Failed";

//                }

//                else

//                {

//                    xlWorkSheet.Cells[claimRowNum, statusCol].value = "DS";

//                }

//            }



//            xlWorkBook.Close(true, Type.Missing, Type.Missing);

//            xlApp.Quit();

//        }

//        catch (Exception e)

//        {

//            xlWorkBook.Close(true, Type.Missing, Type.Missing);

//            xlApp.Quit();

//            Console.WriteLine(e.Message);

//            Debug.Write(e.Message);

//        }

//    }



//}

 







