using Microsoft.AspNetCore.Mvc;
using MVCLibraryManagementSystem.Models;
using MVCLibraryManagementSystem.ViewModels;

namespace MVCLibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        public static List<Author> _authors = new List<Author>() //Statik liste oluşturulması
        {
            new Author { Id=1, FullName= "Mustafa Kemal Atatürk", DateofBirth= new DateTime(1881,05,19)},
            new Author { Id=2, FullName="Yaşar Kemal", DateofBirth= new DateTime(1923,10,06)},
            new Author { Id=3, FullName="Halide Edip Adıvar", DateofBirth= new DateTime(1884,01,01)},

        };
        public IActionResult List() //View'da görünecek verilere göre liste oluşturulması
        {
            var viewModel= _authors.Where(x=>x.IsDeleted==false).Select(x=> new AuthorListViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                DateofBirth= x.DateofBirth,
            }).ToList();


            return View(viewModel);
        }

        [HttpGet] //Kitap ekleme view'ı için HttpGet kullanıldı
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author formData) //Form'dan gelen bilgilerin işlenmesi için HttpPost kullanıldı
        {

            if (!ModelState.IsValid) //"Required" gereklilikleri kontrol edildi
            {
                return View(formData);
            }

            int maxId = _authors.Max(x => x.Id); //Listedeki en büyük Id bulundu

            var newAuthor = new Author() //Yeni yazara formdan gelen bilgiler verildi, Id bir arttırıldı
            {
                Id = maxId + 1,
                FullName = formData.FullName,
                DateofBirth = formData.DateofBirth,
               
            };

            _authors.Add(newAuthor); //Listeye eklendi
            return RedirectToAction("List");
        }


        public IActionResult Detail(int id) 
        {
            var author = _authors.Find(x => x.Id == id); //İlgili yazar Id ile yakalandı

            return View(author);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editedAuthor=_authors.Find(x=> x.Id == id); //İlgili yazar Id ile yakalandı


            var editedModel = new AuthorEditViewModel 
            {
                Id = editedAuthor.Id,
                FullName = editedAuthor.FullName,
                DateofBirth = editedAuthor.DateofBirth,

            };

            return View(editedModel); // İlgili yazarın bilgileri dolu bir şekilde gelecek

        }

        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel formData)
        {
            if(!ModelState.IsValid) //"Required" gereklilikleri kontrol edildi
            {
                return View(formData); // Veriler silinmesi diye gene eski bilgiler gelecek
            }

            var task = _authors.Find(x => x.Id == formData.Id);

            //Form'dan gelen bilgiler verildi
            task.FullName = formData.FullName;
            task.DateofBirth = formData.DateofBirth;

           return RedirectToAction("List");

        }
        public IActionResult Delete (int id) // İlgili yazar Id ile yakalandı
        {

            var deletedAuthor= _authors.Find(x => x.Id == id);

            deletedAuthor.IsDeleted=true; //Default olarak false gelen değişken true yapılarak Soft Delete işlemi gerçekleştirildi.


            return RedirectToAction("List");
        }

    }
}
