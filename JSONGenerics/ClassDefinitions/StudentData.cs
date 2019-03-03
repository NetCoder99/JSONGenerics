using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONGenerics.ClassDefinitions
{
    public class StudentData
    {
        public object ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return ((ID == null)? "" : ID.ToString()) + "," + Name + "," + Address + "," + City;
        }
    }

    public class StudentDataRoot
    {
        public List<StudentData> StudentData { get; set; }
    }

}
