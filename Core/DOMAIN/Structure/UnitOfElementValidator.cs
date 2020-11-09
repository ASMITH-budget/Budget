using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class UnitOfElementValidator
    {
        public UnitOfElementValidator()
        {}
        public List<DomainValidationResult> Validate(string FullName, string ShortName)
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();

            if (string.IsNullOrWhiteSpace(ShortName))
                errors.Add(new DomainValidationResult(1, "The shortname is to short", this));

            if (string.IsNullOrWhiteSpace(FullName))
                errors.Add(new DomainValidationResult(1, "The fullname is to short", this));

            if (ShortName.Length < 1 || ShortName.Length > 20)
                errors.Add(new DomainValidationResult(1, "Lenght is incorrect", this));

            if (FullName.Length < 1 || FullName.Length > 120)
                errors.Add(new DomainValidationResult(1, "Lenght is incorrect", this));

            return errors;
        }
    }
}