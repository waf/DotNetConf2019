using System;

namespace DotNetConfThailand.Features.Demos
{
    public class DefaultInterfaceMemberDemo
    {
        public static void Demo()
        {
            IShell cmd = new CommandShell();
            IShell powershell = new PowerShell();
            IShell bash = new BashShell();
        }
    }

    // our interface. part of our library we publish on Nuget
    public interface IShell
    {
        public void Write(string output);
    }

    // in some other project
    public class CommandShell : IShell
    {
        public void Write(string output)
        {
            /* Windows Terminal implementation not shown */
        }
    }

    // in some other project
    public class PowerShell : IShell
    {
        public void Write(string output)
        {
            /* ConEmu implementation not shown */
        }
    }

    // in some other project
    public class BashShell : IShell
    {
        public void Write(string output)
        {
            /* Command Prompt implementation not shown */
        }
    }

}
