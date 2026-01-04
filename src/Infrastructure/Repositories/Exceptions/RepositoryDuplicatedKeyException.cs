namespace Infrastructure.Repositories.Exceptions;

public class RepositoryDuplicatedKeyException : Exception
{
    private const string DEFAULT_MESSAGE = "The repository already contains an entity with the same key.";

    public RepositoryDuplicatedKeyException() : base(DEFAULT_MESSAGE)
    {
    }
}
