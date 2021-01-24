namespace NT.UM.Application.Contracts.ViewModels
{
    public class PermissionTypesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }


        public PermissionTypesDto(int id, string title, int parentid)
        {
            Id = id;
            Title = title;
            ParentId = parentid;
        }
    }
}