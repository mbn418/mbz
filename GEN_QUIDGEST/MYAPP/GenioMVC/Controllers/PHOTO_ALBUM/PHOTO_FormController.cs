using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Photo_album;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL TRA INCLUDE_CONTROLLER PHOTO_ALBUM]/

namespace GenioMVC.Controllers
{
	public partial class Photo_albumController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PHOTO_CANCEL = new("PHOTO_ALBUM49258", "Photo_Cancel", "Photo_album") { vueRouteName = "form-PHOTO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PHOTO_SHOW = new("PHOTO_ALBUM49258", "Photo_Show", "Photo_album") { vueRouteName = "form-PHOTO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PHOTO_NEW = new("PHOTO_ALBUM49258", "Photo_New", "Photo_album") { vueRouteName = "form-PHOTO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PHOTO_EDIT = new("PHOTO_ALBUM49258", "Photo_Edit", "Photo_album") { vueRouteName = "form-PHOTO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PHOTO_DUPLICATE = new("PHOTO_ALBUM49258", "Photo_Duplicate", "Photo_album") { vueRouteName = "form-PHOTO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PHOTO_DELETE = new("PHOTO_ALBUM49258", "Photo_Delete", "Photo_album") { vueRouteName = "form-PHOTO", mode = "DELETE" };

		#endregion

		#region Photo private

		private void FormHistoryLimits_Photo()
		{

		}

		#endregion

		#region Photo_Show

// USE /[MANUAL TRA CONTROLLER_SHOW PHOTO]/

		[HttpPost]
		public ActionResult Photo_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Photo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Photo_Show_GET",
				AreaName = "photo_album",
				Location = ACTION_PHOTO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo();
// USE /[MANUAL TRA BEFORE_LOAD_SHOW PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_SHOW PHOTO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Photo_New

// USE /[MANUAL TRA CONTROLLER_NEW_GET PHOTO]/
		[HttpPost]
		public ActionResult Photo_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Photo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Photo_New_GET",
				AreaName = "photo_album",
				FormName = "PHOTO",
				Location = ACTION_PHOTO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Photo();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW PHOTO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Photo_album/Photo_New
// USE /[MANUAL TRA CONTROLLER_NEW_POST PHOTO]/
		[HttpPost]
		public ActionResult Photo_New([FromBody]Photo_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Photo_New",
				ViewName = "Photo",
				AreaName = "photo_album",
				Location = ACTION_PHOTO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_NEW PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_NEW PHOTO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_NEW_EX PHOTO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_NEW_EX PHOTO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Photo_Edit

// USE /[MANUAL TRA CONTROLLER_EDIT_GET PHOTO]/
		[HttpPost]
		public ActionResult Photo_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Photo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Photo_Edit_GET",
				AreaName = "photo_album",
				FormName = "PHOTO",
				Location = ACTION_PHOTO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo();
// USE /[MANUAL TRA BEFORE_LOAD_EDIT PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT PHOTO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Photo_album/Photo_Edit
// USE /[MANUAL TRA CONTROLLER_EDIT_POST PHOTO]/
		[HttpPost]
		public ActionResult Photo_Edit([FromBody]Photo_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Photo_Edit",
				ViewName = "Photo",
				AreaName = "photo_album",
				Location = ACTION_PHOTO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_EDIT PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_EDIT PHOTO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_EDIT_EX PHOTO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_EDIT_EX PHOTO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Photo_Delete

// USE /[MANUAL TRA CONTROLLER_DELETE_GET PHOTO]/
		[HttpPost]
		public ActionResult Photo_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Photo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Photo_Delete_GET",
				AreaName = "photo_album",
				FormName = "PHOTO",
				Location = ACTION_PHOTO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Photo();
// USE /[MANUAL TRA BEFORE_LOAD_DELETE PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DELETE PHOTO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Photo_album/Photo_Delete
// USE /[MANUAL TRA CONTROLLER_DELETE_POST PHOTO]/
		[HttpPost]
		public ActionResult Photo_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Photo_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Photo_Delete",
				ViewName = "Photo",
				AreaName = "photo_album",
				Location = ACTION_PHOTO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_DESTROY_DELETE PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_DESTROY_DELETE PHOTO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Photo_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PHOTO");
		}

		#endregion

		#region Photo_Duplicate

// USE /[MANUAL TRA CONTROLLER_DUPLICATE_GET PHOTO]/

		[HttpPost]
		public ActionResult Photo_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Photo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Photo_Duplicate_GET",
				AreaName = "photo_album",
				FormName = "PHOTO",
				Location = ACTION_PHOTO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE PHOTO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Photo_album/Photo_Duplicate
// USE /[MANUAL TRA CONTROLLER_DUPLICATE_POST PHOTO]/
		[HttpPost]
		public ActionResult Photo_Duplicate([FromBody]Photo_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Photo_Duplicate",
				ViewName = "Photo",
				AreaName = "photo_album",
				Location = ACTION_PHOTO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_SAVE_DUPLICATE PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_SAVE_DUPLICATE PHOTO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_LOAD_DUPLICATE_EX PHOTO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_LOAD_DUPLICATE_EX PHOTO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Photo_Cancel

		//
		// GET: /Photo_album/Photo_Cancel
// USE /[MANUAL TRA CONTROLLER_CANCEL_GET PHOTO]/
		public ActionResult Photo_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Photo_album model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("photo_album");

// USE /[MANUAL TRA BEFORE_CANCEL PHOTO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL TRA AFTER_CANCEL PHOTO]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_photo_album", "true", true);
			}

			Navigation.ClearValue("photo_album");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Photo_PropertyValTitleModel : RequestLookupModel
		{
			public Photo_ViewModel Model { get; set; }
		}

		//
		// GET: /Photo_album/Photo_PropertyValTitle
		// POST: /Photo_album/Photo_PropertyValTitle
		[ActionName("Photo_PropertyValTitle")]
		public ActionResult Photo_PropertyValTitle([FromBody] Photo_PropertyValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_property")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_property");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Photo_album parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Photo_PropertyValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Photo_album/Photo_SaveEdit
		[HttpPost]
		public ActionResult Photo_SaveEdit([FromBody] Photo_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Photo_SaveEdit",
				ViewName = "Photo",
				AreaName = "photo_album",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL TRA BEFORE_APPLY_EDIT PHOTO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL TRA AFTER_APPLY_EDIT PHOTO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PhotoDocumValidateTickets : RequestDocumValidateTickets
		{
			public Photo_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPhoto([FromBody] PhotoDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
