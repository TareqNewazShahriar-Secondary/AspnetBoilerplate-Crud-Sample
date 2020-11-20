using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Testing
{
    public class GenerateExcel
    {
        string[] headerColumns = new string[] { "A", "B", "C" };

        public void f()
        {
            //Make a copy of the template file
            File.Copy("template.xlsx", "generated.xlsx", true);

            SheetData sheetData;

            //Open up the copied template workbook
            using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open("generated.xlsx", true))
            {
                //Access the main Workbook part, which contains all references
                WorkbookPart workbookPart = myWorkbook.WorkbookPart;

                //Grab the first worksheet
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                //SheetData will contain all the data
                sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            }

            //My data starts at row 2
            for(int index = 2; index < 50; index++)
            {   
                //Add a new row
                Row contentRow = CreateContentRow(index, DateTime.Now.ToShortTimeString(), index * 50, index * 100);

                //Append new row to sheet data
                sheetData.AppendChild(contentRow);
            }
        }

        public Row CreateContentRow(int index, string territory, decimal salesLastYear, decimal salesThisYear)
        {
            //Create new row
            Row r = new Row();
            r.RowIndex = (UInt32)index;

            //First cell is a text cell, so create it and append it
            Cell firstCell = CreateTextCell(headerColumns[0], territory, index);
            r.AppendChild(firstCell);

            //Create cells that contain data
            for (int i = 1; i < headerColumns.Length; i++)
            {
                Cell c = new Cell();
                c.CellReference = headerColumns[i] + index;
                CellValue v = new CellValue();

                if (i == 1)
                    v.Text = salesLastYear.ToString();
                else
                    v.Text = salesThisYear.ToString();

                c.AppendChild(v);
                r.AppendChild(c);
            }

            return r;
        }

        private Cell CreateTextCell(string header, string text, int index)
        {
            //Create new inline string cell
            Cell c = new Cell();
            c.DataType = CellValues.InlineString;
            c.CellReference = header + index;

            //Add text to text cell
            InlineString inlineString = new InlineString();
            Text t = new Text();

            t.Text = text;
            inlineString.AppendChild(t);
            c.AppendChild(inlineString);

            return c;
        }
    }
}
