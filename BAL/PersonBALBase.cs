using APIDemo.DAL;
using APIDemo.Models;

namespace APIDemo.BAL
{
    public class PersonBALBase
    {
        #region Method : dbo.API_Person_SelectAll
        public List<PersonModel> dbo_API_Person_SelectAll()
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                List<PersonModel> personModels = personDALBase.dbo_API_Person_SelectAll();
                return personModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_Person_SelectByID
        public PersonModel dbo_API_Person_SelectByID(int UserID)
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                PersonModel personModel = personDALBase.dbo_API_Person_SelectByID(UserID);
                return personModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
