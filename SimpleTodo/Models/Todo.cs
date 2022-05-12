namespace SimpleTodo.Models
{
    public class Todo
    {
        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
            IsDone = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }    
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            string status = IsDone ? "Concluída" : "Pendente";
            return $"| {Id} | {Title} | {Description} | { status } | {CreatedDate} |";
        }
    }
}
