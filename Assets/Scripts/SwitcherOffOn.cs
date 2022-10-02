using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherOffOn : MonoBehaviour {
    public Image img;
    public Sprite on;
    public Sprite off;

    private bool enabled = true;

    public void Switch() {
        img.sprite = enabled ? off : on;
        enabled = !enabled;
    }

}
