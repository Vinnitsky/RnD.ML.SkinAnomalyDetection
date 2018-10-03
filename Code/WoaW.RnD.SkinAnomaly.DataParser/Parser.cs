using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WoaW.RnD.SkinAnomaly.DataParser.Models;

namespace WoaW.RnD.SkinAnomaly.DataParser
{
    public class Parser
    {
        public void Save(string filePath, List<DiseasRecord> records)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            string output = JsonConvert.SerializeObject(records);
            File.WriteAllText(filePath, output);
        }
        public List<DiseasRecord> Load(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException(nameof(filePath));

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<DiseasRecord>>(json);
        }
        public DiseasRecord Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            return JsonConvert.DeserializeObject<DiseasRecord>(json);
        }
    }
}
