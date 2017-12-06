using MedCore.Tests.Objects;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Tests
{
    [TestFixture]
    public class Gp2Test
    {
        private Gp2Claim gp2Claim;
        private string gp2File = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp2.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(gp2File))
            {
                // No claim file has been generated. Generate a claim and write it to a file.
                var testClaim = new TestGp2Claim();
                testClaim.WriteGp2Json();
            }
            using (var file = File.OpenText(gp2File))
            {
                var serializer = new JsonSerializer();
                gp2Claim = (Gp2Claim)serializer.Deserialize(file, typeof(Gp2Claim));
            }
        }

        [Test]
        public void GenerateGp2Claim()
        {
            var output = gp2Claim.GenerateClaim();
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp2Output.txt"), output);

            var testClaim = new TestGp2Claim();
            var actual = testClaim.GetGp2Actual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
