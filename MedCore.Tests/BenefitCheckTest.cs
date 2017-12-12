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
    public class BenefitCheckTest
    {
        private BenefitCheck1 _benefitCheck;
        private string _benefitCheckFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\BenefitCheck1.json");

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(_benefitCheckFile))
            {
                var testClaim = new TestBenefitCheck();
                testClaim.WriteBenefitCheckJson();
            }
            using (var file = File.OpenText(_benefitCheckFile))
            {
                var serializer = new JsonSerializer();
                _benefitCheck = (BenefitCheck1)serializer.Deserialize(file, typeof(BenefitCheck1));
            }
        }

        [Test]
        public void GenerateBenefitCheckClaim()
        {
            var output = _benefitCheck.GenerateClaim();

            var testClaim = new TestBenefitCheck();
            var actual = testClaim.GetBenefitCheckActual();

            Assert.That(output, Is.EqualTo(actual));
        }
    }
}
