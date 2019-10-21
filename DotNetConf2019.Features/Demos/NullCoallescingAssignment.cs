using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    class NullCoallescingAssignment
    {
        public void AddUser(string username, string role)
        {
            role ??= "Guest";

            var user = new SystemUser(username, role);
            // insert user record to database
        }

        class SystemUser
        {
            public SystemUser(string username, string role)
            {
                Id = Guid.NewGuid();
                Username = username;
                Role = role;
            }

            public Guid Id { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }
        }
    }
}
