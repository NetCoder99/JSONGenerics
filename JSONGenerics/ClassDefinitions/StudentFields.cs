using System.Collections.Generic;

namespace JSONGenerics.ClassDefinitions
{
    public class StudentField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public override string ToString()
        {
            return  Name + "," + Type + "," + Length.ToString();
        }
    }

    public class StudentFieldRoot
    {
        public List<StudentField> StudentFields { get; set; }
    }
}
