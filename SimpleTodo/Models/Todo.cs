namespace SimpleTodo.Models
{
    public class Todo
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }    
        public DateTime CreatedDate { get; set; }
    }
}
