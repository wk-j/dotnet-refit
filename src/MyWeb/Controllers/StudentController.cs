using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase {

    public record Student(int Id, string Name);

    [HttpGet("get-students")]
    public List<Student> GetStudents() {
        return new List<Student> {
            new Student(1, "wk"),
            new Student(1, "jw"),
        };
    }

}