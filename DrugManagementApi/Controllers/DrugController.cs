using DrugManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DrugManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        //hard code of drug because we dont have a db

        private static  List<Drug> drugList = new List<Drug>()
        {
            new Drug{Name = "Dolo350", Id = 100,
                SerialNumber = "AB100",  ManufacturedDate = new DateTime(2020,12,8),
               ExpiredDate = new DateTime(2017,12,6) },

             new Drug{Name = "CPM350", Id = 200,
                SerialNumber = "XY200",  ManufacturedDate = new DateTime(2020,12,8),
               ExpiredDate = new DateTime(2017,12,6) }

        };
        //method
        [HttpGet("GetAllDrugs")]
        public List<Drug> GetAll()
        {
            return drugList;
        }

        [HttpPost("AddDrug")]
        public void AddDrug(Drug drug)
        {
            drugList.Add(drug);
        }

        [HttpDelete("DeleteDrug")]
        public void DeleteDrug(int drugId)
        {
            var drugToBeDeleted = drugList.Where(d => d.Id == drugId).FirstOrDefault();    
            drugList.Remove(drugToBeDeleted);
        }

        [HttpGet("GetDrug")]
        public Drug  GetDrug(int drugId)
        {
            var drugRecord = drugList.Where(d => d.Id == drugId).FirstOrDefault();
            return drugRecord;
        }
    }
}
