namespace TodoListModels;

public class TodoItem
{
    public int Id { get; set; }
    public DateTime? Due_Date { get; set; }
    public DateTime? Completed_Date { get; set; }
    public string Description_of_Todo { get; set; }
}