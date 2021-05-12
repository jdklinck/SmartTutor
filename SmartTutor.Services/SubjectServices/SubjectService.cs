using SmartTutor.Data;
using SmartTutor.Models.SubjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Services.SubjectServices
{
    public class SubjectService
    {
        private readonly Guid _userId;

        public SubjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSubject(SubjectCreate subjectCreate)
        {
            var entity = new Subject
            {
                OwnerId = _userId,
                Name = subjectCreate.Name,
                StudentId = subjectCreate.StudentId,
                TutorId = subjectCreate.TutorId,
                IsAdvanced = subjectCreate.IsAdvanced,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Subjects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SubjectListItem> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Subjects
                    .Where(s => s.OwnerId == _userId)
                    .Select(s => new SubjectListItem
                    {
                        SubjectId = s.SubjectId,
                        Name = s.Name,

                    }).ToArray();
                return query;
            }
        }

        public SubjectDetails Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Subjects
                    .SingleOrDefault(s => s.OwnerId == _userId && s.SubjectId == id);
                return new SubjectDetails
                {
                    SubjectId = query.SubjectId,
                    Name = query.Name,
                    IsAdvanced = query.IsAdvanced,
                    Student = query.Student,
                    Tutor = query.Tutor,
                };
            }
        }
        public bool UpdateSubject(SubjectEdit subjectEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldsubject =
                    ctx
                    .Subjects
                    .SingleOrDefault(s => s.OwnerId == _userId && s.SubjectId == subjectEdit.SubjectId);
                oldsubject.Name = subjectEdit.Name;
                oldsubject.IsAdvanced = subjectEdit.IsAdvanced;
                oldsubject.StudentId = subjectEdit.StudentId;
                oldsubject.TutorId = subjectEdit.TutorId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

