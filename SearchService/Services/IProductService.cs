namespace SearchService.Services
{
    public interface IProductService
    {
        string ImageUrl { get; set; }
        Task<string> GetProductImagePathAsync(int productId);    
    }
}
