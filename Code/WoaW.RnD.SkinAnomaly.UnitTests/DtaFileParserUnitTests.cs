using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoaW.RnD.SkinAnomaly.DataParser;
using WoaW.RnD.SkinAnomaly.DataParser.Models;

namespace WoaW.RnD.SkinAnomaly.UnitTests
{
    [TestClass]
    public class DtaFileParserUnitTests
    {
        [TestMethod]
        [TestCategory("Parser")]
        public void PrepareDataFile_SuccessTest()
        {
            var parser = new Parser();
            var originalDataFilePath = Path.GetFullPath(@"..\..\..\..\Data\images.json");
            var lines = File.ReadAllLines(originalDataFilePath).ToList();
            var okRcords = new List<DiseasRecord>();
            var failRcords = new List<string>();

            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i].Replace("$", string.Empty);                                
                try
                {
                    var record = parser.Parse(line);
                    okRcords.Add(record);
                }
                catch (Exception)
                {
                    failRcords.Add(line);
                }

                if (i != lines.Count - 1)
                    lines[i] = lines[i] + ",";
            }

            lines.Insert(0, "[");
            lines.Add("]");
            var newDataFilePath = Path.GetFullPath(@"..\..\..\..\Data\transformed.images.json");
            File.WriteAllLines(newDataFilePath, lines);

            var okDataFilePath = Path.GetFullPath(@"..\..\..\..\Data\ok.images.json");
            parser.Save(okDataFilePath, okRcords);

            var failDataFilePath = Path.GetFullPath(@"..\..\..\..\Data\fail.images.json");
            File.WriteAllLines(failDataFilePath, failRcords);

        }

        [TestMethod]
        [TestCategory("Parser")]
        public void Load_SuccessTest()
        {
            var parser = new Parser();
            var dataFilePath = Path.GetFullPath(@"..\..\..\..\Data\ok.images.json");
            var records = parser.Load(dataFilePath);

            Assert.IsNotNull(records);
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void ParseFailRecord_SuccessTest()
        {
            var parser = new Parser();
            var dataFilePath = Path.GetFullPath(@"..\..\..\WoaW.RnD.SkinAnomaly.DataParser\Data\tmp.json");
            var json = File.ReadAllText(dataFilePath);
            var records = parser.Parse(json);

            Assert.IsNotNull(records);
        }
    }
}
