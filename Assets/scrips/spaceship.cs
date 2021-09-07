using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject rafaga;
    [SerializeField] int reducinumenemigos;
    [SerializeField] float fireRate;
    public bool gamePaused = false;

    float minX, maxX, minY, maxY;
    float nextFire= 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxX = esquinaSupDer.x;
        maxY = esquinaSupDer.y;
        minX = esquinaInIzq.x;
        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));
        minY = puntoX.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            Mover();
            Disparar();
        }
       


    }
    void Mover()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);
        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);
        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);
        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);
        if (transform.position.y < minY)
            transform.position = new Vector2(transform.position.x, minY);
    }
    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, transform.position - new Vector3(0, 0.2f, 0), transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
   
   
}

