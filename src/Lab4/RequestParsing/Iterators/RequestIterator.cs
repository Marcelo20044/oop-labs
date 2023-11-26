using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.RequestParsing.Iterators;

public class RequestIterator
{
    private readonly IList<string> _request;
    private int _current;

    public RequestIterator(string request)
    {
        _request = request.Split(" ");
        _current = 0;
    }

    public string Current => _request[_current];

    public bool Move()
    {
        _current++;
        return _current < _request.Count;
    }

    public void Reset()
    {
        _current = 0;
    }
}