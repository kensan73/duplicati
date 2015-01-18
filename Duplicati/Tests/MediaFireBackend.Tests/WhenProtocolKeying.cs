using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duplicati.Library.Backend.MediaFire;
using NUnit.Framework;

namespace Tests.Backend
{
    public partial class MediaFireBackendTests
    {
        [TestFixture]
        public class WhenProtocolKeying
        {
            [SetUp]
            public void Setup()
            {
                
            }

            [TearDown]
            public void Teardown()
            {
                
            }

            [Test]
            public void ReturnsMediaFireKey()
            {
                var mediaFire = new MediaFireBackend();

                Assert.AreEqual("mediafire", mediaFire.ProtocolKey);
            }

        }
    }
}
