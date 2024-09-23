namespace MVCLibraryManagementSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }       
        public DateTime DateofBirth { get; set; }
        public bool IsDeleted { get; set; }
    }
    
}
