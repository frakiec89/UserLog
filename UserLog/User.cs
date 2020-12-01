using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{

    [Serializable]
    public class User
    {
        public string Login { get; private set; }
        public  string Password { get; set; }
        public string Name { get; set; }
        public  DateTime BirthDay { get;  set; }

        public User(string login, string password, string name, DateTime birthDay)
        {
            Login = login ?? throw new ArgumentNullException("Логин не может быть пустым");
            Password = password ?? throw new ArgumentNullException("пароль не может быть пустым");
            Name = name ?? throw new ArgumentNullException("Имя не может быть пустым");
            BirthDay = birthDay;
        }

        public User() /// Для  создания  случайного  пользователя 
        {
            Random random = new Random();
            Login = "NoName" +random.Next(0,10000).ToString();
            Password = random.Next(0, 1000000).ToString();
            Name = "NoName";
        }
    }
}
