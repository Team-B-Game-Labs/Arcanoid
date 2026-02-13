using UnityEngine;

public class SecondaryBall : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    public int ballDamage = 1;

    public int bounceCounter = 0;

    Ball ball;
    Rigidbody rb;

    Vector3 lastVelocity;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        ball = FindAnyObjectByType<Ball>();
        Launch();
    }

    private void Update()
    {
        lastVelocity = rb.linearVelocity;
    }

    public void Launch()
    {
        

        float horizontalDir = Mathf.Sign(Random.Range(-100f, 100f));
       
        float verticalDir = Random.Range(-1f, 1f);

        

        Vector2 direction = new Vector2(horizontalDir, verticalDir);

       

        rb.AddForce(direction * speed, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        float ballSpeed = lastVelocity.magnitude;
        Vector3 ballDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.linearVelocity = ballDirection * Mathf.Max(ballSpeed, 0f);

        if (collision.gameObject.TryGetComponent<IBrick>(out IBrick interactable))
        {
            interactable.TakeDamage(ballDamage);
        }

        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            bounceCounter++;

            if (bounceCounter >= 4)
            {
                Destroy(gameObject);
            }
        }
    }
}
