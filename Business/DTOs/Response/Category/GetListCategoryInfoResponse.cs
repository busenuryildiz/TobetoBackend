using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Category
{
    public class GetListCategoryInfoResponse : BasePageableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Include any additional fields you want to return in the response
    }
}
