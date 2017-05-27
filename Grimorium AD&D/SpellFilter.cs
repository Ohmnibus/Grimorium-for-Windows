/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 24/05/2017
 * Time: 22:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using System.Linq;

using Spell = Grimorium.ADnD.SpellDecoder;
using SpellTable = net.ohmnibus.grimorium.database.GrimoriumContract.SpellTable;

namespace Grimorium.ADnD
{
	/// <summary>
	/// Description of SpellFilter.
	/// </summary>
	public class SpellFilter {
		
		protected const string WHERE_SEP = "And ";
		
		public static readonly long[] NO_SOURCES = new long[0];
		public static long[] UNOFFICIAL_SOURCES = new long[0];
		
		public SpellFilter() {
			Reset();
		}
		
		public string query;
		
		public uint types;
		public uint levels;
		public uint books;
		public uint schools;
		public uint spheres;
		public uint compos;
		public long[] filteredSources;
		
		public bool Verbal {
			get {
				return IsValue(compos, Spell.COMP_VERBAL);
			}
			set {
				compos = SetValue(compos, Spell.COMP_VERBAL, value);
			}
		}
		
		public bool Somatic {
			get {
				return IsValue(compos, Spell.COMP_SOMATIC);
			}
			set {
				compos = SetValue(compos, Spell.COMP_SOMATIC, value);
			}
		}
		
		public bool Material {
			get {
				return IsValue(compos, Spell.COMP_MATERIAL);
			}
			set {
				compos = SetValue(compos, Spell.COMP_MATERIAL, value);
			}
		}
		
		public bool IsSchool(uint SchoolId) {
			return IsValue(schools, SchoolId);
		}

		public bool IsSphere(uint SphereId) {
			return IsValue(spheres, SphereId);
		}
		
//		public property string Query {
//			get {
//				return query;
//			}
//			set {
//				query = value;
//			}
//		}
		
		public void Reset() {
			query = null;
			types = Spell.TYPE_ALL;
			levels = Spell.LEVEL_ALL;
			books = Spell.BOOK_ALL;
			schools = Spell.SCHOOL_ALL;
			spheres = Spell.SPHERE_ALL;
			compos = Spell.COMP_ALL;
			filteredSources = UNOFFICIAL_SOURCES;
		}
	
		public bool IsEmpty() {
			return string.IsNullOrEmpty(query)
				&& types == Spell.TYPE_ALL
				&& levels == Spell.LEVEL_ALL
				&& books == Spell.BOOK_ALL
				&& schools == Spell.SCHOOL_ALL
				&& spheres == Spell.SPHERE_ALL
				&& compos == Spell.COMP_ALL
				&& (filteredSources == null || filteredSources.Length == 0);
				//&& sameSourceLists(filteredSources, UNOFFICIAL_SOURCES);
			
		}
		
