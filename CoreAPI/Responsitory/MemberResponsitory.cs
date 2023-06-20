using CoreAPI.DTO;
using CoreAPI.Model;
using CoreAPI.Responsitory.Interface;

namespace CoreAPI.Responsitory
{
    public class MemberResponsitory : IMemberResponsitory
    {
        public static StoreContext storeContext;
        private static IAuthenticationRepository _authenticationRepository;

        public MemberResponsitory(StoreContext _storeContext, IAuthenticationRepository authenticationRepository)
        {
            storeContext = _storeContext;
            _authenticationRepository = authenticationRepository;
        }

        public static MemberResponsitory GetInstance(IAuthenticationRepository authenticationRepository)
        {
            return new MemberResponsitory(new StoreContext(), authenticationRepository);
        }

        public List<Member> GetMembers()
        {
            List<Member> list = storeContext.Members.ToList();
            if (list != null)
            {
                return list;
            }
            return new List<Member>();
        }

        public string Login(LoginDTO login)
        {
            Member member = storeContext.Members.FirstOrDefault(x=>x.Email.ToLower() == login.Email.ToLower()&&x.Password== login.Password);
            if(member == null) {
                return null;
            }
            return _authenticationRepository.GetJwtToken(member);
        }
    }
}
