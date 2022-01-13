using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;

namespace WebApiRestUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
    }
}
