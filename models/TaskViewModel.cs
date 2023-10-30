namespace tasksApi.models
{
    public class TaskViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string? Title { get; set; }
        public bool Done { get; set; } = false;

        public Task MapToTask()
        {
            return new Task(Id == Guid.Empty ? Guid.NewGuid() : Id, Title, Done);
        }

        public Task CopyValuesToTask(AppDbContext db)
        {
            Task t = FindRelatedInstance(db);
            if (t == null)
                return null;

            t.Title = Title;
            t.Done = Done;

            db.Update(t);

            return t;
        }

        Task FindRelatedInstance(AppDbContext db)
        {
            Task task = db.Tasks.FirstOrDefault(t => t.Id == Id);
            return task;
        }
    }
}