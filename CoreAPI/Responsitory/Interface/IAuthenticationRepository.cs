using CoreAPI.Model;

namespace CoreAPI.Responsitory.Interface
{
    public interface IAuthenticationRepository
    {
        string GetJwtToken(Member member);
    }
}
