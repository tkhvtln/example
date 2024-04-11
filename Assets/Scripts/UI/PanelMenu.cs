using UnityEngine;

public class PanelMenu : MonoBehaviour
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
