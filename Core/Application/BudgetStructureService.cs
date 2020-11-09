using System;
using System.Collections.Generic;
using Budget.Core;

namespace iBUDGET.Application
{
    public class BudgetStructureService
    {
        public BudgetStructureService()
        {
            this.BudgetStructureListOfLines = new SortedList<int, BudgetStructureLine>();
        }
        protected bool IsInitial = false;
        private SortedList<int, BudgetStructureLine> BudgetStructureListOfLines;
        private void InitializeMainItemsIfNewBudgetWasCreated(BudgetFolder _BudgetFolder)
        {
            // ! Create main profit and loss Items if collection is empty. 
            this.AddStructureItem(new BudgetStructureLine(Guid.NewGuid(), null, new LineItem.Builder().Id(Guid.NewGuid()).ItemOpenID("001").ItemName("Profit part").Build(), null, _BudgetFolder, true, 100000, 1));
            this.AddStructureItem(new BudgetStructureLine(Guid.NewGuid(), null, new LineItem.Builder().Id(Guid.NewGuid()).ItemOpenID("002").ItemName("Loss part").Build(), null, _BudgetFolder, true, 200000, 1));
            IsInitial = true;
        }

        // TODO: impementation adding with hierarchy (tree with two main nodes)
        public void AddStructureItem(BudgetStructureLine BudgetStructureLine)
        {
            if (IsParentNotNull(BudgetStructureLine))
            {
                BudgetStructureListOfLines.Add(BudgetStructureLine.OrderLine, BudgetStructureLine);

            }

        }
        public SortedList<int, BudgetStructureLine> GetBudgetStructureAll(BudgetFolder _BudgetFolder)
        {

            if (!IsInitial)
            {
                InitializeMainItemsIfNewBudgetWasCreated(_BudgetFolder);
            }

            return BudgetStructureListOfLines;
        }
        private bool IsParentNotNull(BudgetStructureLine _BudgetStructureLine)
        {
            if (!(_BudgetStructureLine.BudgetStructureLineParentObject == null))
            {
                return false;
            }
            return true;
        }
    }
}