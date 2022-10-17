using Microsoft.AspNetCore.Mvc;
using WebAPI_CB.Model;

namespace WebAPI_CB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RpnController : ControllerBase
    {
        private static List<RpnStack> CalculatorStacks = new List<RpnStack>();

        private static readonly IReadOnlyCollection<string> Operands = new[] { "+", "-", "*", "/" };

        public RpnController()
        {
        }

        /// <summary>
        /// Get all available operands
        /// </summary>
        /// <returns>declared operands</returns>
        [Route("op")]
        [HttpGet]
        public IReadOnlyCollection<string> GetOperands()
        {
            return Operands;
        }


        /// <summary>
        /// ApplyOperand to stack
        /// </summary>
        /// <param name="operand"></param>
        /// <param name="stackId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        [Route("op/{op}/stack/{stack_id}")]
        [HttpPost]
        public Task ApplyOperands(string op, string stack_id)
        {
            if (!CalculatorStacks.Exists(x => x.Id.Equals(stack_id)))
            {
                throw new ArgumentOutOfRangeException();
            }
            var stack = CalculatorStacks.Single(x => x.Id.Equals(stack_id));

            if (!string.IsNullOrEmpty(op) && Operands.Contains(op))
            {
                switch (op)
                {
                    case "+":
                        int result1 = stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        result1 += stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        stack.Stack.Add(result1);
                        break;
                    case "-":
                        int result2 = stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        result2 -= stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        stack.Stack.Add(result2);
                        break;
                    case "*":
                        int result3 = stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        result3 *= stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        stack.Stack.Add(result3);
                        break;
                    case "/":
                        int result4 = stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        result4 /= stack.Stack.Last();
                        stack.Stack.RemoveAt(stack.Stack.Last());
                        stack.Stack.Add(result4);
                        break;
                }
            }
            else
            {
                throw new ArgumentException("invalid argument {0}", op);
            }

            return Task.CompletedTask;
        }

        
        /// <summary>
        /// Create a new stack
        /// </summary>
        /// <returns></returns>
        [Route("stack")]
        [HttpPost]
        public Task<int> CreateStack()
        {
            var newStack = new RpnStack();

            CalculatorStacks.Add(newStack);

            return Task.FromResult(newStack.Id);
        }

        /// <summary>
        /// List created stacks
        /// </summary>
        /// <returns>All the stack</returns>
        [Route("stack")]
        [HttpGet]
        public IReadOnlyCollection<RpnStack> GetRpnStacks()
        {
            return CalculatorStacks;
        }

        /// <summary>
        /// Delete a stack
        /// </summary>
        /// <param name="id">Id of the stack to delete</param>
        /// <returns></returns>
        [Route("stack/{stack_id}")]
        [HttpDelete]
        public Task DeleteStack(int stack_id)
        {
            var itemToRemove = CalculatorStacks.Single(x => x.Id == stack_id);
            CalculatorStacks.Remove(itemToRemove);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Add a new value in the stack
        /// </summary>
        /// <param name="value">value to be inserted</param>
        /// <param name="stack_id"></param>
        /// <returns></returns>
        [Route("stack/{stack_id}")]
        [HttpPost]
        public Task AddValue(int value, int stack_id)
        {
            var stack = CalculatorStacks.Single(x => x.Id.Equals(stack_id));
            stack.Stack.Add(value);

            return Task.CompletedTask;
        }

        /// <summary>
        /// get a stack according to an Id
        /// </summary>
        /// <param name="id">Id of the stack to retrieve</param>
        /// <returns></returns>
        [Route("stack/{stack_id}")]
        [HttpGet]
        public Task<RpnStack> GetStack(string stack_id)
        {
            var stack = CalculatorStacks.Single(x => x.Id.Equals(stack_id));

            return Task.FromResult(stack);
        }
    }
}