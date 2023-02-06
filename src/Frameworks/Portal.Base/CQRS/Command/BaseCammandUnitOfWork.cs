namespace Portal.Base.CQRS.Command;

public interface BaseCammandUnitOfWork
{
    // <summary>
    /// If you need to control transactions, this method is used to start the transaction.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// In case of manual transaction control, this method is used to successfully end the transaction.
    /// </summary>
    void CommitTransaction();

    /// <summary>
    /// If an error occurs in the processes, this method is used to return the changes.
    /// </summary>
    void RollbackTransaction();

    /// <summary>
    /// This method is used to confirm the transaction that was created automatically by the system.
    /// </summary>
    /// <returns></returns>
    int Commit();

    /// <summary>
    /// This method is used to confirm the transaction that was created automatically by the system.
    /// </summary>
    /// <returns></returns>
    Task<int> CommitAsync();
}
