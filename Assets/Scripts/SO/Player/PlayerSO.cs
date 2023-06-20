using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Manager", fileName = "new HealthManager")]
public class PlayerSO : ScriptableObject
{
    public float  MaxHealth;
    public UnityEvent<float> healthChangeEvent;
    public UnityEvent LoseGame;


   [SerializeField] private float _Health;
    public float Health
    {
        get { return _Health; }
        set
        {
      //      if (_Health == value) return;
            _Health = value;
          //  if (OnVariableChange != null)
          //      OnVariableChange(_Health);
        }
    }
  //  public delegate void OnVariableChangeDelegate(float newVal);
  //  public event OnVariableChangeDelegate OnVariableChange;


    private void OnEnable()
    {
       // OnVariableChange += VariableChangeHandler;
        Health = MaxHealth;
        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent<float>();
        }
    }
   // private void VariableChangeHandler(float newVal)
   // {
   //     
   // }
    public void DecreaseHealth(float Damage)
    {
        if (Health < Damage)
        {
            LoseGame.Invoke();
            return;
        }
        Health -= Damage;
        
    }

    public void LosedGame()
    {

    }
}
