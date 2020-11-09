using Budget.Core;

namespace Budget.Core
{
    public class DomainValidationResult
    {
        protected DomainValidationResult()
        {

        }
        public DomainValidationResult(int NumberOfError, string ErrorMessage, object ErrorObject)
        {
            this.NumberOfError = NumberOfError;
            this.ErrorMessage = ErrorMessage;
            this.ErrorObject = ErrorObject;
        }
        public int NumberOfError { get; private set; }
        public string ErrorMessage { get; private set; }
        public object ErrorObject { get; private set; }
    }
}