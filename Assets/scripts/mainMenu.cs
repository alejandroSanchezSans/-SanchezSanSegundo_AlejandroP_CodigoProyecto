using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
   
    public void volverAMenu()
    {
        SceneManager.LoadScene("mainMenu");

    }
    public void cargarMesa1()
    {
        SceneManager.LoadScene("mesaBasica");

    }
    public void cargarMesa2()
    {
        SceneManager.LoadScene("mesaMedia");

    }
    public void cargarMesa3()
    {
        SceneManager.LoadScene("mesaExperto");

    }
    public void cargarLogin()
    {

        SceneManager.LoadScene("escenaLogin");
    }

    public void cargarOpcionesLogged() {

        SceneManager.LoadScene("cargarOpcionesLogged");
    }
    public void cargarmesaFree()
    {

        SceneManager.LoadScene("mesaBasicaFree");
    }
    public void salir()
    {

        Application.Quit();
    }

}
