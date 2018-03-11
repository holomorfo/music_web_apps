using UnityEngine;
using System.Collections;

public class CoordenadaTonal
{
    // Quizá cambiar por Tonalidad
    public int escala = 0, grado = 0;
    public string tipo = "M", etq = "-";

    public CoordenadaTonal() { }

    public CoordenadaTonal(int esc, string tp, int gra)
    {
        escala = esc;
        grado = gra;
        tipo = tp;
    }

    public void setRegion(int esc, string tp, int gra)
    {
        escala = esc;
        grado = gra;
        tipo = tp;
    }

    public void imprimir()
    {
        Debug.Log("Escala " + escala + " " + tipo
            + " grado: " + grado + " Etq " + etq);
    }
}
