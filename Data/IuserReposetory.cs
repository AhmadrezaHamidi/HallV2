using System.Linq;
using tama.Domain.BaseDomain;
using tama.Domain.Entity;

namespace tama.Data
{
    public interface IuserReposetory
    {
         bool isExistByEmail(string emailAddress);
         bool isExistByPhoneNumber(string phoneNumber);
         void AddUser(CustomerEntity customer);
        public CustomerEntity LogingWhiteEmail(string emailAddress,string password); 

    }
    public class userReposetory : IuserReposetory
    {
        private TamasaContext _dbContext;
        public userReposetory(TamasaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(CustomerEntity customer)
        {
            _dbContext.CustomerTb.Add(customer);
            _dbContext.SaveChanges();
        }

        public bool isExistByEmail(string emailAddress)
        {
            return _dbContext.CustomerTb.Any(x => x.Email.Equals(emailAddress));
        }

        public bool isExistByPhoneNumber(string phoneNumber)
        {
            return _dbContext.CustomerTb.Any(x => x.Email.Equals(phoneNumber));
        }

        
        public CustomerEntity LogingWhiteEmail(string emailAddress,string password)
        {
            return _dbContext.CustomerTb.SingleOrDefault(x => x.Email.Equals(emailAddress) &&
             x.Password.Equals(password));
        } 
    }
}