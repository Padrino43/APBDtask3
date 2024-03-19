namespace ContainerManagementApp;

public class OverfillException : SystemException
{
    public OverfillException()
    {
    }

    public OverfillException(string message)
        : base(message)
    {
    }

    public OverfillException(string message, System.Exception inner)
        : base(message,inner)
    {
    }
}