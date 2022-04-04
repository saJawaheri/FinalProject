using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemcollectore : MonoBehaviour
{
    private int Pineapple = 0;

    [SerializeField] private Text pineapplestext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            Destroy(collision.gameObject);
            Pineapple++;
            pineapplestext.text = "pineapples:" + Pineapple;
            
        }
    }
}
