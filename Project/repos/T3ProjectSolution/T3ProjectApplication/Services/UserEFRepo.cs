using T3ProjectApplication.Models;

namespace T3ProjectApplication.Services
{
    public class UserEFRepo : IRepo<int, User>
    {
        private readonly T3ShopContext _context;

        public UserEFRepo(T3ShopContext context)
        {
            _context = context;
        }

        public bool Add(User t)
        {
            _context.Users.Add(t);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int k)
        {

            _context.Users.Remove(GetT(k));
            _context.SaveChanges();
            return true;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetT(int k)
        {
            return _context.Users.FirstOrDefault(p => p.UserId == k);
        }

        public bool Update(int k, User t)
        {
            var MyUser = _context.Users.FirstOrDefault(p => p.UserId == k);
            if (MyUser != null)
            {
                MyUser.Username = t.Username;
                MyUser.Password = t.Password;
                MyUser.Email = t.Email;
                MyUser.Phone = t.Phone;
                MyUser.DOB = t.DOB;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
