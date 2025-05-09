namespace SistemaBancario.Exception.ExceptionBase
{
    public abstract class AppException : SystemException
    {
        protected AppException(string message) : base(message) { }

        public abstract int StatusCode { get; }

        public abstract List<string> GetErrors();
    }
}
