namespace Domain
{
    public class User
    {
        private int id;
        private string name;

        public int Id { get { return id; } private set { id = value; } }
        public string Name { get { return name; } private set { name = value; } }

        public User(int userId, string userName)
        {
            this.id = userId;
            this.name = userName;
        }
    }
}