
public class Armonia
{
    float fundamental = 0;
    public float Fundamental
    {
        get { return fundamental; }
        set { fundamental = value; }
    }

    public float[] notasArmonia;
    public List<float> notasSimplificadas;

    public float[] notasTipo;
    public string tipoDeAcordeStr = "*";
    public float inversion;
    public string inversionStr = "";
    private DefAcordesJazz defAc;
    bool isSeptimo = false;
    float restar;





    private bool perteneceEnLista(float[] acordeNotas)
    {
        bool cond = false;
        float[] tempA;
        if (notasSimplificadas.Count == acordeNotas.Length)
        {
            tempA = new float[notasSimplificadas.Count];
            for (int r = 0; r < notasSimplificadas.Count; r++)
            {
                restar = notasSimplificadas[r];
                for (int i = 0; i < tempA.Length; i++)
                {
                    // El modulo debe ser el de grupos
                    // no con negativos
                    tempA[i] = MatematicasOper.mod(notasSimplificadas[i] - restar, 12);
                }

                System.Array.Sort(tempA);
                if (tempA.SequenceEqual(acordeNotas))
                {
                    fundamental = MatematicasOper.mod(restar, 12);
                    cond = true;
                    // Quiza usar un while, para
                }
            }
        }
        ////////////////////7

        return cond;
    }

    private void asignarIndiceLista()
    {
        // Revisar si es igual a alguno de la librería
        //int i=0;
        for (int i = 0; i < defAc.arms.Count; i++)
        {
            if (this.perteneceEnLista(defAc.arms[i].notasDef))
            {
                tipoDeAcordeStr = defAc.arms[i].Nombre;
            }
        }
    }

    private void setTipoVoces()
    {
        float dist;
        notasTipo = new float[notasArmonia.Length];
        for (int i = 0; i < notasArmonia.Length; i++)
        {
            // float resta = (fundamental - notasArmonia[i]);
            dist = Math.Abs((fundamental - notasArmonia[i])) % 12;
            notasTipo[i] = this.intervaloDiatonico(dist);
            if (this.intervaloDiatonico(dist) == 7)
            {
                isSeptimo = true;
            }
        }
    }

    public float intervaloDiatonico(float dist)
    {
        float regresar = -1;
        switch ((int)dist)
        {
            case 0:
                regresar = 1;
                break;
            case 1:
                regresar = 2;
                break;
            case 2:
                regresar = 2;
                break;
            case 3:
                regresar = 3;
                break;
            case 4:
                regresar = 3;
                break;
            case 5:
                regresar = 5;
                break;
            case 6:
                regresar = 5;
                break;
            case 7:
                regresar = 5;
                break;
            case 8:
                regresar = 3;
                break;
            case 9:
                regresar = 3;
                break;
            case 10:
                regresar = 7;
                break;
            case 11:
                regresar = 7;
                break;
            default:
                break;
        }
        return regresar;
    }

    private void setInversion()
    {
        switch ((int)notasTipo[0])
        {
            case 1:
                inversion = 0;
                break;
            case 3:
                inversion = 1;
                break;
            case 5:
                inversion = 2;
                break;
            case 7:
                inversion = 3;
                break;
        }
    }

    private void setInversionString()
    {
        string invS = "";
        float inv = inversion;
        if (!isSeptimo)
        {
            if (inv == 1)
            {
                invS = invS + "6";
            };
            if (inv == 2)
            {
                invS = invS + "6,4";
            };
        }
        else
        {
            if (inv == 0)
            {
                invS = invS + "7";
            }
            if (inv == 1)
            {
                invS = invS + "6,5";
            }
            if (inv == 2)
            {
                invS = invS + "4,3";
            }
            if (inv == 3)
            {
                invS = invS + "2";
            }
        }
        inversionStr = invS;
    }

    public List<float[]> calcularIntervalos()
    {        
        List<float[]> intervs = new List<float[]>();
        //Debug.Log("_________________________________");
        //foreach (float i in notasSimplificadas)
        //{
        //    Debug.Log("NotasSimplificadas " + i);
        //}
        if (notasSimplificadas != null)
        {
            for (int i = 0; i < notasSimplificadas.Count; i++)
            {
                for (int j = 0; j < notasSimplificadas.Count; j++)
                {
                    //              intervs.Add(MatematicasOper.mod(notasArmonia[i] - notasArmonia[j], 12));
                    //Debug.Log("Primera nota " + notasArmonia[0] % 12);
                    //Debug.Log("Segunda nota " + notasArmonia[1] % 12);
                    //&& notasSimplificadas[i] < notasSimplificadas[j]
                    if (notasSimplificadas[i] % 12 != notasSimplificadas[j] % 12)
                    {
                        intervs.Add(new float[2] { notasSimplificadas[i] % 12, notasSimplificadas[j] % 12 });
                    }
                }
            }
        }
        //Debug.Log("_________________________________");
        //foreach (float[] i in intervs)
        //{
        //    Debug.Log("Acorde intervalo " + i[0] + " " + i[1]);
        //}
        return intervs; 
    }

    public bool equivalente(Armonia unArm)
    {
        bool cond = false;
        if (this.fundamental % 12 == unArm.fundamental % 12)
        {
            if (this.tipoDeAcordeStr.Equals(unArm.tipoDeAcordeStr))
            {
                cond = true;
            }
        }
        return cond;
    }

	//=================================================
	//=================================================
	//=================================================
	// FUZY
	public List<float> intersection(List<float> b) {
//		HashSet<float> canAdd = new HashSet<>(notasSimplificadas);
		List<float> result = new List<float>();

		foreach (float n in b) {
			if (notasSimplificadas.Contains(n)) {
				result.Add(n);
				// we wish to add only one n
	//			canAdd.Remove(n);
			}
		}
		return result;
	}


