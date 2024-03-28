using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Linq;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlSalaryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;

        public XlSalaryController(QosteqEmployeeContext db)
        {
            _db = db;
        }
      

        [HttpPost("api/excel/upload")]
        public IActionResult UploadExcelFile([FromForm] XlSalary file)
        {
          
            if (file == null || file.File.Length <= 0)
                return BadRequest("Invalid file");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Check if the file is an Excel file
            if (Path.GetExtension(file.File.FileName).ToLower() != ".xlsx")
                return BadRequest("Only Excel files are allowed");

            var employeeIds = _db.Salaries.Select(s => s.EmployeeId).ToList();

            //var employeeNames = _db.Employeedetails.Select(s => s.FirstName+s.LastName).ToList();

            List<Dictionary<string, object>> excelData = new List<Dictionary<string, object>>();

            List<string> emptyExcelData = new List<string>();

            // Read the Excel file
            using (var stream = new MemoryStream())
            {
                file.File.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet

                    // Process Excel data here and store it in a list of dictionaries
                    for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                       
                        var employeeIdString = worksheet.Cells[row, 2].Value?.ToString();

                        if (employeeIdString != null && long.TryParse(employeeIdString, out long employeeId) && employeeIds.Contains(employeeId))
                        {
                            var rowData = new Dictionary<string, object>();
                            for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                            {
                                rowData[worksheet.Cells[1, col].Value.ToString()] = worksheet.Cells[row, col].Value;
                            }
                            excelData.Add(rowData);

                        }
                        else
                        {
                           
                            var employeeName = worksheet.Cells[row,3].Value?.ToString();
                            
                            emptyExcelData.Add(employeeName);
                            //if(employeeIdString !=null && long.TryParse(employeeIdString,out long tempEmployeeId)  != employeeIds.Contains(tempEmployeeId))
                            //{
                            //    if (!employeeIds.Contains(tempEmployeeId))
                            //    {

                            //    }


                            //}


                        }

                    }

                    if (emptyExcelData.Count > 0)
                    {
                        List<string> errorNames = new List<string>();

                        for (int i = 0; i < emptyExcelData.Count; i++)
                        {
                            // Assuming emptyExcelData[i] gives you an employee ID or some identifier
                            errorNames.Add($" {emptyExcelData[i]}");
                        }

                        return BadRequest(new { UnmatchedEmployees  = errorNames  });
                    }
                 

                }
                
            }
           

            return Ok(excelData);
           
        }

    }
}
