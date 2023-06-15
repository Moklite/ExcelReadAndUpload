using ExcelReadAndUpload.Models;
using ExcelReadAndUpload.Service;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;

namespace ExcelReadAndUpload.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        List<Student> _students = new List<Student>(); 

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SaveStudents(List<Student> students)
        {
            _students = _studentService.SaveStudents(students);
            return Json(_students);
        }

        public string GenerateAndDownloadExcel()
        {
            DataTable dataTable = new DataTable("Students");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Roll");
            dataTable.Columns.Add("Age");

            byte[] fileContents = null;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("students");

                ws.Cells["A1:C1"].Style.Font.Bold = true;
                ws.Cells["A1:C1"].Style.Font.Size = 12;
                ws.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SkyBlue);
                ws.Cells["A1:C1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells["A1:C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["A1"].LoadFromDataTable(dataTable, true);

                pck.Save();
                fileContents = pck.GetAsByteArray();
            }
            return Convert.ToBase64String(fileContents);
        }
    }
}
