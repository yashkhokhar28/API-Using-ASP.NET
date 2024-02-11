using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : Controller
    {
        #region Get All City
        [HttpGet]
        public IActionResult Get()
        {
            CityDAL cityDAL = new CityDAL();
            List<CityModel> cityModels = cityDAL.dbo_API_City_SelectAll();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (cityModels.Count > 0 && cityModels != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", cityModels);
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", cityModels);
                return Ok(response);
            }
        }
        #endregion

        #region Get All City
        [HttpGet]
        public IActionResult DropDown()
        {
            CityDAL cityDAL = new CityDAL();
            List<CityDropDownModel> cityModels = cityDAL.dbo_API_City_DropDown();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (cityModels.Count > 0 && cityModels != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", cityModels);
                return Ok(response);
            }
            else
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", cityModels);
                return Ok(response);
            }
        }
        #endregion
    }
}
