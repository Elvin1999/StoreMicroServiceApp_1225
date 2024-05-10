using RabbitMQService;
using System.Text;

namespace SearchService.Services
{
    public class ProductService : IProductService
    {
        private readonly IQueueService _queueService;
        public string ImageUrl = "";
        public ProductService(IQueueService queueService)
        {
            _queueService = queueService;
        }

        string IProductService.ImageUrl { get; set; }

        public async Task<string> GetProductImagePathAsync(int productId)
        {
            //HttpClient httpClient = new HttpClient();
            //HttpResponseMessage response=new HttpResponseMessage();
            //string url = "https://localhost:10601/api/Product/GetImage/" + productId;
            //response=await httpClient.GetAsync(url);
            //var str=await response.Content.ReadAsStringAsync();
            //return str;

            var queueName = $"product-queue-{productId}";
            var data=_queueService.ConsumeMessageFromQueue(queueName);
            return data;
        }

        private void Data_Received(object? sender, RabbitMQ.Client.Events.BasicDeliverEventArgs e)
        {
            this.ImageUrl = Encoding.UTF8.GetString(e.Body.ToArray());
        }
    }
}
