/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'CONTACT',
			area: 'CONTACT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Contact',
				updateFilesTickets: 'UpdateFilesTicketsContact',
				setFile: 'SetFileContact'
			}
		})

		/** The primary key. */
		this.ValCodcontact = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodcontact',
			originId: 'ValCodcontact',
			area: 'CONTACT',
			field: 'CODCONTACT',
			description: '',
		}).cloneFrom(values?.ValCodcontact))
		this.stopWatchers.push(watch(() => this.ValCodcontact.value, (newValue, oldValue) => this.onUpdate('contact.codcontact', this.ValCodcontact, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodproperty = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodproperty',
			originId: 'ValCodproperty',
			area: 'CONTACT',
			field: 'CODPROPERTY',
			relatedArea: 'PROPERTY',
			description: computed(() => this.Resources.CODPROPERTY44451),
		}).cloneFrom(values?.ValCodproperty))
		this.stopWatchers.push(watch(() => this.ValCodproperty.value, (newValue, oldValue) => this.onUpdate('contact.codproperty', this.ValCodproperty, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'CONTACT',
			field: 'DATE',
			description: computed(() => this.Resources.DATE13470),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('contact.date', this.ValDate, newValue, oldValue)))

		this.TablePropertyTitle = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePropertyTitle',
			originId: 'ValTitle',
			area: 'PROPERTY',
			field: 'TITLE',
			maxLength: 80,
			description: computed(() => this.Resources.TITLE11628),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePropertyTitle))
		this.stopWatchers.push(watch(() => this.TablePropertyTitle.value, (newValue, oldValue) => this.onUpdate('property.title', this.TablePropertyTitle, newValue, oldValue)))

		this.ValClient_name = reactive(new modelFieldType.String({
			id: 'ValClient_name',
			originId: 'ValClient_name',
			area: 'CONTACT',
			field: 'CLIENT_NAME',
			maxLength: 50,
			description: computed(() => this.Resources.CLIENT_NAME18061),
		}).cloneFrom(values?.ValClient_name))
		this.stopWatchers.push(watch(() => this.ValClient_name.value, (newValue, oldValue) => this.onUpdate('contact.client_name', this.ValClient_name, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'CONTACT',
			field: 'EMAIL',
			maxLength: 50,
			description: computed(() => this.Resources.EMAIL45345),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('contact.email', this.ValEmail, newValue, oldValue)))

		this.ValPhone_number = reactive(new modelFieldType.Number({
			id: 'ValPhone_number',
			originId: 'ValPhone_number',
			area: 'CONTACT',
			field: 'PHONE_NUMBER',
			maxDigits: 15,
			decimalDigits: 0,
			description: computed(() => this.Resources.PHONE_NUMBER54560),
		}).cloneFrom(values?.ValPhone_number))
		this.stopWatchers.push(watch(() => this.ValPhone_number.value, (newValue, oldValue) => this.onUpdate('contact.phone_number', this.ValPhone_number, newValue, oldValue)))

		this.ValDescription = reactive(new modelFieldType.String({
			id: 'ValDescription',
			originId: 'ValDescription',
			area: 'CONTACT',
			field: 'DESCRIPTION',
			maxLength: 50,
			description: computed(() => this.Resources.DESCRIPTION07438),
		}).cloneFrom(values?.ValDescription))
		this.stopWatchers.push(watch(() => this.ValDescription.value, (newValue, oldValue) => this.onUpdate('contact.description', this.ValDescription, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormContactViewModel instance.
	 * @returns {QFormContactViewModel} A new instance of QFormContactViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodcontact'

	get QPrimaryKey() { return this.ValCodcontact.value }
	set QPrimaryKey(value) { this.ValCodcontact.updateValue(value) }
}
