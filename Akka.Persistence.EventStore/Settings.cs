using Akka.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Persistence.EventStore
{
    /// <summary>
    /// Configuration settings representation targeting Azure TableStorage journal actor.
    /// </summary>
    public class JournalSettings 
    {
        public string ConnectionName {get; private set;}
        public string ConnectionString {get; private set;}

        public JournalSettings(Config config)
        {
            if (config == null) throw new ArgumentNullException("config", "EventStore journal settings cannot be initialized, because required HOCON section couldn't be found");
            ConnectionName = config.GetString("connection-name");
            ConnectionString = config.GetString("connection-string");
        }
    }

    /// <summary>
    /// Configuration settings representation targeting Azure Table Storage snapshot store actor.
    /// </summary>
    public class SnapshotStoreSettings
    {
        public string ConnectionName { get; private set; }
        public string ConnectionString { get; private set; }

        public SnapshotStoreSettings(Config config)
        {
            if (config == null) throw new ArgumentNullException("config", "EventStore journal settings cannot be initialized, because required HOCON section couldn't be found");
            ConnectionName = config.GetString("connection-name");
            ConnectionString = config.GetString("connection-string");
        }
    }
}
