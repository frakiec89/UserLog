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

            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    object content = formatter.Deserialize(stream);
                    
                    if (  content ==null)
                    {
                        return default(T); 
                    }
                    else
                    {
                        return content as T;
                    }
                }
                catch
                {
                 return default(T);
                }
                finally
                {
                    stream.Close();
                }
            }
        }

        public void Save<T>(string filePath, T t) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(stream, t);
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


    }
}
