using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Repository;
using Stock.Model;

namespace Stock.BLL
{
    class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();


        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public bool CheckCode(Category category)
        {
            return _categoryRepository.CheckCode(category);
        }

        public bool CheckName(Category category)
        {
            return _categoryRepository.CheckName(category);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public List<Category> Display()
        {
            return _categoryRepository.Display();
        }

        public List<Category> Search(string item)
        {
            return _categoryRepository.Search(item);
        }


    }
}
