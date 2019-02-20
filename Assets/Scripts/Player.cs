using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    SpriteRenderer mySprite;
    Transform myTransform;

    public static int gold_count = 0;
    public static bool thegate1 = false; //geçici 
    public static bool thegate2 = false; //bi çözüm intractable conditionlarını bu classın update scope'unda çalıştır.

    public GameObject outroImage;
    public float horizontal;//horizontal'ı unity'de görmek için yaptın.
    public Text goldCounterText;
    public float Speed = 5;
    public float Jumppow = 250; 
    private bool orientRight = true;
    public static bool died = false;
    //public Button level2Button;
    //public Button level3Button;

    void Start()
    {
        outroImage = GameObject.Find("OutroImage");
        outroImage.SetActive(false);
        myTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }
    public float kontrol()
    {
        if (!died)
        {
            horizontal = Input.GetAxis("Horizontal");
            return horizontal;
        }
        else
        {
            Invoke("characterDie", 3f);
            return 0F;//öldüğü zaman 0 gönderiyor böylelikle karakter haraket etmiyor....

        }
    }
    void Update()
    {
        goldCounterText.text = gold_count.ToString();
        //horizontal = Input.GetAxis("Horizontal");
        //transform.Translate(Time.deltaTime * (Speed * horizontal),0,0); //şekli x ekseni üzerinde gitmek istediğimiz yere çeviriyoruz
        if (myTransform.position.y < -10.0)
        {
            died = true;
            characterDie();
        }
        Run(kontrol());
        Flip(kontrol());
        _Input();
        jumpAnimationControl(kontrol());
    }
    void Run(float horizontalGet)
    {
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontalGet));
        myAnimator.SetBool("slide", false);
    }
    void Flip(float horizontalGet)
    {
        if ((horizontalGet < 0 && orientRight) || (horizontalGet > 0 && !orientRight))//karakterin yönelimi için
        {
            orientRight = !orientRight;
            //SpriteRenderer flipX = GetComponent<SpriteRenderer>();
            //flipX.flipX = !orientRight;
            mySprite.flipX = !orientRight;
        }
    }

    void _Input()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && myRigidbody.velocity.y == 0)// havada zıplamayı engellemek için
            Jump();

        if (Input.GetKeyDown(KeyCode.X))
        {
            Melee();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Slide();
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Application.LoadLevel(0);
        //}
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, Jumppow));
        myAnimator.SetTrigger("jump");
    }
    void jumpAnimationControl(float horizontalGet)
    {
        if (myRigidbody.velocity.y == 0) // sadece y eksenindeki hızı 0 ise yatay düzlemde hareket edecek.
        {
            myRigidbody.velocity = new Vector2(Speed * horizontalGet, 0); // yatay düzlemde hareketi sağlıyor
        }

        if (myRigidbody.velocity.y < 0)
        {

            myAnimator.SetBool("land", true);
            myAnimator.ResetTrigger("jump");
        }
        else
        {
            myAnimator.SetBool("land", false);
        }
    }
    void Melee()
    {
        myAnimator.SetTrigger("melee");
    }
    void Slide()
    {

        myAnimator.SetBool("slide", true);
    }
    void characterDie()
    {
        if (died)
        {
            gold_count = 0;
            outroImage.SetActive(true);
            died = false;
            Invoke("gameOver", 3f);
        }
    }
    void OnCollisionEnter2D(Collision2D bilesen)
    {
        if (bilesen.gameObject.name == "TheGate1")
        {
            thegate1 = true;
            //level2Button.interactable = true;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
          
        }
        if (bilesen.gameObject.name == "TheGate2")
        {
            thegate2 = true;
            //level3Button.interactable = true;
            SceneManager.LoadScene(1, LoadSceneMode.Single);

        }
        
    }
    void gameOver()
    {

        SceneManager.LoadScene(1,LoadSceneMode.Single);
        //Application.LoadLevel(1);
        outroImage.SetActive(false);
    }

}
