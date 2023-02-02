using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    public static Player Instance;

    public int life;

    public int maxLife;

    public Transform sight;
    public Transform arm;
    public Transform anchor;
    public Transform sheepAnchor;

    public float speed;

    public LayerMask sheepLayer;
    public LayerMask barnLayer;
    public float interactRay;

    public GameObject bullet;

    private float inputVertical;
    private float inputHorizontal;

    Sheep sheep;

    public event Action OnShoot;
    public event Action<Sheep> OnStoreSheep;
    public event Action<Sheep> OnCarrySheep;
    public event Action<Sheep> OnDropSheep;
    public static event Action OnGameOver;
    public static event Action OnTakeDamage;
    public static event Action OnHeal;

    public  bool onDead;


    public AudioClip shootAC;

    AudioSource audioSource;

    public float timeBtwDamageBySheep;
    public float cooldownDamageSheep;

    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(onDead){
            return;
        }
        
        cooldownDamageSheep += Time.deltaTime;
        if (sheep == null)
        {
            sight.gameObject.SetActive(true);
            // Rotate the sight
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir1 = sight.position - arm.transform.position;
            Vector2 dir2 = mousePosition - arm.transform.position;
            float angle = Vector3.SignedAngle(dir1, dir2, new Vector3(0, 0, 1));
            arm.transform.Rotate(new Vector3(0, 0, angle), Space.Self);
            // sight.RotateAround(arm.transform.position, new Vector3(0, 0, 1), angle);

            if (Input.GetMouseButtonDown(0))
            {
                Bullet b = Instantiate(bullet, sight.position, Quaternion.identity).GetComponent<Bullet>();
                b.Shoot(mousePosition);
                audioSource.PlayOneShot(shootAC);
                if (OnShoot != null)
                    OnShoot.Invoke();
            }
        }
        else
        {
            if(!sheep.freezed){
                if(cooldownDamageSheep > timeBtwDamageBySheep){
                    takeDamage();
                    cooldownDamageSheep = 0;
                }
            }


            sight.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StoreSheep();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CarrySheep();
        }

        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");

        if (inputHorizontal == 0 && inputVertical == 0)
        {
            ani.SetBool("Moving", false);
        }
        else
        {
            ani.SetBool("Moving", true);
            transform.Translate(new Vector2(inputHorizontal, inputVertical) * speed * Time.deltaTime);
        }

        if(life < 0){
            if(!onDead){
                if(OnGameOver != null){
                    OnGameOver.Invoke();
                }

                onDead = true;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(anchor.transform.position, interactRay);
    }

    public void CarrySheep()
    {
        if (sheep == null)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRay, sheepLayer);
            if (hit != null)
            {
                sheep = hit.GetComponent<Sheep>();
                sheep.beingCarried = true;
                sheep.transform.parent = sheepAnchor;
                arm.gameObject.SetActive(false);
                if (OnCarrySheep != null)
                    OnCarrySheep.Invoke(sheep);
            }
        }
        else
        {
            sheep.transform.parent = transform.parent;
            sheep.beingCarried = false;
            arm.gameObject.SetActive(true);

            if (OnDropSheep != null)
                OnDropSheep.Invoke(sheep);
            sheep = null;
        }

    }

    public void StoreSheep()
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRay, barnLayer);
        if (hit != null)
        {
            Barn b = hit.GetComponent<Barn>();
            b.StoreSheep(sheep);
            arm.gameObject.SetActive(true);
            if (OnStoreSheep != null)
                OnStoreSheep.Invoke(sheep);
            sheep = null;
        }

    }

    public void takeDamage()
    {
        if(OnTakeDamage != null){
            OnTakeDamage.Invoke();
        }
        life -= 10;
    }

    public void heal(){
        if(OnHeal != null){
            OnHeal.Invoke();
        }
        life+=20;
        if(life  > maxLife){
            life = maxLife;
        }
    }

}
