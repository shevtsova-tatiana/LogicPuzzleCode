using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject confirmPanel;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    [SerializeField] private Button continueButton;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button backButton2;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;


    [SerializeField] private Button levelOne;
    [SerializeField] private Button levelTwo;
    [SerializeField] private Button levelThree;
    [SerializeField] private Button levelFour;
    [SerializeField] private Button levelFive;
    [SerializeField] private Button levelSix;
    [SerializeField] private Button levelSeven;
    [SerializeField] private Button levelEight;
    [SerializeField] private Button levelNine;
    [SerializeField] private Button levelTen;
    [SerializeField] private Button levelEleven;
    [SerializeField] private Button levelTwelve;


    private void Awake()
    {
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        confirmPanel.SetActive(false);

        continueButton.onClick.AddListener(OnContinueButton);
        newGameButton.onClick.AddListener(OnNewGameButton);
        exitButton.onClick.AddListener(OnExitButton);
        settingsButton.onClick.AddListener(OnSettingsButton);
        backButton.onClick.AddListener(OnBackButton);
        backButton2.onClick.AddListener(OnBackButton);
        yesButton.onClick.AddListener(OnYesButton);
        noButton.onClick.AddListener(OnBackButton);

        levelOne.onClick.AddListener(OnLevelOne);
        levelTwo.onClick.AddListener(OnLevelTwo);
        levelThree.onClick.AddListener(OnLevelThree);
        levelFour.onClick.AddListener(OnLevelFour);
        levelFive.onClick.AddListener(OnLevelFive);
        levelSix.onClick.AddListener(OnLevelSix);
        levelSeven.onClick.AddListener(OnLevelSeven);
        levelEight.onClick.AddListener(OnLevelEight);
        levelNine.onClick.AddListener(OnLevelNine);
        levelTen.onClick.AddListener(OnLevelTen);
        levelEleven.onClick.AddListener(OnLevelEleven);
        levelTwelve.onClick.AddListener(OnLevelTwelve);
    }

    private void OnYesButton()
    {
        PlayerPrefs.DeleteAll();
        confirmPanel.SetActive(false);
        mainPanel.SetActive(true);
        SceneManager.LoadScene("Stage 1");
    }

    private void OnNewGameButton()
    {
        confirmPanel.SetActive(true);
    }


    private void OnBackButton()
    {
        mainPanel.SetActive(true);
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        confirmPanel.SetActive(false);
    }

    private void OnContinueButton()
    {
        mainPanel.SetActive(false);
        levelsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private void OnSettingsButton()
    {
        mainPanel.SetActive(false);
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnLevelOne()
    {
        SceneManager.LoadScene("Stage 1");
    }

    private void OnLevelTwo()
    {
        SceneManager.LoadScene("Stage 2");
    }

    private void OnLevelThree()
    {
        SceneManager.LoadScene("Stage 3");
    }

    private void OnLevelFour()
    {
        SceneManager.LoadScene("Stage 4");
    }

    private void OnLevelFive()
    {
        SceneManager.LoadScene("Stage 5");
    }

    private void OnLevelSix()
    {
        SceneManager.LoadScene("Stage 6");
    }

    private void OnLevelSeven()
    {
        SceneManager.LoadScene("Stage 7");
    }

    private void OnLevelEight()
    {
        SceneManager.LoadScene("Stage 8");
    }

    private void OnLevelNine()
    {
        SceneManager.LoadScene("Stage 9");
    }

    private void OnLevelTen()
    {
        SceneManager.LoadScene("Stage 10");
    }

    private void OnLevelEleven()
    {
        SceneManager.LoadScene("Stage 11");
    }

    private void OnLevelTwelve()
    {
        SceneManager.LoadScene("Stage 12");
    }

    private void OnExitButton()
    {
        Application.Quit();
    }
}