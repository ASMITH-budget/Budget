using System;
using Budget.Core;

namespace Budget.Core
{
    public class BudgetPeriod : ValueObject<BudgetPeriod>
    {
        protected BudgetPeriod() { }
        public BudgetPeriod(string Period)
        {
            this.Period = Period;
        }
        public string Period { get; protected set; }
        protected override bool EqualsCore(BudgetPeriod other)
        {
            return Period == other.Period;
        }
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Period.GetHashCode();
                return hashCode;
            }
        }
    }
}