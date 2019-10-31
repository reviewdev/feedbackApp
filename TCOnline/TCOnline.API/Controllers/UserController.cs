using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCOnline.API.DataAccessLayer;
using TCOnline.API.Models;

namespace TCOnline.API.Controllers
{
    public class UserController : ApiController
    {
    
        #region Get AllUsers and Get One User

        /// <summary>
        /// Get all the available users who can use this app.
        /// </summary>
        /// <returns> a list of user</returns>

        [System.Web.Http.HttpGet]
        public List<User_DTO> GetAllUsers()
        {
            List<User> userDALList = DAL.GetAllUsers();
            List<User_DTO> userApiList = new List<User_DTO>();

            foreach (var item in userDALList)
            {
                User_DTO userapi = new User_DTO();
                userapi.Id = item.Id;
                userapi.UserName = item.UserName;
                userapi.Password = item.Password;
                userApiList.Add(userapi);
            }
            return userApiList;
        }

       /// <summary>
       /// Find user record with uer login information
       /// </summary>
       /// <param name="username">User Name </param>
       /// <param name="password">Password</param>
       /// <returns></returns>
        [System.Web.Http.HttpGet]
        public bool FindUser(string username, string password)
        {
            return DAL.FindUser(username, password);

        }

        #endregion
    } // end of class
}