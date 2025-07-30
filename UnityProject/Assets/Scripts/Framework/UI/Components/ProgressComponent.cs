using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressComponent : MonoBehaviour
{
    public Scrollbar progressBar;
    public Text progressLabel;

    public void SetVaule(float progress, string label)
    {
        progressBar.value = progress;
        progressLabel.text = label;
    }
    public float GetVaule()
    {
        return progressBar.value;
    }

}
