using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Property
{
	public class TRA_Menu_411_ViewModel : MenuListViewModel<Models.Property>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<TRA_Menu_411_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "property";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "c1c8fa01-8256-4245-9d7a-77197d5d7efb";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();
				// Limitations

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				conds.Equal(CSGenioAproperty.FldBrokers_fk, Navigation.GetValue("broker"));

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL TRA LIST_LIMITS 411]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("property", user, "TRA");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML411");
			conditions.Equal(CSGenioAproperty.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAproperty.FldCodproperty, CSGenioAproperty.FldZzstate, CSGenioAproperty.FldTopoogy, CSGenioAproperty.FldSize, CSGenioAproperty.FldTitle, CSGenioAproperty.FldCity_fk, CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAproperty.FldBrokers_fk, CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAproperty.FldBathroom_number, CSGenioAproperty.FldPhoto, CSGenioAproperty.FldDate, CSGenioAproperty.FldBuildingtype, CSGenioAproperty.FldPrice };

			ListingMVC<CSGenioAproperty> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);

			if (!qs.Joins.Select(x => x.Table).Select(y => y.TableAlias).Contains(CSGenio.business.Area.AreaBROKER.Alias))
				qs.Join(CSGenio.business.Area.AreaBROKER, TableJoinType.Inner).On(CriteriaSet.And().Equal(CSGenioAbroker.FldCodbroker, CSGenioAproperty.FldBrokers_fk));



			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public TRA_Menu_411_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TRA_Menu_411_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public TRA_Menu_411_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ADMINISTRATION;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TRA_Menu_411_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public TRA_Menu_411_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAproperty.FldTopoogy, FieldType.ARRAY_NUMERIC, Resources.Resources.TOPOOGY11786, 1, 0, true, "Typology"),
				new Exports.QColumn(CSGenioAproperty.FldSize, FieldType.NUMERIC, string.Empty, 5, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldTitle, FieldType.TEXT, Resources.Resources.TITLE11628, 30, 0, true),
				new Exports.QColumn(CSGenioAcity.FldCity, FieldType.TEXT, Resources.Resources.CITY35974, 30, 0, true),
				new Exports.QColumn(CSGenioAbroker.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldBathroom_number, FieldType.NUMERIC, Resources.Resources.BATHROOM_NUMBER01832, 2, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldDate, FieldType.DATE, Resources.Resources.DAT56009, 8, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldBuildingtype, FieldType.ARRAY_TEXT, Resources.Resources.BUILDINGTYPE40152, 1, 0, true, "building_type"),
				new Exports.QColumn(CSGenioAproperty.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 15, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAproperty> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAproperty> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAproperty.FldPhoto, FieldType.IMAGE, Resources.Resources.PHOTO38852, 3, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldTitle, FieldType.TEXT, Resources.Resources.TITLE11628, 80, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldPrice, FieldType.CURRENCY, Resources.Resources.PRICE06900, 14, 2, true),
				new Exports.QColumn(CSGenioAproperty.FldBathroom_number, FieldType.NUMERIC, Resources.Resources.BATHROOM_NUMBER01832, 2, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldDate, FieldType.DATE, Resources.Resources.DAT56009, 8, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldSize, FieldType.NUMERIC, String.Empty, 5, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldBuildingtype, FieldType.ARRAY_TEXT, Resources.Resources.BUILDINGTYPE40152, 1, 0, true, "building_type"),
				new Exports.QColumn(CSGenioAproperty.FldTopoogy, FieldType.ARRAY_NUMERIC, Resources.Resources.TOPOOGY11786, 1, 0, true, "Typology"),
				new Exports.QColumn(CSGenioAproperty.FldId, FieldType.NUMERIC, Resources.Resources.ID48520, 10, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldDateofconstruction, FieldType.DATE, Resources.Resources.DATE_OF_CONSTRUCTION18871, 8, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldGroundsize, FieldType.NUMERIC, Resources.Resources.GROUND_SIZE31027, 6, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldFloornumber, FieldType.NUMERIC, Resources.Resources.FLOOR_NUMBER61665, 3, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldFeilddescription, FieldType.TEXT, Resources.Resources.FEILDDESCRIPTION37400, 50, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldSold, FieldType.NUMERIC, Resources.Resources.SOLD56700, 5, 0, true),
				new Exports.QColumn(CSGenioAproperty.FldSolddate, FieldType.DATE, Resources.Resources.SOLD_DATE50102, 8, 0, true),
				new Exports.QColumn(CSGenioAcity.FldCity, FieldType.TEXT, Resources.Resources.CITY35974, 30, 0, true),
				new Exports.QColumn(CSGenioAbroker.FldName, FieldType.TEXT, Resources.Resources.NAME31974, 30, 0, true),
			};
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<TRA_Menu_411_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			// Limit "DB"
			crs.Equal(CSGenioAproperty.FldBrokers_fk, Navigation.GetValue("broker"));
			if (isToExport)
			{
				// EPH
				crs = Models.Property.AddEPH<CSGenioAproperty>(ref u, crs, "ML411");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAproperty.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PROPERTY", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAproperty.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_property");
				Navigation.DestroyEntry("QMVC_POS_RECORD_property");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Property.AddEPH<CSGenioAproperty>(ref u, null, "ML411"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAproperty> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAproperty> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAproperty> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAproperty> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<TRA_Menu_411_RowViewModel>();

			CriteriaSet tra_menu_411Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("PROPERTY.TITLE", new OrderedDictionary());
			allSortOrders["PROPERTY.TITLE"].Add("PROPERTY.TITLE", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "property", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAproperty.FldTitle), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAproperty.FldCodproperty, CSGenioAproperty.FldZzstate, CSGenioAproperty.FldTopoogy, CSGenioAproperty.FldSize, CSGenioAproperty.FldTitle, CSGenioAproperty.FldCity_fk, CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAproperty.FldBrokers_fk, CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAproperty.FldBathroom_number, CSGenioAproperty.FldPhoto, CSGenioAproperty.FldDate, CSGenioAproperty.FldBuildingtype, CSGenioAproperty.FldPrice };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("property", "topoogy");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAproperty model_limit_area = new CSGenioAproperty(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML411");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}

			// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
			// Limit origin: menu 

			//Limit type: "DB"
			//Current Area = "PROPERTY"
			//1st Area Limit: "BROKER"
			//1st Area Field: "CODBROKER"
			//1st Area Value: ""
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.DB;
				limit.NaoAplicaSeNulo = false;
				CSGenioAbroker model_limit_area = new CSGenioAbroker(m_userContext.User);
				string limit_field = "codbroker", limit_field_value = "";
				object this_limit_field = Navigation.GetStrValue(limit_field_value);
				Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
				if (!this.TableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
					this.TableLimits.Add(limit);
			}

			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(tra_menu_411Conds);
			tra_menu_411Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL TRA OVERRQ 411]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAproperty>(m_userContext, false, ref tra_menu_411Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML411", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL TRA OVERRQLSTEXP 411]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL TRA OVERRQLIST 411]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_property");
				Navigation.DestroyEntry("QMVC_POS_RECORD_property");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAproperty.GetInformation(), QMVC_POS_RECORD, sorts, tra_menu_411Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAproperty> listing = Models.ModelBase.Where<CSGenioAproperty>(m_userContext, distinct, tra_menu_411Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML411", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapTRA_Menu_411(listing);

				Menu.Identifier = "ML411";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML411";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<TRA_Menu_411_RowViewModel> MapTRA_Menu_411(ListingMVC<CSGenioAproperty> Qlisting)
		{
			List<TRA_Menu_411_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapTRA_Menu_411(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAproperty row
		/// to a TRA_Menu_411_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private TRA_Menu_411_RowViewModel MapTRA_Menu_411(CSGenioAproperty row)
		{
			var model = new TRA_Menu_411_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "property":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "city":
						model.City.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "broker":
						model.Broker.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAproperty> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Property m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Property m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL TRA VIEWMODEL_CUSTOM TRA_MENU_411]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Property", "Property.ValCodproperty", "Property.ValZzstate", "Property.ValTopoogy", "Property.ValSize", "Property.ValTitle", "City", "City.ValCity", "Broker", "Broker.ValName", "Property.ValBathroom_number", "Property.ValPhoto", "Property.ValDate", "Property.ValBuildingtype", "Property.ValPrice", "Property.ValBrokers_fk", "Property.ValCity_fk"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValTopoogy", CSGenioAproperty.FldTopoogy, typeof(decimal), array : "Typology"),
			new TableSearchColumn("ValSize", CSGenioAproperty.FldSize, typeof(decimal?)),
			new TableSearchColumn("ValTitle", CSGenioAproperty.FldTitle, typeof(string), defaultSearch : true),
			new TableSearchColumn("City_ValCity", CSGenioAcity.FldCity, typeof(string)),
			new TableSearchColumn("Broker_ValName", CSGenioAbroker.FldName, typeof(string)),
			new TableSearchColumn("ValBathroom_number", CSGenioAproperty.FldBathroom_number, typeof(decimal?)),
			new TableSearchColumn("ValDate", CSGenioAproperty.FldDate, typeof(DateTime?)),
			new TableSearchColumn("ValBuildingtype", CSGenioAproperty.FldBuildingtype, typeof(string), array : "building_type"),
			new TableSearchColumn("ValPrice", CSGenioAproperty.FldPrice, typeof(decimal?)),
		];
		protected void SetTicketToImageFields(Models.Property row)
		{
			if (row == null)
				return;

			row.ValPhotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPERTY, CSGenioAproperty.FldPhoto.Field, null, row.ValCodproperty);
		}
	}
}
