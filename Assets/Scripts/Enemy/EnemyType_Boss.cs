using UnityEngine;

public class EnemyType_Boss : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreaDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;
    public Transform player;

    public Transform firePoint;

    static public bool isTrigger;

    public Animator anim;

    private AudioSource audioSource;
    private EnemyHealthManger healthManger;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthManger = GetComponent<EnemyHealthManger>();

        timeBtwShots = startTimeBtwShots;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (healthManger.currentHealth < healthManger.staringHealth / 2)
        {
            speed = 3.0f;
            stoppingDistance = 9.0f;
            retreaDistance  = 6.0f;
        }

        if (isTrigger)
        {
            transform.LookAt(player.transform.position);

            //Moving AI
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                anim.SetBool("Run Forward", true);
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            else if(Vector3.Distance(transform.position, player.position) < stoppingDistance && 
                    Vector3.Distance(transform.position, player.position) < retreaDistance)
            {
                anim.SetBool("Run Forward", false);
                transform.position = this.transform.position;
            }

            else if (Vector3.Distance(transform.position, player.position) > retreaDistance)
            {
                anim.SetBool("Run Forward", true);
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            if (timeBtwShots <= 0)
            {
                audioSource.Play();

                if(healthManger.currentHealth >= healthManger.staringHealth / 2)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,  25f, 0f));
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f,   0f, 0f));
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, -25f, 0f));
                }

                if (healthManger.currentHealth < healthManger.staringHealth / 2)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 50f, 0f));
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 25f, 0f)); 
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, -25f, 0f));
                    Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, -50f, 0f));
                }

                anim.SetBool("Attack 02", true);
                transform.position = this.transform.position;
                //Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
            anim.SetBool("Run Forward", false);
    }
}
