using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
namespace Presistence.DAL
{
    public class DataBaseContext
    {
         private readonly string _jsonFileLocation;
        public DataBaseContext()
        {
            _jsonFileLocation = AppDomain.CurrentDomain.BaseDirectory + @"\Database";
        }

        public void SaveChanges<T>(IList<T> entities) where T : class
        {
            if (entities == null)
                return;

            string filePath = Path.Combine(_jsonFileLocation, $"{typeof(T).Name}.json");

            using (var writer = new StreamWriter(filePath))
            {
                var serializer =  Newtonsoft.Json.JsonConvert.SerializeObject(entities);
                writer.Write(serializer);
                writer.Flush();
            }
        }

        public IList<T> Set<T>() where T : class
        {
            string filePath = Path.Combine(_jsonFileLocation, $"{typeof(T).Name}.json");
            IList<T> entities = new List<T>();
            
            if (File.Exists(filePath))
            {
                string values = File.ReadAllText(filePath);
                if(values == "")  {entities =  new List<T>();}
                else{ entities =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(values);};
            }
            else
            {
                using(System.IO.File.Create(filePath)){};
            }

            return entities;
        }
    }
}