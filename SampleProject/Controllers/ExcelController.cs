using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {

            return View();
            
        }

        public List<ProductModel> ProductList()
        {
            List<ProductModel> destinationmodel = new List<ProductModel>();
            using(var c=new Context())
            {
                destinationmodel = c.Products.Select(x => new ProductModel
                {
                    Name = x.Name,
                    Description=x.Description,
                    Price=x.Price
                }).ToList();
            }

            return destinationmodel;
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Gürcistan turu";
            worksheet.Cells[2, 2].Value = "Kadir yıldız";
            worksheet.Cells[2, 3].Value = "50";

            worksheet.Cells[3, 1].Value = "sırbistan turu";
            worksheet.Cells[3, 2].Value = "Zeynep öztürk";
            worksheet.Cells[3, 3].Value = "50";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");
        }


        public IActionResult ProductExcelReport()
        {
            using(var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Ürün Listesi");
                worksheet.Cell(1, 1).Value = "Ürün Adı";
                worksheet.Cell(1, 2).Value = "Açıklama";
                worksheet.Cell(1, 3).Value = "Fiyatı";

                int rowcount = 2;
                foreach (var item in ProductList())
                {
                    worksheet.Cell(rowcount, 1).Value = item.Name;
                    worksheet.Cell(rowcount, 2).Value = item.Description;
                    worksheet.Cell(rowcount, 3).Value = item.Price;
                    rowcount++;
                }

                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }

            }
        }
    }
}
