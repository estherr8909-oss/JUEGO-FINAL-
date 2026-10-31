using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    public Transform groundCheck;

    public float radio = 0.2f;

    public LayerMask suelo;

    private Rigidbody2D rb;

    private bool enSuelo;
    public TextMeshProUGUI puntosUI;
    public int puntos;

    private GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip sonidoSalto;
    public AudioSource audioEstrella;
    public ControladorEstrellas controladorEstrellas;

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        puntosUI.text = "puntos: " + puntos;
    }

    public void RestarPunto(int cantidad)
    {  
        puntos -= cantidad;
        if(puntos <0 )
        {
            puntos = 0;
        }
        puntosUI.text = "puntos: " + puntos;
    }
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        controladorEstrellas = FindAnyObjectByType<ControladorEstrellas>();
    }



    // puntaje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Estrella"))
        {
            gameManager.RecolectarEstrella();
            controladorEstrellas.ActivarEstrella();
            Destroy(collision.gameObject);  
        }

        if (collision.gameObject.GetComponent<Estrellas>())
        {
            puntos ++;
            puntosUI.text ="puntos:" + puntos;
            audioEstrella.Play();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<EnemigoPiedra>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.GetComponent<Enemigo2>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.GetComponent<Puas>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.GetComponent<Dinosaurio>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
      
    }

    void Update()
    {

        if (transform.position.y < -11)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Detecta el suelo
        enSuelo = Physics2D.OverlapCircle(
            groundCheck.position,
            radio,
            suelo
        );

        float mover = 0f;

        // Izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mover = -1f;
            transform.localScale = new Vector3(-2, 2, 1);
        }

        // Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mover = 1f;
            transform.localScale =  new Vector3(2 , 2, 1);
        }

        // Movimiento
        rb.linearVelocity = new Vector2(
            mover * velocidad,
            rb.linearVelocity.y
        );

        // Salto
        if (Input.GetKeyDown(KeyCode.Z) && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            
            );
            audioSource.PlayOneShot(sonidoSalto);



        }
    }
}