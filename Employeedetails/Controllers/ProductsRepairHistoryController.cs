using Employeedetails.DTO.ProductsRepairHistory;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsRepairHistoryController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public ProductsRepairHistoryController(QosteqEmployeeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<Productsrepairhistory> RepairHistory = new List<Productsrepairhistory>();
            RepairHistory = _db.Productsrepairhistories.ToList();
            return Ok(RepairHistory);
        }

        [HttpPost]
        public IActionResult Post(PostProductsRepairHistoryDTO productsrepairhistory)
        {
            var ProductsHistoryEntity = new Productsrepairhistory
            {
                ProductsDetailId = productsrepairhistory.ProductsDetailId,
                Comments = productsrepairhistory.Comments,
                CreatedBy = productsrepairhistory.CreatedBy,
                CreatedDate = productsrepairhistory.CreatedDate,
                ModifiedDate = productsrepairhistory.ModifiedDate,
                ModifiedBy = productsrepairhistory.ModifiedBy
            };
            _db.Productsrepairhistories.Add(ProductsHistoryEntity);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut]
        public IActionResult Put(PutProductsRepairHistoryDTO productsRepairhistory)
        {
            var ProductHistory = new Productsrepairhistory
            {
                Id = productsRepairhistory.Id,
                ProductsDetailId = productsRepairhistory.ProductsDetailId,
                Comments = productsRepairhistory.Comments,
                CreatedBy = productsRepairhistory.CreatedBy,
                CreatedDate = productsRepairhistory.CreatedDate,
                ModifiedDate = productsRepairhistory.ModifiedDate,
                ModifiedBy = productsRepairhistory.ModifiedBy,
                IsDeleted = productsRepairhistory.IsDeleted,
            };
            _db.Productsrepairhistories.Update(ProductHistory);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var ProductHistory = _db.Productsrepairhistories.FirstOrDefault(x => x.Id == id);
            _db.Productsrepairhistories.Remove(ProductHistory);
            _db.SaveChanges();
            return Ok();
        }
    }
}