	public float fuzzyBelonging(List<float> acordeNotas) {
		float reg = -1;
		float numerador = (float) (Math.Pow(intersection(acordeNotas).Count, 2));
		// System.out.println("\nNumerador " + numerador);
		float denominador = ((float) notasSimplificadas.Count * acordeNotas.Count);
		// System.out.println("Denominador " + denominador);
		if (denominador != 0) {
			reg = numerador / denominador;
			// System.out.println("Fuzzyness " + (reg));
		}
		return reg;
	}

	public Armonia fuzzyOptimalUnique() {
		// Tengo que correr sobre TOOOODOS los 144 acordes? =o
		// ArrayList<Acorde> reg = new ArrayList<>();
		bool isReturn = false;
		Armonia  tempAc = new Armonia ();
		string[] tips = { "M", "m", "o", "+", "M7", "D7", "m7", "o/7", "mM7", "D7*5" };
//		ArrayList<String> tips = new ArrayList<>(
//			Arrays.asList("M", "m", "o", "+", "M7", "D7", "m7", "o/7", "mM7", "D7*5"));
		Armonia  maxAc = new Armonia ();
		float maxFuzzyVal = 0;
		float fuzzyTempVal = 0;
		// I dont need a list, just the undisputable maximum.
		for (int i = 0; i < 12; i++) {
			for (int j = 0; j < tips.Length; j++) {
				tempAc = new Armonia(i, tips[j]);
				fuzzyTempVal = this.fuzzyBelonging(tempAc.notasSimplificadas);
				Debug.Log ("Fuzzines "+fuzzyTempVal);
				if (fuzzyTempVal > 0.4f) { // alpha cut ;)
					if (fuzzyTempVal > maxFuzzyVal) {
						Debug.Log ("Encontré máximo");
						// System.out.println("Agregado max");
						maxAc = tempAc;
						// reg.add(0, tempAc);
						maxFuzzyVal = fuzzyTempVal;
						isReturn=true;
					}else if(fuzzyTempVal == maxFuzzyVal){
						isReturn=false;
					}
				}
			}
		}
		// This is if the chord is not unique maximum, then nothing returns
		if(!isReturn){
			maxAc = new Armonia();
		}
		return maxAc;
	}

	public List<Armonia> fuzzyProbables() {
		// Tengo que correr sobre TOOOODOS los 144 acordes? =o
		List<Armonia> reg = new List<Armonia> ();
		Armonia tempAc = new Armonia();
		string[] tips = { "M", "m", "o", "+", "M7", "D7", "m7", "o/7", "mM7", "D7*5" };
		//ArrayList<String> tips = new ArrayList<>(
		//	Arrays.asList("M", "m", "o", "+", "M7", "D7", "m7", "o/7", "mM7", "D7*5"));
		Armonia maxAc = new Armonia(0, tips[0]);
		float maxF = 0;
		float fuzzyTemp = 0;
		// reg.add(maxAc);

		for (int i = 0; i < 12; i++) {
			for (int j = 0; j < tips.Length; j++) {
				tempAc = new Armonia(i, tips[j]);

				fuzzyTemp = this.fuzzyBelonging(tempAc.notasSimplificadas);
				if (fuzzyTemp > 0.4f) {
					if (fuzzyTemp >= maxF) {
						// System.out.println("Agregado max");
						reg.Insert(0, tempAc);
						maxF = fuzzyTemp;
					} else {
						reg.Add(tempAc);
						// System.out.println("Agregado Fin");
					}
				}
				// System.out.print("Notas acorde actual ");
				// for (Float f : notasSimplificadas) {
				// System.out.print(" " + f);
				// }
				// System.out.println();
			}
		}
		return reg;
	}

	public string fundamentalString()
    {
        string nota = "";
        // string acS = "";
        switch ((int)fundamental % 12)
        {
            case 0:
                nota = "C";
                break;
            case 1:
                nota = "C#";
                break;
            case 2:
                nota = "D";
                break;
            case 3:
                nota = "D#";
                break;
            case 4:
                nota = "E";
                break;
            case 5:
                nota = "F";
                break;
            case 6:
                nota = "F#";
                break;
            case 7:
                nota = "G";
                break;
            case 8:
                nota = "G#";
                break;
            case 9:
                nota = "A";
                break;
            case 10:
                nota = "A#";
                break;
            case 11:
                nota = "B";
                break;
        }
        return nota;
    }

    public void imprimir()
    {
        Debug.Log(fundamentalString() + " " + tipoDeAcordeStr + " " + inversionStr);
        string notas = "";
        for (int i = 0; i < notasArmonia.Length; i++)
        {
            notas = notas + " " + notasArmonia[i];
        }
        notas += " - ";
        for (int i = 0; i < notasArmonia.Length; i++)
        {
            notas = notas + " " + notasTipo[i];
        }
        Debug.Log(notas);
    }

    public void imprimriSencillo()
    {
        Debug.Log(fundamentalString() + "" + tipoDeAcordeStr + " " + inversionStr);
    }

    public string getStringSencillo()
    {
        string str = "" + fundamentalString() + "" + tipoDeAcordeStr + " " + inversionStr;
        return str;
    }
    public string getStringSencillo(Tonalidad ton)
    {
        string str = "" + ton.num2nota12(this.Fundamental) + "" + tipoDeAcordeStr + " " + inversionStr;
        return str;
    }

}
