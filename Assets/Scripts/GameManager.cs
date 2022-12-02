using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public GameObject columna;
    public List<GameObject> columnas;
    public float velocidad = 2.0f;
    public GameObject taladro;
    public GameObject destornillador;
    public List<GameObject> recompensa;
    public GameObject roca1;
    public List<GameObject> obstaculos;

    // Start is called before the first frame update
    void Start()
    {
        //crear mapa
        for (int i = 0; i <= 21; i++)
        {
            columnas.Add(Instantiate(columna, new Vector2(- 9 + i, -3), Quaternion.identity));
        }
        //crear recompensa
        recompensa.Add(Instantiate(taladro, new Vector2(20, -2), Quaternion.identity));
        recompensa.Add(Instantiate(destornillador, new Vector2(30, -2), Quaternion.identity));
        recompensa.Add(Instantiate(roca1, new Vector2(15, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

        //Mover plataforma
        for (int i = 0; i < columnas.Count; i++)
        {
            if (columnas[i].transform.position.x <= -10)
            {
                columnas[i].transform.position = new Vector3(10, -3, 0);
            }
            columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }

        //Mover recompensa
        for (int i = 0; i < columnas.Count; i++)
        {
            if (recompensa[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(15, 20);
                recompensa[i].transform.position = new Vector3(randomObs, -2, 0);
            }
            recompensa[i].transform.position = recompensa[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }
        //Mover obstaculo
        for (int i = 0; i < columnas.Count; i++)
        {
            if (obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(5, 15);
                obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
            }
            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }
    }
}
