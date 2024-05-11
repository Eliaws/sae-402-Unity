 using UnityEngine;

public class Coffre : MonoBehaviour
{   
    private bool isInRange;  
    public Animator  animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& isInRange )
        {
             OuvrirCoffre(); 
        }
    }

    void OuvrirCoffre()
    {
         animator.SetTrigger("OuvrirCoffre");

        //Désactiver le Boxcollider2D pour que l'animation ne se joue pas à l'infinie lorsque le joueur appuie sur E
         GetComponent<BoxCollider2D>().enabled=false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
