using JSONGenerics.ClassDefinitions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            string defs_dir_name = "";
            try
            {
                string json_string1 = File.ReadAllText(@"C:\Users\dughome002\source\repos\DynamicEF\DynamicEF\ClassDefinitions\StudentFields.json");
                List<StudentField> l1 = ProcessJSONClass<StudentField>(json_string1).Cast<StudentField>().ToList();

                string json_string2 = File.ReadAllText(@"C:\Users\dughome002\source\repos\DynamicEF\DynamicEF\ClassDefinitions\StudentData.json");
                List<StudentData> l2 = ProcessJSONClass<StudentData>(json_string2).Cast<StudentData>().ToList();

                foreach (StudentData s_data in l2)
                { Console.WriteLine(s_data.ToString()); }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }


        private static List<T> ProcessJSONClass<T>(string json_string)
        {
            Type type = typeof(T);
            if (type == typeof(StudentField))
            {
                var root = JsonConvert.DeserializeObject<StudentFieldRoot>(json_string);
                List<StudentField> sf_list = new List<StudentField>();
                sf_list.AddRange(root.StudentFields);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            if (type == typeof(StudentData))
            {
                var root = JsonConvert.DeserializeObject<StudentDataRoot>(json_string);
                List<StudentData> sf_list = new List<StudentData>();
                sf_list.AddRange(root.StudentData);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            throw new Exception("Unknow type");
        }
    }
}
