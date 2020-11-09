using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class LineItemEventArgs
    {
        public Guid guid;
        public string ItemOpenID;
        public string ItemName;
        public List <DomainValidationResult> Errors;
    }
}