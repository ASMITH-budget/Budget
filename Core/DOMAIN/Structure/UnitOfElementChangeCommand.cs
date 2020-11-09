using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class UnitOfElementChangeCommand
    {
        private UnitOfElement local_unitOfElement;
        private UnitOfElementValidator local_UnitOfElementValidator;
        protected UnitOfElementChangeCommand()
        {
        }

        public UnitOfElementChangeCommand(UnitOfElement unitOfElement)
        {
            local_UnitOfElementValidator = new UnitOfElementValidator();
            local_unitOfElement = unitOfElement;
            this.RaiseEvent += local_unitOfElement.OnChangedUnitOfElement;
            this.RaiseNotValidEvent+=local_unitOfElement.OnChangeNotValidUnitOfElement;
        }
        public event UnitOfElementEventHandler<UnitOfElementEventArgs> RaiseEvent;
        public event UnitOfElementNotValidEventHandler<UnitOfElementEventArgs> RaiseNotValidEvent;

        public List <DomainValidationResult> Execute(string ShortName, string FullName)
        {
            List <DomainValidationResult> ValidResultErrors= local_UnitOfElementValidator.Validate(FullName, ShortName);
                        
            if (ValidResultErrors?.Count == 0)
            {
                DoValidEvent(FullName, ShortName);
                return null;
            }
            else 
            {
                DoNotValidEvent (FullName, ShortName, ValidResultErrors);
                return ValidResultErrors;
            }
        }

        private void DoValidEvent (string FullName, string ShortName)
        {
            RaiseEvent?.Invoke(local_unitOfElement, new UnitOfElementEventArgs { guid = local_unitOfElement.Id, ShortName = ShortName, FullName = FullName });
            
        }

        private void DoNotValidEvent (string FullName, string ShortName, List <DomainValidationResult> ValidResultErrors)
        {
            RaiseNotValidEvent?.Invoke(local_unitOfElement, new UnitOfElementEventArgs { guid = local_unitOfElement.Id, ShortName = ShortName, FullName = FullName, Errors=ValidResultErrors });
        }
    }
}