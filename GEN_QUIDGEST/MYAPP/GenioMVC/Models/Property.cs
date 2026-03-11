using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Property : ModelBase
	{
		[JsonIgnore]
		public CSGenioAproperty klass { get { return baseklass as CSGenioAproperty; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Property.ValCodproperty")]
		public string ValCodproperty { get { return klass.ValCodproperty; } set { klass.ValCodproperty = value; } }

		[DisplayName("photo")]
		/// <summary>Field : "photo" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Property.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("title")]
		/// <summary>Field : "title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Property.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("Price")]
		/// <summary>Field : "Price" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Property.ValPrice")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValPrice { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPrice, 2)); } set { klass.ValPrice = Convert.ToDecimal(value); } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Property.ValBrokers_fk")]
		public string ValBrokers_fk { get { return klass.ValBrokers_fk; } set { klass.ValBrokers_fk = value; } }

		private Broker _broker;
		[DisplayName("Broker")]
		[ShouldSerialize("Broker")]
		public virtual Broker Broker
		{
			get
			{
				if (!isEmptyModel && (_broker == null || (!string.IsNullOrEmpty(ValBrokers_fk) && (_broker.isEmptyModel || _broker.klass.QPrimaryKey != ValBrokers_fk))))
					_broker = Models.Broker.Find(ValBrokers_fk, m_userContext, Identifier, _fieldsToSerialize);
				_broker ??= new Models.Broker(m_userContext, true, _fieldsToSerialize);
				return _broker;
			}
			set { _broker = value; }
		}

		[DisplayName("BATHROOM_NUMBER")]
		/// <summary>Field : "BATHROOM_NUMBER" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValBathroom_number")]
		[NumericAttribute(0)]
		public decimal? ValBathroom_number { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBathroom_number, 0)); } set { klass.ValBathroom_number = Convert.ToDecimal(value); } }

		[DisplayName("dat")]
		/// <summary>Field : "dat" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Property.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("")]
		/// <summary>Field : "" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValSize")]
		[NumericAttribute(0)]
		public decimal? ValSize { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSize, 0)); } set { klass.ValSize = Convert.ToDecimal(value); } }

		[DisplayName("CITY_FK")]
		/// <summary>Field : "CITY_FK" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Property.ValCity_fk")]
		public string ValCity_fk { get { return klass.ValCity_fk; } set { klass.ValCity_fk = value; } }

		private City _city;
		[DisplayName("City")]
		[ShouldSerialize("City")]
		public virtual City City
		{
			get
			{
				if (!isEmptyModel && (_city == null || (!string.IsNullOrEmpty(ValCity_fk) && (_city.isEmptyModel || _city.klass.QPrimaryKey != ValCity_fk))))
					_city = Models.City.Find(ValCity_fk, m_userContext, Identifier, _fieldsToSerialize);
				_city ??= new Models.City(m_userContext, true, _fieldsToSerialize);
				return _city;
			}
			set { _city = value; }
		}

		[DisplayName("BUILDINGTYPE")]
		/// <summary>Field : "BUILDINGTYPE" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Property.ValBuildingtype")]
		[DataArray("Building_type", GenioMVC.Helpers.ArrayType.Character)]
		public string ValBuildingtype { get { return klass.ValBuildingtype; } set { klass.ValBuildingtype = value; } }
		[JsonIgnore]
		public SelectList ArrayValbuildingtype { get { return new SelectList(CSGenio.business.ArrayBuilding_type.GetDictionary(), "Key", "Value", ValBuildingtype); } set { ValBuildingtype = value.SelectedValue as string; } }

		[DisplayName("TOPOOGY")]
		/// <summary>Field : "TOPOOGY" Tipo: "AN" Formula:  ""</summary>
		[ShouldSerialize("Property.ValTopoogy")]
		[DataArray("Typology", GenioMVC.Helpers.ArrayType.Numeric)]
		public decimal ValTopoogy { get { return klass.ValTopoogy; } set { klass.ValTopoogy = value; } }
		[JsonIgnore]
		public SelectList ArrayValtopoogy { get { return new SelectList(CSGenio.business.ArrayTypology.GetDictionary(), "Key", "Value", ValTopoogy); } set { ValTopoogy = Convert.ToDecimal(value.SelectedValue); } }

		[DisplayName("ID")]
		/// <summary>Field : "ID" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValId")]
		[NumericAttribute(0)]
		public decimal? ValId { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValId, 0)); } set { klass.ValId = Convert.ToDecimal(value); } }

		[DisplayName("BUILDING AGE")]
		/// <summary>Field : "BUILDING AGE" Tipo: "N" Formula: + "Year([Today]) - Year([PROPERTY->DATEOFCONSTRUCTION])"</summary>
		[ShouldSerialize("Property.ValBuildingage")]
		[NumericAttribute(0)]
		public decimal? ValBuildingage { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValBuildingage, 0)); } set { klass.ValBuildingage = Convert.ToDecimal(value); } }

		[DisplayName("DATE OF CONSTRUCTION")]
		/// <summary>Field : "DATE OF CONSTRUCTION" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Property.ValDateofconstruction")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDateofconstruction { get { return klass.ValDateofconstruction; } set { klass.ValDateofconstruction = value ?? DateTime.MinValue; } }

		[DisplayName("GROUND SIZE")]
		/// <summary>Field : "GROUND SIZE" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValGroundsize")]
		[NumericAttribute(0)]
		public decimal? ValGroundsize { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValGroundsize, 0)); } set { klass.ValGroundsize = Convert.ToDecimal(value); } }

		[DisplayName("FLOOR NUMBER")]
		/// <summary>Field : "FLOOR NUMBER" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValFloornumber")]
		[NumericAttribute(0)]
		public decimal? ValFloornumber { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValFloornumber, 0)); } set { klass.ValFloornumber = Convert.ToDecimal(value); } }

		[DisplayName("FEILDDESCRIPTION")]
		/// <summary>Field : "FEILDDESCRIPTION" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Property.ValFeilddescription")]
		public string ValFeilddescription { get { return klass.ValFeilddescription; } set { klass.ValFeilddescription = value; } }

		[DisplayName("sold")]
		/// <summary>Field : "sold" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Property.ValSold")]
		[NumericAttribute(0)]
		public decimal? ValSold { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSold, 0)); } set { klass.ValSold = Convert.ToDecimal(value); } }

		[DisplayName("sold date")]
		/// <summary>Field : "sold date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Property.ValSolddate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValSolddate { get { return klass.ValSolddate; } set { klass.ValSolddate = value ?? DateTime.MinValue; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Property.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Property(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAproperty(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Property(UserContext userContext, CSGenioAproperty val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAproperty csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "broker":
						_broker ??= new Broker(m_userContext, true, _fieldsToSerialize);
						_broker.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "city":
						_city ??= new City(m_userContext, true, _fieldsToSerialize);
						_city.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Property Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAproperty>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Property(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Property> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAproperty>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Property>((r) => new Property(userCtx, r));
		}

// USE /[MANUAL TRA MODEL PROPERTY]/
	}
}
