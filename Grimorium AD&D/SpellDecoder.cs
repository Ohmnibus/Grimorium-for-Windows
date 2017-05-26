/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 22/05/2017
 * Time: 22:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Drawing;

namespace Grimorium.ADnD {
	/// <summary>
	/// Description of SpellDecoder.
	/// </summary>
	public class SpellDecoder {
		
		private const uint BITFIELD_UNDEFINED = 0xffffffff;
		private const uint BITFIELD_ALL = 0x0fffffff;
		private const uint BITFIELD_NONE = 0x00000000;

		public const uint TYPE_ALL = BITFIELD_ALL;
		public const uint TYPE_WIZARDS = 0x00000001;
		public const uint TYPE_CLERICS = 0x00000002;

		public const uint LEVEL_ALL = BITFIELD_ALL;
		public const uint LEVEL_CANTRIP = 0;
		//	public const uint LEVEL_01 = 1;
		//	public const uint LEVEL_02 = 2;
		//	public const uint LEVEL_03 = 3;
		//	public const uint LEVEL_04 = 4;
		//	public const uint LEVEL_05 = 5;
		//	public const uint LEVEL_06 = 6;
		//	public const uint LEVEL_07 = 7;
		//	public const uint LEVEL_08 = 8;
		//	public const uint LEVEL_09 = 9;
		//	public const uint LEVEL_10 = 10;
		public const uint LEVEL_QUEST = 11;
		
		public const uint SCHOOL_NONE = BITFIELD_NONE;
		public const uint SCHOOL_ABJURATION = 0x00000001;
		public const uint SCHOOL_ALTERATION = 0x00000002;
		public const uint SCHOOL_CONJURATION = 0x00000004;
		public const uint SCHOOL_DIVINATION = 0x00000008;
		public const uint SCHOOL_ENCHANTMENT = 0x00000010;
		public const uint SCHOOL_EVOCATION = 0x00000020;
		public const uint SCHOOL_ILLUSION = 0x00000040;
		public const uint SCHOOL_NECROMANCY = 0x00000080;
		public const uint SCHOOL_ALL = BITFIELD_ALL;

		public const uint SPHERE_NONE = BITFIELD_NONE;
		public const uint SPHERE_ANIMAL = 0x00000001;
		public const uint SPHERE_ASTRAL = 0x00000002;
		public const uint SPHERE_CHARM = 0x00000004;
		public const uint SPHERE_COMBAT = 0x00000008;
		public const uint SPHERE_CREATION = 0x00000010;
		public const uint SPHERE_DIVINATION = 0x00000020;
		public const uint SPHERE_ELEMENTAL_AIR = 0x00000040;
		public const uint SPHERE_ELEMENTAL_EARTH = 0x00000080;
		public const uint SPHERE_ELEMENTAL_FIRE = 0x00000100;
		public const uint SPHERE_ELEMENTAL_WATER = 0x00000200;
		public const uint SPHERE_GUARDIAN = 0x00000400;
		public const uint SPHERE_HEALING = 0x00000800;
		public const uint SPHERE_NECROMANTIC = 0x00001000;
		public const uint SPHERE_PLANT = 0x00002000;
		public const uint SPHERE_PROTECTION = 0x00004000;
		public const uint SPHERE_SUMMONING = 0x00008000;
		public const uint SPHERE_SUN = 0x00010000;
		public const uint SPHERE_WEATHER = 0x00020000;
		public const uint SPHERE_CHAOS = 0x00040000;
		public const uint SPHERE_LAW = 0x00080000;
		public const uint SPHERE_NUMBERS = 0x00100000;
		public const uint SPHERE_THOUGHT = 0x00200000;
		public const uint SPHERE_TIME = 0x00400000;
		public const uint SPHERE_TRAVELERS = 0x00800000;
		public const uint SPHERE_WAR = 0x01000000;
		public const uint SPHERE_WARDS = 0x02000000;
		public const uint SPHERE_ALL = BITFIELD_ALL;

