using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 0f;
    public int xDirection = 1;
    public int yDirection = 1;

    private Transform _componentTransform;
    private SpriteRenderer _componentSpriteRenderer;
    private Rigidbody2D _componentRigidbody2D;

    void Awake()
    {
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
        _componentTransform = GetComponent<Transform>();
        _componentSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Inicializa la velocidad del personaje
        _componentRigidbody2D.velocity = new Vector2(xDirection * speed, yDirection * speed);
    }

    void FixedUpdate()
    {
        // Mantiene la velocidad y dirección actual del personaje
        _componentRigidbody2D.velocity = new Vector2(xDirection * speed, yDirection * speed);
    }

    void Update()
    {
        _componentTransform.Rotate(0, 0, 0 * Time.deltaTime);
    }

    // Detecta colisiones con los bordes y cambia la dirección
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bloque abajo" || collision.gameObject.name == "bloque arriba")
        {
            yDirection *= -1;
            _componentSpriteRenderer.flipY = !_componentSpriteRenderer.flipY;
        }

        if (collision.gameObject.name == "bloque izquierdo" || collision.gameObject.name == "bloque derecho")
        {
            xDirection *= -1;
            _componentSpriteRenderer.flipX = !_componentSpriteRenderer.flipX;
        }

        _componentRigidbody2D.velocity = new Vector2(xDirection * speed, yDirection * speed);

        // Mensaje en la consola al chocar con un muro
        Debug.Log("Hola muro");
    }

    // Detecta cuando deja de colisionar con el muro
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Mensaje en la consola al salir del muro
        Debug.Log("Adios muro");
    }
}




