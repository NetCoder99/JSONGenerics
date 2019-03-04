﻿using JSONGenerics.ClassDefinitions;
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
            DisplayJSONData1();
            DisplayJSONData2();
        }

        // ---------------------------------------------------------------------------------------
        // demo 2 the arrays are combined, NewtonSoft stills parses with ease
        // ---------------------------------------------------------------------------------------
        private static void DisplayJSONData2()
        {
            try
            {
                string defs_dir_name = GetLocalJsonDirectory("ClassDefinitions");

                string json_string1 = File.ReadAllText(defs_dir_name + "\\" + "Student.json");
                List<Student> l1 = ProcessJSONClass<Student>(json_string1).Cast<Student>().ToList();
                DisplayList(l1);

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.ReadLine();
        }

        // ---------------------------------------------------------------------------------------
        // demo-1 the arrays are stand alone json file, easy peasy
        // ---------------------------------------------------------------------------------------
        private static void DisplayJSONData1()
        {
            try
            {
                string defs_dir_name = GetLocalJsonDirectory("ClassDefinitions");

                string json_string1 = File.ReadAllText(defs_dir_name + "\\" + "StudentFields.json");
                List<StudentField> l1 = ProcessJSONClass<StudentField>(json_string1).Cast<StudentField>().ToList();
                DisplayList(l1);

                string json_string2 = File.ReadAllText(defs_dir_name + "\\" + "StudentData.json");
                List<StudentData> l2 = ProcessJSONClass<StudentData>(json_string2).Cast<StudentData>().ToList();
                DisplayList(l2);
                
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.ReadLine();

        }

        // ---------------------------------------------------------------------------------------
        // this only works when you have an override of ToString() in the List<class>
        // ---------------------------------------------------------------------------------------
        private static void DisplayList<T>(List<T> any_list)
        {
            foreach (var list_item in any_list)
            { Console.WriteLine(list_item.ToString()); }
        }

        // ---------------------------------------------------------------------------------------
        // messing around with Generics and JSON
        // ---------------------------------------------------------------------------------------
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
            if (type == typeof(Student))
            {
                var root = JsonConvert.DeserializeObject<StudentRoot>(json_string);
                List<Student> sf_list = new List<Student>();
                sf_list.AddRange(root.Student);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            throw new Exception("Unknow type");
        }

        // ---------------------------------------------------------------------------------------
        // recursively backtrack from the base dir until we find the directory we're looking for
        // ---------------------------------------------------------------------------------------
        private static string GetLocalJsonDirectory(string srch_dir, DirectoryInfo p1 = null)
        {
            if (p1 == null)
            {
                p1 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent;
                GetLocalJsonDirectory(srch_dir, p1);
            }
            if (p1.GetDirectories(srch_dir).Length > 0)
            {
                return p1.GetDirectories(srch_dir, SearchOption.AllDirectories)[0].FullName;
            }
            if (p1.Parent == null)
            {
                throw new Exception("Local Directory for JSON data not found: " + srch_dir);
            }

            return GetLocalJsonDirectory(srch_dir, p1.Parent);
        }


    }
}
