using WebAPI_CB.Model;

namespace WebAPI_CB.Controllers
{
    public interface IRpnServices
    {
        /// <summary>
        /// Get all available operands
        /// </summary>
        /// <returns>declared operands</returns>
        public Task ApplyOperands(string op, int stack_id);

        /// <summary>
        /// ApplyOperand to stack
        /// </summary>
        /// <param name="operand"></param>
        /// <param name="stackId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Task<IReadOnlyCollection<string>> GetOperands();

        /// <summary>
        /// Create a new stack
        /// </summary>
        /// <returns></returns>
        public Task<int> CreateStack();

        /// <summary>
        /// List created stacks
        /// </summary>
        /// <returns>All the stack</returns>
        public IReadOnlyCollection<RpnStack> GetRpnStacks();

        /// <summary>
        /// Delete a stack
        /// </summary>
        /// <param name="id">Id of the stack to delete</param>
        /// <returns></returns>
        public Task DeleteStack(int stack_id);

        /// <summary>
        /// Add a new value in the stack
        /// </summary>
        /// <param name="value">value to be inserted</param>
        /// <param name="stack_id"></param>
        /// <returns></returns>
        public Task AddValue(int value, int stack_id);

        /// <summary>
        /// get a stack according to an Id
        /// </summary>
        /// <param name="id">Id of the stack to retrieve</param>
        /// <returns></returns>
        public Task<RpnStack> GetStack(string stack_id);
    }
}
