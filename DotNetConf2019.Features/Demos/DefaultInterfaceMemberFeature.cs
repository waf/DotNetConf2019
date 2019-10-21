using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    // our interface. part of our library we publish on Nuget
    public interface ITerminal
    {
        public void Write(string output);
        public void WriteLine(string output) => Write(output);
        public void Scream(string output) => Write(output.ToUpper());
    }

    // in some other project
    public class WindowsTerminal : ITerminal
    {
        public void Write(string output)
        {
            /* Windows Terminal implementation not shown */
        }
    }

    // in some other project
    public class CommandPromptConsole : ITerminal
    {
        public void Write(string output)
        {
            /* Command Prompt implementation not shown */
        }
    }

    // in some other project
    public class PowerShellConsole : ITerminal
    {
        public void Write(string output)
        {
            /* PowerShell implementation not shown */
        }
    }

    // in some other project
    public class ConEmuConsole : ITerminal
    {
        public void Write(string output)
        {
            /* ConEmu implementation not shown */
        }
    }
}
