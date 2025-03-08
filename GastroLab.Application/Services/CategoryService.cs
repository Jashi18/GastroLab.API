using GastroLab.Application.Interfaces;
using GastroLab.Data.Data;
using GastroLab.Data.Entities;
using GastroLab.Models.CategoryModels;

namespace GastroLab.Application.Services
{
    public class CategoryService(GastroLabDbContext dbContext) : ICategoryService
    {
        private readonly GastroLabDbContext _dbContext = dbContext;

        public IEnumerable<CategoryListModel> GetCategories()
        {
            var categories = _dbContext.Categories
                .Where(c => c.DeleteDate == null)
                .Select(c => new CategoryListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                });
            return categories;
        }
        public CategoryListModel GetCategoryById(int id)
        {
            var category = _dbContext.Categories
                .Where(c => c.DeleteDate == null && c.Id == id)
                .Select(c => new CategoryListModel
                {
                    Id = id,
                    Name = c.Name,
                    Description = c.Description
                }).FirstOrDefault();
            return category == null ? throw new ArgumentNullException() : category;
        }
        public int CreateCategory(CategoryCreateModel categoryModel)
        {
            var category = new Category
            {
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                CreateDate = DateTime.UtcNow
            };

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Id;
        }
        public int UpdateCategory(CategoryUpdateModel categoryModel)
        {
            var category = _dbContext.Categories
                .FirstOrDefault(c => c.DeleteDate == null && c.Id == categoryModel.Id);

            if (category == null)
                throw new KeyNotFoundException($"Category with ID {categoryModel.Id} not found");

            category.Name = categoryModel.Name;
            category.Description = categoryModel.Description;
            category.UpdateDate = DateTime.UtcNow;

            _dbContext.SaveChanges();

            return category.Id;
        }
        public bool DeleteCategory(int id)
        {
            var category = _dbContext.Categories
                .FirstOrDefault(c => c.DeleteDate == null && c.Id == id);

            if (category == null)
                return false;

            category.DeleteDate = DateTime.UtcNow;
            _dbContext.SaveChanges();

            return true;
        }
    }
}
