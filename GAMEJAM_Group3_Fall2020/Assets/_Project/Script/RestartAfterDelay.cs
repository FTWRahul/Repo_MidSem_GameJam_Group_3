using UnityEngine;

public class RestartAfterDelay : MonoBehaviour
{
    public void RestartSoonOKay()
    {
      Invoke(nameof(TurnOn), 3f);  
    }

    private void TurnOn()
    {
        gameObject.SetActive(true);
    }
}