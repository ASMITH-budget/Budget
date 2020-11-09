using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class UnitOfElementEventArgs
    {
        public Guid guid;
        public string ShortName;
        public string FullName;
        public List <DomainValidationResult> Errors;
    }
}