namespace Simulation
{
    public interface ISnapshot
    {
        SnapshotData TakeSnapshot();
        // void RollBackTo(SnapshotDataBase snapshotData); 
    }
}