using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    public interface IApplicationSessionStore
    {
        // Indexer declaration:
        object this[int index] { get; set; }

        object this[string key] { get; set; }

        void Remove(string key);

        void RemoveAll();

        void RemoveAt(int index);

        NameObjectCollectionBase.KeysCollection Keys { get; }

        int Count { get; }

        void Abandon();

        void Add(string name, object value);

    }
}
