using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class Task: Entity, IValidatableObject
    {
        string Name { get; set; }

        internal TaskState TaskState { get; set; }

        internal DateTime StateDateTime { get; set; }
        List<Forecast> Forecasts { get; set; }
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }

    }
}
