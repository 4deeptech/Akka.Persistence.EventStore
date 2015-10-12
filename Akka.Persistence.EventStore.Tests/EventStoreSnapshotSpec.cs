using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.TestKit;
using Akka.Persistence;
using Akka.Persistence.Journal;
using Xunit;
using Akka.Persistence.TestKit.Snapshot;
using Akka.Configuration;


namespace Akka.Persistence.EventStore.Tests
{
    public partial class EventStoreSnapshotSpec : SnapshotStoreSpec
    {
        private static readonly Config SpecConfig = ConfigurationFactory.ParseString(@"
            akka {
                stdout-loglevel = DEBUG
	            loglevel = DEBUG
                loggers = [""Akka.Logger.NLog.NLogLogger,Akka.Logger.NLog""]

                persistence {

                publish-plugin-commands = off
                snapshot-store {
                    plugin = ""akka.persistence.snapshot-store.event-store""
                    event-store {
                        class = ""EventStore.Persistence.EventStoreSnapshotStore, Akka.Persistence.EventStore""
                        plugin-dispatcher = ""akka.actor.default-dispatcher""
                        
                        # the event store connection string
			            connection-string = ""ConnectTo=tcp://admin:changeit@127.0.0.1:1113;""

			            # name of the connection
			            connection-name = ""akka.net""
                    }
                }
            }
        }
        ");

        public EventStoreSnapshotSpec()
            : base(SpecConfig, "EventStoreSnapshotSpec")
        {
            Initialize();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //cleanup
            StorageCleanup.Clean();
        }
    }

     
}
