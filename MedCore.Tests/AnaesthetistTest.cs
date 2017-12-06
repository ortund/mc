using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using MedCore.Tests.Claims;

namespace MedCore.Tests
{
    [TestFixture]
    public class AnaesthetistTest
    {
        private Anaesthetist _anaesthetistClaim;

        private readonly string _anaesthetistFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Anaesthetist.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_anaesthetistFile))
            {
                var testClaim = new TestAnaesthetistClaim();
                testClaim.WriteAnaesthetistJson();
            }

            using (var file = File.OpenText(_anaesthetistFile))
            {
                var serializer = new JsonSerializer();
                _anaesthetistClaim = (Anaesthetist)serializer.Deserialize(file, typeof(Anaesthetist));
            }
        }

        [Test]
        public void GenerateAnaesthetistClaim()
        {
            var output = _anaesthetistClaim.GetCSV();

            var testClaim = new TestAnaesthetistClaim();
            var actual = testClaim.GetAnaesthetistActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
