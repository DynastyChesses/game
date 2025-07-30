namespace HotUpdate.osP1.Save
{
    public interface IPlayerSave
    {
        public void OnLoad();
        public void OnUpdate(UpdateTimeInfo time);

        public void OnSave();
    }
}