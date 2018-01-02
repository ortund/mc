using MedCore.Tests.Claims;
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
    public class EraTest
    {
        private ERA _eraClaim;
        private string _eraFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Era.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_eraFile))
            {
                var testClaim = new TestEraClaim();
                testClaim.WriteEraJson();
            }
            using (var file = File.OpenText(_eraFile))
            {
                var serializer = new JsonSerializer();
                _eraClaim = (ERA)serializer.Deserialize(file, typeof(ERA));
            }
        }

        [Test]
        public void GenerateEraClaim()
        {
            var output = _eraClaim.GenerateClaim();

            var testClaim = new TestEraClaim();
            var actual = testClaim.GetEraActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
