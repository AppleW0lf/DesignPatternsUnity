using System;

public class CounterModel
{
    private int _count = 0;
    private bool _isRunning = true;

    public int Count => _count;
    public bool IsRunning => _isRunning;

    public void Increment()
    {
        if (_isRunning)
        {
            _count++;
        }
    }

    public void Reset()
    {
        _count = 0;
    }

    public void Stop()
    {
        _isRunning = false;
    }
}