using MedCore.Tests.Claims;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;

namespace MedCore.Tests
{
    [TestFixture]
    public class Gp2Test
    {
        private Gp2Claim _gp2Claim;

        private readonly string _gp2File = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp2.json");

        [SetUp]
        public void SetUp()
        {
            if (!File.Exists(_gp2File))
            {
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
            var output = _gp2Claim.GetCSV();
            var actual = TestGp2Claim.GetExampleCSV();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}