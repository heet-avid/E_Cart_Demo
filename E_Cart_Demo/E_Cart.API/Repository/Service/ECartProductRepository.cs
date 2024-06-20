using Microsoft.EntityFrameworkCore;
using ECart.API.Data.Entity;
using ECart.API.Data.Entity.DbSet;
using ECart.API.Data.Models;
using ECart.API.Repository.Interface;

namespace ECart.API.Repository.Service;

public class ECartProductRepository : IECartProductRepository
{
    private readonly ECartDbContext _db;

    public ECartProductRepository(ECartDbContext dbContext) => _db = dbContext;

    public async Task<ApiResult<List<ECartProductModel>>> GetAllProducts()
    {
        var result = new ApiResult<List<ECartProductModel>>();
        try
        {
            var products = _db.Products.Where(x=> x.IsDeleted == false).ToList();

            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status200OK;
            result.Message = "Products fetched successfully.";
            result.Data = new List<ECartProductModel>();
            foreach (var product in products)
            {

                result.Data.Add(new ECartProductModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Stock = product.Stock,
                    Description = product.Description,
                    Price = product.Price,
                    CreatedAt = product.CreatedAt
                });
            }
        }
        catch (Exception ex)
        {
            result.IsSuccess = true;
            result.StatusCode = StatusCodes.Status500InternalServerError;
            result.Message = "Something went wrong. Please try again after some time.";
        }
        return result;
    }

    public async Task<ApiResult> CreateProduct(ECartProductModel model)
    {
        try
        {
            var user = _db.Users.Where(x => x.Id == model.UserId).FirstOrDefault();
            if (user is not null)
            {
                if (user.IsAdmin)
                {
                    var product = new Product()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        Stock = model.Stock,
                        CreatedAt = model.CreatedAt
                    };
                    await _db.Products.AddAsync(product);
                    await _db.SaveChangesAsync();

                    return new ApiResult(true, "Product created successfully.", StatusCodes.Status201Created);
                }
                else
                {
                    return new ApiResult(false, "You don't have rights to create product.", StatusCodes.Status406NotAcceptable);
                }
            }
            else
            {
                return new ApiResult(false, "Invalid user details.", StatusCodes.Status404NotFound);
            }
        }
        catch (Exception ex)
        {
            return new ApiResult(false, "Something went wrong. Please try again after some time.", StatusCodes.Status500InternalServerError);
        }
    }
    public async Task<ApiResult> UpdateProduct(ECartProductModel model, int id)
    {
        try
        {
            var user = await _db.Users.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
            if (user is not null)
            {
                if (user.IsAdmin)
                {
                    var product = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (product is not null)
                    {
                        product.Name = model.Name;
                        product.Description = model.Description;
                        product.Price = model.Price;
                        product.Stock = model.Stock;

                        _db.Update(product);
                        _db.SaveChanges();

                        return new ApiResult(true, "Product updated successfully.", StatusCodes.Status200OK);
                    }
                    else
                    {
                        return new ApiResult(true, "Product not found.", StatusCodes.Status404NotFound);
                    }
                }
                else
                {
                    return new ApiResult(false, "You don't have rights to update product.", StatusCodes.Status406NotAcceptable);
                }
            }
            else
            {
                return new ApiResult(false, "Only admin can update products.", StatusCodes.Status404NotFound);
            }


        }
        catch (Exception ex)
        {
            return new ApiResult(false, "Something went wrong. Please try again after some time.", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ApiResult> DeleteProduct(int id, int userId)
    {
        try
        {
            var user = await _db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (user is not null)
            {
                if (user.IsAdmin)
                {
                    var product = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                    if (product is not null)
                    {
                        product.IsDeleted = true;
                        _db.Products.Update(product);
                        _db.SaveChanges();

                        return new ApiResult(true, "Product deleted successfully.", StatusCodes.Status200OK);
                    }
                    else
                    {
                        return new ApiResult(true, "Product not found.", StatusCodes.Status404NotFound);
                    }
                }
                else
                {
                    return new ApiResult(false, "You don't have rights to update product.", StatusCodes.Status406NotAcceptable);
                }
            }
            else
            {
                return new ApiResult(false, "Invalid user details.", StatusCodes.Status404NotFound);
            }
        }
        catch (Exception ex)
        {
            return new ApiResult(false, "Something went wrong. Please try again after some time.", StatusCodes.Status500InternalServerError);
        }
    }

}
