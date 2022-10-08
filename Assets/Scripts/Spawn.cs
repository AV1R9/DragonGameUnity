using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float maxtime = 2f;
    float timer;
    public DragonController thePlayer;
    public GameObject Flame;
    public float speed = 20;
    GameObject newflame;
    private float SpawnTime;
    private Vector2 lastPlayerPosition;

    // Update is called once per frame
    private void Update(){
    
        thePlayer = FindObjectOfType<DragonController>();
        lastPlayerPosition = thePlayer.transform.position;
        //random = new Vector3(10f, -4f, 0);
        float random = Random.Range(30, 40);
        timer += Time.deltaTime;


        if (timer > maxtime)
        {
            // Instanciar una nueva flama con la rotación en z para que voltee de lado del jugador
            GameObject newflame = Instantiate(Flame, new Vector2 (lastPlayerPosition.x + random, lastPlayerPosition.y) , Quaternion.Euler(0, 0, -180)); 
            timer = 0;
            // Destruir clon
            Destroy(newflame, 8);
        }

    }
    /*
    void Spawn () {
        float x = R;
    }*/
}
