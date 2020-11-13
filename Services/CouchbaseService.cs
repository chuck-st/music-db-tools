using System;
using Couchbase;
using Couchbase.Core;

namespace music_db_tools.Services {
    public interface IDbService {
        public void Write();
        public void Read();
    }
    public class CouchbaseService : IDbService {
        private IBucket _bucket { get; set; }
        public CouchbaseService() {
            this._bucket = ClusterHelper.GetBucket("music");
        }

        public void Write() {
            throw new NotImplementedException();
        }

        public void Read() {
            throw new NotImplementedException();
        }
    }
}
