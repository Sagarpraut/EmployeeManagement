using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class UserDataAccessLayer
    {
        public void addUser(User user)
        {

            string jsonData = System.IO.File.ReadAllText(@"E:\userData.json");

            List<User> userList = new List<User>();

            userList = JsonConvert.DeserializeObject<List<User>>(jsonData);

            userList.Add(user);

            string jsonData2 = JsonConvert.SerializeObject(userList);

            System.IO.File.WriteAllText(@"E:\userData.json", jsonData2);

        }

        public bool checkUserLogin(string email, string pass)
        {
            string jsonData = System.IO.File.ReadAllText(@"E:\userData.json");

            List<User> userList = new List<User>();

            userList = JsonConvert.DeserializeObject<List<User>>(jsonData);
            int flag = 0;
            foreach(User user in userList)
            {
                if (email == user.EmailID && pass == user.Password)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
                return true;
            else
                return false;

        }

    }

}