		public const uint BOOK_NONE = BITFIELD_NONE;
		public const uint BOOK_BASE = 0x00000001;
		public const uint BOOK_TOME = 0x00000002;
		public const uint BOOK_WIZARDS = 0x00000004;
		public const uint BOOK_PRIESTS = 0x00000008;
		public const uint BOOK_SPELLS = 0x00000010;
		public const uint BOOK_ADVENTURES = 0x00000020;
		public const uint BOOK_CUSTOM = 0x00000040;
		public const uint BOOK_CARNAL = 0x00000080;
		public const uint BOOK_ALCOHOL = 0x00000100;
		public const uint BOOK_ALL = BITFIELD_ALL;

		public const uint COMP_NONE = BITFIELD_NONE;
		public const uint COMP_VERBAL = 0x00000001;
		public const uint COMP_SOMATIC = 0x00000002;
		public const uint COMP_MATERIAL = 0x00000004;
		public const uint COMP_ALL = BITFIELD_ALL;

		private const uint IDX_CODE = 0;
		private const uint IDX_LABEL = 1;
		private const uint IDX_TEXT = 2;
		
		private const string SEPARATOR = ",";

		private const string LEVEL_LBL_CANTRIP = "C";
		//	private const string LEVEL_LBL_01 = "1";
		//	private const string LEVEL_LBL_02 = "2";
		//	private const string LEVEL_LBL_03 = "3";
		//	private const string LEVEL_LBL_04 = "4";
		//	private const string LEVEL_LBL_05 = "5";
		//	private const string LEVEL_LBL_06 = "6";
		//	private const string LEVEL_LBL_07 = "7";
		//	private const string LEVEL_LBL_08 = "8";
		//	private const string LEVEL_LBL_09 = "9";
		//	private const string LEVEL_LBL_10 = "10";
		private const string LEVEL_LBL_QUEST = "Q";
		
		private readonly string[] LEVEL_LBL = {
			"Cantrip/Orison",
			"First",
			"Second",
			"Third",
			"Fourth",
			"Fifth",
			"Sixth",
			"Seventh",
			"Eighth",
			"Ninth",
			"Tenth",
			"Quest"
		};
		

		//	private static final Object[][] LEVEL = new Object[][] {
		//			{SCHOOL_ALL, SCHOOL_LBL_ALL, R.string.lbl_school_all},
		//			{SCHOOL_ABJURATION, SCHOOL_LBL_ABJURATION, R.string.lbl_school_abjuration},
		//			{SCHOOL_ALTERATION, SCHOOL_LBL_ALTERATION, R.string.lbl_school_alteration},
		//			{SCHOOL_CONJURATION, SCHOOL_LBL_CONJURATION, R.string.lbl_school_conjuration},
		//			{SCHOOL_DIVINATION, SCHOOL_LBL_DIVINATION, R.string.lbl_school_divination},
		//			{SCHOOL_ENCHANTMENT, SCHOOL_LBL_ENCHANTMENT, R.string.lbl_school_enchantment},
		//			{SCHOOL_EVOCATION, SCHOOL_LBL_EVOCATION, R.string.lbl_school_evocation},
		//			{SCHOOL_ILLUSION, SCHOOL_LBL_ILLUSION, R.string.lbl_school_illusion},
		//			{SCHOOL_NECROMANCY , SCHOOL_LBL_NECROMANCY, R.string.lbl_school_necromancy}
		//	};

		private const string SCHOOL_LBL_ALL = "All Schools";
		private const string SCHOOL_LBL_ABJURATION = "Abjuration";
		private const string SCHOOL_LBL_ALTERATION = "Alteration";
		private const string SCHOOL_LBL_CONJURATION = "Conjuration";
		private const string SCHOOL_LBL_DIVINATION = "Divination";
		private const string SCHOOL_LBL_ENCHANTMENT = "Enchantment";
		private const string SCHOOL_LBL_EVOCATION = "Evocation";
		private const string SCHOOL_LBL_ILLUSION = "Illusion";
		private const string SCHOOL_LBL_NECROMANCY = "Necromancy";
		private readonly object[][] SCHOOLS = {
			new object[] { SCHOOL_ALL, SCHOOL_LBL_ALL, "All" },
			new object[] { SCHOOL_ABJURATION, SCHOOL_LBL_ABJURATION, "Abjuration" },
			new object[] { SCHOOL_ALTERATION, SCHOOL_LBL_ALTERATION, "Alteration" },
			new object[] { SCHOOL_CONJURATION, SCHOOL_LBL_CONJURATION, "Conjuration/Summoning" },
			new object[] { SCHOOL_DIVINATION, SCHOOL_LBL_DIVINATION, "Divination" },
			new object[] { SCHOOL_ENCHANTMENT, SCHOOL_LBL_ENCHANTMENT, "Enchantment/Charm" },
			new object[] { SCHOOL_EVOCATION, SCHOOL_LBL_EVOCATION, "Evocation" },
			new object[] { SCHOOL_ILLUSION, SCHOOL_LBL_ILLUSION, "Illusion/Phantasm" },
			new object[] { SCHOOL_NECROMANCY, SCHOOL_LBL_NECROMANCY, "Necromancy" }
		};
		
