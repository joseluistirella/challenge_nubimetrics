using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MediatR;

using Service.Queries;

namespace ml.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            //_mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(string id)
        {
            ListUser query = new(id);
            List<User> result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost()]
        public async Task<ActionResult<User>> Post(CreateUser command)
        {
            if(command == null)
            {
                return BadRequest();                
            }

            User userCreated = await _mediator.Send(command);
            return  CreatedAtAction(nameof(Get), userCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(string id, UpdateUser command)
        {
            if  (
                    string.IsNullOrEmpty(id) || 
                    !id.Equals(command.Id)
                )
            {
                return BadRequest("El Id no coincide");
            }

            User updatedUser = await _mediator.Send(command);
            
            if (updatedUser == null)
                return NotFound($"El usuario con Id = {id.ToString()} no existe");

            return updatedUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(string id)
        {
            DeleteUser command = new(id);
            bool deletedUser = await _mediator.Send(command);

            if (!deletedUser)
            {
                return NotFound($"El usuario con Id = {id} no existe");
            }

            return Ok("Usuario eliminado");
        }

    }
}
