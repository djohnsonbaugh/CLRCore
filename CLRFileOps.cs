using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CLRCore
{
    static public class CLRFileOps
    {
        static public void SaveFile(string filename, CLRCoreData clrdata)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.Write(JsonConvert.SerializeObject(clrdata));
            }
        }
        static public CLRCoreData OpenFile(string filename)
        {
            string data = "";
            using (StreamReader file = new StreamReader(filename))
            {
                data = file.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<CLRCoreData>(data);
        }
    }
}
