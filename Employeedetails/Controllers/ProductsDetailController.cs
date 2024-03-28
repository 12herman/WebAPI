using Employeedetails.DTO.ProductsDetail;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public ProductsDetailController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //List<Productdetail> productdetails = new List<Productdetail>();

            ////productdetails = _db.Productdetails.ToList();
            ////return Ok(productdetails);

            var result = from Productdetail in _db.Productdetails
                         join Accessory in _db.Accessories on Productdetail.AccessoriesId equals Accessory.Id
                         join Brand in _db.Brands on Productdetail.BrandId equals Brand.Id
                         join Employee in _db.Employeedetails on Productdetail.EmployeeId equals Employee.Id into employeeGroup
                         from Employee in employeeGroup.DefaultIfEmpty()
                             //join Employeedetail in _db.Employeedetails on Productdetail.EmployeeId equals Employeedetail.Id
                             //join Employeedetail in _db.Employeedetails on Productdetail.EmployeeId equals Employeedetail.Id
                         join Officelocation in _db.Officelocations on Productdetail.OfficeLocationId equals Officelocation.Id into officeLocationGroup
                         from Officelocation in officeLocationGroup.DefaultIfEmpty()
                             //join Productsrepairhistory in _db.Productsrepairhistories on Productdetail.Id equals Productsrepairhistory.ProductsDetailId
                         select new
                         {
                             Id = Productdetail.Id,
                             BrandId = Brand.Id,
                             AccessoriesId = Accessory.Id,
                             BrandName = Brand.Name,
                             AccessoryName = Accessory.Name,
                             ProductName = Productdetail.ProductName,
                             ModelNumber = Productdetail.ModelNumber,
                             SerialNumber = Productdetail.SerialNumber,
                             CreatedDate = Productdetail.CreatedDate,
                             CreatedBy = Productdetail.CreatedBy,
                             ModifiedDate = Productdetail.ModifiedDate,
                             ModifiedBy = Productdetail.ModifiedBy,
                             IsDeleted = Productdetail.IsDeleted,
                             IsRepair = Productdetail.IsRepair,
                             IsAssigned = Productdetail.IsAssigned,
                             Comments = Productdetail.Comments,
                             OfficeLocationId = Officelocation != null ? Officelocation.Id : (int?)null,
                             OfficeName = Officelocation != null ? Officelocation.Officename : null,
                             IsStorage = Productdetail.IsStorage,
                             EmployeeId = Productdetail.EmployeeId,
                             //EmployeeId = Employee?.Id,
                             EmployeeName = Employee != null ? Employee.FirstName + " " + Employee.LastName : null,
                             //ProductRepairHistoryId = Productsrepairhistory.ProductsDetailId,
                             //ProductRepairComments = Productsrepairhistory.Comments,
                             //ProductRepairDate = Productsrepairhistory.CreatedDate,

                         };

            //var result = from Product in _db.Productdetails
            //             join Employee in _db.Employeedetails on Product.EmployeeId equals Employee.Id

            //             select new
            //             {
            //                Id = Product.Id,
            //                Name=Product.ProductName,
            //                SerialNumber=Product.SerialNumber,
            //                //EmployeeId = Employee.Id,
            //                //Name = Employee.FirstName + " " + Employee.LastName,

            //             };
            return Ok(result.ToList());
        }

        [HttpPost]
        public IActionResult Post(PostProductDetailsDTO productdetailDTO)
        {
            var productDetails = new Productdetail
            {
                AccessoriesId = productdetailDTO.AccessoriesId,
                BrandId = productdetailDTO.BrandId,
                ProductName = productdetailDTO.ProductName,
                ModelNumber = productdetailDTO.ModelNumber,
                SerialNumber = productdetailDTO.SerialNumber,
                IsDeleted = productdetailDTO.IsDeleted,
                IsAssigned = productdetailDTO.IsAssigned,
                IsRepair = productdetailDTO.IsRepair,
                CreatedBy = productdetailDTO.CreatedBy,
                CreatedDate = productdetailDTO.CreatedDate,
                ModifiedBy = productdetailDTO.ModifiedBy,
                ModifiedDate = productdetailDTO.ModifiedDate,
                Comments = productdetailDTO.Comments,
                OfficeLocationId = productdetailDTO.OfficeLocationId,
                IsStorage = productdetailDTO.IsStorage,
                EmployeeId = productdetailDTO.EmployeeId
            };
            _db.Productdetails.Add(productDetails);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(PutProductDetailsDTO productDetailsDTO)
        {
            var productDetails = new Productdetail
            {
                Id = productDetailsDTO.Id,
                BrandId = productDetailsDTO.BrandId,
                ModelNumber = productDetailsDTO.ModelNumber,
                AccessoriesId = productDetailsDTO.AccessoriesId,
                ProductName = productDetailsDTO.ProductName,
                SerialNumber = productDetailsDTO.SerialNumber,
                IsDeleted = productDetailsDTO.IsDeleted,
                IsAssigned = productDetailsDTO.IsAssigned,
                IsRepair = productDetailsDTO.IsRepair,
                CreatedBy = productDetailsDTO.CreatedBy,
                CreatedDate = productDetailsDTO.CreatedDate,
                ModifiedBy = productDetailsDTO.ModifiedBy,
                ModifiedDate = productDetailsDTO.ModifiedDate,
                Comments = productDetailsDTO.Comments,
                OfficeLocationId = productDetailsDTO.OfficeLocationId,
                IsStorage = productDetailsDTO.IsStorage,
                EmployeeId = productDetailsDTO.EmployeeId,
            };

            _db.Productdetails.Update(productDetails);
            _db.SaveChanges();
            return Ok(productDetails);
        }

        ////[HttpPut("{id:int}")]
        ////public IActionResult Put(int id,  PutProductDetailsDTO productDetailsDTO)
        ////{
        ////    var productDetails = from Productdetail in _db.Productdetails
        ////                         join Accessory in _db.Accessories on Productdetail.AccessoriesId equals Accessory.Id
        ////                         join Brand in _db.Brands on Productdetail.BrandId equals Brand.Id
        ////                         join Employee in _db.Employeedetails on Productdetail.EmployeeId equals Employee.Id into employeeGroup
        ////                         from Employee in employeeGroup.DefaultIfEmpty()
        ////                         join Officelocation in _db.Officelocations on Productdetail.OfficeLocationId equals Officelocation.Id into officeLocationGroup
        ////                         from Officelocation in officeLocationGroup.DefaultIfEmpty()
        ////                         select new
        ////                         {
        ////                             Id = Productdetail.Id,
        ////                             BrandId = Brand.Id,
        ////                             AccessoriesId = Accessory.Id,
        ////                             BrandName = Brand.Name,
        ////                             AccessoryName = Accessory.Name,
        ////                             ProductName = Productdetail.ProductName,
        ////                             ModelNumber = Productdetail.ModelNumber,
        ////                             SerialNumber = Productdetail.SerialNumber,
        ////                             CreatedDate = Productdetail.CreatedDate,
        ////                             CreatedBy = Productdetail.CreatedBy,
        ////                             ModifiedDate = Productdetail.ModifiedDate,
        ////                             ModifiedBy = Productdetail.ModifiedBy,
        ////                             IsDeleted = Productdetail.IsDeleted,
        ////                             IsRepair = Productdetail.IsRepair,
        ////                             IsAssigned = Productdetail.IsAssigned,
        ////                             Comments = Productdetail.Comments,
        ////                             OfficeLocationId = Officelocation != null ? Officelocation.Id : (int?)null,
        ////                             OfficeName = Officelocation != null ? Officelocation.Officename : null,
        ////                             IsStorage = Productdetail.IsStorage,
        ////                             EmployeeId =Productdetail.Id,
        ////                             EmployeeName = Employee != null ? Employee.FirstName + " " + Employee.LastName : null,
        ////                         };
        ////    // You can return the updated product details if necessary
        ////    return Ok(productDetails.ToList());
        ////}


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var productDetails = _db.Productdetails.FirstOrDefault(x => x.Id == id);
            _db.Productdetails.Remove(productDetails);
            _db.SaveChanges();
            return Ok();
        }
    }
}