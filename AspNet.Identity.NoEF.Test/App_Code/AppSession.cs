using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AspNet.Identity.NoEF.Test
{
    public class ApplicationSession : IApplicationSessionStore
    {
       

        public object this[string key]
        {
            get
            {
                return HttpContext.Current.Session[key];
            }

            set
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        public object this[int index]
        {
            get
            {
                return HttpContext.Current.Session[index];
            }

            set
            {
                HttpContext.Current.Session[index] = value;
            }
        }


        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        public void RemoveAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }


        public void RemoveAt(int index)
        {
            HttpContext.Current.Session.RemoveAt(index);
        }

        public NameObjectCollectionBase.KeysCollection Keys
        {
            get { return HttpContext.Current.Session.Keys; }
        }

        public int Count
        {
            get { return HttpContext.Current.Session.Count; }
        }


        public void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }


        public void Add(string name, object value)
        {
            HttpContext.Current.Session.Add(name, value);
        }
    }
}