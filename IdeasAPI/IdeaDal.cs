using IdeasAPI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class IdeaDal : IBankIdeaDal 
    {
        private DatabaseConnection _configCon;
        private MySqlConnection conn;
        public IdeaDal()
        {
            _configCon = new DatabaseConnection();
            conn = new MySqlConnection(_configCon.SqlConnectionString);
        }

        public void SaveEntry(IdeaEntry ideaEntry)
        {
            string ideaEntryQuery = "INSERT INTO `idea`( `user_id`, `username`, `subject`, `description`, `type`, `start_date`, `end_date`, `categories`)" +
                " VALUES (@userId, @userName, @subject, @description, @type, @startDate, @endDate, @categories)";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(ideaEntryQuery, conn);
                cmd.Parameters.AddWithValue("@userId", ideaEntry.UserId);
                cmd.Parameters.AddWithValue("@userName", ideaEntry.UserName);
                cmd.Parameters.AddWithValue("@subject", ideaEntry.Subject);
                cmd.Parameters.AddWithValue("@description", ideaEntry.Description);
                cmd.Parameters.AddWithValue("@type", ideaEntry.Type);
                cmd.Parameters.AddWithValue("@startDate", ideaEntry.StartDate);
                cmd.Parameters.AddWithValue("@endDate", ideaEntry.EndDate);
                cmd.Parameters.AddWithValue("@categories", ideaEntry.Categories);
            cmd.ExecuteReader();
            conn.Close();
        }

        public List<IdeaEntry> GetIdeaEntries()
        {
            string applyOnJobQuery = "SELECT * From idea";
            var ideas = new List<IdeaEntry>();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(applyOnJobQuery, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ideas.Add(new IdeaEntry()
                    {
                        Id = dataReader.GetInt32("id"),
                        UserId = dataReader.GetInt32("user_id"),
                        UserName = dataReader.GetString("username"),
                        Subject = dataReader.GetString("subject"),
                        Type = dataReader.GetString("type"),
                        StartDate = dataReader.GetDateTime("start_date"),
                        EndDate = dataReader.GetDateTime("end_date"),
                        Categories = dataReader.GetString("categories")
                    });
                }
            }
            return ideas;
        }
    }
}
