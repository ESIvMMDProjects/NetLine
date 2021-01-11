using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;

namespace NetLine.Domain.Services.InterFaces.ProductAndCategory
{
    public interface ICategoryRe
    {
        Task<IEnumerable<Category>> ShowAllCategory();
        Task AddCategory(Category addCategory);
        Task<Category> EditCategory(int id, Category addCategory);
        Task ApplyEdit(Category addCategory);
        Task DeleteCategory(int id);
    }
}
