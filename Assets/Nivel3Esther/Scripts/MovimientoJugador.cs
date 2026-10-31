using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Nivel3Esther
{
    public class MovimientoJugador : MonoBehaviour
    {
        [Header("Configuración de Puntuación")]
        public int puntos = 0;
        public TMP_Text puntosUI;
        public AudioSource audioEstrella;

        [Header("Configuración de Movimiento y Salto")]
        public float velocidad = 5f;
        public float fuerzaSalto = 7f;
        public Transform groundCheck;
        public float radio = 0.2f;
        public LayerMask suelo;
        public AudioSource audioSource;
        public AudioClip sonidoSalto;

        private Rigidbody2D rb;
        private bool enSuelo;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (rb == null) return;
            if (Time.timeScale <= 0f)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }
            // Reinicio por caída libre
            if (transform.position.y < -11f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            // Detección de suelo
            if (groundCheck != null)
            {
                // Do not count the player's own collider as ground.
                enSuelo = false;
                if (rb.linearVelocity.y <= 0.1f)
                {
                    Collider2D[] contactos = Physics2D.OverlapCircleAll(groundCheck.position, radio, suelo);
                    foreach (Collider2D contacto in contactos)
                    {
                        if (contacto != null && !contacto.isTrigger &&
                            contacto.attachedRigidbody != rb &&
                            !contacto.transform.IsChildOf(transform))
                        {
                            enSuelo = true;
                            break;
                        }
                    }
                }
            }

            float mover = 0f;

            // Movimiento a la izquierda
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                mover = -1f;
                transform.localScale = new Vector3(-2, 2, 1);
            }

            // Movimiento a la derecha
            if (Input.GetKey(KeyCode.RightArrow))
            {
                mover = 1f;
                transform.localScale = new Vector3(2, 2, 1);
            }

            // Aplicar velocidad horizontal
            rb.linearVelocity = new Vector2(mover * velocidad, rb.linearVelocity.y);

            // Salto
            if (Input.GetKeyDown(KeyCode.Z) && enSuelo)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                if (audioSource != null && sonidoSalto != null)
                {
                    audioSource.PlayOneShot(sonidoSalto);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Recolección de estrellas
            if (collision.gameObject.CompareTag("Estrella") || collision.gameObject.GetComponent<Estrellas>())
            {
                puntos++;
                if (puntosUI != null)
                {
                    puntosUI.text = "puntos: " + puntos;
                }
                if (audioEstrella != null)
                {
                    audioEstrella.Play();
                }
                Destroy(collision.gameObject);
            }

            // Impacto con enemigos u obstáculos
            if (collision.gameObject.GetComponent<EnemigoPiedra>() != null ||
                collision.gameObject.GetComponent<Enemigo2>() != null ||
                collision.gameObject.GetComponent<Puas>() != null ||
                collision.gameObject.GetComponent<Dinosaurio>() != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
