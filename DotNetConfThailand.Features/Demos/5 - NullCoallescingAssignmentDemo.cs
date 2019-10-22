using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConfThailand.Features.Demos
{
    class NullCoallescingAssignmentDemo
    {
        public static void Demo()
        {
            AddUser("Sally", "Admin");
            AddUser("John");
            AddUser("Bob");
        }
        public static void AddUser(string username, string role = null)
        {
            role ??= "Guest";

            var user = new User(username, role);
            // insert user record to database
        }

        class User
        {
            public User(string username, string role)
            {
                Username = username;
                Role = role;
            }

            public string Username { get; set; }
            public string Role { get; set; }
        }
    }
}
