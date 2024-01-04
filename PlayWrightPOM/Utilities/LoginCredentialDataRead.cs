using ExcelDataReader;
using PlayWrightPOM.Test_Helper_Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWrightPOM.Utilities
{
    internal class LoginCredentialDataRead
    {
        public static List<EAText> ReadLoginData(string excelFilePath, string sheetname)
        {
            List<EAText> excelDataList = new List<EAText>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            EAText excelData = new EAText
                            {
                                UserName= GetValueOrDefault(row, "un"),
                                Password= GetValueOrDefault(row, "pwd")

                            };
                            excelDataList.Add(excelData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return excelDataList;

        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "" + columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}
