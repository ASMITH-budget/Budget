using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    class Employee : Entity, IValidatableObject
    {
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string SureName { get; set; }
        public string ShortName { get; private set; }

        public void GenerateShortName()
        {
            this.ShortName = this.SureName + " " + this.Name.Substring(0, 1).ToUpper().ToString() + ". " + this.FathersName.Substring(0, 1).ToUpper().ToString()+".";
        }
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}
