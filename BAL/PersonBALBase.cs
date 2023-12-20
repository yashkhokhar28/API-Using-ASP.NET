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
        public PersonModel dbo_API_Person_SelectByID(int PersonID)
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                PersonModel personModel = personDALBase.dbo_API_Person_SelectByID(PersonID);
                return personModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_Person_DeleteByID
        public bool dbo_API_Person_Delete(int PersonID)
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                if (personDALBase.dbo_API_Person_Delete(PersonID))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.API_Person_Insert
        public bool dbo_API_Person_Insert(PersonModel personModel)
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                if (personDALBase.dbo_API_Person_Insert(personModel))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.API_Person_Update
        public bool dbo_API_Person_Update(int PersonID, PersonModel personModel)
        {
            try
            {
                PersonDALBase personDALBase = new PersonDALBase();
                if (personDALBase.dbo_API_Person_Update(PersonID,personModel))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
