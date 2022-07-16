using UnityEngine;

public class fps : MonoBehaviour
{
    public int targetFrameRate = 120;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}