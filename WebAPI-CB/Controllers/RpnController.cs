using Microsoft.AspNetCore.Mvc;
using WebAPI_CB.Model;

namespace WebAPI_CB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RpnController : ControllerBase
    {
        private readonly IRpnServices rpnService;

        public RpnController(IRpnServices rpnService)
        {
            this.rpnService = rpnService;
        }

        [Route("op")]
        [HttpGet]
        public Task<IReadOnlyCollection<string>> GetOperands()
        {
            return rpnService.GetOperands(); ;
        }

        [Route("op/{op}/stack/{stack_id}")]
        [HttpPost]
        public Task ApplyOperands(string op, int stack_id)
        {
            return rpnService.ApplyOperands(op, stack_id);
        }

        [Route("stack")]
        [HttpPost]
        public Task<int> CreateStack()
        {
            return rpnService.CreateStack();
        }

        [Route("stack")]
        [HttpGet]
        public IReadOnlyCollection<RpnStack> GetRpnStacks()
        {
            return rpnService.GetRpnStacks();
        }

        [Route("stack/{stack_id}")]
        [HttpDelete]
        public Task DeleteStack(int stack_id)
        {
            return rpnService.DeleteStack(stack_id);
        }

        [Route("stack/{stack_id}")]
        [HttpPost]
        public Task AddValue(int value, int stack_id)
        {
            return rpnService.AddValue(value, stack_id);
        }

        [Route("stack/{stack_id}")]
        [HttpGet]
        public Task<RpnStack> GetStack(string stack_id)
        {
            return rpnService.GetStack(stack_id);
        }
    }
}