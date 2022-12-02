using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IRepository<Product> productsRepository;
    private readonly IMapper mapper;
    public ProductService(IRepository<Product> productsRepository, IMapper mapper)
    {
        this.productsRepository = productsRepository;
        this.mapper = mapper;
    }

    public void DeleteProduct(Guid id)
    {
        var productToDelete = productsRepository.GetById(id);
        if (productToDelete == null)
        {
            throw new Exception("Product not found");
        }

        productsRepository.Delete(productToDelete);
    }

    public ProductModel GetProduct(Guid id)
    {
        var product = productsRepository.GetById(id);
        return mapper.Map<ProductModel>(product);
    }

    public PageModel<ProductPreviewModel> GetProducts(int limit = 20, int offset = 0)
    {
        var products = productsRepository.GetAll();
        int totalCount = products.Count();
        var chunk = products.OrderBy(x => x.ProductName).Skip(offset).Take(limit);

        return new PageModel<ProductPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ProductPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ProductModel UpdateProduct(Guid id, UpdateProductModel product)
    {
        var existingProduct = productsRepository.GetById(id);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }        

        existingProduct.CaloricContent = product.CaloricContent;
        existingProduct.ProductName = existingProduct.ProductName;

        existingProduct = productsRepository.Save(existingProduct);
        return mapper.Map<ProductModel>(existingProduct);
    }

     public CreateProductModel AddProduct(ProductModel product){
        
         if(productsRepository.GetAll(x => x.Id == product.Id).FirstOrDefault() != null)
        {
            throw new Exception ("Attempt to create a non-unique object!");
        }

        CreateProductModel productModel = new CreateProductModel();

        productModel.ProductName = product.ProductName;
        productModel.CaloricContent = product.CaloricContent;

        productsRepository.Save(mapper.Map<Entities.Models.Product>(productModel));
        return productModel;
    }
}