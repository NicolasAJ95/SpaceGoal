using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasMenu, canvasNiveles, canvasCreditos;
    Animator animMenu, animNiveles, animCreditos;

    void Start()
    {
        animMenu = canvasMenu.GetComponent<Animator>();
        animNiveles = canvasNiveles.GetComponent<Animator>();
        animCreditos = canvasCreditos.GetComponent<Animator>();
    }

    public void Fade (string nombreCanvas)
    {
        if (nombreCanvas == "Creditos")
        {
            if (animCreditos.GetBool("Fade") == false)
                animCreditos.SetBool("Fade", true);
            else if (animCreditos.GetBool("Fade") == true)
                animCreditos.SetBool("Fade", false);
        }
        if (nombreCanvas == "Niveles")
        {
            if (animNiveles.GetBool("Fade") == false)
                animNiveles.SetBool("Fade", true);
            else if (animNiveles.GetBool("Fade") == true)
                animNiveles.SetBool("Fade", false);
        }
    }
}
