using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region GetAll
        [HttpGet]
        public IActionResult Get()
        {
            PersonBALBase personBALBase = new PersonBALBase();
            List<PersonModel> personList = personBALBase.dbo_API_Person_SelectAll();
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (personList.Count > 0 && personList != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", personList);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region GetByID
        [HttpGet("{PersonID}")]
        public IActionResult Get(int PersonID)
        {
            PersonBALBase personBALBase = new PersonBALBase();
            PersonModel personModel = personBALBase.dbo_API_Person_SelectByID(PersonID);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (personModel.PersonID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", personModel);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{PersonID}")]
        public IActionResult Delete(int PersonID)
        {
            PersonBALBase personBALBase = new PersonBALBase();
            bool IsSuccess = personBALBase.dbo_API_Person_Delete(PersonID);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Deleted");
                return NotFound(response);
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Post([FromForm] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            PersonBALBase personBALBase = new PersonBALBase();
            bool IsSuccess = personBALBase.dbo_API_Person_Insert(personModel);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Inserted");
                return NotFound(response);
            }

        }
        #endregion

        #region Update
        [HttpPut("{PersonID}")]
        public IActionResult Put(int PersonID, [FromForm] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            PersonBALBase personBALBase = new PersonBALBase();
            bool IsSuccess = personBALBase.dbo_API_Person_Update(PersonID, personModel);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Updated");
                return NotFound(response);
            }

        }
        #endregion
    }




}
