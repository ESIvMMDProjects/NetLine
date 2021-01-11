using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Services.InterFaces.ProductAndCategory;
using NetLine.Infrastructure.Context;

namespace NetLine.Infrastructure.Services.Repository.ProductAndCategory
{
    public class CategoryRe : ICategoryRe
    {
        private readonly NetLineDbContext _context;

        public CategoryRe(NetLineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> ShowAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddCategory(Category addCategory)
        {
            var category = new Category()
            {
                Name = addCategory.Name,
                Description = addCategory.Description,
            };
         await   _context.AddAsync(category);
          await  _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var deleteCategory = await _context.Categories.FindAsync(id);
            _context.Remove(deleteCategory);
           await _context.SaveChangesAsync();

        }

        public async Task<Category> EditCategory(int id, Category addCategory)
        {
            var editCategory =await _context.Categories.Where(c => c.Id == id)
                .Select(ca => new Category
                {
                    Name = addCategory.Name,
                    Description = addCategory.Description
                }).FirstAsync();
            return editCategory;

        }

        public async Task ApplyEdit(Category addCategory)
        {
            var applyEditCategory = await _context.Categories.FindAsync(addCategory);

            applyEditCategory.Name = addCategory.Name;
            applyEditCategory.Description = addCategory.Description;

            await _context.SaveChangesAsync();
        }


    }
}
