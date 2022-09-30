using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyCampusData.Helpers
{
    public static class SeedHelper
    {
        public static List<TEntity> SeedData<TEntity>(string fileName)
        {
            string? currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if(currentDirectory == null) throw new DirectoryNotFoundException("Assembly directory not found");
            string path = "seed";
            string fullPath = Path.Combine(currentDirectory, @"..\..\..\..\", nameof(MyCampusData), path, fileName);

            var result = new List<TEntity>();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string json = reader.ReadToEnd();
                result = JsonSerializer.Deserialize<List<TEntity>>(json);

                if (result == null)
                    throw new NullReferenceException("Error while parsing json file");
            }

            return result;
        }
    }
}
