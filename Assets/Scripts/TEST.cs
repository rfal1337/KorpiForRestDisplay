using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    public void OnClicked(Button button) 
    {
        print ("Videon pituus: " + button.name);
    }
}
