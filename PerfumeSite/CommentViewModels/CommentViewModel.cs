using PerfumeSite.UserViewModels;

namespace PerfumeSite.CommentViewModels
{
    public class CommentViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public int ProductId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
