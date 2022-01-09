using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaUI : MonoBehaviour
{
    public void ShowLavaUI(bool show)
    {
        GetComponentInChildren<Image>().enabled = show;
        GetComponentInChildren<Text>().enabled = show;
    }
}
