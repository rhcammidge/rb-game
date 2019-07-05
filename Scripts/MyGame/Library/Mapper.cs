using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
public class Mapper
{

    /**
        Serialize JSON (Object to String)
     */
    public static string serialize<T>(object obj)
    {
        if(obj == null)
            return null;
        MemoryStream stream = new MemoryStream();  
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));  
        ser.WriteObject(stream, obj);
        stream.Position = 0;
        StreamReader sr = new StreamReader(stream);
        
        return sr.ReadToEnd();
    }


    /**
    Deserialize - JSON (String to Object)
    usage: Layers layers = deserialize<Layers>(string);

    @param string s - json to deserialize
    */
    public static T deserialize<T>(string s) where T: new()
    {
        T obj = new T();
        MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));  
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));  

        obj = (T)ser.ReadObject(stream);  
        stream.Close();
        return obj;
    }
}