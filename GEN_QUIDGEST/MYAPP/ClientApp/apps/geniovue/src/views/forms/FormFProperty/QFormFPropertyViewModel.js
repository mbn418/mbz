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
			name: 'F_PROPERTY',
			area: 'PROPERTY',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_property',
				updateFilesTickets: 'UpdateFilesTicketsF_property',
				setFile: 'SetFileF_property'
			}
		})

		/** The primary key. */
		this.ValCodproperty = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodproperty',
			originId: 'ValCodproperty',
			area: 'PROPERTY',
			field: 'CODPROPERTY',
			description: '',
		}).cloneFrom(values?.ValCodproperty))
		this.stopWatchers.push(watch(() => this.ValCodproperty.value, (newValue, oldValue) => this.onUpdate('property.codproperty', this.ValCodproperty, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValBrokers_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValBrokers_fk',
			originId: 'ValBrokers_fk',
			area: 'PROPERTY',
			field: 'BROKERS_FK',
			relatedArea: 'BROKER',
			description: '',
		}).cloneFrom(values?.ValBrokers_fk))
		this.stopWatchers.push(watch(() => this.ValBrokers_fk.value, (newValue, oldValue) => this.onUpdate('property.brokers_fk', this.ValBrokers_fk, newValue, oldValue)))

		this.ValCity_fk = reactive(new modelFieldType.ForeignKey({
			id: 'ValCity_fk',
			originId: 'ValCity_fk',
			area: 'PROPERTY',
			field: 'CITY_FK',
			relatedArea: 'CITY',
			description: computed(() => this.Resources.CITY_FK13761),
		}).cloneFrom(values?.ValCity_fk))
		this.stopWatchers.push(watch(() => this.ValCity_fk.value, (newValue, oldValue) => this.onUpdate('property.city_fk', this.ValCity_fk, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PROPERTY',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO38852),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('property.photo', this.ValPhoto, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PROPERTY',
			field: 'TITLE',
			maxLength: 80,
			description: computed(() => this.Resources.TITLE11628),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('property.title', this.ValTitle, newValue, oldValue)))

		this.ValPrice = reactive(new modelFieldType.Number({
			id: 'ValPrice',
			originId: 'ValPrice',
			area: 'PROPERTY',
			field: 'PRICE',
			maxDigits: 12,
			decimalDigits: 2,
			description: computed(() => this.Resources.PRICE06900),
		}).cloneFrom(values?.ValPrice))
		this.stopWatchers.push(watch(() => this.ValPrice.value, (newValue, oldValue) => this.onUpdate('property.price', this.ValPrice, newValue, oldValue)))

		this.TableBrokerName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableBrokerName',
			originId: 'ValName',
			area: 'BROKER',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableBrokerName))
		this.stopWatchers.push(watch(() => this.TableBrokerName.value, (newValue, oldValue) => this.onUpdate('broker.name', this.TableBrokerName, newValue, oldValue)))

		this.ValBathroom_number = reactive(new modelFieldType.Number({
			id: 'ValBathroom_number',
			originId: 'ValBathroom_number',
			area: 'PROPERTY',
			field: 'BATHROOM_NUMBER',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.BATHROOM_NUMBER01832),
		}).cloneFrom(values?.ValBathroom_number))
		this.stopWatchers.push(watch(() => this.ValBathroom_number.value, (newValue, oldValue) => this.onUpdate('property.bathroom_number', this.ValBathroom_number, newValue, oldValue)))

		this.ValDate = reactive(new modelFieldType.Date({
			id: 'ValDate',
			originId: 'ValDate',
			area: 'PROPERTY',
			field: 'DATE',
			description: computed(() => this.Resources.DAT56009),
		}).cloneFrom(values?.ValDate))
		this.stopWatchers.push(watch(() => this.ValDate.value, (newValue, oldValue) => this.onUpdate('property.date', this.ValDate, newValue, oldValue)))

		this.ValSize = reactive(new modelFieldType.Number({
			id: 'ValSize',
			originId: 'ValSize',
			area: 'PROPERTY',
			field: 'SIZE',
			maxDigits: 5,
			decimalDigits: 0,
			description: '',
		}).cloneFrom(values?.ValSize))
		this.stopWatchers.push(watch(() => this.ValSize.value, (newValue, oldValue) => this.onUpdate('property.size', this.ValSize, newValue, oldValue)))

		this.TableCityCity = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCityCity',
			originId: 'ValCity',
			area: 'CITY',
			field: 'CITY',
			maxLength: 50,
			description: computed(() => this.Resources.CITY35974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCityCity))
		this.stopWatchers.push(watch(() => this.TableCityCity.value, (newValue, oldValue) => this.onUpdate('city.city', this.TableCityCity, newValue, oldValue)))

		this.ValBuildingtype = reactive(new modelFieldType.String({
			id: 'ValBuildingtype',
			originId: 'ValBuildingtype',
			area: 'PROPERTY',
			field: 'BUILDINGTYPE',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayBuilding_type(vm.$getResource).elements),
			description: computed(() => this.Resources.BUILDINGTYPE40152),
		}).cloneFrom(values?.ValBuildingtype))
		this.stopWatchers.push(watch(() => this.ValBuildingtype.value, (newValue, oldValue) => this.onUpdate('property.buildingtype', this.ValBuildingtype, newValue, oldValue)))

		this.ValTopoogy = reactive(new modelFieldType.Number({
			id: 'ValTopoogy',
			originId: 'ValTopoogy',
			area: 'PROPERTY',
			field: 'TOPOOGY',
			maxDigits: 1,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayTypology(vm.$getResource).elements),
			description: computed(() => this.Resources.TOPOOGY11786),
		}).cloneFrom(values?.ValTopoogy))
		this.stopWatchers.push(watch(() => this.ValTopoogy.value, (newValue, oldValue) => this.onUpdate('property.topoogy', this.ValTopoogy, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormFPropertyViewModel instance.
	 * @returns {QFormFPropertyViewModel} A new instance of QFormFPropertyViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodproperty'

	get QPrimaryKey() { return this.ValCodproperty.value }
	set QPrimaryKey(value) { this.ValCodproperty.updateValue(value) }
}
