using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }

    public class UserCreatedEventArgs : EventArgs
    {
        public User User { get; set; }//hangi kullanıcı eklendi
        public DateTime CreatedDate { get; set; }
    }

    public class UserService
    {
        //public delegate void UserCreatedEventHandler(object sender, UserCreatedEventArgs e);
        public event EventHandler<UserCreatedEventArgs> UserCreated;
        //biz delege, event yazana kadar Microsoft bize özelleştirilmiş EventHandler yazmıştır ve onu kullanabiliriz

        //yeni kullanıcı oluşturulduğunda event fırlatmaya karar verildi
        public void CreateUser(User user)
        {
            // TODO 01 : event burada fırlatılacak
            if(UserCreated != null)
            {
                UserCreatedEventArgs arg = new UserCreatedEventArgs
                {
                    User = user,
                    CreatedDate = DateTime.Now,
                };
                UserCreated(this, arg);

            }
        }
    }
}
