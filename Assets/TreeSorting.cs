using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSorting : MonoBehaviour{
    public GameObject root;
    public SpriteRenderer[] sprites;
    public int behindSorting;
    public int frontSorting;

    GameObject player;
    Player playerScript;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update(){
        if (player != null){
            if (root.transform.position.y > player.transform.position.y){
                foreach (SpriteRenderer s in sprites){
                    s.sortingOrder = frontSorting;
                }

            }else{
                foreach (SpriteRenderer s in sprites){
                    s.sortingOrder = behindSorting;
                }
            }
        }
    }

}
