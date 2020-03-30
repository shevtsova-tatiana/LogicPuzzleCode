using UnityEngine;

public class LevelProgressScript : MonoBehaviour
{
    [SerializeField] private GameObject LeftStarDisabled;
    [SerializeField] private GameObject middleStarDisable;
    [SerializeField] private GameObject rightStarDisabled;
    [SerializeField] private GameObject leftStarEnabled;
    [SerializeField] private GameObject middleStarEnabled;
    [SerializeField] private GameObject rightStarEnabled;

    [SerializeField] private int levelId;

    private void Start()
    {
        int starsNum = PlayerPrefs.GetInt("Level" + levelId);
        switch (starsNum)
        {
            case 0:
                return;
            case 1:
                LeftStarDisabled.SetActive(false);
                leftStarEnabled.SetActive(true);
                break;
            case 2:
                LeftStarDisabled.SetActive(false);
                leftStarEnabled.SetActive(true);
                middleStarDisable.SetActive(false);
                middleStarEnabled.SetActive(true);
                break;
            case 3:
                LeftStarDisabled.SetActive(false);
                leftStarEnabled.SetActive(true);
                middleStarDisable.SetActive(false);
                middleStarEnabled.SetActive(true);
                rightStarDisabled.SetActive(false);
                rightStarEnabled.SetActive(true);
                break;
        }
    }
}