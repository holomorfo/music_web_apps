using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefEscalasAcordes
{

    public List<Armonia> armsList;

    public DefEscalasAcordes(float bas, string tipo = "M")
    {
        DefAcordesJazz def = new DefAcordesJazz();
        armsList=new List<Armonia>();
        switch(tipo){
            case "M":
		    armsList.Add(new Armonia(def.crearAcorde(bas+0,"M")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+2,"m")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+4,"m")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+5,"M")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7,"M")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+9,"m")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+11,"o")));
            // Septimos
            armsList.Add
            (new Armonia(def.crearAcorde(bas+0,"M7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+2,"m7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+4,"m7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+5,"M7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7,"D7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+9,"m7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+11,"o/7")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+4,"m7")));
            // Mayor armonica
            armsList.Add
            (new Armonia(def.crearAcorde(bas+2, "o")));
            // Mayor armonicos septimo
            armsList.Add
            (new Armonia(def.crearAcorde(bas+11, "o7")));
            //Napolitano
            armsList.Add
            (new Armonia(def.crearAcorde(bas + 1, "m")));
            //Subdominante armonico
            armsList.Add
            (new Armonia(def.crearAcorde(bas+5, "m")));
            //Dominante noveno
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "9")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "DM9*5")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "Dm9*5")));
            // 9na de Cristian
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "7b9")));
            //Dominantes alterados
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "7b5")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "7#5")));
            armsList.Add
            (new Armonia(def.crearAcorde(bas+7, "D7*5")));

                break;
            case "m":
            //    armsList.Add(new Armonia(def.crearAcorde(bas+0,"M")));
            
			// Menor natural
			// {"m", "o", "M", "m", "m", "M", "M"};
			armsList.Add
			(new Armonia(def.crearAcorde(bas+0,"m")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+2,"o")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+3,"M")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+5,"m")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"m")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+8,"M")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+10,"M")));
			//public static String[] Ac7EscMenNat = {"m7", "o/7", "M7", "m7", "m7", "M7", "D7"};
			armsList.Add
			(new Armonia(def.crearAcorde(bas+0,"m7")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+2,"o/7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+3,"M7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+5,"m7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"m7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+8,"M7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+10,"D7")));
			//Menor armonico
			//    armsList.Add(new Armonia(def.crearAcorde(bas+3,"+")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"M")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+11,"o")));
			//Setpimos
			//    armsList.Add(new Armonia(def.crearAcorde(bas+0,"I+")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+3,"III+")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"D7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+11,"o7")));
			//Menor MelÃ³dico
			// Menor melodica
			armsList.Add
			(new Armonia(def.crearAcorde(bas+2,"m")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+3,"+")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+5,"M")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+9,"o")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+11,"o")));
			//Septimos
			armsList.Add
			(new Armonia(def.crearAcorde(bas+2,"m7")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+5,"D7")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+9,"o/7")));
			//    armsList.Add(new Armonia(def.crearAcorde(bas+11,"o/7")));
			//Napolitano
			// No jala el napolitano :/
            armsList.Add(new Armonia(def.crearAcorde(bas+1,"M")));
			//Dominante noveno
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"DM9*5")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"Dm9*5")));
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"D7*5")));
			// 9na de Cristian
			armsList.Add
			(new Armonia(def.crearAcorde(bas+7,"7b9")));
                break;
        }
    }
}
