using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    //Det ska vara möjligt att användaren:
    //• Lägga till en kategori
    //• Skall kunna ändra namn på en kategori.När användaren ändrar namn på en kategori skall
    //tillhörande podcast kategori också ändras.
    //• Skall kunna ta bort en kategori.Applikationen ska också ta bort podcast(s) som har den
    //kategori.För att utföra detta ska applikationen fråga användaren om hen är säker på att hen
    //vill göra detta och om svaret är JA ska applikationen ta bort kategorin och alla podcasts som
    //har den kategorin.
    //• Skall kunna sortera podcast utifrån kategori. Väljs “Musik” skall applikationen endast visa alla
    //podcasts som hör till musik kategori.
    public class CategoryRepository : Feed<Category>, ICategoryRepository<Category>
    {
        private List<Category> categoryList;
        public CategoryRepository(string url) : base(url)
        {
            categoryList = new List<Category>();
            categoryList = GetAll();
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            //Remove all podcast with this same category!
            //Warn the user!
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<Category> SortByCategory()
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
