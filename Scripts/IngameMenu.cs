using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button backButton2;
    [SerializeField] private Button refreshButton;

    [Header("Level Complete Panel")]
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject gridGameObject;

    [SerializeField] private Button refreshButton2;
    [SerializeField] private Button backButton3;
    [SerializeField] private GameObject activeStar1;
    [SerializeField] private GameObject activeStar2;
    [SerializeField] private GameObject activeStar3;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundlider.value = PlayerPrefs.GetFloat("soundVolume");
        
        settingsPanel.SetActive(false);
        activeStar1.SetActive(false);
        activeStar2.SetActive(false);
        activeStar3.SetActive(false);
        levelCompletePanel.SetActive(false);

        settingsButton.onClick.AddListener(OnSettingsButton);
        backButton.onClick.AddListener(OnBackButton1);
        backButton2.onClick.AddListener(OnBackButton2);
        refreshButton.onClick.AddListener(OnRefreshButton);

        backButton3.onClick.AddListener(OnBackButton2);
        playButton.onClick.AddListener(OnPlayButton);
        refreshButton2.onClick.AddListener(OnRefreshButton);
    }

    
    private void OnRefreshButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSettingsButton()
    {
        Time.timeScale = 0f;
        settingsPanel.SetActive(true);
    }

    private void OnBackButton1()
    {
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
        PlayerPrefs.SetFloat("soundVolume", soundlider.value);
    }

    private void OnBackButton2()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowResults(int starsCollected)
    {
        gridGameObject.SetActive(false);

        if (starsCollected == 1)
        {
            activeStar1.SetActive(true);

        }

        if (starsCollected == 2)
        {
            activeStar1.SetActive(true);
            activeStar2.SetActive(true);

        }

        if (starsCollected == 3)
        {
            activeStar1.SetActive(true);
            activeStar2.SetActive(true);
            activeStar3.SetActive(true);
        }
        
        levelCompletePanel.SetActive(true);

        
    }
}