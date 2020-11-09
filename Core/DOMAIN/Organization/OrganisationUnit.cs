using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public enum OrganisationUnitType
    {
        Person,
        Department
    }
    public abstract class OrganisationUnit : Entity, IValidatableObject
    {
#nullable disable
        protected OrganisationUnit()
        { }
        public OrganisationUnit(Guid _Id, string _FullName, string _ShortName, OrganisationUnitType _OrganisationUnitType)
        {
            this.Id = _Id;
            this.FullName = _FullName;
            this.ShortName = _ShortName;
            this.OrganisationUnitType = _OrganisationUnitType;
        }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        OrganisationUnitType OrganisationUnitType { get; set; }
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}