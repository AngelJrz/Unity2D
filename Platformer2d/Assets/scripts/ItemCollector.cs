using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Se saca la clase Text

public class ItemCollector : MonoBehaviour
{
    private int FrutasColeccionanas = 0;
    [SerializeField] private TextMeshProUGUI textoColeccionables;
    [SerializeField] private AudioSource CollectEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coleccionable"))
        {
            Destroy(collision.gameObject);
            CollectEffect.Play();
            FrutasColeccionanas++;
            Debug.Log("Frutas: " + FrutasColeccionanas);
            textoColeccionables.text = "Frutas: " + FrutasColeccionanas;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
