using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public void Create(Category category)
        {
            _categoryDal.Create(category);
        }
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(Category category)
        {

            _categoryDal.Delete(category);

        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(x => x.CategoryId == id);
        }
    }
}
