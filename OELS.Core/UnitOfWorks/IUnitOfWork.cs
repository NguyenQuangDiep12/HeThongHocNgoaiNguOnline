using OELS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        // Cac Repository truy cap qua day
        IUserRepository UserRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICertificateRepository CertificateRepository { get; }
        IEnrollmentRepository EnrollmentRepository { get; }
        ICourseReviewRepository CourseReviewRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        ILessonProgressRepository LessonProgressRepository { get; }
        ILessonRepository LessonRepository { get; }
        IPaymentRepository PaymentsRepository { get; }
        IQuizAnswerRepository QuizAnswerRepository { get; }
        IQuizAttemptRepository QuizAttemptRepository { get; }
        IQuizOptionRepository QuizOptionRepository { get; }
        IQuizQuestionRepository QuizQuestionRepository { get; }
        IQuizRepository QuizRepository { get; }
        ISectionRepository SectionRepository { get; }


        int Commit();
        Task<int> CommitAsync();
    }
}
