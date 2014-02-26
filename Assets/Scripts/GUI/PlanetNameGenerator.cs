using UnityEngine;
using System.Collections;

public class PlanetNameGenerator : MonoBehaviour {

	private static string[] seedNames = {
		"Rulea",
		"Usmypso",
		"Tiybos",
		"Eshiea",
		"Ciaarus",
		"Uqskao",
		"Giaonus",
		"Efrzuna",
		"Cieiuthea",
		"Useupliuq",
		"Colea",
		"Ocladus",
		"Bainov",
		"Owhoth",
		"Buyeturn",
		"Uvprillon",
		"Sueayama",
		"Oclmillon",
		"Faeciethea",
		"Imayglore",
		"Maturn",
		"Atragua",
		"Gionope",
		"Afloria",
		"Seiutov",
		"Atwhapus",
		"Beiophus",
		"Uflxilia",
		"Faieria",
		"Oioeswore",
		"Iuturn",
		"Ebrara",
		"Coayama",
		"Ochars",
		"Suiehiri",
		"Uhsweron",
		"Soiapra",
		"Ebldomia",
		"Siamiotis",
		"Ibeofliuq",
		"Konov",
		"Oblara",
		"Gaunia",
		"Eplorth",
		"Bieapra",
		"Esplypso",
		"Ceoulea",
		"Ucrzolla",
		"Ciosiutune",
		"Eniesnoth"
	};

	private static MarkovNameGenerator generator = new MarkovNameGenerator(seedNames, 6, 3);

	public static string generateName() {
		return generator.NextName;
	}
}
