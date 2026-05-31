using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.DAL;

namespace TrainReservationSystem.BAL
{
   public class UserException:Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }
    public class UserBAL
    {
        UserDAL dal = new UserDAL();

        public string Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new UserException("Username and Password required");

            return dal.Login(username, password);
        }

        public int AddUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new UserException("Username and Password required");

            return dal.AddUser(username, password);
        }
    }

}
