using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

public class Message : IEquatable<Message>
{
    public Message(string header, string body, ImportanceLevel importanceLevel)
    {
        Header = header;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Header { get; }
    public string Body { get; }
    public ImportanceLevel ImportanceLevel { get; }

    public override string ToString()
    {
        return new StringBuilder(Header).Append('\n').Append(Body).ToString();
    }

    public bool Equals(Message? other)
    {
        return ReferenceEquals(this, other);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, (int)ImportanceLevel);
    }
}