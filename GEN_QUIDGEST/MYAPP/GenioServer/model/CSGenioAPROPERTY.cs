
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Property
	/// </summary>
	public class CSGenioAproperty : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAproperty(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL TRA CONSTRUTOR PROPERTY]/
		}

		public CSGenioAproperty(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codproperty", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "photo", FieldType.IMAGE);
			Qfield.FieldDescription = "photo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHOTO38852";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "title", FieldType.TEXT);
			Qfield.FieldDescription = "title";
			Qfield.FieldSize =  80;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITLE11628";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "price", FieldType.CURRENCY);
			Qfield.FieldDescription = "Price";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PRICE06900";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "brokers_fk", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "bathroom_number", FieldType.NUMERIC);
			Qfield.FieldDescription = "BATHROOM_NUMBER";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "BATHROOM_NUMBER01832";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "date", FieldType.DATE);
			Qfield.FieldDescription = "dat";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DAT56009";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "size", FieldType.NUMERIC);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "city_fk", FieldType.KEY_INT);
			Qfield.FieldDescription = "CITY_FK";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CITY_FK13761";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buildingtype", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "BUILDINGTYPE";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BUILDINGTYPE40152";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCbuilding_type";
            Qfield.ArrayClassName = "Building_type";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "topoogy", FieldType.ARRAY_NUMERIC);
			Qfield.FieldDescription = "TOPOOGY";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TOPOOGY11786";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayNtypology";
            Qfield.ArrayClassName = "Typology";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "id", FieldType.NUMERIC);
			Qfield.FieldDescription = "ID";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "ID48520";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getGreaterPlus1_int, "id");
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "buildingage", FieldType.NUMERIC);
			Qfield.FieldDescription = "BUILDING AGE";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "BUILDING_AGE20720";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"dateofconstruction"}, new int[] {0}, "property", "codproperty"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GenFunctions.Year(DateTime.Today)-GenFunctions.Year(((DateTime)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "dateofconstruction", FieldType.DATE);
			Qfield.FieldDescription = "DATE OF CONSTRUCTION";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATE_OF_CONSTRUCTION18871";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "groundsize", FieldType.NUMERIC);
			Qfield.FieldDescription = "GROUND SIZE";
			Qfield.FieldSize =  6;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 6;
			Qfield.CavDesignation = "GROUND_SIZE31027";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "floornumber", FieldType.NUMERIC);
			Qfield.FieldDescription = "FLOOR NUMBER";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "FLOOR_NUMBER61665";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "feilddescription", FieldType.TEXT);
			Qfield.FieldDescription = "FEILDDESCRIPTION";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FEILDDESCRIPTION37400";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "sold", FieldType.NUMERIC);
			Qfield.FieldDescription = "sold";
			Qfield.FieldSize =  5;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.CavDesignation = "SOLD56700";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "solddate", FieldType.DATE);
			Qfield.FieldDescription = "sold date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "SOLD_DATE50102";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"sold"}, new int[] {0}, "property", "codproperty"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])==1;
			});
			Qfield.DefaultValue = new DefaultValue(DefaultValue.getToday);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("photo_album", new String[] {"codpropetry"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("contact", new String[] {"codproperty"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("broker", new Relation("TRA", "traproperty", "property", "codproperty", "brokers_fk", "TRA", "trabroker", "broker", "codbroker", "codbroker"));
			info.ParentTables.Add("city", new Relation("TRA", "traproperty", "property", "codproperty", "city_fk", "TRA", "tracity", "city", "codcity", "codcity"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("broker","broker");
			info.Pathways.Add("city","city");
			info.Pathways.Add("country","city");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("property", "broker", "nrofpropeties", "1", '+', false));
			info.RelatedSumArgs.Add( new RelatedSumArgument("property", "broker", "salesprofit", "price", '+', true));



			//Actualiza as seguintes rotinas de ultimo Qvalue:
			info.LastValueArgs = new List<LastValueArgument>();
			info.LastValueArgs.Add( new LastValueArgument("broker",
				new string [] {"lastsold"},
				new string [] {"solddate"},
				"id",
				null,

				null, false));


			info.InternalOperationFields = new string[] {
			 "buildingage"
			};

			info.DefaultValues = new string[] {
			 "solddate"
			};

			info.SequentialDefaultValues = new string[] {
			 "id"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();

			// [PROPERTY->PRICE]>0
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"price"},new int[] {0},"property","codproperty"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 1, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>0;
			});
			writeCondition.ErrorWarning = "You cant save a property without a price";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = true;
			writeCondition.Field = info.DBFields["price"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAproperty()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="TRA";
			info.TableName="traproperty";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codproperty";
			info.HumanKeyName="title,price,".TrimEnd(',');
			info.Alias="property";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Property";
			info.AreaPluralDesignation="Properties";
			info.DescriptionCav="PROPERTY43977";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodproperty { get { return m_fldCodproperty; } }
		private static FieldRef m_fldCodproperty = new FieldRef("property", "codproperty");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodproperty
		{
			get { return (string)returnValueField(FldCodproperty); }
			set { insertNameValueField(FldCodproperty, value); }
		}

		/// <summary>Field : "photo" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("property", "photo");

		/// <summary>Field : "photo" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}

		/// <summary>Field : "title" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitle { get { return m_fldTitle; } }
		private static FieldRef m_fldTitle = new FieldRef("property", "title");

		/// <summary>Field : "title" Tipo: "C" Formula:  ""</summary>
		public string ValTitle
		{
			get { return (string)returnValueField(FldTitle); }
			set { insertNameValueField(FldTitle, value); }
		}

		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldPrice { get { return m_fldPrice; } }
		private static FieldRef m_fldPrice = new FieldRef("property", "price");

		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		public decimal ValPrice
		{
			get { return (decimal)returnValueField(FldPrice); }
			set { insertNameValueField(FldPrice, value); }
		}

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldBrokers_fk { get { return m_fldBrokers_fk; } }
		private static FieldRef m_fldBrokers_fk = new FieldRef("property", "brokers_fk");

		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		public string ValBrokers_fk
		{
			get { return (string)returnValueField(FldBrokers_fk); }
			set { insertNameValueField(FldBrokers_fk, value); }
		}

		/// <summary>Field : "BATHROOM_NUMBER" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldBathroom_number { get { return m_fldBathroom_number; } }
		private static FieldRef m_fldBathroom_number = new FieldRef("property", "bathroom_number");

		/// <summary>Field : "BATHROOM_NUMBER" Tipo: "N" Formula:  ""</summary>
		public decimal ValBathroom_number
		{
			get { return (decimal)returnValueField(FldBathroom_number); }
			set { insertNameValueField(FldBathroom_number, value); }
		}

		/// <summary>Field : "dat" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDate { get { return m_fldDate; } }
		private static FieldRef m_fldDate = new FieldRef("property", "date");

		/// <summary>Field : "dat" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDate
		{
			get { return (DateTime)returnValueField(FldDate); }
			set { insertNameValueField(FldDate, value); }
		}

		/// <summary>Field : "" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSize { get { return m_fldSize; } }
		private static FieldRef m_fldSize = new FieldRef("property", "size");

		/// <summary>Field : "" Tipo: "N" Formula:  ""</summary>
		public decimal ValSize
		{
			get { return (decimal)returnValueField(FldSize); }
			set { insertNameValueField(FldSize, value); }
		}

		/// <summary>Field : "CITY_FK" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCity_fk { get { return m_fldCity_fk; } }
		private static FieldRef m_fldCity_fk = new FieldRef("property", "city_fk");

		/// <summary>Field : "CITY_FK" Tipo: "CE" Formula:  ""</summary>
		public string ValCity_fk
		{
			get { return (string)returnValueField(FldCity_fk); }
			set { insertNameValueField(FldCity_fk, value); }
		}

		/// <summary>Field : "BUILDINGTYPE" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldBuildingtype { get { return m_fldBuildingtype; } }
		private static FieldRef m_fldBuildingtype = new FieldRef("property", "buildingtype");

		/// <summary>Field : "BUILDINGTYPE" Tipo: "AC" Formula:  ""</summary>
		public string ValBuildingtype
		{
			get { return (string)returnValueField(FldBuildingtype); }
			set { insertNameValueField(FldBuildingtype, value); }
		}

		/// <summary>Field : "TOPOOGY" Tipo: "AN" Formula:  ""</summary>
		public static FieldRef FldTopoogy { get { return m_fldTopoogy; } }
		private static FieldRef m_fldTopoogy = new FieldRef("property", "topoogy");

		/// <summary>Field : "TOPOOGY" Tipo: "AN" Formula:  ""</summary>
		public decimal ValTopoogy
		{
			get { return (decimal)returnValueField(FldTopoogy); }
			set { insertNameValueField(FldTopoogy, value); }
		}

		/// <summary>Field : "ID" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldId { get { return m_fldId; } }
		private static FieldRef m_fldId = new FieldRef("property", "id");

		/// <summary>Field : "ID" Tipo: "N" Formula:  ""</summary>
		public decimal ValId
		{
			get { return (decimal)returnValueField(FldId); }
			set { insertNameValueField(FldId, value); }
		}

		/// <summary>Field : "BUILDING AGE" Tipo: "N" Formula: + "Year([Today]) - Year([PROPERTY->DATEOFCONSTRUCTION])"</summary>
		public static FieldRef FldBuildingage { get { return m_fldBuildingage; } }
		private static FieldRef m_fldBuildingage = new FieldRef("property", "buildingage");

		/// <summary>Field : "BUILDING AGE" Tipo: "N" Formula: + "Year([Today]) - Year([PROPERTY->DATEOFCONSTRUCTION])"</summary>
		public decimal ValBuildingage
		{
			get { return (decimal)returnValueField(FldBuildingage); }
			set { insertNameValueField(FldBuildingage, value); }
		}

		/// <summary>Field : "DATE OF CONSTRUCTION" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDateofconstruction { get { return m_fldDateofconstruction; } }
		private static FieldRef m_fldDateofconstruction = new FieldRef("property", "dateofconstruction");

		/// <summary>Field : "DATE OF CONSTRUCTION" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDateofconstruction
		{
			get { return (DateTime)returnValueField(FldDateofconstruction); }
			set { insertNameValueField(FldDateofconstruction, value); }
		}

		/// <summary>Field : "GROUND SIZE" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldGroundsize { get { return m_fldGroundsize; } }
		private static FieldRef m_fldGroundsize = new FieldRef("property", "groundsize");

		/// <summary>Field : "GROUND SIZE" Tipo: "N" Formula:  ""</summary>
		public decimal ValGroundsize
		{
			get { return (decimal)returnValueField(FldGroundsize); }
			set { insertNameValueField(FldGroundsize, value); }
		}

		/// <summary>Field : "FLOOR NUMBER" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldFloornumber { get { return m_fldFloornumber; } }
		private static FieldRef m_fldFloornumber = new FieldRef("property", "floornumber");

		/// <summary>Field : "FLOOR NUMBER" Tipo: "N" Formula:  ""</summary>
		public decimal ValFloornumber
		{
			get { return (decimal)returnValueField(FldFloornumber); }
			set { insertNameValueField(FldFloornumber, value); }
		}

		/// <summary>Field : "FEILDDESCRIPTION" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldFeilddescription { get { return m_fldFeilddescription; } }
		private static FieldRef m_fldFeilddescription = new FieldRef("property", "feilddescription");

		/// <summary>Field : "FEILDDESCRIPTION" Tipo: "C" Formula:  ""</summary>
		public string ValFeilddescription
		{
			get { return (string)returnValueField(FldFeilddescription); }
			set { insertNameValueField(FldFeilddescription, value); }
		}

		/// <summary>Field : "sold" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldSold { get { return m_fldSold; } }
		private static FieldRef m_fldSold = new FieldRef("property", "sold");

		/// <summary>Field : "sold" Tipo: "N" Formula:  ""</summary>
		public decimal ValSold
		{
			get { return (decimal)returnValueField(FldSold); }
			set { insertNameValueField(FldSold, value); }
		}

		/// <summary>Field : "sold date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldSolddate { get { return m_fldSolddate; } }
		private static FieldRef m_fldSolddate = new FieldRef("property", "solddate");

		/// <summary>Field : "sold date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValSolddate
		{
			get { return (DateTime)returnValueField(FldSolddate); }
			set { insertNameValueField(FldSolddate, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("property", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAproperty search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAproperty area = new CSGenioAproperty(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAproperty> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAproperty>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAproperty> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAproperty>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL TRA TABAUX PROPERTY]/

 
                    

	}
}
