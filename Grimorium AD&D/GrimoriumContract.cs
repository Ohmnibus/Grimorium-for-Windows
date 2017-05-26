/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 22/05/2017
 * Time: 22:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace net.ohmnibus.grimorium.database
{
	public sealed class GrimoriumContract {

	private GrimoriumContract() {}

	public class BaseColumns {
		public const string _ID = "_id";
		public BaseColumns() {}
	}
	
	public sealed class SourceTable : BaseColumns {
		public const string TABLE_NAME = "source";
		public const string COLUMN_NAME_NAME = "name";
		public const string COLUMN_NAME_NAMESPACE = "namespace";
		public const string COLUMN_NAME_VERSION = "version";
		public const string COLUMN_NAME_DESCRIPTION = "description";
		public const string COLUMN_NAME_URL = "url";
	}

	public sealed class SpellTable : BaseColumns {
		public const string TABLE_NAME = "spell";
		public const string COLUMN_NAME_SOURCE = "source";
		public const string COLUMN_NAME_UID = "uid";
		public const string COLUMN_NAME_TYPE = "type";
		public const string COLUMN_NAME_LEVEL = "level";
		public const string COLUMN_NAME_NAME = "name";
		public const string COLUMN_NAME_REVERSIBLE = "rev";
		public const string COLUMN_NAME_SCHOOLS = "schools";
		public const string COLUMN_NAME_SCHOOLS_BITFIELD = "schools_bf";
		public const string COLUMN_NAME_SPHERES = "spheres";
		public const string COLUMN_NAME_SPHERES_BITFIELD = "spheres_bf";
		public const string COLUMN_NAME_RANGE = "range";
		public const string COLUMN_NAME_COMPONENTS = "components";
		public const string COLUMN_NAME_COMPONENTS_BITFIELD = "components_bf";
		public const string COLUMN_NAME_DURATION = "duration";
		public const string COLUMN_NAME_CAST_TIME = "cast_time";
		public const string COLUMN_NAME_AOE = "aoe";
		public const string COLUMN_NAME_SAVING = "saving";
		public const string COLUMN_NAME_BOOK = "book";
		public const string COLUMN_NAME_BOOK_BITFIELD = "book_bf";
		public const string COLUMN_NAME_AUTHOR = "author";
		public const string COLUMN_NAME_DESCRIPTION = "desc";
		public const string INDEX_NAME = TABLE_NAME + COLUMN_NAME_TYPE + COLUMN_NAME_LEVEL + COLUMN_NAME_NAME;
	}

	public sealed class ProfileTable : BaseColumns {
		public const string TABLE_NAME = "profile";
		public const string COLUMN_NAME_KEY = "key";
		public const string COLUMN_NAME_NAME = "name";
		public const string COLUMN_NAME_SYS = "sys";
		public const string COLUMN_NAME_TYPES = "types";
		public const string COLUMN_NAME_LEVELS = "levels";
		public const string COLUMN_NAME_BOOKS = "books";
		public const string COLUMN_NAME_SCHOOLS = "schools";
		public const string COLUMN_NAME_SPHERES = "spheres";
		public const string COLUMN_NAME_COMPONENTS = "components";
		public const string COLUMN_NAME_STARRED_ONLY = "starred_only";
		public const string COLUMN_NAME_FILTERED_SOURCES = "filtered_sources";
		public const string INDEX_NAME = TABLE_NAME + COLUMN_NAME_KEY;
	}

	public sealed class StarTable : BaseColumns {
		public const string TABLE_NAME = "star";
		public const string COLUMN_NAME_PROFILE_ID = "profile_id";
		public const string COLUMN_NAME_SPELL_ID = "spell_id";
		public const string COLUMN_NAME_STARRED = "starred";
		public const string INDEX_NAME = TABLE_NAME + COLUMN_NAME_PROFILE_ID + COLUMN_NAME_SPELL_ID;
	}
}

}
