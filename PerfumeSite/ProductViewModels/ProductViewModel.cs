using PerfumeSite.UserViewModels;

namespace PerfumeSite.ProductViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int BrandId { get; set; }
        public int CategoryId { get; set; }

    }
}
