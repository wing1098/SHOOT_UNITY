using UnityEngine;
using System;

public class PlayerController : MonoBehaviour , IShopCustomer
{
    public float moveSpeed = 5.0f;

    public float jumpSpeed = 2;


    public float distToGround;  //プレイヤーから地面の距離

    public Animator anim;

    public Rigidbody myRigidbody;

    public BoxCollider col;

    //Melee Attack
    public Transform meleeAttackPoint;
    public LayerMask enemyLayers;
    public float meleeAttackRange = 0.5f;
    public int meleeAttackDamage = 5;

    private Vector3 moveInput;

    private Vector3 moveVelocity;

    private Camera mainCamera;

    public PistolController pistol;
    
    public RifleController rifle;

    public ShotGunController shotGun;

    public ParticleSystem dust;

    public event EventHandler OnGoldAmountChanged;
    public event EventHandler OnHealthPotionAmountChanged;
    public event EventHandler OnPistolDamageAmountChanged;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        col         = GetComponent<BoxCollider>();

        anim = GetComponent<Animator>();

        //col.bounds.extents.y: プレイヤーから地面の距離
        distToGround = col.bounds.extents.y;

        //Find the camera and the name is Main Camera
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(h, 0f, v);
        moveVelocity = moveInput * moveSpeed;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run Forward", true);
        }
        else
        {
            anim.SetBool("Run Forward", false);
        }

        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    anim.SetBool("Jump", true);
        //    anim.SetBool("Run Forward", false);
        //    CreateDust(); 
        //    moveVelocity.y += jumpSpeed;
        //}

        //開始射擊處理
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        RaycastHit hit;

        float rayLenght;  //Ray長度

        //Camera射Ray到地面 玩家面向Ray
        if(groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght); 
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if(Physics.Raycast(cameraRay, out hit) && hit.transform.tag == "Item")
        {
            RifleAmmo.isTrigger = true;
            Debug.Log("Item");
        }
        else
        {
            RifleAmmo.isTrigger = false;
        }

        //射撃
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Attack 01", true);

            pistol.isFiring  = true;
            rifle.isFiring   = true;
            shotGun.isFiring = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attack 01", false);

            pistol.isFiring  = false;
            rifle.isFiring   = false;
            shotGun.isFiring = false;
        }

        //近接攻撃
        if (Input.GetKeyDown(KeyCode.Space) && DashMovement.currentDash > 0)
        {
            DashMovement.currentDash -= 1;
            MeleeAttack();
            CreateDust();
        }
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity + new Vector3(0, myRigidbody.velocity.y, 0);
    }

    ////着地チャック
    //bool IsGrounded()
    //{
    //    return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    //}

    void CreateDust()
    {
        dust.Play();
    }

    void MeleeAttack()
    {
        anim.SetTrigger("Attack 01");

        Collider[] hitEnemies = Physics.OverlapSphere(meleeAttackPoint.position, meleeAttackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealthManger>().HurtEnemy(meleeAttackDamage);

            Debug.Log("melee hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (meleeAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeAttackRange);
    }

    private void AddHealthPotion()
    {
        PlayerHealthManager.currentHealth++;
        OnHealthPotionAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddDamagePistol()
    {
        PistolController.bulletDamage++;
        OnPistolDamageAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddDamageRifle()
    {
        RifleController.bulletDamage++;
        OnPistolDamageAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddDamageShotgun()
    {
        ShotGunController.bulletDamage++;
        OnPistolDamageAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void BouthItem(ShopItem.ItemType itemType)
    {
        Debug.Log("Bouth Itme : " + itemType);
        switch (itemType)
        {
            case ShopItem.ItemType.Hp:      AddHealthPotion(); break;
            case ShopItem.ItemType.Pistol:  AddDamagePistol(); break;
            case ShopItem.ItemType.Rifle:   AddDamageRifle(); break;
            case ShopItem.ItemType.Shotgun: AddDamageShotgun(); break;
        }
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if(GameManager.currentMoney >= spendGoldAmount)
        {
            GameManager.currentMoney -= spendGoldAmount;
            OnGoldAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