		private bool sameSourceLists(long[] sourceList1, long[] sourceList2) {
			if (sourceList1 == null && sourceList2 == null) {
				return true;
			}
			if (sourceList1 == null
			    || sourceList2 == null
			    || sourceList1.Length != sourceList2.Length) {
				return false;
			}
			return sourceList1.SequenceEqual(sourceList2);
		}
		
				
		public bool WriteToFile(string path) {
			try {
				//using (FileStream fs = File.OpenWrite(path)) {
				using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
					using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) {
						sw.WriteLine(Serialize());
					}
				}
			} catch (Exception ex) {
				//Uh oh....
				Console.WriteLine(ex);
				return false;
			}
			return true;
		}

		public string Serialize() {
			//string retVal = "";
			return types.ToString("X") + 
				"|" + levels.ToString("X") +
				"|" + books.ToString("X") +
				"|" + schools.ToString("X") +
				"|" + spheres.ToString("X") +
				"|" + compos.ToString("X") +
				"|" + (filteredSources == null ? "" : string.Join(",", filteredSources.Select(S => S.ToString("X"))));
		}
		
		public static SpellFilter ReadFromFile(string path) {
			SpellFilter retVal;
			try {
				using (FileStream fs = File.OpenRead(path)) {
					using (StreamReader sr = new StreamReader(fs, Encoding.UTF8)) {
						retVal = SpellFilter.Deserialize(
							sr.ReadLine()
						);
					}
				}
			} catch (Exception ex) {
				//Uh oh....
				Console.WriteLine(ex);
				retVal = new SpellFilter();
			}
			return retVal;
		}
		
		public static SpellFilter Deserialize(string serialized) {
			SpellFilter retVal;
			try {
				string[] fields = serialized.Split('|');
				retVal = new SpellFilter();
				retVal.types = uint.Parse(fields[0], System.Globalization.NumberStyles.HexNumber);
				retVal.levels = uint.Parse(fields[1], System.Globalization.NumberStyles.HexNumber);
				retVal.books = uint.Parse(fields[2], System.Globalization.NumberStyles.HexNumber);
				retVal.schools = uint.Parse(fields[3], System.Globalization.NumberStyles.HexNumber);
				retVal.spheres = uint.Parse(fields[4], System.Globalization.NumberStyles.HexNumber);
				retVal.compos = uint.Parse(fields[5], System.Globalization.NumberStyles.HexNumber);
				string[] rawfilteredSources = fields[6].Split(',');
				retVal.filteredSources = rawfilteredSources
					.Where(T => ! string.IsNullOrEmpty(T))
					.Select(T => long.Parse(T, System.Globalization.NumberStyles.HexNumber))
					.ToArray();
			} catch (Exception ex) {
				Console.WriteLine(ex);
				retVal = new SpellFilter();
			}
			return retVal;
		}
		
		public static bool IsValue(uint bitField, uint bitToTest) {
			return (bitField & bitToTest) != 0;
		}
			
		public static uint SetValue(uint bitField, uint bitToTest, bool value) {
			if (value) {
				bitField |= bitToTest;
			} else {
				bitField &= ~bitToTest;
			}
			return bitField;
		}
		
		public static string GetWhereClause(SpellFilter spellFilter) {
			string whereClause = "";
			string whereSep = "";
			if (spellFilter != null && ! spellFilter.IsEmpty()) {
				if (! string.IsNullOrEmpty(spellFilter.query)) {
					whereClause += whereSep + SpellTable.COLUMN_NAME_NAME + " Like @filter ";
					whereSep = WHERE_SEP;
				}
				if (spellFilter.types != SpellDecoder.TYPE_ALL) {
					whereClause += whereSep + getBitTest(
							SpellTable.COLUMN_NAME_TYPE,
							spellFilter.types
					);
					whereSep = WHERE_SEP;
				}
				long[] filteredSources = spellFilter.filteredSources;
				if (filteredSources.Length > 0) {
					whereClause += whereSep + SpellTable.COLUMN_NAME_SOURCE + " " +
						"Not In (" + string.Join(",", filteredSources) + ") ";
					whereSep = WHERE_SEP;
				}
				if (spellFilter.books != Spell.BOOK_ALL) {
					whereClause += whereSep + getBitTest(
							SpellTable.COLUMN_NAME_BOOK_BITFIELD,
							spellFilter.books,
							Spell.BOOK_ALL
					);
					whereSep = WHERE_SEP;
				}
				if (spellFilter.levels != Spell.LEVEL_ALL) {
					whereClause += whereSep + getBitTest(
							"(1 << " + SpellTable.COLUMN_NAME_LEVEL + ")",
							spellFilter.levels
					);
					whereSep = WHERE_SEP;
				}
				if (spellFilter.schools != Spell.SCHOOL_ALL) {
					whereClause += whereSep + getBitTest(
							SpellTable.COLUMN_NAME_SCHOOLS_BITFIELD,
							spellFilter.schools,
							Spell.SCHOOL_ALL
					);
					whereSep = WHERE_SEP;
				}
				if (spellFilter.spheres != Spell.SCHOOL_ALL) {
					whereClause += whereSep + getBitTest(
							SpellTable.COLUMN_NAME_SPHERES_BITFIELD,
							spellFilter.spheres,
							Spell.SPHERE_ALL
					);
					whereSep = WHERE_SEP;
				}
	
				if (! spellFilter.Verbal) {
					whereClause += whereSep + getCompoTest(
							SpellTable.COLUMN_NAME_COMPONENTS_BITFIELD,
							Spell.COMP_VERBAL
					);
					whereSep = WHERE_SEP;
				}
				if (! spellFilter.Somatic) {
					whereClause += whereSep + getCompoTest(
							SpellTable.COLUMN_NAME_COMPONENTS_BITFIELD,
							Spell.COMP_SOMATIC
					);
					whereSep = WHERE_SEP;
				}
				if (! spellFilter.Material) {
					whereClause += whereSep + getCompoTest(
							SpellTable.COLUMN_NAME_COMPONENTS_BITFIELD,
							Spell.COMP_MATERIAL
					);
					whereSep = WHERE_SEP;
				}
//				if (spellFilter.isStarredOnly()) {
//					whereClause += whereSep + StarTable.TABLE_NAME + "." + StarTable.COLUMN_NAME_STARRED + " = 1";
//					whereSep = WHERE_SEP;
//				}
			}
			return whereClause;
		}
		
		protected static string getCompoTest(string field, uint component) {
			return string.Format("(({0} & {1}) = 0) ",
					field, component);
		}
		
		protected static string getBitTest(string field, uint filterValue) {
			return string.Format("(({0} & {1}) <> 0) ",
					field, filterValue);
		}
	
		protected static string getBitTest(string field, uint filterValue, uint defaultValue) {
			return string.Format("({0} = {2} Or ({0} & {1}) <> 0) ",
					field, filterValue, defaultValue);
		}
	}
}
