using OELS.Core.Repositories;
using OELS.Core.UnitOfWorks;
using OELS.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Lazy init - chi tao repository khi can dung
        private IUserRepository? _users;
        private ICourseRepository? _courses;
        private ICourseReviewRepository? _courseReviews;
        private ICertificateRepository? _certificates;
        private IEnrollmentRepository? _enrollments;
        private ILanguageRepository? _languages;
        private ILessonProgressRepository? _lessonProgresses;
        private ILessonRepository? _lessons;
        private IPaymentRepository? _payments;
        private IQuizAttemptRepository? _quizAttempts;
        private IQuizAnswerRepository? _quizAnswers;
        private IQuizOptionRepository? _quizOptions;
        private IQuizQuestionRepository? _quizQuestions;
        private IQuizRepository? _quizzes;
        private ISectionRepository? _sections;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository 
            => _users ??= new UserRepository(_context);

        public ICourseRepository CourseRepository
            => _courses ??= new CourseRepository(_context);

        public ICertificateRepository CertificateRepository
            => _certificates ??= new CertificateRepository(_context);

        public IEnrollmentRepository EnrollmentRepository
            => _enrollments ??= new EnrollmentRepository(_context);

        public ICourseReviewRepository CourseReviewRepository
            => _courseReviews ??= new CourseReviewRepository(_context);

        public ILanguageRepository LanguageRepository
            => _languages ??= new LanguageRepository(_context);

        public ILessonProgressRepository LessonProgressRepository
            => _lessonProgresses ??= new LessonProgressRepository(_context);

        public ILessonRepository LessonRepository
            => _lessons ??= new LessonRepository(_context);

        public IPaymentRepository PaymentsRepository
            => _payments ??= new PaymentRepository(_context);

        public IQuizAnswerRepository QuizAnswerRepository
            => _quizAnswers ??= new QuizAnswerRepository(_context);

        public IQuizAttemptRepository QuizAttemptRepository
            => _quizAttempts ??= new QuizAttemptRepository(_context);

        public IQuizOptionRepository QuizOptionRepository
            => _quizOptions ??= new QuizOptionRepository(_context);

        public IQuizQuestionRepository QuizQuestionRepository
            => _quizQuestions ??= new QuizQuestionRepository(_context);

        public IQuizRepository QuizRepository
            => _quizzes ??= new QuizRepository(_context);

        public ISectionRepository SectionRepository
            => _sections ??= new SectionRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