		private const string SPHERE_LBL_ALL = "All";
		private const string SPHERE_LBL_ANIMAL = "Animal";
		private const string SPHERE_LBL_ASTRAL = "Astral";
		private const string SPHERE_LBL_CHARM = "Charm";
		private const string SPHERE_LBL_COMBAT = "Combat";
		private const string SPHERE_LBL_CREATION = "Creation";
		private const string SPHERE_LBL_DIVINATION = "Divination";
		private const string SPHERE_LBL_ELEMENTAL_AIR = "Elemental (Air)";
		private const string SPHERE_LBL_ELEMENTAL_EARTH = "Elemental (Earth)";
		private const string SPHERE_LBL_ELEMENTAL_FIRE = "Elemental (Fire)";
		private const string SPHERE_LBL_ELEMENTAL_WATER = "Elemental (Water)";
		private const string SPHERE_LBL_GUARDIAN = "Guardian";
		private const string SPHERE_LBL_HEALING = "Healing";
		private const string SPHERE_LBL_NECROMANTIC = "Necromantic";
		private const string SPHERE_LBL_PLANT = "Plant";
		private const string SPHERE_LBL_PROTECTION = "Protection";
		private const string SPHERE_LBL_SUMMONING = "Summoning";
		private const string SPHERE_LBL_SUN = "Sun";
		private const string SPHERE_LBL_WEATHER = "Weather";
		private const string SPHERE_LBL_CHAOS = "Chaos";
		private const string SPHERE_LBL_LAW = "Law";
		private const string SPHERE_LBL_NUMBERS = "Numbers";
		private const string SPHERE_LBL_THOUGHT = "Thought";
		private const string SPHERE_LBL_TIME = "Time";
		private const string SPHERE_LBL_TRAVELERS = "Travelers";
		private const string SPHERE_LBL_WAR = "War";
		private const string SPHERE_LBL_WARDS = "Wards";
		private readonly object[][] SPHERES = {
			new object[] { SPHERE_ALL, SPHERE_LBL_ALL, "All" },
			new object[] { SPHERE_ANIMAL, SPHERE_LBL_ANIMAL, "animal" },
			new object[] { SPHERE_ASTRAL, SPHERE_LBL_ASTRAL, "astral" },
			new object[] { SPHERE_CHARM, SPHERE_LBL_CHARM, "charm" },
			new object[] { SPHERE_COMBAT, SPHERE_LBL_COMBAT, "combat" },
			new object[] { SPHERE_CREATION, SPHERE_LBL_CREATION, "creation" },
			new object[] { SPHERE_DIVINATION, SPHERE_LBL_DIVINATION, "divination" },
			new object[] { SPHERE_ELEMENTAL_AIR, SPHERE_LBL_ELEMENTAL_AIR, "elemental_air" },
			new object[] { SPHERE_ELEMENTAL_EARTH, SPHERE_LBL_ELEMENTAL_EARTH, "elemental_earth" },
			new object[] { SPHERE_ELEMENTAL_FIRE, SPHERE_LBL_ELEMENTAL_FIRE, "elemental_fire" },
			new object[] { SPHERE_ELEMENTAL_WATER, SPHERE_LBL_ELEMENTAL_WATER, "elemental_water" },
			new object[] { SPHERE_GUARDIAN, SPHERE_LBL_GUARDIAN, "guardian" },
			new object[] { SPHERE_HEALING, SPHERE_LBL_HEALING, "healing" },
			new object[] { SPHERE_NECROMANTIC, SPHERE_LBL_NECROMANTIC, "necromantic" },
			new object[] { SPHERE_PLANT, SPHERE_LBL_PLANT, "plant" },
			new object[] { SPHERE_PROTECTION, SPHERE_LBL_PROTECTION, "protection" },
			new object[] { SPHERE_SUMMONING, SPHERE_LBL_SUMMONING, "summoning" },
			new object[] { SPHERE_SUN, SPHERE_LBL_SUN, "sun" },
			new object[] { SPHERE_WEATHER, SPHERE_LBL_WEATHER, "weather" },
			new object[] { SPHERE_CHAOS, SPHERE_LBL_CHAOS, "chaos" },
			new object[] { SPHERE_LAW, SPHERE_LBL_LAW, "law" },
			new object[] { SPHERE_NUMBERS, SPHERE_LBL_NUMBERS, "numbers" },
			new object[] { SPHERE_THOUGHT, SPHERE_LBL_THOUGHT, "thought" },
			new object[] { SPHERE_TIME, SPHERE_LBL_TIME, "time" },
			new object[] { SPHERE_TRAVELERS, SPHERE_LBL_TRAVELERS, "travelers" },
			new object[] { SPHERE_WAR, SPHERE_LBL_WAR, "war" },
			new object[] { SPHERE_WARDS, SPHERE_LBL_WARDS, "wards" }
		};
		
