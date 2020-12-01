using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; // Это надо
using System.IO;// Это надо
namespace UserLog
{
    public class UserController
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
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("User.bin", FileMode.OpenOrCreate))
            {
                try
                {
                    Object userObject = formatter.Deserialize(stream);
                    if (userObject==null)
                    {
                        return new List<User>();
                    }

                    List<User> users = userObject as List<User>; // конвертирование  объекта
                    return users;
                }
                catch
                {
                    return new List<User>();
                }

            }
        }
        public  void AddUSer ( User user)
        {
            Users.Add(user);
            SaveUser();
        }

        public void SaveUser()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("User.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, Users);
                stream.Close();
            }
        }

    }
}
