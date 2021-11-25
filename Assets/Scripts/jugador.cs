using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jugador : MonoBehaviour
{

    Rigidbody rig;
    public float speed = 1;
    public float jumpForce = 1;
    public Transform cam;
    public float enemies = 3;
    public GameObject bolaDeFuego;
    public AudioClip sonidoGanar;
    public AudioClip sonidoPerder;
    AudioSource audioSource;
    public float gunSpeed = 1; bool chasingPlayer = false;
    public Transform player;
    public float vida = 5;
    jugador playerScript;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Disparar();
        }

        Vector3 pos = Input.mousePosition;
        pos.z = 20;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = transform.position.y;

        transform.LookAt(pos);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rig.velocity = transform.forward * vertical * speed + transform.right * horizontal * speed + new Vector3(0, rig.velocity.y, 0);

        if(Input.GetKeyDown(KeyCode.Space)) {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y + jumpForce, rig.velocity.z);
        }

        cam.position = Vector3.Lerp(cam.position,new Vector3(transform.position.x,cam.position.y,transform.position.z),1);
    }

     // Funcion para disparar bolas de fuego
    void Disparar() {
        // Crear la instancia de la bola de fuego
        GameObject nuevaBolaDeFuego = Instantiate(bolaDeFuego, transform.position + transform.forward, new Quaternion(0,0,0,0));
        // Se guarda el rgid body de objeto nuevo para poder utilizarlo
        Rigidbody bolaDeFuegoRig = nuevaBolaDeFuego.transform.GetComponent<Rigidbody>();
        // Se le asigna una nueva velocidad a la bola de fuego
        bolaDeFuegoRig.velocity = transform.forward * gunSpeed;
        // Destruir despues de 3 segundos
        Destroy(nuevaBolaDeFuego, 3);
    }

    public void EnemigoMuerto() {
        enemies -= 1;

        // Se usa StartCoroutine cuando la funcion es un IEnumerator
        if(enemies <= 0) StartCoroutine(Ganar());
    }

    // IEnumerator me funciona cuando necesito esperar un tiempo para ejecutar alguna instruccion
    IEnumerator Ganar () {
        
        audioSource.clip = sonidoGanar;
        audioSource.Play();

        // Esta instruccion hace que el codigo espere 5 segundos para ejecutar las instrucciones que le siguen
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Ganar");
    }

    // IEnumerator me funciona cuando necesito esperar un tiempo para ejecutar alguna instruccion
    public IEnumerator Perder () {
        
        audioSource.clip = sonidoPerder;
        audioSource.Play();

        // Esta instruccion hace que el codigo espere 5 segundos para ejecutar las instrucciones que le siguen
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Perder");
    }
}