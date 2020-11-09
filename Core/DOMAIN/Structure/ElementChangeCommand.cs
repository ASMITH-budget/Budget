using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class ElementChangeCommand
    {
        private Element local_Element;
        private ElementValidator local_ElementValidator;

        protected ElementChangeCommand()
        {}
        public ElementChangeCommand(Element element)
        {
            local_Element=element;
            local_ElementValidator = new ElementValidator();
            this.RaiseEvent += local_Element.OnChangedElement;
            this.RaiseNotValidEvent+=local_Element.OnChangeNotValidElement;
        }

        public event ElementEventHandler<ElementEventArgs> RaiseEvent;
        public event ElementNotValidEventHandler<ElementEventArgs> RaiseNotValidEvent;
#nullable enable
        public List <DomainValidationResult>? Execute(string ElementName, UnitOfElement? unitOfElement)
        {
            List <DomainValidationResult> ValidResultErrors= local_ElementValidator.Validate(ElementName,unitOfElement);
                        
            if (ValidResultErrors?.Count ==0)
            {
                DoValidEvent(ElementName,unitOfElement);
                return null;
            }
            else 
            {
                DoNotValidEvent (ElementName,unitOfElement,ValidResultErrors);
                return ValidResultErrors;
            }
        }

        private void DoValidEvent (string ElementName, UnitOfElement? unitOfElement)
        {
            RaiseEvent?.Invoke(local_Element, new ElementEventArgs { guid = local_Element.Id, ElementName=ElementName, UnitOfElement = unitOfElement });
        }

        private void DoNotValidEvent (string ElementName, UnitOfElement? unitOfElement, List <DomainValidationResult>? ValidResultErrors)
        {
            RaiseNotValidEvent?.Invoke(local_Element, new ElementEventArgs { guid = local_Element.Id, ElementName=ElementName, UnitOfElement = unitOfElement, Errors=ValidResultErrors });
        }
#nullable restore
    }
}