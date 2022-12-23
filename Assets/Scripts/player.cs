using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidadMov=0;
    public float velocidadRot = 0;
    public Animator animator;
    public Rigidbody rgbody;
    // Start is called before the first frame update
    private float x, y;
    private bool salto=false;
    public float fuerzaSalto = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("fuerzaSalto", rgbody.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("inFloor", false);
            rgbody.AddForce(new Vector3(0, fuerzaSalto,0));
            salto = true;
            

        }
        transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);
        animator.SetFloat("velY", y);
        animator.SetFloat("velX", x);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terreno")
        {
            
            salto = false;
            animator.SetBool("inFloor", true);
        }
    }
}
