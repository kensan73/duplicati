using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duplicati.Library.Interface;
using RestSharp;

namespace Duplicati.Library.Backend.MediaFire
{
    public class MediaFireBackend : IBackend, IStreamingBackend
    {
        private readonly IRestClient _client;
        private readonly ISettings _settings;

        public MediaFireBackend()
        {
            
        }

        public MediaFireBackend(string url, Dictionary<string, string> options, IRestClient client, ISettings settings)
        {
            _client = client;
            _settings = settings;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string DisplayName { get; private set; }

        public string ProtocolKey
        {
            get { return "mediafire"; }
        }

        public List<IFileEntry> List()
        {
            throw new NotImplementedException();
        }

        public void Put(string remotename, string filename)
        {
            if (string.IsNullOrEmpty(remotename))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException();
            }

            var email = _settings.Email;
            var password = _settings.Password;
            var applicationId = _settings.ApplicationId;
            var signature = _settings.Signature;
            var tokenVersion = _settings.TokenVersion;

            var response = _client.Execute<GetSessionTokenResponse>(new RestRequest());
            if(response.Data.result != "Success")
                throw new Exception("Failed to get session token");
        }

        public void Get(string remotename, string filename)
        {
            throw new NotImplementedException();
        }

        public void Delete(string remotename)
        {
            throw new NotImplementedException();
        }

        public IList<ICommandLineArgument> SupportedCommands { get; private set; }
        public string Description { get; private set; }
        public void Test()
        {
            throw new NotImplementedException();
        }

        public void CreateFolder()
        {
            throw new NotImplementedException();
        }

        public void Put(string remotename, Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Get(string remotename, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
