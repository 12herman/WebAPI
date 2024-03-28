using DinkToPdf;
using DinkToPdf.Contracts;
using Employeedetails.Models;
using Employeedetails.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Reflection.Metadata;
using System.Text;

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfGeneratorController : ControllerBase
    {
        private readonly PdfGenerator _pdfGenerator;

        //public readonly QosteqEmployeeContext _db;
        //public PdfGeneratorController(QosteqEmployeeContext db)
        //{
        //    _db = db;
        //}

        public PdfGeneratorController( PdfGenerator pdfGenerator) {
            this._pdfGenerator = pdfGenerator;
        }

        

        [HttpPost]
        public IActionResult Post (PdfGeneratorModel pdf)
        {
            try
            {
                string htmlContent = $@"
<html>
    <body style=""width: 90%; margin: 0 auto; font-family: Arial, Helvetica, sans-serif; "">
   
    <table width=""100%"" style=""margin-top: 5rem;"">
      <tr
        style=""
          display: flex;
          justify-content: space-between;
          align-items: center;
          list-style-type: none;
          padding: 0;
        ""
      >
        <th width=""80%"">
          <h2
            style=""
              font-size: 1.8rem;
              font-weight: 600;
              margin: 0;
              text-align: start;
            ""
          >
            QOSTEQ IT PRIVATELIMITED
          </h2>
          <p
            style=""
              text-transform: uppercase;
              font-size: 1rem; text-align: justify; font-weight: 500;"" >4/229 FIRST STREET MUTHAMMAL COLONY Tuticorin Tamil Nadu 628002 India</p>
        </th>
        <th width=""20%"">
          <img
            src=""https://static.wixstatic.com/media/be1b62_cc6b93d35fe4471ba5af404f465e00f8~mv2.png/v1/fill/w_184,h_110,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/customcolor_logo_transparent_background.png""
            alt=""Company Logo""
            style=""width: auto; height: 110px""
          />
        </th>
      </tr>
     
    </table>

    <hr style=""border: 1px solid #e5e7eb; margin-top: 50px; margin-bottom: 20px;"" />

    <div >
      <table width=""100%"">
      <tr>
        <th width=""50%"">
            <span style=""display: block; text-align: start;"">Payslip for the month of {pdf.PaySlipMonth}</span>
            <span style=""display: block; text-align: start; font-size: 1.5rem; padding: 10px 0 5px 0;"">{pdf.Name}</span>
            <span style=""display: block; text-align: start; font-weight: 200; font-size: 0.9rem;"">3D Modeller | {pdf.DepartmentName} | | Date of Joining: {pdf.DateOfJoining}</span>
        </th>
        
        <th width=""50%"">
            <span style=""display: block; text-align: end;font-size: 0.9rem; font-weight: 600;""> Employee Net Pay</span>
            <span style=""display: block; text-align: end; font-size: 2.5rem; padding: 8px 0;"">₹{pdf.NetSalary}.00</span>
            <span style=""display: block; text-align: end; font-weight: 200; font-size: 0.9rem; color: #6b7280;"">Paid Days: 29 | LOP Days: 0</span> 
        </th>
       
    </tr>
    </table>
      <hr
        style=""
          border: 1px dashed #e5e7eb;
          margin-top: 1.25rem;
          margin-bottom: 10px;
          border-bottom-width: 0.0625rem;
          border-color: #d1d5db;
        ""
      />
    </div>

    <div>
      <table style=""gap: 0; color: #6b7280; font-size: 0.9rem; font-weight: 200;; padding: 10px 0;"" width=""100%"">
        <tr>
          <th width=""50%"" style=""text-align: start; font-size: 1rem; font-weight: 500;"">Banck Account No : {pdf.AccountNo}</th>
          <th width=""50%"" style=""text-align: start; font-size: 1rem; font-weight: 500;"">UAN :</th>
        </tr>
        <tr style=""border-top: 1px solid #e5e7eb""></tr>
      </table>
     
      <hr style=""border: 1px solid #e5e7eb; margin-top: 50px; margin-bottom: 20px;"" />
    </div>

    <table style=""gap: 0; margin-top: 20px;"" width=""100%"">
        <tr>
        <th width=""50%"" style=""text-align: start"">
         <div>
            <table
            style=""width: 100%; margin-top: 1rem; border-collapse: collapse"">
            <tr
              style=""text-transform: uppercase;
                font-size: 0.9rem;
                font-weight: 600;"">
              <th style=""text-align: left; padding-bottom: 22px; font-size: 0.9rem;font-style: italic;"">Earnings</th>
              <th style=""text-align: right; padding-bottom: 22px; font-size: 0.9rem;font-style: italic;"">Amount</th>
              <th style=""text-align: right; padding-bottom: 22px; font-size: 0.9rem;font-style: italic;"">YTD</th>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;  border-top: 1px solid #e5e7eb;"">
              <td style=""padding-top: 22px;"">Basic</td>
              <td style=""text-align: right;  font-weight: 600;padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right; padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">House Rent Allowance</td>
              <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right;padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">Conveyance Allowance</td>
              <td style=""text-align: right; font-weight: 600; padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right;padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">Transport Allowance</td>
              <td style=""padding-top: 22px; text-align: right; font-weight: 600;"">₹ 10,000.00</td>
              <td style=""padding-top: 22px; text-align: right"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">Travelling Allowance</td>
              <td style=""padding-top: 22px; text-align: right; font-weight: 600;"">₹ 10,000.00</td>
              <td style=""padding-top: 22px; text-align: right"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">LTA</td>
              <td style=""padding-top: 22px; text-align: right; font-weight: 600;"">₹ 10,000.00</td>
              <td style=""padding-top: 22px; text-align: right"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px; padding-bottom: 22px;"">Fixed Allowance</td>
              <td style=""padding-top: 22px; padding-bottom: 22px; text-align: right; font-weight: 600;"">₹ 10,000.00</td>
              <td style=""padding-top: 22px; padding-bottom: 22px; text-align: right"">₹ 10,000.00</td>
            </tr>
            <tr style=""border-top: 1px solid #e5e7eb;font-size: 0.9rem;"">
              <td style=""font-weight: 600;padding-top: 22px;"">Gross Earnings</td>
              <td style=""text-align: right; padding-top: 22px;"">₹ {pdf.NetSalary}.00</td>
              <td style=""text-align: right;padding-top: 22px;""></td>
            </tr>
          </table>
         </div>
        </th>
       
        <th width=""100%"" style=""text-align: start;  padding-left: 30px;"">
          <div>
            <table
            width=""100%""
            style="" margin-top: 0.875rem; border-collapse: collapse"">
            <tr
              style=""
                text-transform: uppercase;
                font-size: 0.9rem;
                font-weight: 600;
              "">
              <th style=""text-align: left; padding-bottom: 22px;font-size: 0.9rem;font-style: italic;"">DEDUCTIONS</th>
              <th style=""text-align: right; padding-bottom: 22px;font-size: 0.9rem;font-style: italic;"">Amount</th>
              <th style=""text-align: right; padding-bottom: 22px;font-size: 0.9rem;font-style: italic;"">YTD</th>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;; border-top: 1px solid #e5e7eb"">
              <td style=""padding-top: 22px;"">EPF Contribution</td>
              <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right;padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">Professional Tax</td>
              <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right;padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
              <td style=""padding-top: 22px;"">Income Tax</td>
              <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">₹ 10,000.00</td>
              <td style=""text-align: right;padding-top: 22px;"">₹ 10,000.00</td>
            </tr>
            <tr style=""font-size: 0.9rem; font-weight: 200;"">
                <td style=""padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right;padding-top: 22px;"">&#160;</td>
              </tr>
              <tr style=""font-size: 0.9rem; font-weight: 200;"">
                <td style=""padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right;padding-top: 22px;"">&#160;</td>
              </tr>
              <tr style=""font-size: 0.9rem; font-weight: 200;"">
                <td style=""padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">&#160;</td>
                <td style=""text-align: right;padding-top: 22px;"">&#160;</td>
              </tr>
              <tr style=""font-size: 0.9rem; font-weight: 200;"">
                <td style=""padding-top: 22px;padding-bottom: 22px;"">&#160;</td>
                <td style=""text-align: right; font-weight: 600;padding-top: 22px;padding-bottom: 22px;"">&#160;</td>
                <td style=""text-align: right;padding-top: 22px;padding-bottom: 22px;"">&#160;</td>
              </tr>

            <tr style=""border-top: 1px solid #e5e7eb;font-size: 0.9rem;"">
              <td style=""font-weight: 600;padding-top: 22px;"">Total Deductions</td>
              <td style=""text-align: right; font-weight: 600;padding-top: 22px;"">₹ 0.00</td>
              <td style=""text-align: right;padding-top: 22px;""></td>
            </tr>
          </table>
          </div>
        </th>
      </tr>
    </table>

    <div class=""footer-amount"" style=""margin-top: 4rem;"">
      <ul
        style=""
          list-style: none;
          display: flex;
          flex-direction: column;
          gap: 0.25rem;
          justify-content: center;
          align-items: center;
          padding: 1.25rem 0;
          background-color: #f0f5ff;
          margin-top: 1.25rem;
          padding-left: 0;
        ""
      >
        <li style=""font-weight: 500; text-align: center; font-size: 1.2rem; font-weight: 400;"">
          Total <span style=""font-weight: bold"">₹{pdf.NetSalary}.00</span>
         (Indian Rupee {pdf.SalaryWords} only)
          
        </li>
        <li style=""font-size: 0.8rem; text-align: center; margin-bottom: 25px;"">
          **Total Net Payable = Gross Earnings - Total Deductions
        </li>
      </ul>
      <span
        style=""
          display: block;
          text-align: center;
          font-size: 0.725rem;
          margin-top: 0.0625rem;
        ""
      >
        -- This is a system generated payslip, hence the signature is not
        required. --
      </span>
    </div>
  </body>
</html>";

                byte[] pdfBytes = _pdfGenerator.GeneratorPdf(htmlContent);

                return File(pdfBytes,"application/pdf",$"{pdf.PaySlipMonth}.pdf");

                }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while generating the PDF.");
            }
            
        }
    }
}
