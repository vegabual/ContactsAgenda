using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Contacts.Services
{
    public class JsonSaverServicecs
    {

        public static void SaveJson(string filePath, object _data)
        {
            if (!File.Exists(filePath))
            {
                File.CreateText(filePath);
            }
            //open file stream
            using (StreamWriter file = new StreamWriter(filePath, false))
            {
                string jsonString = JsonSerializer.Serialize(_data);
                file.Write(jsonString);
            }
        }

        public static T GetJson<T>(string filePath)
        {
            var jsonBytes = File.ReadAllBytes(filePath);
            T jsonData = JsonSerializer.Deserialize<T>(jsonBytes);

            return jsonData;
        }
    }
}
