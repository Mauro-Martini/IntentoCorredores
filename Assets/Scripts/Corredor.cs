// Corredor.cs
using UnityEngine;
using TMPro;

public class Corredor : MonoBehaviour
{
    public float velocidad = 3f;
    public int posicionActual = 0;
    public int posicionInicial = 0;
    public ControladorPosta controlador;
    public Corredor siguienteCorredor;
    public TextMeshPro textoVueltas;
    private Vector3 destino;
    private bool moverse = false;
    private bool pasarPosta = false;
    private bool yaContado = false;
    private int vueltas = 0;

    public void IrAlPunto(Vector3 punto)
    {
        destino = punto;
        moverse = true;
        pasarPosta = false;
        yaContado = false;
    }

    public void Detener()
    {
        moverse = false;
    }

    void Update()
    {
        if (moverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, controlador.velocidad * Time.deltaTime);

            if (transform.position == destino)
            {
                if (pasarPosta && siguienteCorredor != null)
                {
                    Detener();
                    controlador.PasarAlSiguiente(siguienteCorredor);
                }

                if (posicionActual == posicionInicial && !yaContado)
                {
                    vueltas++;
                    yaContado = true;
                    textoVueltas.text = vueltas.ToString();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (siguienteCorredor != null && otro.gameObject == siguienteCorredor.gameObject)
        {
            pasarPosta = true;
        }
    }
}