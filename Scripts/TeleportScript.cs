using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Transform targetLocation;
    [SerializeField] private CharacterMove playerController;
    public bool isFirstTimeUsed;

    private void Start()
    {
        isFirstTimeUsed = true;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMove>();
        if (!player)
        {
            Destroy(other.gameObject);
        }

        if (isFirstTimeUsed)
        {
            soundManager.teleportSound();
            if (!playerController.isMoving)
            {
                var targetScript = targetLocation.gameObject.GetComponent<TeleportScript>();
                targetScript.isFirstTimeUsed = false;
                player.rig.transform.position = new Vector3(targetLocation.position.x, targetLocation.position.y,
                    targetLocation.position.z);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isFirstTimeUsed = true;
    }
}