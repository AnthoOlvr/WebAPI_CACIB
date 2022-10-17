using WebAPI_CB.Model;

namespace WebAPI_CB.Controllers
{
    public class RpnServices : IRpnServices
    {
        private static List<RpnStack> CalculatorStacks = new List<RpnStack>();

        private static readonly IReadOnlyCollection<string> Operands = new[] { "+", "-", "*", "/" };

        /// <inheritdoc />
        public Task ApplyOperands(string op, int stack_id)
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

        /// <inheritdoc />
        public Task<IReadOnlyCollection<string>> GetOperands()
        {
            return Task.FromResult(Operands);
        }

        /// <inheritdoc />
        public Task<int> CreateStack()
        {
            var newStack = new RpnStack();

            CalculatorStacks.Add(newStack);

            return Task.FromResult(newStack.Id);
        }

        /// <inheritdoc />
        public IReadOnlyCollection<RpnStack> GetRpnStacks()
        { 
            return CalculatorStacks;
        }

        /// <inheritdoc />
        public Task DeleteStack(int stack_id)
        {
            var itemToRemove = CalculatorStacks.Single(x => x.Id == stack_id);
            CalculatorStacks.Remove(itemToRemove);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task AddValue(int value, int stack_id)
        {
            var stack = CalculatorStacks.Single(x => x.Id.Equals(stack_id));
            stack.Stack.Add(value);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<RpnStack> GetStack(string stack_id)
        {
            var stack = CalculatorStacks.Single(x => x.Id.Equals(stack_id));

            return Task.FromResult(stack);
        }
    }
}
