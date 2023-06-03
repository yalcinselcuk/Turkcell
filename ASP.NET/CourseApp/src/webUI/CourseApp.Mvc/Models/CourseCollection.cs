using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;

namespace CourseApp.Mvc.Models
{
    //sepet işlemleri yapılacak
    public class CourseCollection
    {
        public List<CourseItem> CourseItems { get; set; } = new List<CourseItem>();

        public void ClearAll()
        {
            CourseItems.Clear();
        }
        public decimal TotalCoursePrice()
        {
            return CourseItems.Sum(item => (decimal)item.Course.Price * item.Quantity);
        }
        public int TotalCoursesCount()
        {
            return CourseItems.Sum(course => course.Quantity);
        }
        //silme işlemi yok, sen yapacaksın

        //hiç eklenmemişse ekle
        //eklenmişse adeti artır
        public void AddNewCourse(CourseItem courseItem)
        {
            var exists = CourseItems.FirstOrDefault(course => course.Course.Id == courseItem.Course.Id); // var mı yok mu diye kontrol ediyoruz
            if (exists != null)//eğer exists doğruysa 
            {
                //var existingCourse = CourseItems.FirstOrDefault(course => course.Course.Id == courseItem.Course.Id);
                exists.Quantity += courseItem.Quantity;//var olanın adetini yeni gelenin adedi kadar artır
            }
            else
            {
                CourseItems.Add(courseItem); 
            }
        }


    }

    public class CourseItem
    {
        public CourseDisplayResponse Course { get; set; }
        public int Quantity { get; set; }
        public bool? ApplyCoupon { get; set; }//kupon uygulanabilirliği

    }
}
