using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{

    [Serializable] // атрибут  
    public class LogServer
    {
        public User User { get; set; } // Кто  вошел 

        public DateTime DateTimeIn { get; set; } // Когда вошел

        public bool Status { get; set; } // результат 

        public string BedLogin { get; set; }
        public string BedPassword { get; set; }


        public  LogServer (User user , DateTime time ) // если вход  удачный
        {
            User = user;
            DateTimeIn = time;
            Status = true;
        }

        public LogServer( string bedLogin  ,  string bedPassword ,  DateTime time) // если вход не  удачный  удачный
        {
            BedLogin = bedLogin;
            BedPassword = bedPassword;
            DateTimeIn = time;
        }
    }
}
