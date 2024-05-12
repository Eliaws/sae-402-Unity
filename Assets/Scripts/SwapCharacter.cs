using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SwapCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public PlayerData playerData ;
public SpriteLibrary spriteLibrary;
    // Update is called once per frame
    void Update()
    {
        
    }
public void Awake(){
    spriteLibrary.spriteLibraryAsset = playerData.SpriteLibraryAsset;
}
    
}
