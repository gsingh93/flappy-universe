using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateUniverse : MonoBehaviour {

	class Pair {
		public int x;
		public int y;

		public Pair(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public override bool Equals(System.Object obj) {
			Pair p = obj as Pair;
			if ((object) p == null) {
				return false;
			}
			
			return base.Equals(obj) && this == p;
		}

		public override int GetHashCode() {
			return x + 20 * y;
		}
	}
	
	public int numSystems = 2;
	public SolarSystem solarSystemPrefab;

	private HashSet<Pair> points = new HashSet<Pair>();

	void Start() {
		SolarSystem s = Instantiate(solarSystemPrefab) as SolarSystem;
		s.transform.parent = transform;
		s.ourSolarSystem = true;
		s.transform.position = Vector3.zero;

		int cellSize = 50;
		int rowSize = 2 * HUD.Dim / cellSize;
		
		for (int i = 0; i < numSystems - 1; i++) {
			Pair point = new Pair(0, 0);
			do {
				points.Add(point);
				point = new Pair(Random.Range(0, rowSize), Random.Range(0, rowSize));
			} while (points.Contains(point));

			s = Instantiate(solarSystemPrefab) as SolarSystem;
			s.transform.parent = transform;
			s.transform.position = new Vector3(point.x * cellSize - HUD.Dim, point.y * cellSize - HUD.Dim, 0);
		}


	}
}
