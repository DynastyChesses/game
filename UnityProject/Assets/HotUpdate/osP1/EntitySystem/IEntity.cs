namespace HotUpdate.osP1.EntitySystem
{
    public interface IEntity
    {
        public void Start();
        public void Update(UpdateTimeInfo updateTimeInfo);
    }
}