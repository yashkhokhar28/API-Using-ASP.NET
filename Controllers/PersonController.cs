using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
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
            int personID = personBALBase.dbo_API_Person_Delete(PersonID);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (personID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted");
                response.Add("deletedID", personID);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Deleted");
                response.Add("deletedID", 0);
                return NotFound(response);
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Insert([FromBody] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            PersonModel model = new PersonModel();
            model.Name = personModel.Name;
            model.Email = personModel.Email;
            model.Contact = personModel.Contact;
            PersonBALBase personBALBase = new PersonBALBase();
            personBALBase.dbo_API_Person_Insert(model);
            return CreatedAtAction(nameof(Get), new { id = model.PersonID }, model);
        }
        #endregion

        #region Update
        [HttpPut("{PersonID}")]
        public IActionResult Update([FromRoute] int PersonID, [FromBody] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            PersonModel model = new PersonModel();
            model.Name = personModel.Name;
            model.Email = personModel.Email;
            model.Contact = personModel.Contact;
            PersonBALBase personBALBase = new PersonBALBase();
            personBALBase.dbo_API_Person_Update(model);
            return CreatedAtAction(nameof(Get), new { id = model.PersonID }, model);
        }
        #endregion
    }




}
