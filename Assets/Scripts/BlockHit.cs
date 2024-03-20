using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour

    

{

    public int maxHits = -1;
    private bool isAnimating = false;
    public SpriteRenderer sr;
    public bool isHidden = false;
    public PlatformEffector2D platformEffector2D;
    public GameObject collectiblePrefab;

    private void Awake(){
        platformEffector2D.enabled = isHidden;
        if(isHidden){
            sr.color = Color.clear;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&& !isAnimating && maxHits !=0) {
        Vector3 upDirection = transform.TransformDirection(Vector3.up);
        Vector3 compareDirection = (collision.transform.position - transform.position).normalized;

        if(Vector3.Dot(upDirection, compareDirection)< 0){
            StartCoroutine(Hit());
        }


        }
    }

    IEnumerator Hit() {
        platformEffector2D.enabled = false;
        sr.color = Color.white;
        maxHits = maxHits-1;
        isAnimating = true;
        Vector3 endPosition = transform.position + Vector3.up * 0.5f;
        yield return transform.MoveBackAndForth(endPosition);

        if(collectiblePrefab != null){
            GameObject collectible = Instantiate(
                collectiblePrefab,
                transform.position,
                Quaternion.identity);
            Collectible collec = collectible.GetComponent<Collectible>();
            collec.canBeDestroyedOnContact = false;

            Vector3 collectibleEndPosition = (
                collectible.transform.localPosition + Vector3.up * 1.5f);
            yield return collectible.transform.MoveBackAndForth(
                collectibleEndPosition
            );
            collec.Picked();
        }

        isAnimating = false;

    }
}
