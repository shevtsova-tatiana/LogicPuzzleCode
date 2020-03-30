public class GameController : SingletonObject<GameController>
{
    public int StarsOnLevel
    {
        get => Profile.StarsOnLevel;
        set
        {
            Profile.StarsOnLevel = value;
            Profile.Save();
        }
    }
}