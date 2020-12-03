using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UserLog
{
    public class LogServerController
    {
        public List<LogServer> LogServers { get; private set; } // список логов


        public LogServerController()
        {
            LogServers = Run(); // получааем  список при старте 
        }

        private List<LogServer> Run()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("Log.bin" , FileMode.OpenOrCreate) )
            {
                try
                {
                    return formatter.Deserialize(stream) as List<LogServer>;
                }
                catch 
                {
                    return new List<LogServer>();    
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        private void Save ()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("Log.bin", FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(stream, LogServers);     
                }
                catch
                {
                    throw new Exception("Ошибка сохранения");
                }
                finally
                {
                    stream.Close();
                }
            }
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
