using CoreAPI.Model;

namespace CoreAPI
{
    public class Initialize
    {
        private readonly StoreContext _storeContext;

        public Initialize(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        public void InitializeData()
        {
            if (!_storeContext.Members.Any())
            {
                var listMember = new List<Member>()
                {
                    new Member() {Email="dat@gmail.com",City="Nghe An",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn một mình Thành Đạt",Password="123456"},
                    new Member() {Email="duong@gmail.com",City="Thai Nguyen",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="123456"},
                    new Member() {Email="duy@gmail.com",City="Ha Nam",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="5678"},
                    new Member() {Email="huy@gmail.com",City="Ha Giang",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="123456"},
                    new Member() {Email="haha@gmail.com",City="HaNoi",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="123456"},
                    new Member() {Email="cua@gmail.com",City="HaNoi",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="9876543"},
                    new Member() {Email="gau@gmail.com",City="HaNoi",Country="VietNam",CompanyName="Công ty trách nhiệm hữu hạn Thành Đạt",Password="123456"}
                };
                _storeContext.Members.AddRange(listMember);
                _storeContext.SaveChanges();
            }
        }
    }
}
