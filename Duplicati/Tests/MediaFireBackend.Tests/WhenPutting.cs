using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duplicati.Library.Backend.MediaFire;
using NUnit.Framework;

namespace Tests.Backend
{
    public partial class MediaFireBackendTests
    {
        [TestFixture]
        public class WhenPutting
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
            [ExpectedException(typeof(ArgumentException))]
            public void BadRemoteName()
            {
                var mediaFire = new MediaFireBackend();
                
                mediaFire.Put(null, "filename");
            }

        }
    }
}
