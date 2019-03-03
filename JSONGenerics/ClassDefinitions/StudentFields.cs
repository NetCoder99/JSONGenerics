using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONGenerics.ClassDefinitions
{
    public class StudentField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
    }

    public class StudentFieldRoot
    {
        public List<StudentField> StudentFields { get; set; }
    }
}
