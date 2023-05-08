namespace Team_4_Gruppe_prosjekt.Model
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
        private static int _lastId = 0;

        public ToDoItem(string title, string description, int userId)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            DoneDate = null;
            UserId = userId;
            Id = _lastId++;
        }

        public void SetDone()
        {
            DoneDate = DateTime.Now;
        }
    }
}
