using UnityEngine;

public class PanelDefeat : MonoBehaviour
{
    public void Show() 
    {
        gameObject.SetActive(true);
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
    }
}
