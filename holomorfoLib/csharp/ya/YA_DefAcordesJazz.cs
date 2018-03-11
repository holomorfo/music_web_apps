using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefAcordesJazz  {

	private List<ArmoniaDefs> _arms;
	public List<ArmoniaDefs> arms
	{
		get { return _arms; }
		set { _arms = value; }
	}


	// Use this for initialization
	public DefAcordesJazz () {
		_arms = new List<ArmoniaDefs> ();
		_arms.Add(new ArmoniaDefs("M",new float[]{0, 4, 7}));
		_arms.Add(new ArmoniaDefs("m",new float[]{0, 3, 7}));
		_arms.Add(new ArmoniaDefs("o",new float[]{0, 3, 6}));
		_arms.Add(new ArmoniaDefs("+",new float[]{0, 4, 8}));
		_arms.Add(new ArmoniaDefs("M7",new float[]{0, 4, 7, 11}));
		_arms.Add(new ArmoniaDefs("D7",new float[]{0, 4, 7, 10}));
		_arms.Add(new ArmoniaDefs("m7",new float[]{0, 3, 7, 10}));
		_arms.Add(new ArmoniaDefs("o/7",new float[]{0, 3, 6, 10}));
		_arms.Add(new ArmoniaDefs("o7",new float[]{0, 3, 6, 9}));
		_arms.Add(new ArmoniaDefs("mM7",new float[]{0, 3, 7, 11}));
		_arms.Add(new ArmoniaDefs("D7*5",new float[]{0, 4, 10}));
		_arms.Add(new ArmoniaDefs("DM9*5",new float[]{0, 2, 4, 10}));
		_arms.Add(new ArmoniaDefs("Dm9*5",new float[]{0, 1, 4, 10}));
		
		
		_arms.Add(new ArmoniaDefs("5",new float[]{0,7}));
		_arms.Add(new ArmoniaDefs("Sus4",new float[]{0,5,7}));
		_arms.Add(new ArmoniaDefs("Sus2",new float[]{0,2,7}));
		//_arms.Add(new ArmoniaDefs("6",new float[]{0,4,7,9})); Se confunde con A7 en new float[]{CM}
		//_arms.Add(new ArmoniaDefs("m6",new float[]{0,3,7,9}));
		_arms.Add(new ArmoniaDefs("9",new float[]{0,2,4,7,10}));
		_arms.Add(new ArmoniaDefs("m9",new float[]{0,2,3,7,10}));
		_arms.Add(new ArmoniaDefs("M9",new float[]{0,2,4,7,11}));
		_arms.Add(new ArmoniaDefs("mM9",new float[]{0,2,3,7,11}));
		_arms.Add(new ArmoniaDefs("11",new float[]{0,2,4,5,7,10}));
		_arms.Add(new ArmoniaDefs("m11",new float[]{0,2,3,5,7,10}));
		_arms.Add(new ArmoniaDefs("M11",new float[]{0,2,4,5,7,11}));
		_arms.Add(new ArmoniaDefs("mM11",new float[]{0,2,3,5,7,11}));
		_arms.Add(new ArmoniaDefs("13",new float[]{0,2,4,7,9,10}));
		_arms.Add(new ArmoniaDefs("m13",new float[]{0,2,3,7,9,10}));
		_arms.Add(new ArmoniaDefs("M13",new float[]{0,2,4,7,9,11}));
		_arms.Add(new ArmoniaDefs("mM13",new float[]{0,2,3,7,9,11}));
		_arms.Add(new ArmoniaDefs("Add9",new float[]{0,2,4,7}));
		_arms.Add(new ArmoniaDefs("MAdd9",new float[]{0,2,3,7}));
		_arms.Add(new ArmoniaDefs("6Add9",new float[]{0,2,4,7,9}));
		_arms.Add(new ArmoniaDefs("m6Add9",new float[]{0,2,3,7,9}));
		_arms.Add(new ArmoniaDefs("D7Add11",new float[]{0,4,5,7,10}));
		_arms.Add(new ArmoniaDefs("M7Add11",new float[]{0,4,5,7,11}));
		_arms.Add(new ArmoniaDefs("m7Add11",new float[]{0,3,5,7,10}));
		_arms.Add(new ArmoniaDefs("mM7Add11",new float[]{0,3,5,7,11}));
		_arms.Add(new ArmoniaDefs("D7Add13",new float[]{0,4,7,9,11}));
		_arms.Add(new ArmoniaDefs("M7Add13",new float[]{0,4,7,9,11}));
		_arms.Add(new ArmoniaDefs("m7Add13",new float[]{0,3,7,9,10}));
		_arms.Add(new ArmoniaDefs("mM7Add13",new float[]{0,3,7,9,11}));
		_arms.Add(new ArmoniaDefs("7b5",new float[]{0,4,6,10}));
		_arms.Add(new ArmoniaDefs("7#5",new float[]{0,4,8,10}));
		_arms.Add(new ArmoniaDefs("7b9",new float[]{0,1,4,7,10}));
		_arms.Add(new ArmoniaDefs("7#9",new float[]{0,3,4,7,10}));
		_arms.Add(new ArmoniaDefs("7#5b9",new float[]{0,1,4,8,10}));
		_arms.Add(new ArmoniaDefs("m7#5",new float[]{0,3,8,10}));
		_arms.Add(new ArmoniaDefs("m7b9",new float[]{0,1,3,7,10}));
		_arms.Add(new ArmoniaDefs("9#11",new float[]{0,2,4,6,7,11}));
		_arms.Add(new ArmoniaDefs("9b13",new float[]{0,2,4,7,8,11}));
		_arms.Add(new ArmoniaDefs("6sus4",new float[]{0,5,7,9}));
		
		_arms.Add(new ArmoniaDefs("7sus4",new float[]{0,5,7,10}));
		_arms.Add(new ArmoniaDefs("M7sus4",new float[]{0,5,7,11}));
		_arms.Add(new ArmoniaDefs("9sus4",new float[]{0,2,5,7,10}));
		_arms.Add(new ArmoniaDefs("M9sus4",new float[]{0,2,5,7,11}));
		
		_arms.Add(new ArmoniaDefs("2m",new float[]{0,1}));
		_arms.Add(new ArmoniaDefs("2M",new float[]{0,2}));
		_arms.Add(new ArmoniaDefs("3m",new float[]{0,3}));
		_arms.Add(new ArmoniaDefs("3M",new float[]{0,4}));
		_arms.Add(new ArmoniaDefs("4P",new float[]{0,5}));
		_arms.Add(new ArmoniaDefs("6+",new float[]{0,6}));
		_arms.Add(new ArmoniaDefs("5P",new float[]{0,7}));
		_arms.Add(new ArmoniaDefs("6m",new float[]{0,8}));
		_arms.Add(new ArmoniaDefs("6M",new float[]{0,9}));
		_arms.Add(new ArmoniaDefs("7m",new float[]{0,10}));
		_arms.Add(new ArmoniaDefs("7M",new float[]{0,11}));

	}

	 
    public float[] str2Ac(string tip){
        float[] acord = new float[0];
        for(int i =0; i<arms.Count; i++){
            if(tip == arms[i].Nombre){
                acord = (float[])arms[i].notasDef;
            }
        }
        return acord;
    }

    public List<float> crearAcorde(float bas, string tip)
    {
       // float[] acord = new float[0];
        List<float> acordL = new List<float>();
        for (int i = 0; i < arms.Count; i++)
        {
            if (tip == arms[i].Nombre)
            {
               // Debug.Log("Nombre; " + arms[i].Nombre);
              //  acord = new float[arms[i].notasDef.Length];
                for (int j = 0; j < arms[i].notasDef.Length; j++)
                {
                    //acord[i] = bas + arms[i].notasDef[j];
                    acordL.Add(bas + arms[i].notasDef[j]);
                 //   Debug.Log("cosa; " + acord[i]);
                
                }
            }
        }
//        Debug.Log("Largo; " + acord.Length);
                
//        return (float[])acord.Clone();
        return acordL;
    }
}
