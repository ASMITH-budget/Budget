using System;
using System.Collections.Generic;
using Budget.Core;

namespace Budget.Core
{
    public class BudgetFolder : Entity, IValidatableObject
    {
        protected BudgetFolder()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="BudgetOpenID"></param>
        /// <param name="BudgetName"></param>
        /// <param name="BudgetPeriod"></param>
        public BudgetFolder(Guid Id, string BudgetOpenID, string BudgetName, BudgetPeriod BudgetPeriod)
        {
            this.Id = Id;
            this.BudgetOpenID = BudgetOpenID;
            this.BudgetName = BudgetName;
            this.BudgetPeriod = BudgetPeriod;
        }
        /// <summary>
        /// Open key 
        /// </summary>
        /// <value></value>
        public string BudgetOpenID { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string BudgetName { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public BudgetPeriod BudgetPeriod { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DomainValidationResult>  Validate()
        {
            List<DomainValidationResult> errors = new List<DomainValidationResult>();
            // TODO: Validating implementation
            return errors;
        }
    }
}