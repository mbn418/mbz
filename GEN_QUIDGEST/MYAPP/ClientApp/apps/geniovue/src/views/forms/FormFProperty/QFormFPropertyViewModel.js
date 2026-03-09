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
