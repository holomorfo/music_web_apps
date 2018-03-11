using UnityEngine;
using System.Collections;

public class ArmoniaDefs {

	private string _nombre;
	public string Nombre
	{
		//set the person name
		set { this._nombre = value; }
		//get the person name 
		get { return this._nombre; }
	}

	private float[] _notasDef;
	public float[] notasDef
	{
		//set the person name
		set { this._notasDef = value; }
		//get the person name 
		get { return this._notasDef; }
	}

	public ArmoniaDefs(string nom, float[] nts){
		_nombre = nom;
		_notasDef = nts;
	}


}
