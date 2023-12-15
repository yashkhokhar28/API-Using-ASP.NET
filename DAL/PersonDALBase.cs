﻿using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class PersonDALBase : DALHelper
    {
        #region Method : dbo.API_Person_SelectAll
        public List<PersonModel> dbo_API_Person_SelectAll()
        {
            try
            {
                List<PersonModel> listOfPerson = new List<PersonModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_SelectAll");
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        PersonModel personModel = new PersonModel();
                        personModel.PersonID = Convert.ToInt32(dataReader["PersonID"]);
                        personModel.Name = dataReader["Name"].ToString();
                        personModel.Email = dataReader["Email"].ToString();
                        personModel.Contact = dataReader["Contact"].ToString();
                        listOfPerson.Add(personModel);
                    }

                }
                return listOfPerson;
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

                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", DbType.Int32, PersonID);
                PersonModel personModel = new PersonModel();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataReader.Read();
                        personModel.PersonID = Convert.ToInt32(dataReader["PersonID"].ToString());
                        Console.WriteLine(Convert.ToInt32(dataReader["PersonID"].ToString()));
                        personModel.Name = dataReader["Name"].ToString();
                        personModel.Email = dataReader["Email"].ToString();
                        personModel.Contact = dataReader["Contact"].ToString();
                }
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