using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IProductService
{
    ProductModel GetProduct(Guid id);

    ProductModel UpdateProduct(Guid id, UpdateProductModel product);

    void DeleteProduct(Guid id);

    CreateProductModel AddProduct(ProductModel product);

    PageModel<ProductPreviewModel> GetProducts(int limit = 20, int offsert = 0);
}