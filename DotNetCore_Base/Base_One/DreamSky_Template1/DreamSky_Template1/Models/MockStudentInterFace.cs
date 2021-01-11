using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamSky_Template1.Models
{
    public class MockStudentInterFace:IStudentInterface
    {
        private List<Student> _student;

        public MockStudentInterFace()
        {
            _student = new List<Student> {
                new Student() { Id=1,Name="Tom",ClassName="202001119",Email="11@qq.com"},
                new Student() { Id=1,Name="Jeck",ClassName="202001119",Email="11@qq.com"},
                new Student() { Id=1,Name="Jone",ClassName="202001119",Email="11@qq.com"},
                new Student() { Id=1,Name="Bob",ClassName="202001119",Email="11@qq.com"}
            };
        }

        public Student GetStudent(int Id)
        {
            return _student.FirstOrDefault(a=> a.Id == Id);
        }
    }
}
