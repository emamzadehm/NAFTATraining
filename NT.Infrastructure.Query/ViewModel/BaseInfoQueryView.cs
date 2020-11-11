namespace NT.Infrastructure.Query.ViewModel
{
    public class BaseInfoQueryView
    {
        
        public long ID { get; set; }
        public string? Title { get; set; }
        public long? TypeID { get; set; }
        public string? TypeName { get; set; }
        public long? ParentID { get; set; }
        public string? ParentName { get; set; }
        public bool Status { get; set; }
    }
}
