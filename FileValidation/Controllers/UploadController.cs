using Microsoft.AspNetCore.Mvc;

namespace FileValidation.Controllers
{
    /// <summary>
    /// References: 
    /// https://code-maze.com/aspnetcore-how-to-validate-file-upload-extensions/
    /// https://code-maze.com/aspnetcore-validate-uploaded-file/
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        public IActionResult Upload(IFormFile file)
        {
            Result result = FileValidator.Validate(file);

            return result.Acceptable ? Ok(result) : BadRequest(result);
        }
    }
}
