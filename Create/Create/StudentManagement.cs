using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create
{
    public class StudentManagement
    {
        public PM13897[] GetStudents()
        {
            var db = new OOPCSEntities();
            return db.PM13897.ToArray();
        }
        public PM13897 GetStudent(int id)
        {
            var db = new OOPCSEntities();
            return db.PM13897.Find(id);
        }
        public void CreateStudent(string code,string name,bool gender,string hometown)
        {
            var newStudent = new PM13897();
            newStudent.Name = name;
            newStudent.Gender = gender;
            newStudent.Home_town = hometown;

            var db = new OOPCSEntities();
            db.PM13897.Add(newStudent);
            db.SaveChanges();
        }
        public void UpdateStudent(int id,string code,string name,string hometown, bool gender)
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM13897.Find(id);
            oldStudent.Code = code;
            oldStudent.Name = name;
            oldStudent.Home_town = hometown;
            oldStudent.Gender = gender;
           
            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();
            var student = db.PM13897.Find(id);
            db.PM13897.Remove(student);
            db.SaveChanges();
        }
    }
}
