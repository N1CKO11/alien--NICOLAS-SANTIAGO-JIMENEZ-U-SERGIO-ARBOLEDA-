using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRigth;
    [SerializeField] GameManager gm;
    float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxX = esquinaInDer.x;
        minX = esquinaInIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRigth)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }
        if (transform.position.x > maxX-0.4f)
        {
            movingRigth = false;
        }
        else if (transform.position.x < minX+0.4f)
        {
            movingRigth = true;
        }

 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Disparo"))
        {
            gm.reducirnumenemigos();
            Destroy(this.gameObject);
        }
    }
}
