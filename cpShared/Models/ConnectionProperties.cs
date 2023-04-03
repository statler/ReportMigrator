using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cpShared.Models
{
    public class ConnectionProperties
    {

        [XmlAttribute(AttributeName = "Type")]
        public string ServerType;
        public string Server;
        public string Database;
        public string Username;
        public string Password;
        public FirewallProperties FirewallInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionProperties"/> class.
        /// </summary>
        public ConnectionProperties()
        {
            ServerType = String.Empty;
            Server = String.Empty;
            Database = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public ConnectionProperties(string serverType, string server, string database, string username, string password)
        {
            ServerType = serverType;
            Server = server;
            Database = database;
            Username = username;
            Password = password;
        }
    }
}
