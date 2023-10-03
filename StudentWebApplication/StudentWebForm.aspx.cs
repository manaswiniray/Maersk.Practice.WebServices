using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebApplication
{
    public partial class StudentWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labelMessage.Text = "Hello Welcome to The Student Portal! \n First Loading Time: " + DateTime.Now.ToLongTimeString();
            }
            else
            {
                labelMessage.Text = "Post Back At: " + DateTime.Now.ToLongTimeString();
            }
        }

        protected void addStudent_Click(object sender, EventArgs e)
        {
            StudentWebService studentWebService = new StudentWebService();
            List<StudentWebService.Student> students = studentWebService.DisplayAllStudentDetails().ToList();

            students.Add(new StudentWebService.Student
            {
                Id = int.Parse(textId.Text),
                Name = textName.Text,
                Age = int.Parse(textAge.Text),
            });

            studentWebService.UpdateStudentListInSession(students);
            labelMessage.Text = "Student Added Successfully";

            // studentWebService.AddStudent(int.Parse(textId.Text),textName.Text,int.Parse(textAge.Text));


        }

        protected void getStudentById_Click(Object sender, EventArgs e)
        {
            StudentWebService studentWebService = new StudentWebService();
            int studentId = int.Parse(textId.Text);

            List<StudentWebService.Student> studentList = studentWebService.DisplayAllStudentDetails().ToList();

            StudentWebService.Student studentToFind = studentList.FirstOrDefault(student => student.Id == studentId);

            if (studentToFind != null)
            {
                labelMessage.Text = $"Student Id: {studentToFind.Id}, Student Name: {studentToFind.Name}, Student Age: {studentToFind.Age}";
            }
            else
            {
                labelMessage.Text = "Student Not found";
            }
        }

        protected void updateStudent_Click(Object sender, EventArgs e)
        {
            StudentWebService studentWebService=new StudentWebService();
            int studentId = int.Parse(textId.Text);

            List<StudentWebService.Student> studentList = studentWebService.DisplayAllStudentDetails().ToList();

            StudentWebService.Student studentToUpdate = studentList.FirstOrDefault(student => student.Id == studentId);

            if (studentToUpdate!=null)
            {
                studentToUpdate.Name = textName.Text;
                studentToUpdate.Age = int.Parse(textAge.Text);

                studentWebService.UpdateStudentListInSession(studentList);

                labelMessage.Text = "Student Updated Successfully";
            }
            else
            {
                labelMessage.Text = "Student Not Found";
            }
        }

        
        protected void getAllStudents_Click(Object sender, EventArgs e)
        {
            StudentWebService studentWebService = new StudentWebService();

            List<StudentWebService.Student> studentList = studentWebService.DisplayAllStudentDetails().ToList();
            
            if(studentList!=null && studentList.Count > 0)
            {
                gridView.DataSource = studentList;
                gridView.DataBind();
            }
            else
            {
                labelMessage.Text = "No Student Found";
            }
            
        }

        protected void removeStudent_Click(Object sender, EventArgs e)
        {
            StudentWebService studentWebService = new StudentWebService();
            int studentId=int.Parse(textId.Text);

            List<StudentWebService.Student> studentList = studentWebService.DisplayAllStudentDetails().ToList();

            StudentWebService.Student studentToRemove = studentList.Find(student => student.Id == studentId);

            if (studentToRemove != null)
            {
                studentList.Remove(studentToRemove);
                studentWebService.UpdateStudentListInSession(studentList);
                labelMessage.Text = "Student Deleted Successfully";
            }
            
            else
            {
                labelMessage.Text = "Student Not Exist";
            }

        }

        
    }
}