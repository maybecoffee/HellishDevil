using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStat[] playerStats;

    public AudioSource hitSound;

    public float JumpForce = 300;
    private Transform PlayerTransform;
    private Animator animator;
    private Rigidbody2D rb;
    private bool Jumpable = true;
    public float Speed = 0.01f;
    private bool isMoving = false;
    private Vector3 previousPos = Vector3.zero;
    private Weapon weapon;
    [SerializeField] private Transform _render;
    [SerializeField] private GameObject _footParticle;

    private void Start()
    {
        previousPos = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        PlayerTransform = this.GetComponent<Transform>();
        animator = this.GetComponentInChildren<Animator>();
        StartCoroutine(Step());
    }

/*    private void CreateStats()
    {
        PlayerStat Health = new PlayerStat();
        Health.maxValue = 100;
        Health.Value = 100;
        Health.Type = PlayerStatsType.Health;
        playerStats[0] = Health;

        PlayerStat Stamina = new PlayerStat();
        Stamina.maxValue = 100;
        Stamina.Value = 100;
        Stamina.Type = PlayerStatsType.Stamina;
        playerStats[1] = Stamina;
    }*/

    public PlayerStat GetPlayerStat(PlayerStatsType type)
    {
        foreach (PlayerStat item in playerStats)
        {
            if(item.Type == type)
            {
                return item;
            }
        }

        return null;
    }

    

    private void Update()
    {
              if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }  

            if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }



        if(Jumpable == true && isMoving == true)
        {
            GetComponentInChildren<AudioSource>().volume = 0.3f;
        }
        else
        {
            GetComponentInChildren<AudioSource>().volume = 0;
        }
    }

    public void SetWeapon(Weapon item)
    {
        weapon = item;
    }

    private void FixedUpdate()
    {


        if(Input.GetKey(KeyCode.D))
        {
            move(Vector2.right); // ���������� ������ new Vector2(0, 1)
        }

        if (Input.GetKey(KeyCode.A))
        {
            move(Vector2.left);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Move", false);
        }



        SetMoving();

    }

    private void SetMoving()
    {
        if (this.transform.position.x == previousPos.x)
        {
            isMoving = false;
        }

        else
        {
            isMoving = true;
        }

        previousPos = this.transform.position;
        animator.SetBool("Move", isMoving);
    }

    private void Attack()
    {
        GetPlayerStat(PlayerStatsType.Mana).AddValue(-10);
        animator.SetTrigger("Attack");
        //weapon.Attack();
        hitSound.Play();
    }

    //private void moveD()
    //{
      //  PlayerTransform.flipX = false;
       // this.GetComponent<Transform>().position -= new Vector3(-Speed, 0, 0);
      //  animator.SetBool("Move", true);
    //}

    private void move(Vector2 direction) // �����������
    {

        //rb.AddForce(direction * Speed, ForceMode2D.Force); // forcemode2d.force = ����� ���������� ���� � ������� (�������)
        // forcemode2d.impulse = ������

        this.transform.position += new Vector3(direction.x, direction.y, 0) * Speed;

        if(direction.x > 0)
        {
            PlayerTransform.gameObject.transform.localScale = new Vector3(1,1,1);
            _render.localScale = new Vector3(0.61993f , 0.61993f, 0.61993f);
        }

        if(direction.x < 0)
        {
            PlayerTransform.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            _render.localScale = new Vector3(-0.61993f, 0.61993f, 0.61993f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jumpable = true;
        animator.SetBool("Jump", false);
    }

    private void Jump()
    {
        if (Jumpable == true)
        {
            rb.AddForce(Vector2.up * JumpForce , ForceMode2D.Impulse);
            // Vector2.up = new Vector2(0,1);
            Jumpable = false;
            animator.SetBool("Jump", true);
        }
    }

    private IEnumerator Step()
    {
        while (true)
        {
            if (Jumpable == true && isMoving == true)
            {
                Instantiate(_footParticle, this.transform.position, Quaternion.identity); // quaternion.identity = нулевое вращение
            }
            yield return new WaitForSeconds(0.5f);  //yield return = return но для IEnumerator
        }
    }

}
