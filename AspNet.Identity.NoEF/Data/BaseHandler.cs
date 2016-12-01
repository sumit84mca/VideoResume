using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;

namespace AspNet.Identity.NoEF.Data
{
    /// <summary>
    /// Abstract base class for table handler childs.
    /// </summary>
    internal abstract class BaseHandler
    {
        /// <summary>
        /// Database wrapper property.
        /// </summary>
        public Database db { get; private set; }


        /// <summary>
        /// Default constructor.
        /// Intializes 'Database' for table handlers.
        /// </summary>
        public BaseHandler() 
        { 
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            

            //Create Database using 'defaultDatabase' value from 'dataConfiguration' tag in web.config
            //db = factory.CreateDefault();
            db = new SqlDatabase("Server=.;Database=videoresume;User Id=sa;Password=a;");

            
        }
    }
}
