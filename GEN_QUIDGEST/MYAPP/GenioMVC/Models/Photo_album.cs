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
	public class Photo_album : ModelBase
	{
		[JsonIgnore]
		public CSGenioAphoto_album klass { get { return baseklass as CSGenioAphoto_album; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Photo_album.ValCodphoto_album")]
		public string ValCodphoto_album { get { return klass.ValCodphoto_album; } set { klass.ValCodphoto_album = value; } }

		[DisplayName("PHOTO")]
		/// <summary>Field : "PHOTO" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Photo_album.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("title")]
		/// <summary>Field : "title" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Photo_album.ValTitle")]
		public string ValTitle { get { return klass.ValTitle; } set { klass.ValTitle = value; } }

		[DisplayName("CODPROPETRY")]
		/// <summary>Field : "CODPROPETRY" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Photo_album.ValCodpropetry")]
		public string ValCodpropetry { get { return klass.ValCodpropetry; } set { klass.ValCodpropetry = value; } }

		private Property _property;
		[DisplayName("Property")]
		[ShouldSerialize("Property")]
		public virtual Property Property
		{
			get
			{
				if (!isEmptyModel && (_property == null || (!string.IsNullOrEmpty(ValCodpropetry) && (_property.isEmptyModel || _property.klass.QPrimaryKey != ValCodpropetry))))
					_property = Models.Property.Find(ValCodpropetry, m_userContext, Identifier, _fieldsToSerialize);
				_property ??= new Models.Property(m_userContext, true, _fieldsToSerialize);
				return _property;
			}
			set { _property = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Photo_album.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Photo_album(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAphoto_album(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Photo_album(UserContext userContext, CSGenioAphoto_album val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAphoto_album csgenioa)
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
		public static Photo_album Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAphoto_album>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Photo_album(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Photo_album> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAphoto_album>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Photo_album>((r) => new Photo_album(userCtx, r));
		}

// USE /[MANUAL TRA MODEL PHOTO_ALBUM]/
	}
}
