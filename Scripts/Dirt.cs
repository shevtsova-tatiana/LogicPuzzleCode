using UnityEngine;

public class Dirt : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    public GameObject road;
    public GameObject pit;
    public bool isFirstTime = true;

    // Start is called before the first frame update


    void Start()
    {
        road.SetActive(true);
        pit.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMove>();
        if (!isFirstTime)
        {
            var woods = other.GetComponent<WoodsScript>();
            if (!woods)
            {
                return;
            }
            
            soundManager.roadSound();
            pit.SetActive(false);
            road.SetActive(true);
            isFirstTime = true;
            return;
        }

        if (!player)
        {
            return;
        }

        isFirstTime = false;
        road.SetActive(false);
        pit.SetActive(true);
        soundManager.dirtSound();
    }
}