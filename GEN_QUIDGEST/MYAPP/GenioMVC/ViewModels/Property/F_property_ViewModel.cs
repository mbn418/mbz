using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Property
{
	public class F_property_ViewModel : FormViewModel<Models.Property>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "brokers Name" | Type: "CE"
		/// </summary>
		public string ValBrokers_fk { get; set; }
		/// <summary>
		/// Title: "city" | Type: "CE"
		/// </summary>
		public string ValCity_fk { get; set; }

		#endregion
		/// <summary>
		/// Title: "photo" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "title" | Type: "C"
		/// </summary>
		public string ValTitle { get; set; }
		/// <summary>
		/// Title: "Price" | Type: "$"
		/// </summary>
		public decimal? ValPrice { get; set; }
		/// <summary>
		/// Title: "brokers Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Broker> TableBrokerName { get; set; }
		/// <summary>
		/// Title: "BATHROOM_NUMBER" | Type: "N"
		/// </summary>
		public decimal? ValBathroom_number { get; set; }
		/// <summary>
		/// Title: "dat" | Type: "D"
		/// </summary>
		public DateTime? ValDate { get; set; }
		/// <summary>
		/// Title: "" | Type: "N"
		/// </summary>
		public decimal? ValSize { get; set; }
		/// <summary>
		/// Title: "city" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.City> TableCityCity { get; set; }
		/// <summary>
		/// Title: "BUILDINGTYPE" | Type: "AC"
		/// </summary>
		public string ValBuildingtype { get; set; }
		/// <summary>
		/// Title: "TOPOLOGY" | Type: "AN"
		/// </summary>
		public decimal ValTopoogy { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodproperty { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_property_ViewModel() : base(null!) { }

		public F_property_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_PROPERTY", nestedForm) { }

		public F_property_ViewModel(UserContext userContext, Models.Property row, bool nestedForm = false) : base(userContext, "FF_PROPERTY", row, nestedForm) { }

		public F_property_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("property", id);
			Model = Models.Property.Find(id, userContext, "FF_PROPERTY", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Property model = new Models.Property(userContext) { Identifier = "FF_PROPERTY" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_PROPERTY");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Property m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Property) to ViewModel (F_property) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValBrokers_fk = ViewModelConversion.ToString(m.ValBrokers_fk);
				ValCity_fk = ViewModelConversion.ToString(m.ValCity_fk);
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValTitle = ViewModelConversion.ToString(m.ValTitle);
				ValPrice = ViewModelConversion.ToNumeric(m.ValPrice);
				ValBathroom_number = ViewModelConversion.ToNumeric(m.ValBathroom_number);
				ValDate = ViewModelConversion.ToDateTime(m.ValDate);
				ValSize = ViewModelConversion.ToNumeric(m.ValSize);
				ValBuildingtype = ViewModelConversion.ToString(m.ValBuildingtype);
				ValTopoogy = ViewModelConversion.ToNumeric(m.ValTopoogy);
				ValCodproperty = ViewModelConversion.ToString(m.ValCodproperty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Property) to ViewModel (F_property) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Property m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_property) to Model (Property) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValBrokers_fk = ViewModelConversion.ToString(ValBrokers_fk);
				m.ValCity_fk = ViewModelConversion.ToString(ValCity_fk);
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValTitle = ViewModelConversion.ToString(ValTitle);
				m.ValPrice = ViewModelConversion.ToNumeric(ValPrice);
				m.ValBathroom_number = ViewModelConversion.ToNumeric(ValBathroom_number);
				m.ValDate = ViewModelConversion.ToDateTime(ValDate);
				m.ValSize = ViewModelConversion.ToNumeric(ValSize);
				m.ValBuildingtype = ViewModelConversion.ToString(ValBuildingtype);
				m.ValTopoogy = ViewModelConversion.ToNumeric(ValTopoogy);
				m.ValCodproperty = ViewModelConversion.ToString(ValCodproperty);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_property) to Model (Property) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "property.brokers_fk":
						this.ValBrokers_fk = ViewModelConversion.ToString(_value);
						break;
					case "property.city_fk":
						this.ValCity_fk = ViewModelConversion.ToString(_value);
						break;
					case "property.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "property.title":
						this.ValTitle = ViewModelConversion.ToString(_value);
						break;
					case "property.price":
						this.ValPrice = ViewModelConversion.ToNumeric(_value);
						break;
					case "property.bathroom_number":
						this.ValBathroom_number = ViewModelConversion.ToNumeric(_value);
						break;
					case "property.date":
						this.ValDate = ViewModelConversion.ToDateTime(_value);
						break;
					case "property.size":
						this.ValSize = ViewModelConversion.ToNumeric(_value);
						break;
					case "property.buildingtype":
						this.ValBuildingtype = ViewModelConversion.ToString(_value);
						break;
					case "property.topoogy":
						this.ValTopoogy = ViewModelConversion.ToNumeric(_value);
						break;
					case "property.codproperty":
						this.ValCodproperty = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_property) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_property)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Property.Find(id ?? Navigation.GetStrValue("property"), m_userContext, "FF_PROPERTY"); }
			finally { Model ??= new Models.Property(m_userContext) { Identifier = "FF_PROPERTY" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Property.Find(Navigation.GetStrValue("property"), m_userContext, "FF_PROPERTY");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FF_PROPERTY";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Property row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Property.Find(Navigation.GetStrValue("property"), m_userContext, "FF_PROPERTY");
				if (Model == null)
				{
					Model = new Models.Property(m_userContext) { Identifier = "FF_PROPERTY" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("property");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_property__broker__name(qs, lazyLoad);
			Load_F_property__city__city(qs, lazyLoad);

// USE /[MANUAL TRA VIEWMODEL_LOADPARTIAL F_PROPERTY]/
		}

// USE /[MANUAL TRA VIEWMODEL_NEW F_PROPERTY]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValTitle", Resources.Resources.TITLE11628, ValTitle, 80);

			validator.Required("ValTitle", Resources.Resources.TITLE11628, ViewModelConversion.ToString(ValTitle), FieldType.TEXT.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL TRA VIEWMODEL_SAVE F_PROPERTY]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL TRA VIEWMODEL_APPLY F_PROPERTY]/

// USE /[MANUAL TRA VIEWMODEL_DUPLICATE F_PROPERTY]/

// USE /[MANUAL TRA VIEWMODEL_DESTROY F_PROPERTY]/
		public override void Destroy(string id)
		{
			Model = Models.Property.Find(id, m_userContext, "FF_PROPERTY");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		/// <summary>
		/// TableBrokerName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_property__broker__name(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_property__broker__nameDoLoad = true;
			CriteriaSet f_property__broker__nameConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("broker", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_property__broker__nameConds.Equal(CSGenioAbroker.FldCodbroker, hValue);
					this.ValBrokers_fk = DBConversion.ToString(hValue);
				}
			}

			TableBrokerName = new TableDBEdit<Models.Broker>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_broker") != null)
				{
					this.ValBrokers_fk = Navigation.GetStrValue("RETURN_broker");
					Navigation.CurrentLevel.SetEntry("RETURN_broker", null);
				}
				FillDependant_F_propertyTableBrokerName(lazyLoad);
				return;
			}

			if (f_property__broker__nameDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableBrokerName, "sTableBrokerName", "dTableBrokerName", qs, "broker");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAbroker.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableBrokerName_tableFilters"]))
					TableBrokerName.TableFilters = bool.Parse(qs["TableBrokerName_tableFilters"]);
				else
					TableBrokerName.TableFilters = false;

				query = qs["qTableBrokerName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAbroker.FldName, query + "%");
				}
				f_property__broker__nameConds.SubSet(search_filters);

				string tryParsePage = qs["pTableBrokerName"] != null ? qs["pTableBrokerName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName, CSGenioAbroker.FldEmail, CSGenioAbroker.FldZzstate];

// USE /[MANUAL TRA OVERRQ F_PROPERTY_BROKERNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("broker", FormMode.New) || Navigation.checkFormMode("broker", FormMode.Duplicate))
					f_property__broker__nameConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAbroker.FldZzstate, 0)
						.Equal(CSGenioAbroker.FldCodbroker, Navigation.GetStrValue("broker")));
				else
					f_property__broker__nameConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAbroker.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("broker", "name");
				ListingMVC<CSGenioAbroker> listing = Models.ModelBase.Where<CSGenioAbroker>(m_userContext, false, f_property__broker__nameConds, fields, offset, numberItems, sorts, "LED_F_PROPERTY__BROKER__NAME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableBrokerName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableBrokerName.Query = query;
				TableBrokerName.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Broker(m_userContext, r, true, _fieldsToSerialize_F_PROPERTY__BROKER__NAME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_broker") != null)
				{
					this.ValBrokers_fk = Navigation.GetStrValue("RETURN_broker");
					Navigation.CurrentLevel.SetEntry("RETURN_broker", null);
				}

				TableBrokerName.List = new SelectList(TableBrokerName.Elements.ToSelectList(x => x.ValName, x => x.ValCodbroker,  x => x.ValCodbroker == this.ValBrokers_fk), "Value", "Text", this.ValBrokers_fk);
				FillDependant_F_propertyTableBrokerName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableBrokerName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Broker</param>
		public ConcurrentDictionary<string, object> GetDependant_F_propertyTableBrokerName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAbroker.FldCodbroker, CSGenioAbroker.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAbroker tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAbroker.FldCodbroker, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableBrokerName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_propertyTableBrokerName(bool lazyLoad = false)
		{
			var row = GetDependant_F_propertyTableBrokerName(this.ValBrokers_fk);
			try
			{

				// Fill List fields
				this.ValBrokers_fk = ViewModelConversion.ToString(row["broker.codbroker"]);
				TableBrokerName.Value = (string)row["broker.name"];
				if (GenFunctions.emptyG(this.ValBrokers_fk) == 1)
				{
					this.ValBrokers_fk = "";
					TableBrokerName.Value = "";
					Navigation.ClearValue("broker");
				}
				else if (lazyLoad)
				{
					TableBrokerName.SetPagination(1, 0, false, false, 1);
					TableBrokerName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValBrokers_fk),
							Text = Convert.ToString(TableBrokerName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValBrokers_fk);
				}

				TableBrokerName.Selected = this.ValBrokers_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableBrokerName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PROPERTY__BROKER__NAME = ["Broker", "Broker.ValCodbroker", "Broker.ValZzstate", "Broker.ValName", "Broker.ValEmail"];

		/// <summary>
		/// TableCityCity -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_property__city__city(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_property__city__cityDoLoad = true;
			CriteriaSet f_property__city__cityConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("city", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_property__city__cityConds.Equal(CSGenioAcity.FldCodcity, hValue);
					this.ValCity_fk = DBConversion.ToString(hValue);
				}
			}

			TableCityCity = new TableDBEdit<Models.City>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCity_fk = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}
				FillDependant_F_propertyTableCityCity(lazyLoad);
				return;
			}

			if (f_property__city__cityDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableCityCity, "sTableCityCity", "dTableCityCity", qs, "city");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcity.FldCity), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCityCity_tableFilters"]))
					TableCityCity.TableFilters = bool.Parse(qs["TableCityCity_tableFilters"]);
				else
					TableCityCity.TableFilters = false;

				query = qs["qTableCityCity"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcity.FldCity, query + "%");
				}
				f_property__city__cityConds.SubSet(search_filters);

				string tryParsePage = qs["pTableCityCity"] != null ? qs["pTableCityCity"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity, CSGenioAcity.FldZzstate];

