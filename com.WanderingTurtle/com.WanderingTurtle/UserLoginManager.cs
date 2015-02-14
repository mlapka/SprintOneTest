using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.WanderingTurtle.Common;
using com.WanderingTurtle.DataAccess;

namespace com.WanderingTurtle
{
    public class UserLoginManager
    {
        /// <summary>  Create a user login
        /// 
        /// </summary>
        /// <param name="userLogin">userName</param>
        /// <returns>integer of the loginID</returns>

        public int AddAUserLogin(string userLogin)
        {

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public UserLogin RetrieveUserLogin(int userID)
        {
            return new UserLogin();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public List<UserLogin> RetrieveUserLoginList()
        {
            return new List<UserLogin>();
        }

        //Update
        public int EditUserLogin(string oldUserLogin, string newUserLogin)
        {
            return 1;
        }


        //Need Archive user??

        //Create 
        public int AddAnEmployee(Employee employeeToAdd)
        {
            return 1;
        }

        //Read
        public string RetrieveEmployee(string UserName)
        {
            return "";
        }

        public List<Employee> RetrieveEmployeeList()
        {
            try
            {
                return EmployeeAccessor.GetEmployeeList();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                var error = new ApplicationException("There was a problem accessing the server.\nPlease contact your system administrator.");
                throw error;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Update
        public int EditEmployee(Employee employeeToEdit)
        {
            return 1;
        }




    }
}
