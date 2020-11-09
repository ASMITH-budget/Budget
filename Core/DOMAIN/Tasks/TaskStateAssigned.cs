using System;

namespace Budget.Core
{
    class TaskStateAssigned : TaskState
    {
        protected override void ChangeState(Task task, TaskFlow taskFlow)
        {
            switch (taskFlow)
            {
                case TaskFlow.push:
                    {
                        task.TaskState = new TaskStateAssigned();
                        task.StateDateTime = DateTime.Now;
                        break;
                    }
            }
        }
    }
}
