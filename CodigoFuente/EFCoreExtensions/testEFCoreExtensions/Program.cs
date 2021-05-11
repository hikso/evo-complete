using EFCoreExtensions.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data.Common;
using testEFCoreExtensions.Context;
using testEFCoreExtensions.Model;

namespace testEFCoreExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                List<Student> listStudents = context.LoadSPAutoMapper<Student>("spLoadStudentsWithCourse");

                Console.WriteLine(listStudents.Count);

                List<StudentsWithCourse> listStudentsWithCourse = context.LoadSPAutoMapper<StudentsWithCourse>("spLoadStudentsWithCourse");

                Console.WriteLine(listStudentsWithCourse.Count);

                List<CustomStudents> listCustomStudents = context.LoadSPCustomMapper("spLoadStudentsWithCourse", customStudentMapper);

                Console.WriteLine(listCustomStudents.Count);

                object nRecs = context.LoadSPScalar("spCountStudents");

                Console.WriteLine(nRecs.ToString());
            }
        }

        static CustomStudents customStudentMapper(DbDataReader reader)
        {
            CustomStudents c = null;

            if (reader != null)
            {
                c = new CustomStudents();

                c.Id = int.Parse(reader["StudentId"].ToString());
                c.Nombre = reader["StudentName"].ToString();
                c.Curso = reader["CourseName"].ToString();
            }

            return c;
        }
    }
}
