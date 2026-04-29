// ControladorPosta.cs
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    public Corredor corredor1;
    public Corredor corredor2;
    public Corredor corredor3;
    public Corredor corredor4;
    public float velocidad = 10f;
    public Vector3[] posiciones = new Vector3[]
    {
        new Vector3(-8f,  4f, 0f),
        new Vector3( 8f,  4f, 0f),
        new Vector3( 8f, -4f, 0f),
        new Vector3(-8f, -4f, 0f)
    };
    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidad = nuevaVelocidad;
    }
    public void Posicionarse()
    {
        corredor1.posicionActual = corredor1.posicionInicial;
        corredor2.posicionActual = corredor2.posicionInicial;
        corredor3.posicionActual = corredor3.posicionInicial;
        corredor4.posicionActual = corredor4.posicionInicial;

        corredor1.IrAlPunto(posiciones[corredor1.posicionInicial]);
        corredor2.IrAlPunto(posiciones[corredor2.posicionInicial]);
        corredor3.IrAlPunto(posiciones[corredor3.posicionInicial]);
        corredor4.IrAlPunto(posiciones[corredor4.posicionInicial]);
    }

    public void Correr()
    {
        PasarAlSiguiente(corredor1);
    }

    public void PasarAlSiguiente(Corredor corredor)
    {
        int siguiente = corredor.posicionActual + 1;

        if (siguiente >= posiciones.Length)
            siguiente = 0;

        corredor.posicionActual = siguiente;
        corredor.IrAlPunto(posiciones[siguiente]);
    }
}