namespace Context.Rule.Model;

public class SortRules : IDisposable
{
    //   public int Order { get; set; }

    public object Rule { get; set; } = null!;

    protected bool Disposed { get; private set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        Disposed = true;
    }
}