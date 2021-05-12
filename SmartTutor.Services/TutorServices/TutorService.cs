using SmartTutor.Data;
using SmartTutor.Models.TutorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTutor.Services.TutorServices
{
    public class TutorService
    {
        private readonly Guid _userId;

        public TutorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTutor(TutorCreate tutorCreate)
        {
            var entity = new Tutor
            {
                OwnerId = _userId,
                FirstName = tutorCreate.FirstName,
                LastName = tutorCreate.LastName,
                Email = tutorCreate.Email,
                Rate = tutorCreate.Rate,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tutors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TutorListItem> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Tutors
                    .Where(t => t.OwnerId == _userId)
                    .Select(t => new TutorListItem
                    {
                        TutorId = t.TutorId,
                        TutorName = $"{t.FirstName} {t.LastName}"
                    }).ToArray();
                return query;
            }
        }

        public TutorDetails Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Tutors
                    .SingleOrDefault(s => s.OwnerId == _userId && s.TutorId == id);
                return new TutorDetails
                {
                    TutorId = query.TutorId,
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    Email = query.Email,
                    Rate = query.Rate
                };
            }
        }

        public bool UpdateTutor(TutorEdit tutorEdit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldtutor =
                    ctx
                    .Tutors
                    .SingleOrDefault(s => s.OwnerId == _userId && s.TutorId == tutorEdit.TutorId);
                oldtutor.FirstName = tutorEdit.FirstName;
                oldtutor.LastName = tutorEdit.LastName;
                oldtutor.Email = tutorEdit.Email;
                oldtutor.Rate = tutorEdit.Rate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTutor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tutor =
                    ctx
                    .Tutors
                    .SingleOrDefault(s => s.OwnerId == _userId && s.TutorId == id);
                ctx.Tutors.Remove(tutor);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
