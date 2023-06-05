namespace IdeasAPI
{
    public class IdeaEntry
    {
        public int Id;
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Categories { get; set; }
    }
}
