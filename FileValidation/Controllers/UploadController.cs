using Microsoft.AspNetCore.Mvc;

namespace FileValidation.Controllers
{
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
