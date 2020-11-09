using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class LineItemChangeCommand
    {
        private LineItem local_lineItem;
        private LineItemValidator local_LineItemValidator;
        protected LineItemChangeCommand()
        {
        }

        public LineItemChangeCommand(LineItem lineItem)
        {
            local_LineItemValidator = new LineItemValidator();
            local_lineItem = lineItem;
            this.RaiseEvent += local_lineItem.OnChangedLineItem;
            this.RaiseNotValidEvent+=local_lineItem.OnChangeNotValidLineItem;
        }
        public event LineItemEventHandler<LineItemEventArgs> RaiseEvent;
        public event LineItemNotValidEventHandler<LineItemEventArgs> RaiseNotValidEvent;
        public List <DomainValidationResult> Execute(string ItemOpenID, string ItemName)
        {
            List <DomainValidationResult> ValidResultErrors= local_LineItemValidator.Validate(ItemOpenID, ItemName);
                        
            if (ValidResultErrors?.Count ==0)
            {
                DoValidEvent(ItemOpenID, ItemName);
                return null;
            }
            else 
            {
                DoNotValidEvent (ItemOpenID, ItemName,ValidResultErrors);
                return ValidResultErrors;
            }
        }

        private void DoValidEvent (string ItemOpenID, string ItemName)
        {
            RaiseEvent?.Invoke(local_lineItem, new LineItemEventArgs { guid = local_lineItem.Id, ItemOpenID=ItemOpenID, ItemName = ItemName });
        }

        private void DoNotValidEvent (string ItemOpenID, string ItemName, List <DomainValidationResult> ValidResultErrors)
        {
            RaiseNotValidEvent?.Invoke(local_lineItem, new LineItemEventArgs { guid = local_lineItem.Id, ItemOpenID=ItemOpenID, ItemName = ItemName, Errors=ValidResultErrors });
        }  
    }
}