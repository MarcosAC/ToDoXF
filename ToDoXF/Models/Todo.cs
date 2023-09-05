using SQLite;

namespace ToDoXF.Models
{
    [Table("Todo")]
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TodoTitle { get; set; }
        public string Description { get; set; }
    }
}
