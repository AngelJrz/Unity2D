using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource m_AudioSource;
    private bool m_Finished = false;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !m_Finished)
        {
            //collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D personaje);
            //personaje.bodyType = RigidbodyType2D.Static;
            m_AudioSource.Play();
            Invoke("CompleteLevel", 1.5f);
            m_Finished = true;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
