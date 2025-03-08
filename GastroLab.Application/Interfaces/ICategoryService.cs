using GastroLab.Models.CategoryModels;

namespace GastroLab.Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryListModel> GetCategories();
        CategoryListModel GetCategoryById(int id);
        int CreateCategory(CategoryCreateModel categoryModel);
        int UpdateCategory(CategoryUpdateModel categoryModel);
        bool DeleteCategory(int id);
    }
}
