using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OELS.Core.Repositories;
using OELS.Core.Services;
using OELS.Repository;
using OELS.Repository.Repositories;
using OELS.Service.Services;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        options =>
        {
            options.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name);
        });
});
# region Authentication & Authorization
builder.Services.AddAuthentication(options =>
{
    // Schema dung de xac thuc user tu request
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // Schema dung khi request bi tu choi 401
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    // Schema mac dinh tong quat
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Co bat buoc HTTPS khong
    options.RequireHttpsMetadata = false;

    // Co luu token vao AuthenticationProperties khong
    options.SaveToken = true;

    // Quy tac Validate Jwt Token
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            // Co validate server phat hanh token khong
            ValidateIssuer = true,
            // Co validate client nhan token khong
            ValidateAudience = true,
            // Co kiem tra token co het han khong
            ValidateLifetime = true,
            // Co kiem tra chu ky token khong
            ValidateIssuerSigningKey = true,
            // Server phat hanh token hop le
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            // Audience hop le
            ValidAudience = builder.Configuration["JWT:Audience"],
            // Secret key dung verify chu ky
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        builder.Configuration["JWT:SecretKey"]!
                )),
            // Cho phep lech thoi gian nho
            ClockSkew = TimeSpan.Zero
        };
});

#endregion 

// Dependencies Injection Service
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseReviewRepository, CourseReviewRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonProgressRepository, LessonProgressRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IQuizAnswerRepository, QuizAnswerRepository>();
builder.Services.AddScoped<IQuizAttemptRepository, QuizAttemptRepository>();
builder.Services.AddScoped<IQuizOptionRepository, QuizOptionRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizQuestionRepository, QuizQuestionRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();