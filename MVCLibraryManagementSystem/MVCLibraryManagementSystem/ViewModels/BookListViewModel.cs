﻿namespace MVCLibraryManagementSystem.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Isbn { get; set; }
        public int CopiesAvailable { get; set; }
        public int AuthorId { get; set; }

    }
}
