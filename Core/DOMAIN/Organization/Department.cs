using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class Department : Entity, IValidatableObject
    {
        int? ParentNode { get; set; }
        string Name { get; set; }
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}
