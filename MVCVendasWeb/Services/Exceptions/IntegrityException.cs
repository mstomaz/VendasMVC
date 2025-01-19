namespace MVCVendasWeb.Services.Exceptions
{
    public class IntegrityException : Exception
    {
        public IntegrityException() { }
        public IntegrityException(string message) : base(message) { }
        public IntegrityException(string message, Exception innerException) : base(message, innerException) { }
    }
}
