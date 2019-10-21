using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    struct User
    {
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public readonly override string ToString() =>
            $"User {Id} with name {Name}";
    }
}
