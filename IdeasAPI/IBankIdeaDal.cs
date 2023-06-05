namespace IdeasAPI
{
    public interface IBankIdeaDal
    {
        void SaveEntry(IdeaEntry entry);
        List<IdeaEntry> GetIdeaEntries();
    }
}
