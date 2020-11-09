using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public delegate void ElementEventHandler<T>(object sender, ElementEventArgs eventArgs) where T : ElementEventArgs;
    public delegate void ElementNotValidEventHandler<T>(object sender, ElementEventArgs eventArgs) where T : ElementEventArgs;
    
    /// <summary>
    /// Element is base g
    /// </summary>
    public class Element : Entity, IBudgetStructureLineObject
    {
        protected Element()
        {

        }
        private Element(Builder elementBuilder)
        {
            this.Id = elementBuilder._Id;
            this.ElementName = elementBuilder._ElementName;
            this.UnitOfElement = elementBuilder._UnitOfElement;
        }
        public string ElementName { get; protected set; }
        public UnitOfElement UnitOfElement { get; protected set; }
        
        public void OnChangedElement(object sender, ElementEventArgs eventArgs)
        {
            this.ElementName = eventArgs.ElementName;
            this.UnitOfElement = eventArgs.UnitOfElement;
        }
        public void OnChangeNotValidElement(object sender, ElementEventArgs eventArgs)
        {
            
        }
        public class Builder
        {
            internal Guid _Id { get; set; }
            internal string _ElementName { get; set; } = string.Empty;
            internal UnitOfElement _UnitOfElement { get; set; }

            public Builder Id(Guid Id)
            {
                _Id = Id;
                return this;
            }

            public Builder ElementName(string ElementName)
            {
                _ElementName = ElementName;
                return this;
            }

            public Builder UnitOfElement(UnitOfElement unitOfElement)
            {
                _UnitOfElement = unitOfElement;
                return this;
            }

            public Element Build()
            {
                List<DomainValidationResult> validator = new List<DomainValidationResult>();
                var local_ElementValidator = new ElementValidator();
                validator = local_ElementValidator.Validate(this._ElementName, this._UnitOfElement);

                if (validator.Count > 0)
                {
                    foreach (var item in validator)
                    {
                        System.Console.WriteLine(item.NumberOfError.ToString() + "  " + item.ErrorMessage.ToString() + "  " + item.ErrorObject.ToString());
                    }

                    return null;
                }
                return new Element(this);
            }
        }
    }
}