using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float maxtime = 2f;
    float timer;
    public GameObject Flame;
    public float speed = 20;
    GameObject newflame;
    private Vector2 random;
    // Update is called once per frame



    private void Update()
    {

        random = new Vector2(Random.Range(9f, 12f), -4f);
        timer += Time.deltaTime;

        if (timer > maxtime)
        {
            
            GameObject newflame = Instantiate(Flame, random, transform.rotation);
            timer = 0;
            Destroy(newflame, 5f);
        }
        Destroy(newflame, 4f);

    }
}
