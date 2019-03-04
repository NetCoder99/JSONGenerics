using System;
using System.Collections.Generic;

namespace JSONGenerics.ClassDefinitions
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        private int _Length;
        public object Length
        {
            get { return _Length; }
            set {
                    if (value != null)
                    { _Length = Int32.Parse(value.ToString()); }
                    else
                    { _Length = -1; }
                }
            }
    }

    public class StudentDetail
    {
        private int _ID;
        public object ID
        {
            get { return _ID; }
            set {
                    if (value != null)
                    { _ID = Int32.Parse(value.ToString()); }
                    else
                    { _ID = -1; }
            }
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    public class Student
    {
        public List<Field> Fields { get; set; }
        public List<StudentDetail> StudentDetails { get; set; }

        // pretty print for debugging, also works for exporting to CSV, if anyone still does that
        public override string ToString()
        {
            string disp_str = "-- Fields --" + Environment.NewLine; ;
            foreach (Field fld_item in Fields)
            { disp_str += fld_item.Name + "," + fld_item.Type + "," + fld_item.Length.ToString() + Environment.NewLine; }
            disp_str += "-- StudentDetails --" + Environment.NewLine;;
            foreach (StudentDetail std_item in StudentDetails)
            { disp_str += std_item.ID.ToString()  + "," + std_item.Name + "," + std_item.Address + "," + std_item.City + Environment.NewLine; }
            return disp_str;
        }
    }

    public class StudentRoot
    {
        public List<Student> Student { get; set; }
    }

}
