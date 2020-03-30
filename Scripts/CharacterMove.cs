using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private LayerMask ObstacleLayer;
    [SerializeField] private LayerMask WaterLayer;
    [SerializeField] private LayerMask WoodsLayer;
    [SerializeField] private LayerMask PitLayer;
    [SerializeField] private Swipe swipeControl;
    [SerializeField] private AudioSource audioSource;

    public Rigidbody2D rig;
    private Animator animator;
    private Vector3 destination;
    public bool isMoving = false;
    private Vector3 movement;
    public float speed = 2f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
            {
                startMovement(-1.26f, 0f);
                movement.x = -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
            {
                startMovement(1.26f, 0f);
                movement.x = 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
            {
                startMovement(0f, 1.26f);
                movement.y = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
            {
                startMovement(0f, -1.26f);
                movement.y = -1;
            }

            if (swipeControl.SwipeLeft && !isMoving)
            {
                startMovement(-1.26f, 0f);
                movement.x = -1;
            }
            else if (swipeControl.SwipeRight && !isMoving)
            {
                startMovement(1.26f, 0f);
                movement.x = 1;
            }
            else if (swipeControl.SwipeUp && !isMoving)
            {
                startMovement(0f, 1.26f);
                movement.y = 1;
            }
            else if (swipeControl.SwipeDown && !isMoving)
            {
                startMovement(0f, -1.26f);
                movement.y = -1;
            }

            if (isMoving)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                if (transform.position.Equals(destination))
                {
                    movement = Vector3.zero;
                    isMoving = false;
                    animator.SetBool("IsMoving", false);
                }
                else
                {
                    animator.SetFloat("Horizontal", movement.x);
                    animator.SetFloat("Vertical", movement.y);
                    animator.SetBool("IsMoving", true);
                    MoveCharacter();
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    private void startMovement(float x, float y)
    {
        destination = new Vector3(transform.position.x + x, transform.position.y + y, 0f);
        var offset = new Vector3(x, y, 0f);
        if (!moveToBarrier(offset) && !moveOverBounds(destination.x, destination.y) && !moveWoodsToBarrier(offset))
        {
            isMoving = true;
        }
    }

    private bool moveToBarrier(Vector3 offset)
    {
        return Physics2D.OverlapCircle(rig.transform.position + offset, 0.2f, ObstacleLayer) ||
               Physics2D.OverlapCircle(rig.transform.position + offset, 0.2f, WaterLayer) ||
               Physics2D.OverlapCircle(rig.transform.position + offset, 0.2f, PitLayer);
    }

    private bool moveOverBounds(float x, float y)
    {
        return x > rightBound.transform.position.x ||
               x < leftBound.transform.position.x ||
               y > rightBound.transform.position.y ||
               y < leftBound.transform.position.y;
    }

    private bool moveWoodsToBarrier(Vector3 offset)
    {
        var woodsDestination = rig.transform.position + offset + offset;
        return Physics2D.OverlapCircle(rig.transform.position + offset, 0.2f, WoodsLayer) &&
               (Physics2D.OverlapCircle(woodsDestination, 0.2f, ObstacleLayer) ||
                Physics2D.OverlapCircle(woodsDestination, 0.2f, WoodsLayer) ||
                moveOverBounds(woodsDestination.x, woodsDestination.y));
    }

    private void MoveCharacter()
    {
        rig.transform.position = Vector3.MoveTowards(transform.position,
            destination, speed * Time.deltaTime);
    }
}