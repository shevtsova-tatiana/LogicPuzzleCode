using UnityEngine;

public class StarScript : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMove>();
        if (!player)
        {
            return;
        }

        soundManager.starSound();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameController.Instance.StarsOnLevel += 1;
    }
}