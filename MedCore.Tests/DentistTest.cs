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
    public class DentistTest
    {
        private Dentist _dentistClaim;
        private string _dentistFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Dentist.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_dentistFile))
            {
                var testClaim = new TestDentistClaim();
                testClaim.WriteDentistJson();
            }
            using (var file = File.OpenText(_dentistFile))
            {
                var serializer = new JsonSerializer();
                _dentistClaim = (Dentist)serializer.Deserialize(file, typeof(Dentist));
            }
        }

        [Test]
        public void GenerateDentistClaim()
        {
            var output = _dentistClaim.GenerateClaim();

            var testClaim = new TestDentistClaim();
            var actual = testClaim.GetDentistActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
