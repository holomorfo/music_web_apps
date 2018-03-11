using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Tonalidad
{
    //public float[] notasTonalidad;
    // public Tonalidad doMRef;
    public List<float> notasArmadura;
    public string tipoModificador; // b: bemol, s: sostenido, n: natural, c: cancelar
    public List<float> notasTonalidad;
    public float baseEsc;
    public string tipoEsc;
    DefEscalasAcordes defEscAcordes;
    public List<Armonia> listArms;

    public Tonalidad() { }

    public Tonalidad(float bas, string tipo)
    {
        //     doMRef = new Tonalidad(0, "M");
        float[] mayor = { 0, 2, 4, 5, 7, 9, 11 };
        //        float[] menArm = { 0, 2, 3, 5, 7, 8, 11 };
        float[] menArm = { 0, 2, 3, 5, 7, 8, 10 };

        //notasTonalidad = new float[12];
        notasTonalidad = new List<float>();
        baseEsc = bas;
        switch (tipo)
        {
            case "M":
                for (int i = 0; i < mayor.Length; i++)
                {
                    // notasTonalidad[i] = (baseEsc + mayor[i]) % 12;
                    notasTonalidad.Add((baseEsc + mayor[i]) % 12);
                }
                break;

            case "m":
                for (int i = 0; i < menArm.Length; i++)
                {
                    //notasTonalidad[i] = (baseEsc + menArm[i]) % 12;
                    notasTonalidad.Add((baseEsc + menArm[i]) % 12);
                }
                break;
        }
        tipoEsc = tipo;
        defEscAcordes = new DefEscalasAcordes(baseEsc, tipo);
        listArms = defEscAcordes.armsList;
        setTipoArmadura();
    }

    public void setTipoArmadura()
    {
        notasArmadura = new List<float>();
        // CM - Am
        if ((baseEsc == 0 && tipoEsc.Equals("M")) || (baseEsc == 9 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>();
            tipoModificador = "s";
        }
        // C#M (DbM) - bb a#m
        else if ((baseEsc == 1 && tipoEsc.Equals("M")) || (baseEsc == 10 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1, 8, 3, 10, 5, 0 });
            tipoModificador = "s";
        }
        // DM - bm
        else if ((baseEsc == 2 && tipoEsc.Equals("M")) || (baseEsc == 11 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1 });
            tipoModificador = "s";
        }
        // (D#)EbM - cm 
        else if ((baseEsc == 3 && tipoEsc.Equals("M")) || (baseEsc == 0 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 10, 3, 8 });
            tipoModificador = "b";
        }
        // EM - c#m
        else if ((baseEsc == 4 && tipoEsc.Equals("M")) || (baseEsc == 1 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1, 8, 3 });
            tipoModificador = "s";
        }
        // FM - dm
        else if ((baseEsc == 5 && tipoEsc.Equals("M")) || (baseEsc == 2 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 10 });
            tipoModificador = "b";
        }
        // (GbM)F#M - eb d#m
        else if ((baseEsc == 6 && tipoEsc.Equals("M")) || (baseEsc == 3 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1, 8, 3, 10, 5, });
            tipoModificador = "b";
        }
        // GM - em
        else if ((baseEsc == 7 && tipoEsc.Equals("M")) || (baseEsc == 4 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6 });
            tipoModificador = "s";
        }
        // (G#M)AbM - fm
        else if ((baseEsc == 8 && tipoEsc.Equals("M")) || (baseEsc == 5 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 10, 3, 8, 1 });
            tipoModificador = "b";
        }
        // AM - f#m
        else if ((baseEsc == 9 && tipoEsc.Equals("M")) || (baseEsc == 6 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1, 8 });
            tipoModificador = "s";
        }
        // (A#M)BbM - gm
        else if ((baseEsc == 10 && tipoEsc.Equals("M")) || (baseEsc == 7 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 10, 3 });
            tipoModificador = "b";
        }
        // (CbM)BM - g# abm
        else if ((baseEsc == 11 && tipoEsc.Equals("M")) || (baseEsc == 8 && tipoEsc.Equals("m")))
        {
            notasArmadura = new List<float>(new float[] { 6, 1, 8, 3, 10 });
            tipoModificador = "s";
        }

        //foreach (float f in notasArmadura)
        //{
        //    Debug.Log("Armadura: " + f);
        //}
    }

    //// Necesito un metodo que dada una nota MIDI, me diga si tengo que ponerle, Natural, sostenido, bemol o cancelar.
    //public string simboloDeNota(float nota)
    //{
    //    string reg = "n";
    //    bool cond = false;
    //    // int indice = -1;
    //    // Si pertenece directo a la tonalidad, es natural
    //    if (perteneceNota(nota))
    //    {
    //        reg = "n";
    //    }
    //    else
    //    {
    //        // Ver si el indice de la nota
    //        // es igual a algun indice de la armadura
    //        foreach (float ind in notasArmadura)
    //        {
    //            if (indiceNota(ind) == indiceNota(nota % 12))
    //            {
    //                cond = true;
    //                break;
    //            }
    //        }
    //        if (cond)
    //        {
    //            reg = "c";
    //        }
    //        else
    //        {
    //            reg = tipoModificador;
    //        }
    //    }
    //    return reg;
    //    // Si no pertenece a la tonalidad
    //    //      buscar si es tonalidad sostenida o bemol
    //    //      buscar el indice al que pertenece
    //    //       si el indice al que pertenece está en la armadura
    //    //              poner cancelar
    //    //       si no, 
    //    //              poner sostenido o bemol segun el caso.    
    //}

    public float porcentajeNotas(List<float> listaNotas)
    {
        int numNotas = 0;
        for (int i = 0; i < listaNotas.Count; i++)
        {
            if (perteneceNota(listaNotas[i]))
            {
                numNotas++;
            }
        }
        float reg = (float)numNotas / listaNotas.Count;
        return reg;
    }

    public bool perteneceNota(float notaAc)
    {
        bool cond = false;
        int cosa = notasTonalidad.IndexOf(notaAc % 12);
        if (cosa > -1)
        {
            cond = true;
        }
        return cond;
    }

    public bool perteneceListaNotas(List<float> notasLista)
    {
        bool cond = false;
        if (porcentajeNotas(notasLista) == 1)
        {
            cond = true;
        }
        return cond;
    }

    public float gradoNota(float notaAc)
    {
        float reg = -1;
        float grad = notasTonalidad.IndexOf(notaAc % 12);
        if (grad > -1)
        {
            reg = grad + 1;
        }
        return reg;
    }

    public string getTipoTriada(int grado)
    {
        string str = "";
        string[] mayor = { "M", "m", "m", "M", "M", "m", "o" };
        string[] menor = { "m", "o", "+", "m", "M", "M", "o" };
        switch (tipoEsc)
        {
            case "M":
                str = mayor[grado % notasTonalidad.Count];
                break;
            case "m":
                str = menor[grado % notasTonalidad.Count];
                break;
        }
        return str;
    }

    public int distancia(Tonalidad ton)
    {
        int cuantosIgual = 0;
        if (notasTonalidad.Count == ton.notasTonalidad.Count)
        {
            for (int i = 0; i < notasTonalidad.Count; i++)
            {
                for (int j = 0; j < ton.notasTonalidad.Count; j++)
                {
                    if (notasTonalidad[i] == ton.notasTonalidad[j])
                    {
                        cuantosIgual++;
                        break;
                    }
                }
            }
        }
        return (notasTonalidad.Count - cuantosIgual);
    }

    public int indicePentagramaDiatonico(float num)
    {
        int indice = 0;
        // El indice es el grado, tal cual.
        if (perteneceNota(num))
        {
            indice = (int)gradoNota(num); // solo revisa si está en el array de notas
        }
        else
        {
            // El problema es calcular el indice de las notas que no están en la tonalidad
            // Depende si es sostenido o bemol

        }

        return indice;
    }

    public int indicePentagrama(float num)
    {
        int indice = -1;
        int grado = -1;
        int oct = (int)(num / 12);
        float num12 = MatematicasOper.mod(num, 12);

        //doMRef.
        // Buscar si la nota pertenece a Do Mayor
        if (perteneceNota(num12))
        {
            // Si pertenece, su indice es su grado mas octava. fin
            indice = (int)gradoNota(num12) + 7 * oct;
        }
        else
        {
            // Si no pertenece, hay que buscar si es sostenido o bemol la tonalidad
            if (tipoModificador.Equals("s"))
            {
                // Necesito buscar la nota más cercana abajo de ella
                switch ((int)num12)
                {
                    case 0:
                        grado = 0;
                        break;
                    case 1:
                        grado = 0;
                        break;
                    case 2:
                        grado = 1;
                        break;
                    case 3:
                        grado = 1;
                        break;
                    case 4:
                        grado = 2;
                        break;
                    case 5:
                        grado = 3;
                        break;
                    case 6:
                        grado = 3;
                        break;
                    case 7:
                        grado = 4;
                        break;
                    case 8:
                        grado = 4;
                        break;
                    case 9:
                        grado = 5;
                        break;
                    case 10:
                        grado = 5;
                        break;
                    case 11:
                        grado = 6;
                        break;
                }
                indice = 1 + grado + 7 * oct;
            }
            else
            {
                // Necesito buscar la nota más cercana arriba de ella
                // Necesito buscar la nota más cercana abajo de ella
                switch ((int)num12)
                {
                    case 0:
                        grado = 0;
                        break;
                    case 1:
                        grado = 1;
                        break;
                    case 2:
                        grado = 1;
                        break;
                    case 3:
                        grado = 2;
                        break;
                    case 4:
                        grado = 2;
                        break;
                    case 5:
                        grado = 3;
                        break;
                    case 6:
                        grado = 4;
                        break;
                    case 7:
                        grado = 4;
                        break;
                    case 8:
                        grado = 5;
                        break;
                    case 9:
                        grado = 5;
                        break;
                    case 10:
                        grado = 6;
                        break;
                    case 11:
                        grado = 0;
                        break;
                }
                indice = 1 + grado + 7 * oct;

            }
        }
        return indice;
    }

    /**
   * Revisa si un numero nota es elemento de la escala, y que
   * indice tendria. Si no pertenece toma el anterior o siguiente dependiendo
   * si la escala usa bemoles o sostenidos.
   * Cuidado con las escalas menores.
   *
     * El indice siempre es con respecto a Do mayor, para tener el pentagrama
   * @param num
   * @return
   */

    public string indiceTabla(float num)
    {
        int diferencia = (int)num % 12 - (int)this.baseEsc;
        int oct;
        num = num - (int)this.baseEsc;
        int valor = -1;
        string modific = "";
        oct = (int)(num / 12);
        string reg = "";
        List<string> mayores = new List<string>();
        //CM
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        //C#M // CAMBIAR ESTE POR OTRO BEMOL
        mayores.Add("0n,1c,1n,2c,2n,3n,4c,4n,5c,5n,6c,6n");
        // DM
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,4s,5n,6c,6n");
        // EbM
        mayores.Add("0n,0c,1n,2b,2n,3n,3c,4n,4c,5n,6b,6n");
        // EM
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,4s,5n,6c,6n ");
        // FM
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        // GbM
        mayores.Add("0n,0c,1n,1c,2n,3n,3c,4n,4c,5n,5c,6n");
        // GM        
        mayores.Add("0n,0s,1n,1s,2n,3n,3s,4n,4s,5n,5s,6n");
        // AbM        
        mayores.Add("0n,0c,1n,1c,2n,3n,3c,4n,4c,5n,6b,6n");
        // AM        
        mayores.Add("0n,0s,1n,1s,2n,3n,3s,4n,4s,5n,6c,6n");
        // BbM        
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        // BM        
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,5c,5n,6c,6n");

        List<string> menores = new List<string>();
        //Cm
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,5c,6n,6c");
        //C#m
        menores.Add("0n,1c,1n,2n,2s,3n,4c,4n,5n,5s,6n,6s");
        //DM
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,5c,6n,7b");
        //EBm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //Em
        menores.Add("0n,0s,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");
        //Fm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //F#m
        menores.Add("0n,1c,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");
        //Gm
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,6b,6n,7b");
        //G#m
        menores.Add("0n,1c,1n,2n,2s,3n,4c,4n,5n,5s,6n,7c");
        //Am
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,6b,6n,7b");
        //Bbm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //Bm
        menores.Add("0n,0s,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");

        int[] sumarBase = { 0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6 };
        int[] sumarBaseMen = { 0, 0, 1, 2, 2, 3, 3, 4, 4, 5, 6, 6 };

        if (this.tipoEsc.Equals("M"))
        {// Do Mayor
            string[] ind = mayores[(int)this.baseEsc].Split(',');
            reg = ind[(int)(num) % 12];
            valor = Int32.Parse("" + reg[0]) + 1 + 7 * oct + sumarBase[(int)this.baseEsc];
            modific = "" + reg[1];
        }
        else
        {
            string[] ind = menores[(int)this.baseEsc].Split(',');
            reg = ind[(int)(num) % 12];
            valor = Int32.Parse("" + reg[0]) + 1 + 7 * oct + sumarBaseMen[(int)this.baseEsc];
            modific = "" + reg[1];
        }
        //
        return "" + valor + "," + modific;

    }

    public string indiceTablaSring(float num)
    {
        int diferencia = (int)num % 12 - (int)this.baseEsc;
        int oct;
        num = num - (int)this.baseEsc;
        int valor = -1;
        string modific = "";
        oct = (int)(num / 12);
        string reg = "";
        List<string> mayores = new List<string>();
        //CM
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        //C#M // CAMBIAR ESTE POR OTRO BEMOL
        mayores.Add("0n,1c,1n,2c,2n,3n,4c,4n,5c,5n,6c,6n");
        // DM
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,4s,5n,6c,6n");
        // EbM
        mayores.Add("0n,0c,1n,2b,2n,3n,3c,4n,4c,5n,6b,6n");
        // EM
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,4s,5n,6c,6n ");
        // FM
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        // GbM
        mayores.Add("0n,0c,1n,1c,2n,3n,3c,4n,4c,5n,5c,6n");
        // GM        
        mayores.Add("0n,0s,1n,1s,2n,3n,3s,4n,4s,5n,5s,6n");
        // AbM        
        mayores.Add("0n,0c,1n,1c,2n,3n,3c,4n,4c,5n,6b,6n");
        // AM        
        mayores.Add("0n,0s,1n,1s,2n,3n,3s,4n,4s,5n,6c,6n");
        // BbM        
        mayores.Add("0n,1b,1n,2b,2n,3n,4b,4n,5b,5n,6b,6n");
        // BM        
        mayores.Add("0n,0s,1n,2c,2n,3n,3s,4n,5c,5n,6c,6n");

        List<string> menores = new List<string>();
        //Cm
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,5c,6n,6c");
        //C#m
        menores.Add("0n,1c,1n,2n,2s,3n,4c,4n,5n,5s,6n,6s");
        //DM
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,5c,6n,7b");
        //EBm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //Em
        menores.Add("0n,0s,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");
        //Fm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //F#m
        menores.Add("0n,1c,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");
        //Gm
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,6b,6n,7b");
        //G#m
        menores.Add("0n,1c,1n,2n,2s,3n,4c,4n,5n,5s,6n,7c");
        //Am
        menores.Add("0n,1b,1n,2n,3b,3n,4b,4n,5n,6b,6n,7b");
        //Bbm
        menores.Add("0n,1b,1n,2n,2c,3n,3c,4n,5n,5c,6n,6c");
        //Bm
        menores.Add("0n,0s,1n,2n,2s,3n,3s,4n,5n,5s,6n,6s");

        int[] sumarBase = { 0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6 };
        int[] sumarBaseMen = { 0, 0, 1, 2, 2, 3, 3, 4, 4, 5, 6, 6 };

        if (this.tipoEsc.Equals("M"))
        {// Do Mayor
            string[] ind = mayores[(int)this.baseEsc].Split(',');
            reg = ind[(int)(num) % 12];
            // Aqui cambiar por nombre del índice
            valor = Int32.Parse("" + reg[0]) + 1 + 7 * oct + sumarBase[(int)this.baseEsc];
            modific = "" + reg[1];
        }
        else
        {
            string[] ind = menores[(int)this.baseEsc].Split(',');
            reg = ind[(int)(num) % 12];
            valor = Int32.Parse("" + reg[0]) + 1 + 7 * oct + sumarBaseMen[(int)this.baseEsc];
            modific = "" + reg[1];
        }
        //
        return "" + valor + "," + modific;

    }
    //public int indiceNota(float num)
    //{
    //    // AQUI IMPORTA SI ES BEMOL O SOSTENIDO A PARTE DE MAYOR
    //    // necesito que me de el numero de linea de pentagrama de la nota
    //    // es decir, que indice le toca en do mayor, con que modificador
    //    int grado = 0;
    //    int oct;
    //    float numRel = num - this.baseEsc;
    //    //        float numRel = num ;

    //    float numRel12 = MatematicasOper.mod(numRel, 12);
    //    oct = (int)(numRel / 12);
    //    grado = calcularIntervaloDiat((int)numRel12);
    //    //        if (this.baseEsc != 0) {
    //    //            oct++;
    //    //        }
    //    int indice = grado + 7 * oct;
    //    // CORRECCIONES CUCHARERAS =P
    //    if (this.baseEsc == 9 & this.tipoEsc.Equals("M"))
    //    {// Corregir escala solib mayor
    //        indice--;
    //    }

    //    //if (this.baseEsc == 10 & this.tipoEsc.Equals("M"))
    //    //{// Corregir escala sibmayor
    //    //    indice++;
    //    //}
    //    //if (this.baseEsc == 8 & this.tipoEsc.Equals("M"))
    //    //{// Corregir escala labmayor
    //    //    indice++;
    //    //}
    //    //if (this.baseEsc == 1 & this.tipoEsc.Equals("M"))
    //    //{// Corregir escala rebmayor
    //    //    indice++;
    //    //}
    //    //if (this.baseEsc == 3 & this.tipoEsc.Equals("M"))
    //    //{// Corregir escala mibmayor
    //    //    indice++;
    //    //}
    //    //if (this.baseEsc == 10 & this.tipoEsc.Equals("m"))
    //    //{// Corregir escala labmenor
    //    //    indice++;
    //    //}
    //    // Aqui se le debe sumar el intervalo que tiene con respecto a do mayor
    //    return indice + 1 + calcularIntervaloDiat((int)this.baseEsc);
    //}

    int calcularIntervaloDiat(int num)
    {
        int numRel12 = num % 12;
        int grado = -1;
        if (this.tipoEsc.Equals("M"))
        {
            if (tipoModificador.Equals("s"))
            {
                switch ((int)numRel12)
                {
                    case 0:
                        grado = 0;
                        break;
                    case 1:
                        grado = 0;
                        break;
                    case 2:
                        grado = 1;
                        break;
                    case 3:
                        grado = 1;
                        break;
                    case 4:
                        grado = 2;
                        break;
                    case 5:
                        grado = 3;
                        break;
                    case 6:
                        grado = 3;
                        break;
                    case 7:
                        grado = 4;
                        break;
                    case 8:
                        grado = 4;
                        break;
                    case 9:
                        grado = 5;
                        break;
                    case 10:
                        grado = 5;
                        break;
                    case 11:
                        grado = 6;
                        break;
                }
            }
            else
            {
                //Bemol
                switch ((int)numRel12)
                {
                    case 0:
                        grado = 0;
                        break;
                    case 1:
                        grado = 1;
                        break;
                    case 2:
                        grado = 1;
                        break;
                    case 3:
                        grado = 2;
                        break;
                    case 4:
                        grado = 2;
                        break;
                    case 5:
                        grado = 3;
                        break;
                    case 6:
                        grado = 4;
                        break;
                    case 7:
                        grado = 4;
                        break;
                    case 8:
                        grado = 5;
                        break;
                    case 9:
                        grado = 5;
                        break;
                    case 10:
                        grado = 6;
                        break;
                    case 11:
                        grado = 6;
                        break;
                }
            }
        }
        else if (this.tipoEsc.Equals("m"))
        {
            switch ((int)numRel12)
            {
                case 0:
                    grado = 0;
                    break;
                case 1:
                    grado = 0;
                    break;
                case 2:
                    grado = 1;
                    break;
                case 3:
                    grado = 2;
                    break;
                case 4:
                    grado = 2;
                    break;
                case 5:
                    grado = 3;
                    break;
                case 6:
                    grado = 3;
                    break;
                case 7:
                    grado = 4;
                    break;
                case 8:
                    grado = 5;
                    break;
                case 9:
                    grado = 5;
                    break;
                case 10:
                    grado = 6;
                    break;
                case 11:
                    grado = 6;
                    break;
            }
        }
        return grado;
    }

    /**
 * Funcion que le asigna un numero a cada nota de la escala, utilizando
 * sostenidos. Consiste de siete octavas.
 * Debe poner bemoles o sostenidos de acuerdo a que tipo de escala.
 *
 * @param d
 * @return
 */
    public string num2nota12(float d)
    {
        Tonalidad esc = this;
        // 21= A0, 108 = C8
        // 21=12+9;
        // Ver que clase de nota es modulo 12;

        float mod = MatematicasOper.mod(d, 12);
        // Corregir de acuerdo |a bemoles o sostenidos
        string nota = "";
        string comita = "" + (char)(39);

        if ((esc.tipoEsc.Equals("M")
                & (esc.baseEsc == 0 || esc.baseEsc == 7
                || esc.baseEsc == 2 || esc.baseEsc == 9
                || esc.baseEsc == 4 || esc.baseEsc == 11))
                || (esc.tipoEsc.Equals("m")
                & (esc.baseEsc == 9 || esc.baseEsc == 4
                || esc.baseEsc == 11 || esc.baseEsc == 6
                || esc.baseEsc == 1 || esc.baseEsc == 8)))
        {

            switch ((int)mod)
            {
                case 0:
                    nota += "c";
                    break;
                case 1:
                    nota += "c#";
                    break;
                case 2:
                    nota += "d";
                    break;
                case 3:
                    nota += "d#";
                    break;
                case 4:
                    nota += "e";
                    break;
                case 5:
                    nota += "f";
                    break;
                case 6:
                    nota += "f#";
                    break;
                case 7:
                    nota += "g";
                    break;
                case 8:
                    nota += "g#";
                    break;
                case 9:
                    nota += "a";
                    break;
                case 10:
                    nota += "a#";
                    break;
                case 11:
                    nota += "b";
                    break;
                //default:
                //    nota += "";
            }
        }
        else
        {
            if ((esc.tipoEsc == "M"
                    & (esc.baseEsc == 6 || esc.baseEsc == 1
                    || esc.baseEsc == 8 || esc.baseEsc == 3
                    || esc.baseEsc == 10 || esc.baseEsc == 5))
                    || ((esc.tipoEsc.Equals("m")
                    & (esc.baseEsc == 3 || esc.baseEsc == 10
                    || esc.baseEsc == 5 || esc.baseEsc == 0
                    || esc.baseEsc == 7 || esc.baseEsc == 2))))
            {
                switch ((int)mod)
                {
                    case 0:
                        nota += "c";
                        break;
                    case 1:
                        nota += "db";
                        break;
                    case 2:
                        nota += "d";
                        break;
                    case 3:
                        nota += "eb";
                        break;
                    case 4:
                        nota += "e";
                        break;
                    case 5:
                        nota += "f";
                        break;
                    case 6:
                        nota += "gb";
                        break;
                    case 7:
                        nota += "g";
                        break;
                    case 8:
                        nota += "ab";
                        break;
                    case 9:
                        nota += "a";
                        break;
                    case 10:
                        nota += "bb";
                        break;
                    case 11:
                        nota += "b";
                        break;
                    //default:
                    //    nota += "";
                }
            }
        }
        return nota;
    }


    public void imprimir()
    {
        string str = "";
        for (int i = 0; i < notasTonalidad.Count; i++)
        {
            str += notasTonalidad[i] + ",";
        }
        Debug.Log("Fund: " + baseEsc + " tipo: " + tipoEsc);
        Debug.Log(str);
    }

}
