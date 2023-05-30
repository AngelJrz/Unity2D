using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameoverMenu;
    public Renderer fondo;
    public GameObject floorCollision;
    public List<GameObject> suelo;
    public GameObject piedra1;
    public GameObject piedra2;
    public List<GameObject> obstaculos;
    public float velocidad = 0;
    public bool GameOver = false;
    public bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        //Crear mapa 
        for (int i = 0; i < 21; i++)
        {
            suelo.Add(Instantiate(floorCollision, new Vector2(-10 + i, -4), Quaternion.identity));
        }

        //Crear piedras
        obstaculos.Add(Instantiate(piedra1, new Vector2(9, -3), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(15, -3), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(16, -3), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            CambiarMenuInicioGameOver();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true; 
            }
        }

        if (start == true && GameOver == true)
        {
            CambiarMenuInicioGameOver();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(start == true && GameOver == false)
        {
            CambiarMenuInicioGameOver();
            this.fondo.material.mainTextureOffset = this.fondo.material.mainTextureOffset + new Vector2(0.15f, 0) * Time.deltaTime;
            
            //Mover mapa
            for (int i = 0; i < suelo.Count; i++)
            {
                if (suelo[i].transform.position.x <= -10)
                {
                    suelo[i].transform.position = new Vector3(10, -4, 0);
                }

                suelo[i].transform.position = suelo[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mover obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    obstaculos[i].transform.position = new Vector3(Random.Range(10, 15), -3, 0);
                }

                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

        }
    }

    private void CambiarMenuInicioGameOver()
    {
        if (start == false && GameOver == false)
        {
            gameoverMenu.SetActive(false);
            startMenu.SetActive(true);
        }else if (start == true && GameOver == false)
        {
            startMenu.SetActive(false);
        }
        else if (GameOver == true)
        {
            gameoverMenu.SetActive(true);
        }
    }
}
