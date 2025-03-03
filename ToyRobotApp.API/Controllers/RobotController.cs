using Microsoft.AspNetCore.Mvc;
using ToyRobotApp.API.Interfaces;
using ToyRobotApp.API.Models;

namespace ToyRobotApp.API.Controllers
{
    [ApiController]
    [Route("api/robot")]
    public class RobotController : ControllerBase
    {
        #region Properties
        private readonly IRobotAppService _robotAppService;
        #endregion

        #region Constructor
        public RobotController(IRobotAppService robotAppService)
        {
            _robotAppService = robotAppService;
        }
        #endregion

        #region Actions
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadRequest request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Robot task starts
            //var tabletop = new TableTopService();
            //var robotService = new RobotService(tabletop);
            //var app = new Services.RobotAppService(robotService);

            try
            {
                var commands = await GetCommands(request);
                foreach (var command in commands)
                {
                    if (string.IsNullOrWhiteSpace(command)) continue;
                    //app.ProcessCommand(command);
                    _robotAppService.ProcessCommand(command);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Command file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Robot task ends

            // Return response
            return Ok(new
            {
                FileName = request.File.FileName,
                Size = request.File.Length,
                //LineCount = lineCount
            });
        }
        #endregion

        #region Private Methods
        private async Task<string[]> GetCommands(FileUploadRequest request)
        {
            string content;
            using (var reader = new StreamReader(request.File.OpenReadStream()))
            {
                content = await reader.ReadToEndAsync();
            }

            var commands = content.Split("\r\n");
            return commands;
        }
        #endregion
    }
}
