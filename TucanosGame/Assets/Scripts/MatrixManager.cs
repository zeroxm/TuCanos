using UnityEngine;
using System.Collections;

public static class MatrixManager {

	//Da o numero da fase(1 para fase 1, 2 para fase 2), retorna a matriz da fase selecionada
	public static int[,] MatrizDaFase(string NomeDaFase)
	{
		int[,] MatrizResultante;

		if (NomeDaFase.Equals("Level_01", System.StringComparison.OrdinalIgnoreCase)) {
			MatrizResultante = new int[10, 6] 
			{ 	{1, 0, 0, 0, 6, 8},
				{2, 0, 0, 0, 2, 0},
				{0, 0, 2, 0, 0, 0},
				{2, 0, 2, 0, 2, 0},
				{2, 0, 2, 0, 4, 7},
				{0, 0, 2, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{0, 0, 0, 0, 0, 0},
				{2, 0, 0, 0, 0, 0},
				{4, 3, 0, 0, 0, 0}};
		} else
		if (NomeDaFase.Equals("Level_02", System.StringComparison.OrdinalIgnoreCase)) {
			MatrizResultante = new int[10, 9] 
			{ 	{1, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 0, 3, 3, 6, 0, 0, 9},
				{0, 0, 0, 0, 0, 2, 0, 0, 0},
				{2, 0, 0, 0, 0, 2, 0, 0, 0},
				{2, 0, 0, 0, 0, 0, 0, 0, 0},
				{4, 3, 3, 0, 0, 0, 0, 2, 0},
				{0, 0, 0, 0, 0, 0, 0, 2, 0},
				{0, 0, 0, 2, 0, 5, 3, 7, 0},
				{0, 0, 0, 2, 0, 0, 0, 0, 0},
				{0, 0, 0, 4, 3, 3, 0, 0, 0}};
		} else {
			MatrizResultante = new int[1, 1]{{1}};
			Debug.Log("ERRO: MATRIZ DA FASE NAO EXISTE");
		}
		return MatrizResultante;
	}

}
