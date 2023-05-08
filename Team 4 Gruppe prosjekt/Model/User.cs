namespace Team_4_Gruppe_prosjekt.Model
{
    public class User
    {
        private static int _lastId = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
            Id = _lastId++;
        }
    }
}
