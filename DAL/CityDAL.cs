using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace APIDemo.DAL
{
    public class CityDAL : CityDALBase
    {
        #region Method : dbo.API_City_DropDown
        public List<CityDropDownModel> dbo_API_City_DropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_City_DropDown");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<CityDropDownModel> listOfCity = new List<CityDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CityDropDownModel cityDropDownModel = new CityDropDownModel();
                    cityDropDownModel.CityID = Convert.ToInt32(dataRow["CityID"]);
                    cityDropDownModel.CityName = dataRow["CityName"].ToString();
                    listOfCity.Add(cityDropDownModel);
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
