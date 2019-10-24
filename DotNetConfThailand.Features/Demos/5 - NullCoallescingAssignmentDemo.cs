using System.Collections.Generic;

namespace DotNetConfThailand.Features.Demos
{
    class NullCoallescingAssignmentDemo
    {
        public static void Demo()
        {
            AddTalk("Blazor and Azure Functions for Serverless Websites");
            AddTalk("Creating Libra Cryptocurrency Wallet using .NET SDK");
            AddTalk("Xamarin.Forms: More Productive and Beautiful Than Ever");

            AddTalk("Scott Hanselman Greeting", "Video");
        }

        public static void AddTalk(string name, string location = null)
        {
            location ??= "Microsoft (Thailand)";

            var session = new ConferenceSession(name, location);
            sessions.Add(session);
        }




        private static List<ConferenceSession> sessions = new List<ConferenceSession>();
        class ConferenceSession
        {
            public ConferenceSession(string username, string role)
            {
                Username = username;
                Role = role;
            }

            public string Username { get; set; }
            public string Role { get; set; }
        }
    }
}
