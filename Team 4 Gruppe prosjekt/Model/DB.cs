namespace Team_4_Gruppe_prosjekt.Model
{
    public static class DB
    {
        public static List<ToDoItem> ToDoList { get; set; } = new List<ToDoItem>();
        public static List<User> Users { get; set; } = new List<User>();

        public static List<ToDoItem> GetUsersToDoList(int userId)
        {
            return ToDoList.FindAll(x => x.UserId == userId);
            /*
            List<ToDoItem> list = new List<ToDoItem>();
            foreach (ToDoItem item in ToDoList)
            {
                if (item.UserId == userId)
                {
                    list.Add(item);
                }
            }
            return list;
             */
        }
        public static void MakeData()
        {
            Users.Add(new User("Johnny"));
            Users.Add(new User("Rebecka"));
            Users.Add(new User("Erwan"));
            Users.Add(new User("Lars"));
        }
        public static bool MarkTaskAsDone(int taskId)
        {
            try
            {
                ToDoList.First(item => item.Id == taskId).SetDone();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