		private const string COMP_LBL_VERBAL = "V";
		private const string COMP_LBL_SOMATIC = "S";
		private const string COMP_LBL_MATERIAL = "M";
		private readonly object[][] COMPOS = new object[][] {
			new object[] { COMP_VERBAL, COMP_LBL_VERBAL, "Verbal" },
			new object[] { COMP_SOMATIC, COMP_LBL_SOMATIC, "Somatic" },
			new object[] { COMP_MATERIAL, COMP_LBL_MATERIAL, "Material" }
		};

		private const string BOOK_LBL_BASE = "Base";
		private const string BOOK_LBL_TOME = "Tome";
		private const string BOOK_LBL_WIZARDS = "Wizards";
		private const string BOOK_LBL_PRIESTS = "Priests";
		private const string BOOK_LBL_SPELLS = "Spells";
		private const string BOOK_LBL_ADVENTURES = "Adventures";
		private const string BOOK_LBL_CUSTOM = "Custom";
		private const string BOOK_LBL_CARNAL = "Carnal";
		private const string BOOK_LBL_ALCOHOL = "Alcohol";
		private readonly object[][] BOOKS = {
			new object[] { BOOK_BASE, BOOK_LBL_BASE, "Base" },
			new object[] { BOOK_TOME, BOOK_LBL_TOME, "tome" },
			new object[] { BOOK_WIZARDS, BOOK_LBL_WIZARDS, "wizards" },
			new object[] { BOOK_PRIESTS, BOOK_LBL_PRIESTS, "priests" },
			new object[] { BOOK_SPELLS, BOOK_LBL_SPELLS, "spells" },
			new object[] { BOOK_ADVENTURES, BOOK_LBL_ADVENTURES, "adventures" },
			new object[] { BOOK_CUSTOM, BOOK_LBL_CUSTOM, "custom" },
			new object[] { BOOK_CARNAL, BOOK_LBL_CARNAL, "carnal" },
			new object[] { BOOK_ALCOHOL, BOOK_LBL_ALCOHOL, "alcohol" }
		};
		
		public SpellDecoder() {
		}
		
		public string GetSpellType(decimal bitField) {
			return GetSpellType((int)bitField);
		}
		
		public string GetSpellType(int bitField) {
			string retVal;
			if (bitField == TYPE_WIZARDS) {
				retVal = "M";
			} else {
				retVal = "C";
			}
			return retVal;
		}
		
		public string GetSpellLevel(decimal level) {
			return GetSpellLevel((int)level);
		}
		
		public string GetSpellLevel(int level) {
			string retVal;
			
			if (level <= LEVEL_CANTRIP) {
				retVal =  LEVEL_LBL_CANTRIP;
			} else if (level >= LEVEL_QUEST) {
				retVal =  LEVEL_LBL_QUEST;
			} else {
				retVal = level.ToString();
			}
			return retVal;
		}
		
		public string GetSpellAttrib(decimal spellType, decimal level, bool reversible) {
			return GetSpellAttrib((int)spellType, (int)level, reversible);
		}
		
