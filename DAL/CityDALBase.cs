using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class CityDALBase : DALHelper
    {
        #region Method : dbo.API_City_SelectAll
        public List<CityModel> dbo_API_City_SelectAll()
        {
            try
            {
                List<CityModel> listOfCity = new List<CityModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_City_SelectAll");
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        CityModel cityModel = new CityModel();
                        cityModel.CityID = Convert.ToInt32(dataReader["CityID"]);
                        cityModel.CityName = dataReader["CityName"].ToString();
                        listOfCity.Add(cityModel);
                    }
                }
                return listOfCity;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
