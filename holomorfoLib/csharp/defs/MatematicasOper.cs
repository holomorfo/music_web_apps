using UnityEngine;
using System.Collections;

public class MatematicasOper {

	public static float mod(float num, float bas) {
		num = num % bas;
		if (num < 0) {
			num = bas + num;
		}
		return num;
	}
}
