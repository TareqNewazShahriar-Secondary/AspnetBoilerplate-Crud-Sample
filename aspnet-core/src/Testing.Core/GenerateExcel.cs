using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Testing
{
    public class GenerateExcel<T> where T : class
    {
        private List<PropertyInfo> _propList;
        private IEnumerable<T> _data;

        public GenerateExcel(IEnumerable<T> data)
        {
            _data = data;

            var type = typeof(T);
            // take only native and public proeperties
            _propList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance /*| BindingFlags.DeclaredOnly*/).ToList();
        }

        public MemoryStream Gererate()
        {
            var memoryStream = new MemoryStream();

            //Open up the copied template workbook
            using (var spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document.
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add Sheets to the Workbook and append the previous sheet
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                // Get the sheetData cell table.
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                AddAllRows(ref sheetData);
            }

            //reset the position to the start of the stream
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        private void AddAllRows(ref SheetData sheetData)
        {
            int rowCount = 1;

            // Add header
            var headerRow = CreateContentRow(rowCount++, _propList.Select(x => (object)x.Name).ToList());
            sheetData.Append(headerRow);

            foreach (var item in _data)
            {
                var values = GetValues(item);
                var row = CreateContentRow(rowCount++, values);
                sheetData.Append(row);
            }
        }

        private Row CreateContentRow(int index, List<object> values)
        {
            //Create new row
            Row row = new Row();
            row.RowIndex = (UInt32)index;

            //Create cells that contain data
            int i = 0;
            foreach (var value in values)
            {
                Cell cell = new Cell();
                cell.CellReference = char.ConvertFromUtf32(65 + i) + (i + 1);
                var valueType = value.GetType();
                if (valueType == typeof(int) || valueType == typeof(decimal))
                {
                    cell.AppendChild(new CellValue(value.ToString()));
                }
                //else if(valueType == typeof(DateTimeOffset) || valueType == typeof(DateTimeOffset))
                //{
                //    //broadly supported - earliest Excel numeric date 01/01/1900
                //    var date = valueType == typeof(DateTimeOffset) ? ((DateTimeOffset)value).DateTime : (DateTime)value;
                //    double oaValue = date.ToOADate();
                //    cell.CellValue = new CellValue(oaValue.ToString(CultureInfo.InvariantCulture));
                //    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                //    cell.StyleIndex = Convert.ToUInt32(_numericDateCellFormatIndex);
                //}
                else
                {
                    cell.DataType = CellValues.InlineString;
                    cell.AppendChild(new InlineString(new Text(value.ToString())));
                }
                row.AppendChild(cell);
            }

            return row;
        }

        private List<object> GetValues(T obj)
        {   
            object val = null;
            var valueList = new List<object>();
            // get values from the model
            foreach (var s in _propList)
            {
                try
                {
                    val = s.GetValue(obj) ?? DBNull.Value;
                }
                catch
                {
                    val = DBNull.Value;
                }

                valueList.Add(val);
            }

            return valueList;
        }
    }
}
