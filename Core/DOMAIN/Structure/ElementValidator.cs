using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class ElementValidator
    {
        public ElementValidator()
        {}
#nullable enable
        public List<DomainValidationResult> Validate(string ElementName, UnitOfElement? unitOfElement)
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();

            if (string.IsNullOrWhiteSpace(ElementName))
                errors.Add(new DomainValidationResult(1, "The fullname is to short", this));

            if (ElementName.Length < 1 || ElementName.Length > 120)
                errors.Add(new DomainValidationResult(1, "Lenght is incorrect", this));
            
            if (unitOfElement == null)
                errors.Add(new DomainValidationResult(2, "Unit of element is null reference", this));

            return errors;
        }
#nullable restore
    }
}