using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInInterface
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        //public Address Address{ get; set; }
        //ustteki gibi bir baglilik siki bir bagdir
        //bir nesneyle en dusuk bag interface ile yapilir
        //asagidaki gibi
        public IAddress Address { get; set; }
    }

    public interface IAddress
    {
        //Marker: İşaretçi, bir nesnenin "ne olduğunu" belirtmek için de kullanılabilir.
        //Address'e herhangi bir ozellik kazandirmadigindan bu interface marker'dir
    }
    public class Address : IAddress
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

    }

    public class HomeAddress : Address
    {

    }

    public class WorkAddress : Address
    {

    }


    public class Mouse
    {
        public IBattery Pil { get; set; }
    }

    public interface IBattery
    {

    }
    public class Duracell : IBattery
    {

    }
    public class Kodak : IBattery
    {

    }

    public class PowerB : IBattery
    {

    }
}
