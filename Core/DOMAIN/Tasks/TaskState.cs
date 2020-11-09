
namespace Budget.Core
{
    internal abstract class TaskState
    {
        internal virtual void HandeState(Task task, TaskFlow taskFlow)
        {
            ChangeState(task, taskFlow);
        }
        protected abstract void ChangeState(Task task, TaskFlow taskFlow);
    }
}