		public string GetSpellAttrib(int spellType, int level, bool reversible) {
			string retVal;
			string levelName;
			
			if (level <= LEVEL_CANTRIP) {
				levelName = LEVEL_LBL[LEVEL_CANTRIP];
			} else if (level >= LEVEL_QUEST) {
				levelName = LEVEL_LBL[LEVEL_QUEST];
			} else {
				levelName = LEVEL_LBL[level];
			}
			
			if (spellType == TYPE_WIZARDS) {
				//Spell
				if (level == LEVEL_CANTRIP) {
					retVal = "Cantrip";
				} else {
					retVal = levelName + " level spell";
				}
			} else {
				//Prayer
				if (level == LEVEL_CANTRIP) {
					retVal = "Orison";
				} else {
					retVal = levelName + " level prayer";
				}
			}
			
			if (reversible) {
				retVal += " (reversible)";
			}
			
			return retVal;
		}
		
		public string GetSchools(decimal bitField) {
			return GetSchools(bitField, false);
		}
		
		public string GetSchools(decimal bitField, bool brackets) {
			return GetSchools((int)bitField, brackets);
		}
		
		public string GetSchools(int bitField, bool brackets) {
			string retVal;
			if (bitField == (int)SCHOOL_ALL) {
				retVal = SCHOOL_LBL_ALL;
			} else {
				retVal = GetTexts((uint)bitField, SCHOOLS);
			}
			if (brackets && retVal.Length > 0) {
				retVal = "(" + retVal + ")";
			}
			return retVal;
		}
		
		public string GetSpheres(decimal bitField) {
			return GetSpheres((int)bitField);
		}
		
		public string GetSpheres(int bitField) {
			string retVal;
			if (bitField == (int)SPHERE_ALL) {
				retVal = SPHERE_LBL_ALL;
			} else {
				retVal = GetTexts((uint)bitField, SPHERES);
			}
			return retVal;
		}
		
		public string GetComponents(decimal bitField) {
			return GetComponents((int)bitField);
		}
		
		public string GetComponents(int bitField) {
			return GetTexts((uint)bitField, COMPOS);
			
		}
		
		public string GetCompos(decimal bitField) {
			return GetCompos((int)bitField);
		}
		
		public string GetCompos(int bitField) {
			return GetLabels((uint)bitField, COMPOS);
			
		}
		
		private const string INDENT = "&nbsp; &nbsp; ";
		
		public string getDescription(string description) {

			//description += "<br  />";
			
			StringBuilder retVal = new StringBuilder(description.Length + 10);

			//Add indentation after every <br>
			//retVal.Insert(0, indent);
			Color color = SystemColors.Control;
			retVal.Append("<html><head></head><body style=\"background-color:" + ColorTranslator.ToHtml(color) + ";\">");
			retVal.Append("<span style=\"font-family:sans-serif;font-size:x-small;\">");
			retVal.Append(INDENT);
	
			int index = 0;
			int lastIndex = 0;
			do {
				index = description.IndexOf("<br", index);
				if (index >= 0) {
					index = description.IndexOf(">", index);
				}
				if (index >= 0) {
					if (index + 1 == description.Length || description[index + 1] != '<') {
						retVal.Append(description.Substring(lastIndex, (index + 1) - lastIndex));
						retVal.Append(INDENT);
						lastIndex = index + 1;
					}
				}
			} while (index >= 0);

			if (lastIndex < description.Length) {
				retVal.Append(description.Substring(lastIndex));
			}
			retVal.Append("</span>");
			retVal.Append("</body>");
			
			return retVal.ToString();
		}
		
		private string GetLabels(uint bitField, object[][] table) {
			return GetTableValues(bitField, table, IDX_LABEL);
		}
		
		private string GetTexts(uint bitField, object[][] table) {
			return GetTableValues(bitField, table, IDX_TEXT);
		}
		
		private string GetTableValues(uint bitField, object[][] table, uint target) {
			string retVal = "";
			string sep = "";
			foreach (object[] touple in table) {
				uint code = (uint)touple[IDX_CODE];
				if (code == BITFIELD_ALL) {
					//Ignore the "ALL" label
					continue;
				}
				if ((bitField & code) != 0) {
					//retVal.add((String)couple[IDX_LABEL]);
					retVal += sep + (string)touple[target];
					sep = SEPARATOR;
				}
			}
			return retVal;
		}
		
	}
}
