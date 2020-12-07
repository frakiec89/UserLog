using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; // Это надо
using System.IO;// Это надо
namespace UserLog
{
    public class UserController : BaseSerializable
    {
        /// <summary>
        /// Список юзеров
        /// </summary>
        public  List<User> Users { get; private set; }
        public UserController ()
        {
            Users = RunUser();
        }




        /// <summary>
        /// Получит  список из хранилища
        /// </summary>
        /// <returns></returns>
        private List<User> RunUser()
        {
            if (base.Run<List<User>> ("User.bin"  ) !=null  )
            {
                return base.Run<List<User>>("User.bin");
            }
            return new List<User>();
        }
     

        public void SaveUser()
        {
            base.Save("User.bin", Users);
        }



        public void AddUSer(User user)
        {
            Users.Add(user);
            SaveUser();
        }
    }
}
