using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Contacts.Services
{
    public class JsonSaverService
    {

        public static void SaveJson(string folder, string fileName, object _data)
        {
            string filePath = string.Format("{0}/{1}", folder, fileName);

            CreateFileIfNotExists(folder, fileName);

            //open file stream
            using (StreamWriter file = new StreamWriter(filePath, false))
            {
                string jsonString = JsonSerializer.Serialize(_data);
                file.Write(jsonString);
            }
        }

        public static T GetJson<T>(string folder, string fileName)where T : class
        {
            string filePath = string.Format("{0}/{1}", folder, fileName);

            CreateFileIfNotExists(folder, fileName);
            string jsonBytes = File.ReadAllText(filePath);

            T jsonData = null;
            if (jsonBytes != string.Empty)
            {
                jsonData = JsonSerializer.Deserialize<T>(jsonBytes);
            }
            return jsonData;
        }

        private static void CreateFileIfNotExists(string folder, string fileName)
        {
            string filePath = string.Format("{0}/{1}", folder, fileName);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(filePath))
            {
                var myFile = File.CreateText(filePath);
                myFile.Close();
            }
        }
    }
}
