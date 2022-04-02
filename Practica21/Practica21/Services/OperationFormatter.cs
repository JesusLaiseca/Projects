namespace Practica21.Services
{
    public class OperationFormatter : IOperationFormatter
    {
        public string Format(int a, string operation, int b, int result)
        {
            return $"{a}{operation}{b}={result}";
        }
    }
}
