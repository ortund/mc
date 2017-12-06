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
    public class AnaesthetistTest
    {
        private Anaesthetist anaesthetistClaim;

        private string anaesthetistFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Anaesthetist.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(anaesthetistFile))
            {
                var testClaim = new TestAnaesthetistClaim();
                testClaim.WriteAnaesthetistJson();
            }

            using (var file = File.OpenText(anaesthetistFile))
            {
                var serializer = new JsonSerializer();
                anaesthetistClaim = (Anaesthetist)serializer.Deserialize(file, typeof(Anaesthetist));
            }
        }

        [Test]
        public void GenerateAnaesthetistClaim()
        {
            var output = anaesthetistClaim.GenerateClaim();

            var testClaim = new TestAnaesthetistClaim();
            var actual = testClaim.GetAnaesthetistActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
