using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] Timerstuff timer;
    [SerializeField] PlayerData PData;
    [SerializeField] private bool canMove = false, isKeyboard = false; 
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    private Adios EventSystem; 
    [HideInInspector]
    public Vector2 movement;
    VariableJoystick variableJoystick;
    private Vector2 direction;
   
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
        CanMove = true;
        Invoke("InitUI", 2.1f);
    }
    
    void InitUI()
    {
        EventSystem = GameObject.Find("EventSystem").GetComponent<Adios>();
        variableJoystick = EventSystem.joystick;
       
    }
   


    void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        Move();
    }
    void FixedUpdate()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        if (!CanMove)
            return;
        if (isKeyboard)
        {
            rb.MovePosition(rb.position + movement * PData.movementSpeed * Time.deltaTime);
        }
        else
        {
            direction = new Vector2(0, 1) * variableJoystick.Vertical + new Vector2(1, 0) * variableJoystick.Horizontal;

            rb.MovePosition(rb.position + direction * PData.movementSpeed * Time.deltaTime);
        }
    }
    public void MoveToLoad()
    {
        gameObject.transform.position = PData.Playerpos;
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
        PData.Playerpos = gameObject.transform.position;
    }
}
