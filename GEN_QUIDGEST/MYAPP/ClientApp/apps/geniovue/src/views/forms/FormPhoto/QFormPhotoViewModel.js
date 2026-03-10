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
			name: 'PHOTO',
			area: 'PHOTO_ALBUM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Photo',
				updateFilesTickets: 'UpdateFilesTicketsPhoto',
				setFile: 'SetFilePhoto'
			}
		})

		/** The primary key. */
		this.ValCodphoto_album = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodphoto_album',
			originId: 'ValCodphoto_album',
			area: 'PHOTO_ALBUM',
			field: 'CODPHOTO_ALBUM',
			description: '',
		}).cloneFrom(values?.ValCodphoto_album))
		this.stopWatchers.push(watch(() => this.ValCodphoto_album.value, (newValue, oldValue) => this.onUpdate('photo_album.codphoto_album', this.ValCodphoto_album, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpropetry = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpropetry',
			originId: 'ValCodpropetry',
			area: 'PHOTO_ALBUM',
			field: 'CODPROPETRY',
			relatedArea: 'PROPERTY',
			description: computed(() => this.Resources.CODPROPETRY08877),
		}).cloneFrom(values?.ValCodpropetry))
		this.stopWatchers.push(watch(() => this.ValCodpropetry.value, (newValue, oldValue) => this.onUpdate('photo_album.codpropetry', this.ValCodpropetry, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValPhoto = reactive(new modelFieldType.Image({
			id: 'ValPhoto',
			originId: 'ValPhoto',
			area: 'PHOTO_ALBUM',
			field: 'PHOTO',
			description: computed(() => this.Resources.PHOTO32097),
		}).cloneFrom(values?.ValPhoto))
		this.stopWatchers.push(watch(() => this.ValPhoto.value, (newValue, oldValue) => this.onUpdate('photo_album.photo', this.ValPhoto, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'PHOTO_ALBUM',
			field: 'TITLE',
			maxLength: 50,
			description: computed(() => this.Resources.TITLE11628),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('photo_album.title', this.ValTitle, newValue, oldValue)))

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
	}

	/**
	 * Creates a clone of the current QFormPhotoViewModel instance.
	 * @returns {QFormPhotoViewModel} A new instance of QFormPhotoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodphoto_album'

	get QPrimaryKey() { return this.ValCodphoto_album.value }
	set QPrimaryKey(value) { this.ValCodphoto_album.updateValue(value) }
}
