using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Identity.NoEF
{
    /// <summary>
    /// Class that implements IRole Interface.
    /// </summary>
    public class IdentityRole: IRole
    {
        /// <summary>
        /// Default constructor for Role 
        /// </summary>
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Constructor that takes names as argument 
        /// </summary>
        /// <param name="name"></param>
        public IdentityRole(String roleName)
            : this()
        {
            Name = roleName;
        }

        public IdentityRole(String roleName, String description)
        {
            Name = roleName;
            Description = description;
        }

        public IdentityRole(String roleId, String roleName, String description)
        {
            Id = roleId;
            Name = roleName;
            Description = description;            
        }

        /// <summary>
        /// Role ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Role Description
        /// </summary>
        public string Description { get; set; }
    }
}
