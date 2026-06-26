public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if(database.DbState != Database.State.Closed)
        {
            throw new InvalidOperationException();
        }
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        try 
        {
            if (database.DbState != Database.State.TransactionStarted) 
            {
                throw new InvalidOperationException();
            }
            database.Write(data);
        }
        catch(Exception e)
        {
            Dispose();
        }
    }

    public void Commit()
    {
        try 
        {
            if (database.DbState != Database.State.DataWritten) { throw new InvalidOperationException(); }
            database.EndTransaction();
        } 
        catch(Exception e)
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
