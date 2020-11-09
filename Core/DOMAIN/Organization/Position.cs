using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class Position:Entity, IValidatableObject
    {
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}
