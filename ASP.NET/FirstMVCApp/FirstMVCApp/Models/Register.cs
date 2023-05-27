using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class Register
    {
        public string username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
