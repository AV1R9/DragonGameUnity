using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{
    public bool IJ;
    public float jumpforce;
    private Rigidbody2D rigidbody;
    Animator anim;

    public GameObject RestartBO;

    // Start is called before the first frame update
    void Start()
    {
        IJ = false;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IJ==false)
        {
            rigidbody.AddForce(Vector2.up * jumpforce);
            IJ = true;
            anim.SetBool("IJ", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && IJ==true)
        {
            IJ = false;
            anim.SetBool("IJ", false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("Dead", true);
            Time.timeScale = 0;
            RestartBO.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("scene1");
        Time.timeScale = 1;
    }
}
