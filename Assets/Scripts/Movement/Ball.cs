using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 10.0f;
    [SerializeField] GameObject launchVector;

    Rigidbody rb;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    public void Launch()
    {
        float horizontalDir = Mathf.Sign(Random.Range(-100f, 100f));

        float verticalDir = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(horizontalDir, verticalDir);

        rb.AddForce(direction * force);
        Debug.Log("Launch");
    }


//    IEnumerator LaunchDirection()
//    {
//        launchVector.SetActive(true);
//        while (Input.GetKey(KeyCode.Space))
//        {
//            launchVector.transform.Rotate

//                }

//    }
}
