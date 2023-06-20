using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Manager", fileName = "new HealthManager")]
public class PlayerSO : ScriptableObject
{
    public float MaxHealth;
    public UnityEvent<float> healthChangeEvent;
    public UnityEvent LoseGame;


    [SerializeField] private float _Health;
    public float Health
    {
        get { return _Health; }
        set
        {
            _Health = value;
        }
    }


    private void OnEnable()
    {

        Health = MaxHealth;
        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent<float>();
        }
    }

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
