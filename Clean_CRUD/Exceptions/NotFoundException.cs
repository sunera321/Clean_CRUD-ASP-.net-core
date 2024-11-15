namespace Clean_CRUD.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public static NotFoundException Create<T>(int id)
        {
            return new NotFoundException($"{typeof(T).Name} with id {id} was not found.");
        }
    }
}
