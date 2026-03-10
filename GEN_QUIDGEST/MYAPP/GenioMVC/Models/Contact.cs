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
	public class Contact : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcontact klass { get { return baseklass as CSGenioAcontact; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValCodcontact")]
		public string ValCodcontact { get { return klass.ValCodcontact; } set { klass.ValCodcontact = value; } }

		[DisplayName("DATE")]
		/// <summary>Field : "DATE" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValDate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDate { get { return klass.ValDate; } set { klass.ValDate = value ?? DateTime.MinValue; } }

		[DisplayName("CODPROPERTY")]
		/// <summary>Field : "CODPROPERTY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValCodproperty")]
		public string ValCodproperty { get { return klass.ValCodproperty; } set { klass.ValCodproperty = value; } }

		private Property _property;
		[DisplayName("Property")]
		[ShouldSerialize("Property")]
		public virtual Property Property
		{
			get
			{
				if (!isEmptyModel && (_property == null || (!string.IsNullOrEmpty(ValCodproperty) && (_property.isEmptyModel || _property.klass.QPrimaryKey != ValCodproperty))))
					_property = Models.Property.Find(ValCodproperty, m_userContext, Identifier, _fieldsToSerialize);
				_property ??= new Models.Property(m_userContext, true, _fieldsToSerialize);
				return _property;
			}
			set { _property = value; }
		}

		[DisplayName("CLIENT_NAME")]
		/// <summary>Field : "CLIENT_NAME" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValClient_name")]
		public string ValClient_name { get { return klass.ValClient_name; } set { klass.ValClient_name = value; } }

		[DisplayName("EMAIL")]
		/// <summary>Field : "EMAIL" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("PHONE_NUMBER")]
		/// <summary>Field : "PHONE_NUMBER" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValPhone_number")]
		[NumericAttribute(0)]
		public decimal? ValPhone_number { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPhone_number, 0)); } set { klass.ValPhone_number = Convert.ToDecimal(value); } }

		[DisplayName("DESCRIPTION")]
		/// <summary>Field : "DESCRIPTION" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Contact.ValDescription")]
		public string ValDescription { get { return klass.ValDescription; } set { klass.ValDescription = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Contact.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Contact(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcontact(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Contact(UserContext userContext, CSGenioAcontact val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcontact csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "property":
						_property ??= new Property(m_userContext, true, _fieldsToSerialize);
						_property.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Contact Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcontact>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Contact(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Contact> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcontact>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Contact>((r) => new Contact(userCtx, r));
		}

// USE /[MANUAL TRA MODEL CONTACT]/
	}
}
