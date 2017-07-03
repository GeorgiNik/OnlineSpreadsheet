namespace OnlineSpreadsheet.Web.Application.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Web.Hosting;
    using OnlineSpreadsheet.Data.Common;
    using OnlineSpreadsheet.Web.ViewModels.Infrastructure;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public static class ExcelExportHelper
    {
        private const string WorksheetName = "DataExport";
        private const string DateFormat = "dd/MM/yyyy";
        private const int HeaderHeight = 50;
        private const int HeaderWidht = 20;

        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T), new Attribute[] { new ExportAttribute() });
            DataTable table = new DataTable();

            for (var i = 0; i < props.Count; i++)
            {
                table.Columns.Add(props[i].DisplayName);
            }

            var values = new object[table.Columns.Count];
            var counter = 0;

            foreach (var item in data)
            {
                counter++;
                values[0] = counter;

                for (var i = 1; i < values.Length; i++)
                {
                    var propertyType = props[i].PropertyType;
                    var value = props[i].GetValue(item);

                    if (propertyType == typeof(DateTime?))
                    {
                        var date = (DateTime?) value;
                        if (date.HasValue)
                        {
                            values[i] = date.Value.ToString(DateFormat);
                        }
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        var date = (DateTime) value;
                        values[i] = date.ToString(DateFormat);
                    }
                    else
                    {
                        values[i] = value;
                    }

                    if (propertyType == typeof(string))
                    {
                        if (string.IsNullOrEmpty((string) value))
                        {
                            values[i] = "-";
                        }
                    }
                }

                table.Rows.Add(values);
            }

            return table;
        }

        public static string ExportExcel(DataTable dt, string path)
        {
            byte[] result = null;
            const int StartFromRow = 1;
            const int StartFromCol = 1;

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(WorksheetName);
                ws.Cells["A" + StartFromRow].LoadFromDataTable(dt, true);

                for (var colindex = 1; colindex <= dt.Columns.Count; colindex++)
                {
                    ws.Column(colindex).Width = HeaderWidht;
                }

                // format header
                using (ExcelRange r = ws.Cells[StartFromRow, StartFromCol, StartFromRow, dt.Columns.Count])
                {
                    r.Worksheet.Row(StartFromRow).Height = HeaderHeight;

                    r.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    r.Style.Font.Bold = true;
                    r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                    r.Style.WrapText = true;
                    r.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    r.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    r.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
                    r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
                }

                //format cells
                using (ExcelRange r = ws.Cells[StartFromRow + 1, StartFromCol, StartFromRow + dt.Rows.Count, dt.Columns.Count])
                {
                }

                result = pck.GetAsByteArray();
            }

            var fileName = Guid.NewGuid();
            string filePath;

            if (string.IsNullOrEmpty(path))
            {
                filePath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["ExcelExportsPath"]) + fileName;
            }
            else
            {
                filePath = path + fileName;
            }

            if (!File.Exists(filePath))
            {
                try
                {
                    File.WriteAllBytes(filePath, result);
                }
                catch (Exception ex)
                {
                    NLogger.Instance.Error(ex);
                }
            }

            return fileName.ToString();
        }
    }
}