using UnityEngine;

public class DashMovement : MonoBehaviour
{
    private Rigidbody rb;
    public DashBar dashBar;

    public float startDashTime;
    public float dashSpeed;

    public int startDash;
    static public int currentDash;
    public int dashCosting;
    public float reloadDashTime;
    public float timer;

    private int maxDash;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxDash = startDash;
        currentDash = startDash; 
    }

    void Update()
    {
        if (currentDash < maxDash)
        {
            ReloadDash();
        }

        dashBar.SetDash(currentDash);

        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDash > 0)
        {
            currentDash -= dashCosting;

            //GetComponent<PlayerHealthManager>().UsingDash(dashCosting);

            rb.AddForce(transform.forward * dashSpeed, ForceMode.VelocityChange);

            rb.velocity = Vector3.zero;
        }
    }

    void ReloadDash()
    {
        Debug.Log("Reloading");

        timer += Time.deltaTime;

        if (timer > reloadDashTime)
        {
            currentDash += 1;
            timer = 0f;
        }
    }
}
