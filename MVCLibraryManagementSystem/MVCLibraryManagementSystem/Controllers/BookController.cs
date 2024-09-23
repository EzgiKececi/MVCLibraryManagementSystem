using Microsoft.AspNetCore.Mvc;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.ViewModels;

namespace MVCLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        public static List<Book> _books = new List<Book>()  //Statik liste oluşturma
        {
            new Book { Id=1, Title = "Nutuk", AuthorId=1, Genre="Tarih", PublishDate= new DateTime(1927), Isbn="18811881", CopiesAvailable=100},
            new Book { Id=2, Title = "İnce Memed", AuthorId=2, Genre="Roman", PublishDate= new DateTime(1987), Isbn="123456", CopiesAvailable=50},
            new Book { Id=3, Title = "Geometri", AuthorId=1, Genre="Bilim", PublishDate= new DateTime(1937), Isbn="19191919", CopiesAvailable=90},
        };

        
        public IActionResult List() //LINQ kullanarak gerekli değişkenlerin kullanılması adına yeni bir liste oluşturma
        {

            var viewModel = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel
            {
                Id=x.Id,
                Title = x.Title,
                CopiesAvailable = x.CopiesAvailable,
                Genre = x.Genre,                
            }).ToList();

            return View(viewModel); 
        }

        public IActionResult Detail(int id) //İlgili kitabın seçilebilmesi içi Id yakalama
        {
            var book = _books.Find(x => x.Id == id); //LINQ ile istenilen kitabı seçebilmek için Id eşleme

            return View(book); //İlgili view'e parametre atama
        }

        [HttpGet] // Method ile ilgili view oluşturabilmek için HttpGet kullanılır
        public IActionResult Create()
        {
            ViewBag.Authors = AuthorController._authors; //Başka bir controller'da bulunan listeyi kullanma
            return View();
        }

        [HttpPost] // Form'dan bilgileri alabilmek için HttpPost kullanıldı
        public IActionResult Create(Book formData)
        {

            if (!ModelState.IsValid) //"Required" gereklilikleri kontrol edildi
            {
                return View(formData);
            }

            int maxId = _books.Max(x => x.Id); //Listedeki en büyük Id değişkene atandı

            var newBook = new Book() //Yeni kitap tüm değişkenleri ile oluşturulabilmesi için Book modeli kullanıldı, formdan gelen bilgiler atandı.
            {
                Id = maxId + 1,
                Title = formData.Title,
                Genre = formData.Genre,
                PublishDate = formData.PublishDate,
                CopiesAvailable = formData.CopiesAvailable,
                AuthorId = formData.AuthorId,
                Isbn = formData.Isbn,
                IsDeleted = false
            };

            _books.Add(newBook); //Oluşan yeni newBook listeye eklendi
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id) //İlgili kitabın seçilebilmesi için Id yakalama
        {
            var editedBook = _books.Find(x => x.Id == id);

            var editedModel = new BookEditViewModel //İstenilen view verilerine göre new'leme
            {
                Id = editedBook.Id,
                Title = editedBook.Title,
                Genre = editedBook.Genre,
                CopiesAvailable= editedBook.CopiesAvailable              

            };

            return View(editedModel); 

        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData) //Form'dan bilgileri alma
        {
            if (!ModelState.IsValid) //"Required" gereklilikleri kontrol edildi
            {
                return View(formData);
            }

            var task = _books.Find(x => x.Id == formData.Id);
            task.Id = formData.Id;
            task.Title = formData.Title;
            task.Genre = formData.Genre;
            task.CopiesAvailable = formData.CopiesAvailable;
            
            return RedirectToAction("List");

        }
        public IActionResult Delete(int id) //İstenilen kitabın Id ile yakalanması
        {

            var deletedBook = _books.Find(x => x.Id == id); // Listede Id'nin bulunması

            deletedBook.IsDeleted = true; // Default olarak false gelen değer true yapılarak Soft Delete olarak silme işlemi gerçekleştirildi


            return RedirectToAction("List"); 
        }
          


        
    }
}
