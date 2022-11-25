using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IProductService
{
    ProductModel GetProduct(Guid id);

    ProductModel UpdateProduct(Guid id, UpdateProductModel user);

    void DeleteProduct(Guid id);

    ProductModel AddProduct(ProductModel productModel);

    PageModel<ProductPreviewModel> GetProducts(int limit = 20, int offsert = 0);
}