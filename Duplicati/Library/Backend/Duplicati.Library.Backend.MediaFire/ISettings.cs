using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Duplicati.Library.Backend.MediaFire.Properties;

namespace Duplicati.Library.Backend.MediaFire
{
    public interface ISettings
    {
        string Email { get; }
        string Password { get; }
        string ApplicationId { get; }
        string Signature { get; }
        string TokenVersion { get; }
    }

    public class Settings : ISettings
    {
        public string Email { get { return Properties.Settings.Default.Email; }}
        public string Password { get { return Properties.Settings.Default.Password; } }
        public string ApplicationId { get { return Properties.Settings.Default.ApplicationId; } }
        public string Signature { get { return Properties.Settings.Default.Signature; } }
        public string TokenVersion { get { return Properties.Settings.Default.TokenVersion; } }
    }
}
