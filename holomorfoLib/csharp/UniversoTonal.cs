using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniversoTonal
{
    List<Tonalidad> universoMayor;
    List<Tonalidad> universoMenor;
    List<float> porcentajeMayor;
    List<float> porcentajeMenor;
    List<float> porcentajesVector;
    int escActFund;
    string escActTipo;
    //int escActIndice = 0;

    public UniversoTonal()
    {
        escActFund = 0;
        escActTipo = "M";
        // escActIndice = 0;
        universoMayor = new List<Tonalidad>();
        universoMenor = new List<Tonalidad>();

        for (int i = 0; i < 12; i++)
        {
            universoMayor.Add(new Tonalidad(i, "M"));
            //universoMayor[i].imprimir();
        }
        for (int i = 0; i < 12; i++)
        {
            universoMenor.Add(new Tonalidad(i, "m"));
            //universoMenor[i].imprimir();
        }
    }

    public void setEscalaAct(int fund, string tip)
    {
        escActFund = fund;
        escActTipo = tip;
        Debug.Log("Escala actual: " + fund + " " + tip);
    }

    public Tonalidad getEscalaActual()
    {
        Tonalidad esc = new Tonalidad();
        switch (escActTipo)
        {
            case "M":
                esc = universoMayor[escActFund];
                break;
            case "m":
                esc = universoMenor[escActFund];
                break;
        }
        return esc;
    }

    public void cambioEscala(string res)
    {
        // setEscalaAct(0, 'M');
        if (res.Equals("CM"))
        {
            setEscalaAct(0, "M");
        }
        else if (res.Equals("C#M"))
        {
            setEscalaAct(1, "M");
        }
        else if (res.Equals("DM"))
        {
            setEscalaAct(2, "M");
        }
        else if (res.Equals("D#M"))
        {
            setEscalaAct(3, "M");
        }
        else if (res.Equals("EM"))
        {
            setEscalaAct(4, "M");
        }
        else if (res.Equals("FM"))
        {
            setEscalaAct(5, "M");
        }
        else if (res.Equals("F#M"))
        {
            setEscalaAct(6, "M");
        }
        else if (res.Equals("GM"))
        {
            setEscalaAct(7, "M");
        }
        else if (res.Equals("G#M"))
        {
            setEscalaAct(8, "M");
        }
        else if (res.Equals("AM"))
        {
            setEscalaAct(9, "M");
        }
        else if (res.Equals("A#M"))
        {
            setEscalaAct(10, "M");
        }
        else if (res.Equals("BM"))
        {
            setEscalaAct(11, "M");
        }
        if (res.Equals("Cm"))
        {
            setEscalaAct(0, "m");
        }
        else if (res.Equals("C#m"))
        {
            setEscalaAct(1, "m");
        }
        else if (res.Equals("Dm"))
        {
            setEscalaAct(2, "m");
        }
        else if (res.Equals("D#m"))
        {
            setEscalaAct(3, "m");
        }
        else if (res.Equals("Em"))
        {
            setEscalaAct(4, "m");
        }
        else if (res.Equals("Fm"))
        {
            setEscalaAct(5, "m");
        }
        else if (res.Equals("F#m"))
        {
            setEscalaAct(6, "m");
        }
        else if (res.Equals("Gm"))
        {
            setEscalaAct(7, "m");
        }
        else if (res.Equals("G#m"))
        {
            setEscalaAct(8, "m");
        }
        else if (res.Equals("Am"))
        {
            setEscalaAct(9, "m");
        }
        else if (res.Equals("A#m"))
        {
            setEscalaAct(10, "m");
        }
        else if (res.Equals("Bm"))
        {
            setEscalaAct(11, "m");
        }
    }

    public Tonalidad stringToEscala(string res)
    {
        Tonalidad reg = null;
        if (res.Equals("CM"))
        {
            reg = getEscala(0, "M");
        }
        else if (res.Equals("C#M") || res.Equals("DbM"))
        {
            reg = getEscala(1, "M");
        }
        else if (res.Equals("DM"))
        {
            reg = getEscala(2, "M");
        }
        else if (res.Equals("D#M") || res.Equals("EbM"))
        {
            reg = getEscala(3, "M");
        }
        else if (res.Equals("EM"))
        {
            reg = getEscala(4, "M");
        }
        else if (res.Equals("FM"))
        {
            reg = getEscala(5, "M");
        }
        else if (res.Equals("F#M") || res.Equals("GbM"))
        {
            reg = getEscala(6, "M");
        }
        else if (res.Equals("GM"))
        {
            reg = getEscala(7, "M");
        }
        else if (res.Equals("G#M") || res.Equals("AbM"))
        {
            reg = getEscala(8, "M");
        }
        else if (res.Equals("AM"))
        {
            reg = getEscala(9, "M");
        }
        else if (res.Equals("A#M") || res.Equals("BbM"))
        {
            reg = getEscala(10, "M");
        }
        else if (res.Equals("BM"))
        {
            reg = getEscala(11, "M");
        }
        if (res.Equals("Cm"))
        {
            reg = getEscala(0, "m");
        }
        else if (res.Equals("C#m") || res.Equals("Dbm"))
        {
            reg = getEscala(1, "m");
        }
        else if (res.Equals("Dm"))
        {
            reg = getEscala(2, "m");
        }
        else if (res.Equals("D#m") || res.Equals("Ebm"))
        {
            reg = getEscala(3, "m");
        }
        else if (res.Equals("Em"))
        {
            reg = getEscala(4, "m");
        }
        else if (res.Equals("Fm"))
        {
            reg = getEscala(5, "m");
        }
        else if (res.Equals("F#m") || res.Equals("Gbm"))
        {
            reg = getEscala(6, "m");
        }
        else if (res.Equals("Gm"))
        {
            reg = getEscala(7, "m");
        }
        else if (res.Equals("G#m") || res.Equals("Abm"))
        {
            reg = getEscala(8, "m");
        }
        else if (res.Equals("Am"))
        {
            reg = getEscala(9, "m");
        }
        else if (res.Equals("A#m") || res.Equals("Bbm"))
        {
            reg = getEscala(10, "m");
        }
        else if (res.Equals("Bm"))
        {
            reg = getEscala(11, "m");
        }
        return reg;
    }

    public Tonalidad getEscala(int fund, string tip)
    {
        Tonalidad esc = new Tonalidad();
        switch (tip)
        {
            case "M":
                esc = universoMayor[fund];
                break;
            case "m":
                esc = universoMenor[fund];
                break;
            default:
                esc = universoMenor[fund];
                break;
        }
        return esc;
    }

    public List<float> vectorPorcentajes(List<float> listArm)
    {
        porcentajesVector = new List<float>();
        porcentajeMayor = new List<float>();
        porcentajeMenor = new List<float>();
        float porc;
        for (int i = 0; i < 12; i++)
        {
            porc = universoMayor[i].porcentajeNotas(listArm);
            porcentajesVector.Add(porc);
            porcentajeMayor.Add(porc);
        }
        for (int i = 0; i < 12; i++)
        {
            porc = universoMenor[i].porcentajeNotas(listArm);
            porcentajesVector.Add(porc);
            porcentajeMenor.Add(porc);
        }
        return porcentajesVector;
    }

    public int gradoSencillo(Armonia unArm, Tonalidad esc)
    {
        int reg = 0;
        bool cond = false;
        bool napol = false;
        float fund = (-1);
        for (int i = 0; i < esc.listArms.Count; i++)
        {
            if (esc.listArms[i].equivalente(unArm))
            {
                // Revisa si es o7
                if (unArm.tipoDeAcordeStr == "o7")
                {
                    for (int j = 0; j < unArm.notasArmonia.Length; j++)
                    {
                        if (esc.gradoNota(unArm.notasArmonia[j]) == 7)
                        {
                            fund = unArm.notasArmonia[j] % 12;
                            cond = true;
                            //Break
                        }
                    }
                }
                else if (unArm.tipoDeAcordeStr == "M" && esc.tipoEsc=="m" 
                    && MatematicasOper.mod(unArm.Fundamental, 12) == MatematicasOper.mod(esc.baseEsc+1,12))
                {
                    fund = unArm.Fundamental;
                    napol = true;   
                }
                else
                {
                    fund = unArm.Fundamental % 12;
                    cond = true;
                }// Fin IF i7
            }//FIN if equivalente
        }// FIN FOR i
        if (cond)
        {
            reg = (int)esc.gradoNota(fund);
        }
        else
        {
            if (napol)
            {
                reg = 2;
            }
            {
                reg = 0;
            }
        }
        return reg;
    }

    public int gradoSencilloActual(Armonia unArm)
    {
        return gradoSencillo(unArm, getEscalaActual());
    }

    public CoordenadaTonal gradoSecundario(Armonia unArm, Tonalidad escala)
    {
        CoordenadaTonal coor = new CoordenadaTonal();
        float fund = escala.baseEsc;
        string tipo = "M";
        // bool cond = false;
        Tonalidad esc;
        if (this.gradoSencillo(unArm, escala) > 0)
        {
            // Si es acorde de la tonalidad
            coor.setRegion(1, escala.tipoEsc, gradoSencillo(unArm, escala));
        }
        else
        {
            //Debug.Log("Entro 1");
            // Si es dominante de otra escala
            for (int i = 0; i < escala.notasTonalidad.Count; i++)
            {
                //  Debug.Log("Entro 2 " );

                fund = escala.notasTonalidad[i];
                tipo = "" + escala.getTipoTriada(i)[0];
                esc = getEscala((int)fund, tipo);
                // esc.imprimir();
                int grad = gradoSencillo(unArm, esc);
                //Aqui los grados 0-6
                tipo = escala.getTipoTriada(i);
                //Debug.Log(fund+" "+tipo+" "+grad);
                if (grad == 5)
                {
                    //    Debug.Log("Entro 3");
                    coor.setRegion(i + 1, esc.tipoEsc, grad);
                    // AQUI VOY
                }
                if (grad == 7)
                {
                    // FALTA CORREGIR o7
                    //  Debug.Log("Entro 4");
                    // Aqui se revisa si es o7
                    // CUIDADO CON COMPARAR STRINGS
                    if (unArm.tipoDeAcordeStr.Equals("o7"))
                    {
                        for (int j = 0; j < unArm.notasArmonia.Length; j++)
                        {
                            if (esc.gradoNota(unArm.notasArmonia[j]) == 7)
                            {
                                coor.setRegion(i + 1, esc.tipoEsc, grad);
                                break;
                            }
                        }
                    }
                }
            }
        }
        return coor;
    }

    public CoordenadaTonal gradoSecundarioEscAct(Armonia unArm)
    {
        // Antes solo revisaba si el acorde era uno de los diatonicos
        // ahora puedo revisar todas las escalas, pero no se si quiero eso..
        // creo que mejor reviso sâˆ‘olo las diatonicas, es cuestion de llamar
        // a los indices correctos.
        // Revisar si unArm es equivalente a alguno de los acordes de la lista
        // y si es asi, ver que grado es la fundamental

        return gradoSecundario(unArm, getEscalaActual());
    }

    /**
     * Regresa el grado romano de la nota, 0 si no pertenece, usando propiedades
    * de indexOf En menor aun no pone si es accidental o no
     * 
     * @param unAcorde
     * @return
     */
    public string gradoAcordeRomSecEscAct(Armonia unAcorde)
    {
        return gradoAcordeRomSec(unAcorde, getEscalaActual());
    }

    public string gradoAcordeRomSec(Armonia unAcorde, Tonalidad escala)
    {
        CoordenadaTonal cor = gradoSecundario(unAcorde, escala);
        int grado = cor.grado;
        int es = cor.escala;
        // System.out.println(es+"Escala.gradoArodeRomano: " + grado);
        string gradStr = "";
        string esS = "", graS = "", pertS = "";
        if (grado > 0)
        {// 8 significa dominante secundario
            switch (es)
            {
                case 1:
                    esS = "";
                    break;
                case 2:
                    esS = "II";
                    break;
                case 3:
                    esS = "III";
                    break;
                case 4:
                    esS = "IV";
                    break;
                case 5:
                    esS = "V";
                    break;
                case 6:
                    esS = "VI";
                    break;
                case 7:
                    esS = "VII";
                    break;
            }
            switch (grado)
            {
                case 1:
                    if (unAcorde.inversion == 2)
                    {
                        graS = "I";// Aqui cambiar a K para cadencial
                    }
                    else
                    {
                        graS = "I";
                    }
                    break;
                case 2:
                    if (unAcorde.Fundamental % 12 == getEscalaActual().baseEsc + 1)
                    {
                        // graS = "N";
                        graS = "II";
                    }
                    else
                    {
                        graS = "II";
                    }
                    break;
                case 3:
                    graS = "III";
                    break;
                case 4:
                    graS = "IV";
                    break;
                case 5:
                    if (unAcorde.tipoDeAcordeStr.Equals("D7"))
                    {
                        // graS = "N";
                        graS = "DV";
                    }
                    else
                    {
                        graS = "V";
                    }
                    break;
                case 6:
                    graS = "VI";
                    break;
                case 7:
                    if (unAcorde.tipoDeAcordeStr.Equals("o7"))
                    {
                        // graS = "N";
                        graS = "Dvii";
                    }
                    else
                    {
                        graS = "VII";
                    }
                    // graS = "VII";
                    break;
            }
            if (escala.perteneceListaNotas(unAcorde.notasSimplificadas) == false)

            //            if (escala.perteneceArmonia(unAcorde) == false)
            {
                pertS = "*";
            }
            if (es != 1)
            {
                gradStr = pertS + graS + "" + unAcorde.inversionStr + "/"
                        + esS;
            }
            else
            {
                gradStr = pertS + "" + graS + "" + unAcorde.inversionStr;
            }
        }
        else
        {
            gradStr = "x";
        }
        return gradStr;
    }

    public string gradoAcordeRomSencillo(Armonia unAcorde, Tonalidad escala)
    {
        CoordenadaTonal cor = gradoSecundario(unAcorde, escala);
        int grado = cor.grado;
        int es = cor.escala;
        // System.out.println(es+"Escala.gradoArodeRomano: " + grado);
        string gradStr = "";
        string graS = "", pertS = "";
        string esS = "";
        if (grado > 0)
        {// 8 significa dominante secundario
            //switch (es)
            //{
            //    case 1:
            //        esS = "";
            //        break;
            //    case 2:
            //        esS = "II";
            //        break;
            //    case 3:
            //        esS = "III";
            //        break;
            //    case 4:
            //        esS = "IV";
            //        break;
            //    case 5:
            //        esS = "V";
            //        break;
            //    case 6:
            //        esS = "VI";
            //        break;
            //    case 7:
            //        esS = "VII";
            //        break;
            //}
            switch (grado)
            {
                case 1:
                    if (unAcorde.inversion == 2)
                    {
                        graS = "I";// Aqui cambiar a K para cadencial
                    }
                    else
                    {
                        graS = "I";
                    }
                    break;
                case 2:
                    if (unAcorde.Fundamental % 12 == getEscalaActual().baseEsc + 1)
                    {
                        // graS = "N";
                        graS = "II";
                    }
                    else
                    {
                        graS = "II";
                    }
                    break;
                case 3:
                    graS = "III";
                    break;
                case 4:
                    graS = "IV";
                    break;
                case 5:
                    if (unAcorde.tipoDeAcordeStr.Equals("D7"))
                    {
                        // graS = "N";
                        graS = "DV";
                    }
                    else
                    {
                        graS = "V";
                    }
                    break;
                case 6:
                    graS = "VI";
                    break;
                case 7:
                    if (unAcorde.tipoDeAcordeStr.Equals("o7"))
                    {
                        // graS = "N";
                        graS = "Dvii";
                    }
                    else
                    {
                        graS = "VII";
                    }
                    // graS = "VII";
                    break;
            }
            if (escala.perteneceListaNotas(unAcorde.notasSimplificadas) == false)

            //            if (escala.perteneceArmonia(unAcorde) == false)
            {
                pertS = "*";
            }
            if (es != 1)
            {
                //   gradStr = pertS + graS + "" + unAcorde.inversionStr + "/"
                //         + esS;
            }
            else
            {
                gradStr = pertS + "" + graS + "" + unAcorde.inversionStr;
            }
        }
        else
        {
            gradStr = "";
        }
        return gradStr;
    }

    public string num2notaSost(float num)
    {
        num = num % 12;
        string reg = "";
        switch ((int)num)
        {
            case 0:
                reg = "C";
                break;
            case 1:
                reg = "C#";
                break;
            case 2:
                reg = "D";
                break;
            case 3:
                reg = "D#";
                break;
            case 4:
                reg = "E";
                break;
            case 5:
                reg = "F";
                break;
            case 6:
                reg = "F#";
                break;
            case 7:
                reg = "G";
                break;
            case 8:
                reg = "G#";
                break;
            case 9:
                reg = "A";
                break;
            case 10:
                reg = "A#";
                break;
            case 11:
                reg = "B";
                break;

        }

        return reg;
    }
    public string num2notaSostBemol(float num)
    {
        num = num % 12;
        string reg = "";
        switch ((int)num)
        {
            case 0:
                reg = "C";
                break;
            case 1:
                reg = "C#/Db";
                break;
            case 2:
                reg = "D";
                break;
            case 3:
                reg = "D#/Eb";
                break;
            case 4:
                reg = "E";
                break;
            case 5:
                reg = "F";
                break;
            case 6:
                reg = "F#/Gb";
                break;
            case 7:
                reg = "G";
                break;
            case 8:
                reg = "G#/Ab";
                break;
            case 9:
                reg = "A";
                break;
            case 10:
                reg = "A#/Bb";
                break;
            case 11:
                reg = "B";
                break;

        }

        return reg;
    }

}
