using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{ 
    //inheritance, Generic yapıları kullanıldı. efrepositorybase den efuserdal için kalıtım oluşturuldu. user, guid 
    //tobetocontext bunları kullanabilecek.ctor kullanıldı.
    public class EfUserDal: EfRepositoryBase<User, Guid, TobetoContext>, IUserDal
    {
        
        public EfUserDal(TobetoContext context) : base(context)
        {

        }
     
    }
}
