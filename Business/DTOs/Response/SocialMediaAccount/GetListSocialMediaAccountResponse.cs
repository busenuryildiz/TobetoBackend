using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.SocialMediaAccount
{
    public class GetListSocialMediaAccountResponse:BasePageableModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaUrl { get; set; }
    }
}
