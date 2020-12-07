using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UserLog
{
    public class LogServerController  : BaseSerializable
    {
        public List<LogServer> LogServers { get; private set; } // список логов


        public LogServerController()
        {
            LogServers = Run(); // получааем  список при старте 
        }

        private List<LogServer> Run()
        {
           if (  base.Run<List<LogServer>>("Log.bin")!=null)
           {
                return base.Run<List<LogServer>>("Log.bin");
           }

            return new List<LogServer>();
           
        }

        private void Save ()
        {
            base.Save("log.bin", LogServers);
        }

        /// <summary>
        /// Добавляет лог в список 
        /// </summary>
        /// <param name="logServer"></param>
   
        
        
        
        public  void Add( LogServer logServer)
        {
            LogServers.Add(logServer);
            Save();
        }

    }
}
