using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using MedCore.Tests.Claims;

namespace MedCore.Tests
{
    [TestFixture]
    public class Gp2Test
    {
        private Gp2Claim _gp2Claim;

        private readonly string _gp2File = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp2.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_gp2File))
            {
                // No claim file has been generated. Generate a claim and write it to a file.
                var testClaim = new TestGp2Claim();
                testClaim.CreateFiles();
            }
            using (var file = File.OpenText(_gp2File))
            {
                var serializer = new JsonSerializer();
                _gp2Claim = (Gp2Claim)serializer.Deserialize(file, typeof(Gp2Claim));
            }
        }

        [Test]
        public void GenerateGp2Claim()
        {
            var output = _gp2Claim.GenerateClaim();
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp2Output.txt"), output);

            var testClaim = new TestGp2Claim();
            var actual = testClaim.GetGp2Actual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
