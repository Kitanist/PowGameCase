using TMPro;
using UnityEngine;

public class UITimeController : MonoBehaviour
{
    [SerializeField] Timerstuff timer;
    public TextMeshProUGUI Timer;
    public void TimeVariableSet()
    {
        Timer.text = "Remaining Time : " + timer.Time.ToString(); 
    }
}
