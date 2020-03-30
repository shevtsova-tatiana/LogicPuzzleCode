using System.Collections;
using UnityEngine;

public class WoodsScript : MonoBehaviour
{
    [SerializeField] private GameObject waterPoofEffect;
    [SerializeField] private LayerMask ObstacleLayer;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform leftBound;
    [SerializeField] private SoundManager soundManager;
    public Vector3 destinationPos;

    private void Start()
    {
        destinationPos = transform.position;
    }

    private void Update()
    {
        if (transform.position != destinationPos)
        {
            Movement(destinationPos);
        }
    }

    private bool moveToBarrier(Vector3 position)
    {
        return Physics2D.OverlapCircle(position, 0.2f, ObstacleLayer);
    }

    private bool moveOverBounds(float x, float y)
    {
        return x > rightBound.transform.position.x ||
               x < leftBound.transform.position.x ||
               y > rightBound.transform.position.y ||
               y < leftBound.transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<CharacterMove>();
        if (!player)
        {
            return;
        }
        var transformPosition = transform.position;
        var contact = other.contacts[0];
        var direction = transformPosition - new Vector3(contact.point.x, contact.point.y, 0f);

        if (Mathf.Abs(direction.x) > 0.2f)
        {
            if (direction.x > 0.2f)
            {
                transformPosition += new Vector3(1.26f, 0f, 0f);
            }
            else if (direction.x < -0.2f)
            {
                transformPosition += new Vector3(-1.26f, 0f, 0f);
            }
        }
        else if (Mathf.Abs(direction.y) > 0.2f)
        {
            if (direction.y > 0.2f)
            {
                transformPosition += new Vector3(0f, 1.26f, 0f);
            }
            else if (direction.y < -0.2f)
            {
                transformPosition += new Vector3(0f, -1.26f, 0f);
            }
        }

        if (!moveToBarrier(transformPosition) && !moveOverBounds(transformPosition.x, transformPosition.y))
            destinationPos = transformPosition;
    }

    private void Movement(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position,
            destination, 5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var water = other.GetComponent<WaterScript>();
        var pit = other.GetComponent<Dirt>();
        if (water)
        {
            soundManager.bridgeSound();
            var waterPosition = water.transform.position;

            Instantiate(waterPoofEffect, waterPosition, Quaternion.identity);
            Destroy(gameObject);
            water.gameObject.SetActive(false);
            if (water.bridge.name == "BridgeHorizontal (1)")
            {
                waterPosition.y += 0.20f;
            }

            var newBridge = Instantiate(water.bridge, waterPosition, Quaternion.identity);

            newBridge.transform.SetParent(water.transform.parent);
            newBridge.SetActive(true);
        }

        if (pit)
        {
            if (pit.isFirstTime)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
    
}