namespace BookStore.Model
{
    public class SystemMenu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int ParentId { get; set; }
    }
}