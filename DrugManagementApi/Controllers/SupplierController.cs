using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagementApi.Models;

namespace DrugManagementApi.Controllers
{
    [Route("skillihouse/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private static List<Supplier> supplierList = new List<Supplier>()
        {
            new Supplier{
                Name = "Canara Suppliers", 
                Company = "Canara", 
                SupplierId = 100, 
                Address = "Manglore"},
            new Supplier{
                Name = "Malnad Suppliers", 
                Company = "Malnad", 
                SupplierId = 200, 
                Address = "Shivamogga"}
        };

        [HttpGet("GetSuppliers")]
        public List<Supplier> GetSuppliers()
        {
            return new List<Supplier>();
        }

        [HttpPost("AddSupplier")]
        public void AddSupplier(Supplier supplier)
        {
            supplierList.Add(supplier);
        }

        [HttpDelete("DeleteSupplier/{supplierId}")]
        public void DeleteSupplier(int  supplierId)
        {
            var supplier = supplierList.Where(s => s.SupplierId == supplierId).FirstOrDefault();
            supplierList.Remove(supplier);
        }

        [HttpGet("GetSupplier/{supplierId}")]
        public Supplier GetSupplier(int supplierId)
        {
            var supplier = supplierList.Where(s => s.SupplierId == supplierId).FirstOrDefault();
            return supplier;
        }

    }
}
