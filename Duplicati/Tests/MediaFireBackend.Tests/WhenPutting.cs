using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duplicati.Library.Backend.MediaFire;
using NUnit.Framework;
using RestSharp;
using Rhino.Mocks;

namespace Tests.Backend
{
    public partial class MediaFireBackendTests
    {
        [TestFixture]
        public class WhenPutting
        {
            private MediaFireBackend _mediaFire;
            private IRestClient _restClient;
            private ISettings _settings;

            [SetUp]
            public void Setup()
            {
                _restClient = MockRepository.GenerateStrictMock<IRestClient>();
                _settings = MockRepository.GenerateStrictMock<ISettings>();

                _mediaFire = new MediaFireBackend(null, null, _restClient, _settings);
            }

            [TearDown]
            public void Teardown()
            {
                _restClient.VerifyAllExpectations();
                _settings.VerifyAllExpectations();
            }

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void BadRemoteName(string remotename)
            {
                _mediaFire.Put(remotename, "remotename");
            }

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void BadFileName(string filename)
            {
                _mediaFire.Put("remotename", filename);
            }

            [Test]
            [ExpectedException(typeof(Exception))]
            public void GetTokenFails()
            {
                _settings.Expect(s => s.Email).Return("myemail@email.com");
                _settings.Expect(s => s.Password).Return("mypass1234");
                _settings.Expect(s => s.ApplicationId).Return("myappId457");
                _settings.Expect(s => s.Signature).Return("my signature 235123");
                _settings.Expect(s => s.TokenVersion).Return("my token version 77212");

                _restClient.Expect(rc => rc.Execute<GetSessionTokenResponse>(Arg<RestRequest>.Is.Anything))
                    .Return(new RestResponse<GetSessionTokenResponse>
                    {
                        Data = new GetSessionTokenResponse
                        {
                            result = "Error"
                        },
                    });
                
                _mediaFire.Put("remotename", "filename");
            }
        }
    }
}
