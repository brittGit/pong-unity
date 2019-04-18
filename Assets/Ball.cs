using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 30;
    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

   float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight){
        //1 at top of racket
        //0 at middle of racket
        //-1 at bottom of racket

        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        //col holds colision information, 
        //col.gameObject is the racket
        //col.transform.position is the rackets position
        //col.collider is the rackets collider

        //hit left racket?
        if (col.gameObject.name == "RacketLeft") {
            //calculate hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            //calculate direction, make length = 1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            //set velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //hit right racket?
        if (col.gameObject.name == "RacketRight") {
            //calculatr hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            //calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            //set velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

 
}
