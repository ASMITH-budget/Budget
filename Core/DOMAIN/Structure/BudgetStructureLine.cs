using System;
using Budget.Core;

namespace Budget.Core
{
#nullable enable

    public class BudgetStructureLine : AggregateRoot
    {
        /// <summary>
        /// Budget structure item for income statement (operating budget) and CashFlow (Cach Budget) non for balance sheet (financial budget)
        /// </summary>
        /// <param name="_Id"></param>
        /// <param name="_BudgetStructureLineParentObject"></param>
        /// <param name="_BudgetStructureLineObject"></param>
        /// <param name="_FinanceResponsibilityCentre"></param>
        /// <param name="_BudgetFolder"></param>
        /// <param name="_IsBudgetSructureItemProfit"></param>
        /// <param name="_OrderLine"></param>
        /// <param name="_LevelLine"></param>

        // ! 'couse child object like Element or LineItem can be added to parent LineItem. Adding to Element is disabled
        public BudgetStructureLine(Guid _Id, LineItem? _BudgetStructureLineParentObject, IBudgetStructureLineObject _BudgetStructureLineObject, FinanceResponsibilityCentre? _FinanceResponsibilityCentre,
                                                                                         BudgetFolder _BudgetFolder, bool _IsBudgetSructureItemProfit, int _OrderLine, int _LevelLine)
        {
            this.Id = _Id;
            this.BudgetStructureLineParentObject = _BudgetStructureLineParentObject;
            this.BudgetStructureLineObject = _BudgetStructureLineObject;
            this.BudgetFolder = _BudgetFolder;
            this.FinanceResponsibilityCentre = _FinanceResponsibilityCentre;
            this.IsBudgetSructureItemProfit = IsBudgetSructureItemProfit;
            this.OrderLine = OrderLine;
            this.LevelLine = LevelLine;
        }

        public LineItem? BudgetStructureLineParentObject { get; protected set; }
        public IBudgetStructureLineObject BudgetStructureLineObject { get; protected set; }
        public BudgetFolder BudgetFolder { get; protected set; }
        public FinanceResponsibilityCentre? FinanceResponsibilityCentre { get; protected set; }
        public bool IsBudgetSructureItemProfit { get; protected set; }
        public int OrderLine { get; protected set; }
        public int LevelLine { get; protected set; }
        public bool IsElement()
        {
            IBudgetStructureLineObject element = (Element)BudgetStructureLineObject;
            return false;
        }

        public void SetChecked()
        {
            if (BudgetStructureLineObject is Element)
            {
                Element element = (Element)BudgetStructureLineObject;

            }
        }
    }
#nullable restore
}