using Employeedetails.DTO.Brand;
using Employeedetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employeedetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public readonly QosteqEmployeeContext _db;
        public BrandController(QosteqEmployeeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Brand> brands = _db.Brands.ToList();

            List<GetBrandDTO> branded = brands.Select(b => new GetBrandDTO 
            {
                Id = b.Id,
                Name = b.Name,
                CreatedBy = b.CreatedBy,
                CreatedDate = b.CreatedDate,
                ModifiedBy = b.ModifiedBy,
                ModifiedDate = b.ModifiedDate,
                Isdeleted = b.Isdeleted,
            }).ToList();
            return Ok(branded);
        }
        [HttpPost]
        public IActionResult Post(PostBrandDTO brand)
        {
            var brands = new Brand
            { 
                Name = brand.Name,
                CreatedBy = brand.CreatedBy,
                CreatedDate = brand.CreatedDate,
                ModifiedBy = brand.ModifiedBy,
                ModifiedDate = brand.ModifiedDate,
                Isdeleted = brand.Isdeleted,
            };
            _db.Brands.Add(brands);
            _db.SaveChanges();
            return Ok(brands);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id,PutBrandDTO brand)
        {
            //var brands = _db.Brands.FirstOrDefault(x => x.Id == id);
            //brands.Id = brand.Id;
            //brands.Name = brand.Name;
            //brands.CreatedBy = brand.CreatedBy;
            //brands.CreatedDate = brand.CreatedDate;
            //brands.ModifiedBy = brand.ModifiedBy;
            //brands.ModifiedDate = brand.ModifiedDate;
            //brand.Isdeleted = brand.Isdeleted;

            var brands = new Brand
            {
                Id = brand.Id,
                Name = brand.Name,
                CreatedBy = brand.CreatedBy,
                CreatedDate = brand.CreatedDate,
                ModifiedBy = brand.ModifiedBy,
                ModifiedDate = brand.ModifiedDate,
                Isdeleted = brand.Isdeleted,
            };
           
            _db.Brands.Update(brands);
            _db.SaveChanges();
            return Ok(brands);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var brnad = _db.Brands.FirstOrDefault(x => x.Id == id);
            _db.Brands.Remove(brnad);
            _db.SaveChanges();
            return Ok();
        }
    }
}
