using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private IngameMenu ingameMenu;
    private void Start()
    {
        GameController.Instance.StarsOnLevel = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMove>();
        if (!player)
        {
            return;
        }
        
        ingameMenu.ShowResults(Profile.StarsOnLevel);
        Profile.CheckLevelUpdate(SceneManager.GetActiveScene().buildIndex, Profile.StarsOnLevel);
    }
}
