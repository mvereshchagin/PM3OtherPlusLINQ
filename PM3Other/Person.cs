namespace PM3Other;

public class Person : IDisposable
{
    // конструктор
    public Person()
    {
        
    }

    // деструктор
    ~Person()
    {
        ReleaseUnmanagedResources();
    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }
}