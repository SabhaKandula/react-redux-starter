using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace react_redux_starter.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<itemDetails> GetItemDetails()
        {
            string fileName = String.Format(@"C:\Users\ska338\react-redux-starter\files\Student.xlsx");
            var genList = new List<itemDetails>();
            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();
                var i = 0;
                
                foreach (Row row in rows)
                {
                    if (i != 0 && row != null)
                    {
                        List<Cell> cells = row.Descendants<Cell>().ToList();
                        var itemDetails = new itemDetails();
                        itemDetails.toothNumber = Convert.ToInt32(cells[0].InnerText.ToString());
                        itemDetails.itemCode = cells[1].InnerText.ToString();
                        itemDetails.price = Convert.ToDecimal(cells[2].InnerText.ToString());
                        genList.Add(itemDetails);
                    }
                    i++;
                }
            }
            return genList;
        }


        public class itemDetails {
            public int toothNumber { get; set; }
            public string bin { get; set; }
            public string itemCode { get; set; }
            public decimal price { get; set; }
        }
    }
}
