using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] GameEvent Win, Lose;
    [SerializeField] Timerstuff timer;
    public float movementSpeed;
    public int currentLevelofFireRate = 0, currnetLevelofDamage = 0, currentLevelofFireAmount = 0, currentLevelofWeaponAmount = 0;
    public PlayerSO HealthManager;
    public Slider HealtBar;

    public bool isDamageUpg;
    [SerializeField] private bool canMove = false, isKeyboard = false;

    public GameObject Weapon1, Weapon2;
    public GameManager GM;

    Rigidbody2D rb;
    Animator animator;
    PlayerAttack PA;
    Weapons Weapon;

    private Adios EventSystem;
    [HideInInspector]
    public Vector2 movement;
    VariableJoystick variableJoystick;
    private Vector2 direction;
    [SerializeField]
    private Slider HealthBar;
    [SerializeField]
    private PlayerSO PlayerHealth;





    public bool CanMove
    {
        get { return canMove; }
        set
        {
            canMove = value;
        }
    }
    #endregion
    void Start()
    {
        ChangeSliderValue(PlayerHealth.Health);
        CanMove = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PA = GetComponent<PlayerAttack>();
        Weapon = GetComponent<Weapons>();
        Invoke("InitUI", 2.1f);
        InvokeRepeating("UIUpdate", 2.1f, 1f);
        LevelUp();
    }
    public void ChangeSliderValue(float value)
    {
        HealthBar.DOValue(PlayerHealth.Health / PlayerHealth.MaxHealth, 0.5f, false);
    }
    void InitUI()
    {
        //   public TextMeshProUGUI money, health, damage, fireRate;
        EventSystem = GameObject.Find("EventSystem").GetComponent<Adios>();
        variableJoystick = EventSystem.joystick;
       
        EventSystem.damage.text = Weapon.damage.ToString();
        EventSystem.fireRate.text = PA.fireRate.ToString();
    }
    void UIUpdate()
    {
       
        EventSystem.damage.text = "Damage : " + Weapon.damage.ToString();
        EventSystem.fireRate.text = "Fire Rate : " + PA.fireRate.ToString();
    }

    public void LevelUp()
    {
        switch (currentLevelofFireRate)
        {
            case 0:
                PA.fireRate = 2;
                break;
            case 1:
                PA.fireRate = 1.9f;
                break;
            case 2:
                PA.fireRate = 1.8f;
                break;
            case 3:
                PA.fireRate = 1.7f;
                break;
            case 4:
                PA.fireRate = 1.6f;
                break;
            case 5:
                PA.fireRate = 1.5f;
                break;
            case 6:
                PA.fireRate = 1.4f;
                break;
            case 7:
                PA.fireRate = 1.3f;
                break;
            case 8:
                PA.fireRate = 1.2f;
                break;
            case 9:
                PA.fireRate = 1.1f;
                break;
            case 10:
                PA.fireRate = 1;
                break;
            case 11:
                PA.fireRate = 0.9f;
                break;
            default:
                break;
        }
        switch (currnetLevelofDamage)
        {
            case 0:
                Weapon.damage = 10;
                isDamageUpg = true;
                break;
            default:
                break;

        }
        if (!isDamageUpg)
        {
            isDamageUpg = true;
            Weapon.damage *= 1.1f;

        }
        switch (currentLevelofFireAmount)
        {
            case 0:
                PA.FireAmount = 1;
                break;
            case 1:
                PA.FireAmount = 2;
                break;
            case 2:
                PA.FireAmount = 3;
                break;
            case 3:
                PA.FireAmount = 4;
                break;
            default:
                break;
        }
        switch (currentLevelofWeaponAmount)
        {
            case 0:
                Weapon1.SetActive(false);
                Weapon2.SetActive(false);
                break;
            case 1:
                Weapon1.SetActive(true);
                Weapon2.SetActive(true);
                break;
            default:
                break;
        }
    }
    void Update()
    {

        Move();

        if (!timer.isGameContinue && Time.timeScale > 0)
        {
            Win.Raise();
            Time.timeScale = 0f;
            Debug.Log("Zamaný yedim afied");
        }

        if (HealthManager.Health <= 0 && Time.timeScale > 0)
        {
            Lose.Raise();
            Time.timeScale = 0f;
            Debug.Log("Zamaný yedim");
        }

    }
    void FixedUpdate()
    {
        if (!CanMove)
            return;
        if (isKeyboard)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
        }
        else
        {
            direction = new Vector2(0, 1) * variableJoystick.Vertical + new Vector2(1, 0) * variableJoystick.Horizontal;

            rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
        }
    }
    void Move()
    {
        if (!CanMove)
            return;
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
        if (isKeyboard)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
        else
        {
            animator.SetFloat("Horizontal", variableJoystick.Horizontal);
            animator.SetFloat("Vertical", variableJoystick.Vertical);
            animator.SetFloat("Speed", direction.sqrMagnitude);

        }
    }
}
