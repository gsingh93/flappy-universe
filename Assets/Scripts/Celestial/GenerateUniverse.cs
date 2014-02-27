using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateUniverse : MonoBehaviour {

	public float systemDensity = 0.5f;
	public int cellSize = 50;

	private int gridSize = 0;

	public int numSystems = 10;
	public SolarSystem solarSystemPrefab;
	
	void Start() {
		SolarSystem s = Instantiate(solarSystemPrefab) as SolarSystem;
		s.transform.parent = transform;
		s.ourSolarSystem = true;
		s.transform.position = Vector3.zero;
	}

	public void ExpandUniverse() {
		gridSize += 1;
		for (int i = -1 * gridSize; i < gridSize; i++) {
			PossiblyGenerateSystem(i, gridSize);
			PossiblyGenerateSystem(i, -gridSize);
			PossiblyGenerateSystem(gridSize, i);
			PossiblyGenerateSystem(-gridSize, i);
		}
	}

	private void PossiblyGenerateSystem(int row, int col) {
		if (Random.value < systemDensity) {
			Debug.Log("Generating solar system at row " + row + " col " + col);
			SolarSystem s = Instantiate(solarSystemPrefab) as SolarSystem;
			s.transform.parent = transform;
			s.transform.position = new Vector3(col * cellSize, row * cellSize, 0);
		}
	}
}
