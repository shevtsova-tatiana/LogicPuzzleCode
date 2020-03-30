public class SingletonObject<T> where T : new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance !=null)
            {
                return instance;
            }

            instance = new T();
            return instance;
        }
    }

}