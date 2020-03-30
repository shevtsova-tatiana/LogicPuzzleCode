using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
    }

}
