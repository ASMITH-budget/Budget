using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public delegate void LineItemEventHandler<T>(object sender, LineItemEventArgs eventArgs) where T : LineItemEventArgs;
    public delegate void LineItemNotValidEventHandler<T>(object sender, LineItemEventArgs eventArgs) where T : LineItemEventArgs;
    public class LineItem : Entity, IBudgetStructureLineObject
    {
        protected LineItem()
        {

        }
        private LineItem(Builder lineItemBuilder)
        {
            this.Id=lineItemBuilder._id;
            this.ItemOpenID = lineItemBuilder._itemOpenID;
            this.ItemName = lineItemBuilder._itemName;
        }   
        public string ItemOpenID { get; protected set; }
        public string ItemName { get; protected set; }
        public void OnChangedLineItem(object sender, LineItemEventArgs eventArgs)
        {
            this.ItemName = eventArgs.ItemName;
            this.ItemOpenID = eventArgs.ItemOpenID;
        }
        public void OnChangeNotValidLineItem(object sender, LineItemEventArgs eventArgs)
        {
            
        }
        public class Builder
        {
            internal Guid _id {get;set;}
            internal string _itemOpenID  {get;set;} = string.Empty;
            internal string _itemName  {get;set;} = string.Empty;

             public Builder Id(Guid Id)
            {
                this._id = Id;
                return this;
            }
            public Builder ItemOpenID(string ItemOpenID)
            {
                this._itemOpenID = ItemOpenID;
                return this;
            }
            public Builder ItemName(string ItemName)
            {
                this._itemName = ItemName;
                return this;
            }
            public LineItem Build()
            {
                List<DomainValidationResult> validator = new List<DomainValidationResult>();
                var  local_LineItemValidator = new LineItemValidator();
                validator = local_LineItemValidator.Validate(this?._itemOpenID, this?._itemName);

                if (validator.Count > 0)
                {
                    foreach (var item in validator)
                    {
                        System.Console.WriteLine(item.NumberOfError.ToString() + "  " + item.ErrorMessage.ToString() + "  " + item.ErrorObject.ToString());
                    }
                
                    return null;
                }
                return new LineItem(this);
            }
        }
    }
}