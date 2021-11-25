using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverAJugar() {
        SceneManager.LoadScene("Agua y Tierra");
    }

    public void EmpezarAJugar() {
        SceneManager.LoadScene("Agua y Tierra");
    }

    public void SalirDelJuego() {
        Application.Quit();
    }

    public void IrAlMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Perder() {
        SceneManager.LoadScene("Perder");
}
}