using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public void SetActive()
    {
        if (isActiveAndEnabled) return;
        gameObject.SetActive(true);
    }

    public void SetDeactive()
    {
        if (!isActiveAndEnabled) return;
        gameObject.SetActive(false);
    }
}