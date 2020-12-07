using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace UserLog
{
    public  abstract class BaseSerializable
    { 
        public  T  Run<T> ( string filePath)  where T :class // т это  класс
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("Log.bin", FileMode.OpenOrCreate))
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




    }
}
