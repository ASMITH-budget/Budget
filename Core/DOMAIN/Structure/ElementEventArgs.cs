using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class ElementEventArgs
    {
        public Guid guid;
        public string ElementName;
        public UnitOfElement UnitOfElement;
        public List <DomainValidationResult> Errors;
    }
}