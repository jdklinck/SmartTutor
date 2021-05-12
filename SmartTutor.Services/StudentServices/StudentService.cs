using SmartTutor.Data;
using SmartTutor.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Services.StudentServices
{
    public class StudentService
    {
        //Making a GUID to go into the constructor
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStudent(StudentCreate studentCreate)
        {
            var entity = new Student
            {
                OwnerId = _userId,
                FirstName = studentCreate.FirstName,
                LastName = studentCreate.LastName,
                FullName = $"{studentCreate.FirstName} {studentCreate.LastName}",
                Email = studentCreate.Email,
                Grade = studentCreate.Grade,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StudentListItem> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Students
                    .Where(s => s.OwnerId == _userId)
                    .Select(s => new StudentListItem
                    {
                        StudentId = s.StudentId,
                        FullName = s.FullName
                    }).ToArray();
                return query;
            }
        }

        public StudentDetails Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Students
                    .SingleOrDefault(s => s.OwnerId == _userId && s.StudentId == id);
                return new StudentDetails
                {
                    StudentId = query.StudentId,
                    FullName = query.FullName,
                    Email = query.Email,
                    Grade = query.Grade
                };
            }
        }

        public bool UpdateStudent(StudentEdit studentEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldstudent =
                    ctx
                    .Students
                    .SingleOrDefault(s => s.OwnerId == _userId && s.StudentId == studentEdit.StudentId);
                oldstudent.FirstName = studentEdit.FirstName;
                oldstudent.LastName = studentEdit.LastName;
                oldstudent.Email = studentEdit.Email;
                oldstudent.Grade = studentEdit.Grade;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student =
                    ctx
                    .Students
                    .SingleOrDefault(s => s.OwnerId == _userId && s.StudentId == id);
                ctx.Students.Remove(student);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
