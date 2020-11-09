using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{

    public delegate void UnitOfElementEventHandler<T>(object sender, UnitOfElementEventArgs eventArgs) where T : UnitOfElementEventArgs;
    public delegate void UnitOfElementNotValidEventHandler<T>(object sender, UnitOfElementEventArgs eventArgs) where T : UnitOfElementEventArgs;
    /// <summary>
    /// Единица измерения 
    /// </summary>
    public class UnitOfElement : Entity
    {
        protected UnitOfElement() { }
        private UnitOfElement(Builder unitOfElementBuilder)
        {
            this.Id = unitOfElementBuilder._Id;
            this.ShortName = unitOfElementBuilder._ShortName;
            this.FullName = unitOfElementBuilder._FullName;
        }

        /// <summary>
        /// Short name of unit
        /// </summary>
        /// <value>String</value>
        public string ShortName { get; private set; }
        /// <summary>
        /// Full name of unit
        /// </summary>
        /// <value>String</value>
        public string FullName { get; private set; }

        public void OnChangedUnitOfElement(object sender, UnitOfElementEventArgs eventArgs)
        {
            this.FullName = eventArgs.FullName;
            this.ShortName = eventArgs.ShortName;
            this.EntityState = EntityState.Edited;
        }
        public void OnChangeNotValidUnitOfElement(object sender, UnitOfElementEventArgs eventArgs)
        {
            
        }
        /// <summary>
        /// Return UnitOfElement if valid or null of not valid object
        /// </summary>
        public class Builder 
        {
            internal Guid _Id { get; set; }
            internal EntityState _EntityState {get;set;}
            internal string _ShortName { get; set; } = string.Empty;
            internal string _FullName { get; set; } = string.Empty;
 
            public Builder Id(Guid Id)
            {
                this._Id = Id;
                return this;
            }
            public Builder ShortName(string ShortName)
            {
                this._ShortName = ShortName;
                return this;
            }
            public Builder FullName(string FullName)
            {
                this._FullName = FullName;
                return this;
            }
            public UnitOfElement Build()
            {
                List<DomainValidationResult> validator = new List<DomainValidationResult>();
                var  local_UnitOfElementValidator = new UnitOfElementValidator();
                validator = local_UnitOfElementValidator.Validate(this?._FullName, this?._ShortName);

                if (validator.Count > 0)
                {
                    foreach (var item in validator)
                    {
                        System.Console.WriteLine(item.NumberOfError.ToString() + "  " + item.ErrorMessage.ToString() + "  " + item.ErrorObject.ToString());
                    }

                    return null;
                }
                
                _EntityState=EntityState.Created;   
                return new UnitOfElement(this);
            }
        }
    }
}