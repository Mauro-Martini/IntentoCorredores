// CorredorUI.cs
using UnityEngine;
using UnityEngine.UI;

public class CorredorUI : MonoBehaviour
{
    public ControladorPosta controlador;
    public Slider sliderVelocidad;

    void Start()
    {
        sliderVelocidad.onValueChanged.AddListener(controlador.CambiarVelocidad);
    }

    public void BotonPosicionarse()
    {
        controlador.Posicionarse();
    }

    public void BotonCorrer()
    {
        controlador.Correr();
    }
}