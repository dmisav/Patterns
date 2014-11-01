using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public static class ObjectContextFactory
    {
        /// <summary>
        /// Gets the default ObjectContext for the project
        /// </summary>
        /// <returns>The default ObjectContext for the project</returns>
        public static NorthwindEntities GetContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnection"].ConnectionString;

            return GetContext(connectionString);
        }

        /// <summary>
        /// Gets the default ObjectContext for the project
        /// </summary>
        /// <param name="connectionString">Connection string to use for database queries</param>
        /// <returns>The default ObjectContext for the project</returns>
        public static NorthwindEntities GetContext(string connectionString)
        {
            return new NorthwindEntities(connectionString);
        }
    }
}
