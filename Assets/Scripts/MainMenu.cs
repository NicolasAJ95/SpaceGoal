using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasMenu, canvasNiveles, canvasCreditos;
    Animator animMenu, animNiveles, animCreditos;

    void Start()
    {
        animMenu = canvasMenu.GetComponent<Animator>();
        animNiveles = canvasNiveles.GetComponent<Animator>();
        animCreditos = canvasCreditos.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void CreditosFade (bool fade)
    {
        if (fade)
            animCreditos.SetBool("Fade", true);
        else
            animCreditos.SetBool("Fade", false);
    }
    public void NivelesFade (bool fade)
    {
        if (fade)
            animNiveles.SetBool("Fade", true);
        else
            animNiveles.SetBool("Fade", false);
    }
}
