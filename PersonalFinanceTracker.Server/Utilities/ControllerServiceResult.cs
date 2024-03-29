namespace PersonalFinanceTracker.TransactionsRestApi.Utilities
{
    public class ControllerServiceResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ControllerServiceResult<T> FromSuccess(T data) =>
            new ControllerServiceResult<T> { Success = true, Data = data };

        public static ControllerServiceResult<T> FromError(string message) =>
            new ControllerServiceResult<T> { Success = false, Message = message };
    }
}