// USE /[MANUAL TRA OVERRQ F_PROPERTY_CITYCITY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("city", FormMode.New) || Navigation.checkFormMode("city", FormMode.Duplicate))
					f_property__city__cityConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcity.FldZzstate, 0)
						.Equal(CSGenioAcity.FldCodcity, Navigation.GetStrValue("city")));
				else
					f_property__city__cityConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcity.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("city", "city");
				ListingMVC<CSGenioAcity> listing = Models.ModelBase.Where<CSGenioAcity>(m_userContext, false, f_property__city__cityConds, fields, offset, numberItems, sorts, "LED_F_PROPERTY__CITY__CITY", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCityCity.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCityCity.Query = query;
				TableCityCity.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.City(m_userContext, r, true, _fieldsToSerialize_F_PROPERTY__CITY__CITY));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_city") != null)
				{
					this.ValCity_fk = Navigation.GetStrValue("RETURN_city");
					Navigation.CurrentLevel.SetEntry("RETURN_city", null);
				}

				TableCityCity.List = new SelectList(TableCityCity.Elements.ToSelectList(x => x.ValCity, x => x.ValCodcity,  x => x.ValCodcity == this.ValCity_fk), "Value", "Text", this.ValCity_fk);
				FillDependant_F_propertyTableCityCity();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of City</param>
		public ConcurrentDictionary<string, object> GetDependant_F_propertyTableCityCity(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcity.FldCodcity, CSGenioAcity.FldCity];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcity tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcity.FldCodcity, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCityCity (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_propertyTableCityCity(bool lazyLoad = false)
		{
			var row = GetDependant_F_propertyTableCityCity(this.ValCity_fk);
			try
			{

				// Fill List fields
				this.ValCity_fk = ViewModelConversion.ToString(row["city.codcity"]);
				TableCityCity.Value = (string)row["city.city"];
				if (GenFunctions.emptyG(this.ValCity_fk) == 1)
				{
					this.ValCity_fk = "";
					TableCityCity.Value = "";
					Navigation.ClearValue("city");
				}
				else if (lazyLoad)
				{
					TableCityCity.SetPagination(1, 0, false, false, 1);
					TableCityCity.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCity_fk),
							Text = Convert.ToString(TableCityCity.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCity_fk);
				}

				TableCityCity.Selected = this.ValCity_fk;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCityCity): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PROPERTY__CITY__CITY = ["City", "City.ValCodcity", "City.ValZzstate", "City.ValCity"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"property.brokers_fk" => ViewModelConversion.ToString(modelValue),
				"property.city_fk" => ViewModelConversion.ToString(modelValue),
				"property.photo" => ViewModelConversion.ToImage(modelValue),
				"property.title" => ViewModelConversion.ToString(modelValue),
				"property.price" => ViewModelConversion.ToNumeric(modelValue),
				"property.bathroom_number" => ViewModelConversion.ToNumeric(modelValue),
				"property.date" => ViewModelConversion.ToDateTime(modelValue),
				"property.size" => ViewModelConversion.ToNumeric(modelValue),
				"property.buildingtype" => ViewModelConversion.ToString(modelValue),
				"property.topoogy" => ViewModelConversion.ToNumeric(modelValue),
				"property.codproperty" => ViewModelConversion.ToString(modelValue),
				"broker.codbroker" => ViewModelConversion.ToString(modelValue),
				"broker.name" => ViewModelConversion.ToString(modelValue),
				"city.codcity" => ViewModelConversion.ToString(modelValue),
				"city.city" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaPROPERTY, CSGenioAproperty.FldPhoto.Field, null, ValCodproperty);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL TRA VIEWMODEL_CUSTOM F_PROPERTY]/

		#endregion
	}
}
