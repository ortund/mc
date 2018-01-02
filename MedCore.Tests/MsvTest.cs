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
    public class MsvTest
    {
        private MSV _msvClaim;
        private string _msvFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Msv.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_msvFile))
            {
                var testClaim = new TestMsvClaim();
                testClaim.WriteMsvJson();
            }
            using (var file = File.OpenText(_msvFile))
            {
                var serializer = new JsonSerializer();
                _msvClaim = (MSV)serializer.Deserialize(file, typeof(MSV));
            }
        }

        [Test]
        public void GenerateMsvClaim()
        {
            var output = _msvClaim.GenerateClaim();

            var testClaim = new TestMsvClaim();
            var actual = testClaim.GetMsvActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
