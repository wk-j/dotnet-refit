using Microsoft.Extensions.DependencyInjection;
using Refit;

var collection = new ServiceCollection();
collection.AddRefitClient<IStudentClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5126"));

var service = collection.BuildServiceProvider();
var studentClient = service.GetService<IStudentClient>()!;

var students = await studentClient.GetStudents()!;
foreach (var item in students.Content) {
    Console.WriteLine($"Student (Name={item.Name}, Id={item.Id})");
}

class Student {
    public string Name { set; get; } = string.Empty;
    public int Id { set; get; }
}

interface IStudentClient {
    [Get("/api/student/get-students")]
    public Task<ApiResponse<List<Student>>> GetStudents();
}