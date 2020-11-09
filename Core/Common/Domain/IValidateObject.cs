using System.Collections.Generic;


namespace Budget.Core
{
    public interface IValidatableObject
    {
     public IEnumerable<DomainValidationResult> Validate ();
    }
}