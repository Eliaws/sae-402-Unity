using System.Collections;
using UnityEngine;

public class Coffre : MonoBehaviour
{  
    private bool isInRange;  
    public Animator animator;
    public GameObject pommePrefab; // Référence au préfabriqué de la pomme
    public float delayBeforeSpawn = 1f; // Délai avant l'apparition de la pomme

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OuvrirCoffre();
        }
    }

    void OuvrirCoffre()
    {
        // Déclencher l'animation d'ouverture du coffre
        animator.SetTrigger("OuvrirCoffre");

        // Démarrer la coroutine pour faire apparaître la pomme après un délai
        StartCoroutine(SpawnPommeAfterDelay());
    }

    private IEnumerator SpawnPommeAfterDelay()
    {
        // Attendre le délai spécifié avant d'instancier la pomme
        yield return new WaitForSeconds(delayBeforeSpawn);

        // Si un préfabriqué de pomme est défini
        if (pommePrefab != null)
        {
            // Instancier la pomme à partir du préfabriqué au niveau du coffre
            GameObject pomme = Instantiate(pommePrefab, transform.position, Quaternion.identity);

            // Démarrer la coroutine pour déplacer la pomme vers le haut
            StartCoroutine(DeplacerPommeVersLeHaut(pomme));
        }

        // Désactiver le BoxCollider2D pour empêcher l'animation de se répéter
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator DeplacerPommeVersLeHaut(GameObject pomme)
    {
        float speed = 2f; // Vitesse de déplacement de la pomme
        float distanceToMove = 2f; // Distance que la pomme doit parcourir vers le haut

        Vector3 targetPosition = pomme.transform.position + Vector3.up * distanceToMove;

        // Boucle tant que la pomme n'a pas atteint sa position cible
        while (pomme != null && pomme.activeSelf && pomme.transform.position.y < targetPosition.y)
        {
            // Déplacer la pomme progressivement vers le haut
            pomme.transform.position = Vector3.MoveTowards(pomme.transform.position, targetPosition, speed * Time.deltaTime);

            // Attendre le prochain frame
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}