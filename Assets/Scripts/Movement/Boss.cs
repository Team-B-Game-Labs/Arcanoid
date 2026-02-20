using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour               //Simone
{
    public static Boss instance;

    [SerializeField] int maxHp;
    public float currentHp;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject secondaryBall;
    [SerializeField] GameObject energy;
    float timerBullet;
    float timerBall;

    Rigidbody rb;
    SpriteRenderer spriteRenderer;
    bool energy1 = true;
    bool energy2 = true;
    bool energy3 = true;
    bool energy4 = true;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        timerBullet = 0;
        timerBall = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PlayerMovement.instance.transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
        currentHp = maxHp;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            TakeDamage();
            return;
        }

    }


    private void Update()
    {
        if (GameManager.instance.status != GameStatus.GameRunning) return;
        timerBullet += Time.deltaTime;
        timerBall += Time.deltaTime;

        if (timerBullet >= 12)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, -0.3f), transform.rotation);
            timerBullet = 0;
        }

        if (maxHp / currentHp <= 2)
        {
            timerBullet += Time.deltaTime;
        }

        if (timerBall >= 15)
        {
            Instantiate(secondaryBall, new Vector3(transform.position.x, transform.position.y, -0.3f), transform.rotation);
            Instantiate(secondaryBall, new Vector3(transform.position.x, transform.position.y, -0.3f), transform.rotation);
            timerBall = 0;
        }

        EnergySpawn();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.timer >= 0.0001f)
        {
            GameManager.instance.timer = 0f;
        }
    }


    private void TakeDamage()
    {
        currentHp -= Ball.instance.ballDamage;

        StartCoroutine(DamageEffect());

    }

    IEnumerator DamageEffect()
    {
        Debug.Log("colore");
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.1f);

    }

    private void EnergySpawn()
    {
        

        if (currentHp <= 120 && energy1)
        {
            Instantiate(energy, transform);
            Instantiate(energy, transform);
            energy1 = false;
            return;
        }
        if (currentHp <= 90 && energy2)
        {
            Instantiate(energy, transform);
            Instantiate(energy, transform);
            energy2 = false;
            return;
        }
        if (currentHp <= 60 && energy3)
        {
            Instantiate(energy, transform);
            Instantiate(energy, transform);
            energy3 = false;
            return;
        }
        if (currentHp <= 30 && energy4)
        {
            Instantiate(energy, transform);
            Instantiate(energy, transform);
            energy4 = false;
            return;
        }
    }

}
