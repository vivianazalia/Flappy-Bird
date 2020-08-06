using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float upForce = 100;
    [SerializeField] private float speedBullet = 100;
    [SerializeField] private int score;
    [SerializeField] private bool isDead;
    [SerializeField] private Text scoreText;

    [Header("Event")]
    [SerializeField] private UnityEvent OnJump;
    [SerializeField] private UnityEvent OnDead;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private UnityEvent OnShoot;

    private Rigidbody2D birdRb;
    private Animator birdFlapAnim;

    void Start()
    {
        birdRb = GetComponent<Rigidbody2D>();
        birdFlapAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(!isDead && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Burung loncat
            Jump();
        }

        if(!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            if(SceneLoader.CurrentScene() == 1)
            {
                //Burung menembak
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D bulletrb = newBullet.GetComponent<Rigidbody2D>();
        Vector2 distance = new Vector2(newBullet.gameObject.transform.position.x + 100, 0);
        bulletrb.AddForce(distance * speedBullet * Time.deltaTime);

        if(OnShoot != null)
        {
            OnShoot.Invoke();
        }
    }

    //cek burung sudah mati atau belum
    public bool IsDead()
    {
        return isDead;
    }

    //burung mati
    public void Dead()
    {
        if(!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;

    }

    void Jump()
    {
        if (birdRb)
        {
            birdRb.velocity = Vector2.zero;
            birdRb.AddForce(new Vector2(0, upForce));
        }

        if(OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdFlapAnim.enabled = false;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();

        if(OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
    }
}
