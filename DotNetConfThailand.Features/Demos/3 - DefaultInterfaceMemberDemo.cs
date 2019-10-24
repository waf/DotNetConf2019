using System;

namespace DotNetConfThailand.Features.Demos
{
    public class DefaultInterfaceMemberDemo
    {
        public static void Demo()
        {
            IConferenceSession dotnetSession = new DotNetConfSession();
            IConferenceSession rubySession = new RubyConfSession();
            IConferenceSession pythonSession = new PyConSession();
        }
    }

    // our interface. part of our library we publish on Nuget
    public interface IConferenceSession
    {
        public void GiveTalk(string words);
        public void DemoCode(string code);
    }

    // in some other project
    public class DotNetConfSession : IConferenceSession
    {
        public void DemoCode(string code) { /* skipped */ }
        public void GiveTalk(string words) { /* skipped */ }
    }

    // in some other project
    public class RubyConfSession : IConferenceSession
    {
        public void DemoCode(string code) { /* skipped */ }
        public void GiveTalk(string words) { /* skipped */ }
    }

    // in some other project
    public class PyConSession : IConferenceSession
    {
        public void DemoCode(string code) { /* skipped */ }
        public void GiveTalk(string words) { /* skipped */ }
    }
}
