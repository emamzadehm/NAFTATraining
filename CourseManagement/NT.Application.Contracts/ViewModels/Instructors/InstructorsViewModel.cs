namespace NT.CM.Application.Contracts.ViewModels.Instructors
{
    public class InstructorsViewModel
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
        public string? Tel { get; set; }
        public byte[]? IMG { get; set; }
        public string? Password { get; set; }
        public byte[]? IDCardIMG { get; set; }
        //Instructor's table =>
        public long ID { get; set; }
        public string? EducationLevel { get; set; }
        public string? Resume { get; set; }
    }
}
