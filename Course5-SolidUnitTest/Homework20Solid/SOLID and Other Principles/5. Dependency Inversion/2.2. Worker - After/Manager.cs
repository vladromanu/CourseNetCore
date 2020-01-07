namespace DependencyInversionWorkerAfter
{
    public class Manager
    {
        private IWorker worker;

        public void AssignWorker(IWorker worker)
        {
            this.worker = worker;
        }

        public void Manage()
        {
            this.worker.Work();
        }
    }
}
