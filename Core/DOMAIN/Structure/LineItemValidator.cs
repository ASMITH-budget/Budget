using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class LineItemValidator
    {
         public LineItemValidator()
        {}
        public List<DomainValidationResult> Validate(string ItemOpenID, string ItemName)
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();

            if (string.IsNullOrWhiteSpace(ItemOpenID))
                errors.Add(new DomainValidationResult(1, "The shortname is to short", this));

            if (string.IsNullOrWhiteSpace(ItemName))
                errors.Add(new DomainValidationResult(1, "The fullname is to short", this));

            if (ItemOpenID.Length < 1 || ItemOpenID.Length > 12)
                errors.Add(new DomainValidationResult(1, "Lenght is incorrect", this));

            if (ItemName.Length < 1 || ItemName.Length > 120)
                errors.Add(new DomainValidationResult(1, "Lenght is incorrect", this));

            return errors;
        }
    }
}