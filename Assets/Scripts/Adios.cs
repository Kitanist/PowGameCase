using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Adios : MonoBehaviour
{
    public GameObject Win, Lose;
    [SerializeField] GameEvent LoadGameEvent,SavegameEvent;
    public VariableJoystick joystick;
    public void Winned()
    {
        Win.SetActive(true);
    }
    public void Losed()
    {
        Lose.SetActive(true);
    }
  
    
    public void SaveGame()
    {
        SavegameEvent.Raise();
    }
    public void LoadGame()
    {
        LoadGameEvent.Raise();
    }
    
    public void Bye()
    {
        Application.Quit();
    }
}
