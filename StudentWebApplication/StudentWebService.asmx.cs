using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StudentWebApplication
{
    /// <summary>
    /// Summary description for StudentWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StudentWebService : System.Web.Services.WebService
    {
        public StudentWebService()
        {
            if (Session["studentList"] == null)
            {
                Session["studentList"] = new List<Student>
                {
                    new Student { Id = 1001, Name = "Ram", Age = 21 },
                    new Student { Id = 2001, Name = "Ayesha", Age = 25 },
                    new Student { Id = 1005, Name = "Rahul", Age = 20 }
                };
            }
            
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        List<Student> studentList = new List<Student>();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void AddStudent(int id, string name, int age)
        {
            Student student = new Student()
            {
                Id = id,
                Name = name,
                Age = age
            };
            studentList.Add(student);
            
        }

        [WebMethod]
        public List<Student> DisplayAllStudentDetails()
        {
            return (List<Student>)Session["studentList"];
        }

        [WebMethod]
        public Student GetStudentById(int studentId)
        {
            return studentList.Find(student => student.Id == studentId);
        }

        [WebMethod]
        public void UpdateStudentDetail(int id, string name, int age)
        {
            Student student=GetStudentById(id);
            if(student != null)
            {
                student.Name = name;
                student.Age = age;
            }
        }

        [WebMethod]
        public void RemoveStudent(int studentId)
        {
            Student student = GetStudentById(studentId);
            if(student != null)
            {
                studentList.Remove(student);
            }
        }

        public bool StudentExists(int studentId)
        {
            foreach(Student student in studentList)
            {
                if(student.Id == studentId)
                {
                    return true;
                }
                
            }
            return false;
        }

        public void UpdateStudentListInSession(List<Student> updatedStudentList)
        {
            Session["studentList"] = updatedStudentList;
        }

    }
}
