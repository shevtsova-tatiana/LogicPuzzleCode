using UnityEngine;

public static class Profile
{
    
    [System.Serializable]
    public class LevelData
    {
        public int starsOnLevel;
    }

    private static LevelData levelData;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CheckData()
    {
        CheckLevelData();
    }

    private static void CheckLevelData()
    {
        if (levelData != null)
        {
            return;
        }

        levelData = GetData<LevelData>("LevelData");
    }

    private static T GetData<T>(string key) where T : new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }

        var data = new T();
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
        return data;
    }

    public static void Save( bool level = true)
    {

        if (level)
        {
            PlayerPrefs.SetString("LevelData", JsonUtility.ToJson(levelData));
        }
    }
    

    public static int StarsOnLevel
    {
        get => levelData.starsOnLevel;

        set
        {
            levelData.starsOnLevel = value;
            Save();
        }
    }

    public static void CheckLevelUpdate(int levelId, int currentStarsNum)
    {
        if (currentStarsNum > PlayerPrefs.GetInt("Level" + levelId))
        {
            PlayerPrefs.SetInt("Level" + levelId, currentStarsNum);
        }
    }
}