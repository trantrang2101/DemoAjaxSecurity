using CoreAPI.DTO;
using CoreAPI.Model;

namespace CoreAPI.Responsitory.Interface
{
    public interface IMemberResponsitory
    {
        string Login(LoginDTO login);
        List<Member> GetMembers();
    }
}
