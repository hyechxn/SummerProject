using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 playerPosition;
    private float moveSpeed = 6f;
    private SpriteRenderer spriteRenderer;
    public int bulletLevel = 1;

    private bool isHIt;

    public GameObject bulletS;
    public GameObject bulletM;
    public GameObject bulletL;


    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchLeft;
    private bool isTouchRight;
    private float h;
    private float v;

    public float alpha;

    public UI ui;
    public UI score;
    public UI pain;
    public UI um;

    public int HP = 200;
    public int maxHP = 200;
    public GameObject hpBar;
    public GameObject scoreBar;
    public GameObject painBar;
    public GameObject UIManager;
    private Animator anim;

    public int Score = 0;

    private bool isFire;
    private float delayTime = 0.15f;
    private float delay;

    public bool isItem;

    private Rigidbody2D rigid;
    private bool isAction;

    void Awake()
    {
        isAction = true;
        um = UIManager.GetComponent<UI>();
        pain = painBar.GetComponent<UI>();
        score = scoreBar.GetComponent<UI>();
        ui = hpBar.GetComponent<UI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPosition = transform.position;
        rigid = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        StartAction();
    }
    void Update()
    {
        if (!isAction) {
            Move();
            Fire();
        }
        
    }
    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");



        if ((isTouchLeft && h == -1) || (isTouchRight && h == 1))
        {
            h = 0;
        }

        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 movement = new Vector3(h, v, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if ((Input.GetButtonDown("Horizontal")) || (Input.GetButtonUp("Horizontal")))
        {
            anim.SetInteger("Input", (int)h);
        }
    }
    void Fire()
    {
        if (isFire == false)
        {
            if (Input.GetButton("Fire1"))
            {
                if (bulletLevel == 1)
                {
                    Instantiate(bulletS, transform.position, transform.rotation);
                }
                else if (bulletLevel == 2)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.25f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.25f, transform.rotation);
                }
                else if (bulletLevel == 3)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.5f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.5f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.up * 0.3f, transform.rotation);
                }
                else if (bulletLevel == 4)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 0.5f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 0.5f, transform.rotation);
                    Instantiate(bulletL, transform.position + Vector3.up * 0.3f, transform.rotation);
                }
                else if (bulletLevel >= 5)
                {
                    Instantiate(bulletS, transform.position + Vector3.right * 1f, transform.rotation);
                    Instantiate(bulletS, transform.position + Vector3.left * 1f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.right * 0.5f + Vector3.up * 0.3f, transform.rotation);
                    Instantiate(bulletM, transform.position + Vector3.left * 0.5f + Vector3.up * 0.3f, transform.rotation);
                    Instantiate(bulletL, transform.position + Vector3.up * 0.6f, transform.rotation);
                }

                isFire = true;
            }
        }
        if (isFire == true)
        {
            delay += Time.deltaTime;
        }
        if (delayTime <= delay)
        {
            isFire = false;
            delay = 0f;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
        if (other.gameObject.tag == "Enemy")
        {
            if (isHIt == false)
            {
                OnHit();
                um.CurHp -= other.GetComponent<Enemy>().dmg / 2;
            }
        }
        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Bossbullet")
        {
            if (isHIt == false)
            {
                OnHit();
                um.CurHp -= other.GetComponent<BulletController>().dmg;
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Item")
        {
            um.isItem = true;
            Item item = other.GetComponent<Item>();
            switch (item.thisType)
            {
                case "Upgrade":
                    um.nameNameItem = item.thisType;
                    if (bulletLevel < 5)
                        bulletLevel++;
                    else if (bulletLevel >= 5)
                        Score += 2000;
                    break;
                case "NoHit":
                    um.nameNameItem = item.thisType;
                    ChangeAlpha(0.5f);
                    Invoke("ReturnAlpha", 3f);
                    break;
                case "Healing":
                    um.nameNameItem = item.thisType;
                    um.CurHp += 50;
                    if (um.CurHp >= 200)
                        um.CurHp = 200;
                    break;
                case "PainDown":
                    um.nameNameItem = item.thisType;
                    um.CurPain -= 40;
                    break;
                case "AtkSpeedUp":
                    um.nameNameItem = item.thisType;
                    if (delayTime > 0.5f)
                        delayTime -= 0.2f;
                    break;


            }
            um.isItem = false;
            Destroy(other.gameObject);
        }
    }
    private void OnHit()
    {
        ChangeAlpha(0.5f);
        Invoke("ReturnAlpha", 1.5f);

    }

    private void ReturnAlpha()
    {
        ChangeAlpha(1f);
        isHIt = false;
    }
    private void ChangeAlpha(float newAlpha)
    {
        alpha = newAlpha;
        Color currentColor = spriteRenderer.color;
        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
        spriteRenderer.color = newColor;
        isHIt = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }

    void StartAction()
    {
        rigid.velocity = Vector3.up * 3;
        Invoke("StopAction", 1.3f);
    }
    void StopAction()
    {
        rigid.velocity = Vector3.zero;
        isAction = false;
    }
}
