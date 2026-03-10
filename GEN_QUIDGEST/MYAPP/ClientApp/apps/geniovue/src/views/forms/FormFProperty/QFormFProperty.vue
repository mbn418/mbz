<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="F_PROPERTY"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible">
						<q-group-box-container
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP02"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP02"
							:is-visible="controls.F_PROPERTY__PSEUD__NEWGRP02.isVisible">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP02 -->
							<q-row v-if="controls.F_PROPERTY__PROPERTY__PHOTO.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__PHOTO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__PHOTO.isVisible"
										class="q-image"
										v-bind="controls.F_PROPERTY__PROPERTY__PHOTO"
										v-on="controls.F_PROPERTY__PROPERTY__PHOTO.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__PHOTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-image
											v-if="controls.F_PROPERTY__PROPERTY__PHOTO.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTY__PHOTO.props"
											v-on="controls.F_PROPERTY__PROPERTY__PHOTO.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTY__TITLE.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__TITLE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__TITLE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTY__TITLE"
										v-on="controls.F_PROPERTY__PROPERTY__TITLE.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__TITLE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.F_PROPERTY__PROPERTY__TITLE.props"
											@blur="onBlur(controls.F_PROPERTY__PROPERTY__TITLE, model.ValTitle.value)"
											@change="model.ValTitle.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.F_PROPERTY__PROPERTY__PRICE.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__PRICE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__PRICE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTY__PRICE"
										v-on="controls.F_PROPERTY__PROPERTY__PRICE.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__PRICE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTY__PRICE.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTY__PRICE.props"
											@update:model-value="model.ValPrice.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__BROKER__NAME.isVisible">
					<q-col
						v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
							class="i-text"
							v-bind="controls.F_PROPERTY__BROKER__NAME"
							v-on="controls.F_PROPERTY__BROKER__NAME.handlers"
							:loading="controls.F_PROPERTY__BROKER__NAME.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.F_PROPERTY__BROKER__NAME.isVisible"
								v-bind="controls.F_PROPERTY__BROKER__NAME.props"
								v-on="controls.F_PROPERTY__BROKER__NAME.handlers" />
							<q-see-more-f-property-broker-name
								v-if="controls.F_PROPERTY__BROKER__NAME.seeMoreIsVisible"
								v-bind="controls.F_PROPERTY__BROKER__NAME.seeMoreParams"
								v-on="controls.F_PROPERTY__BROKER__NAME.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible"
							id="F_PROPERTY__PSEUD__NEWGRP01"
							v-bind="controls.F_PROPERTY__PSEUD__NEWGRP01"
							:is-visible="controls.F_PROPERTY__PSEUD__NEWGRP01.isVisible">
							<!-- Start F_PROPERTY__PSEUD__NEWGRP01 -->
							<q-row v-if="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.isVisible || controls.F_PROPERTY__PROPERTY__DATE.isVisible || controls.F_PROPERTY__PROPERTY__SIZE.isVisible">
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER"
										v-on="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTY__BATHROOM_NUMBER.props"
											@update:model-value="model.ValBathroom_number.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__DATE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__DATE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTY__DATE"
										v-on="controls.F_PROPERTY__PROPERTY__DATE.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__DATE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.F_PROPERTY__PROPERTY__DATE.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTY__DATE.props"
											:model-value="model.ValDate.value"
											@reset-icon-click="model.ValDate.fnUpdateValue(model.ValDate.originalValue ?? new Date())"
											@update:model-value="model.ValDate.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.F_PROPERTY__PROPERTY__SIZE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.F_PROPERTY__PROPERTY__SIZE.isVisible"
										class="i-text"
										v-bind="controls.F_PROPERTY__PROPERTY__SIZE"
										v-on="controls.F_PROPERTY__PROPERTY__SIZE.handlers"
										:loading="controls.F_PROPERTY__PROPERTY__SIZE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.F_PROPERTY__PROPERTY__SIZE.isVisible"
											v-bind="controls.F_PROPERTY__PROPERTY__SIZE.props"
											@update:model-value="model.ValSize.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End F_PROPERTY__PSEUD__NEWGRP01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__CITY__CITY.isVisible || controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.isVisible || controls.F_PROPERTY__PROPERTY__TOPOOGY.isVisible">
					<q-col
						v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
							class="i-text"
							v-bind="controls.F_PROPERTY__CITY__CITY"
							v-on="controls.F_PROPERTY__CITY__CITY.handlers"
							:loading="controls.F_PROPERTY__CITY__CITY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-lookup
								v-if="controls.F_PROPERTY__CITY__CITY.isVisible"
								v-bind="controls.F_PROPERTY__CITY__CITY.props"
								v-on="controls.F_PROPERTY__CITY__CITY.handlers" />
							<q-see-more-f-property-city-city
								v-if="controls.F_PROPERTY__CITY__CITY.seeMoreIsVisible"
								v-bind="controls.F_PROPERTY__CITY__CITY.seeMoreParams"
								v-on="controls.F_PROPERTY__CITY__CITY.handlers" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.isVisible"
							class="i-text"
							v-bind="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE"
							v-on="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.handlers"
							:loading="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-select
								v-if="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.isVisible"
								v-bind="controls.F_PROPERTY__PROPERTY__BUILDINGTYPE.props"
								@update:model-value="model.ValBuildingtype.fnUpdateValue" />
						</base-input-structure>
					</q-col>
					<q-col
						v-if="controls.F_PROPERTY__PROPERTY__TOPOOGY.isVisible"
						cols="auto">
						<base-input-structure
							v-if="controls.F_PROPERTY__PROPERTY__TOPOOGY.isVisible"
							class="i-radio-container"
							v-bind="controls.F_PROPERTY__PROPERTY__TOPOOGY"
							v-on="controls.F_PROPERTY__PROPERTY__TOPOOGY.handlers"
							:label-position="labelAlignment.topleft"
							:loading="controls.F_PROPERTY__PROPERTY__TOPOOGY.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-radio-group
								v-if="controls.F_PROPERTY__PROPERTY__TOPOOGY.isVisible"
								v-bind="controls.F_PROPERTY__PROPERTY__TOPOOGY.props"
								v-on="controls.F_PROPERTY__PROPERTY__TOPOOGY.handlers">
								<q-radio-button
									v-for="radio in controls.F_PROPERTY__PROPERTY__TOPOOGY.items"
									:key="radio.key"
									:label="radio.value"
									:value="radio.key" />
							</q-radio-group>
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible">
						<q-table
							v-if="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.isVisible"
							v-bind="controls.F_PROPERTY__PSEUD__PROPERTY_GRID"
							v-on="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.F_PROPERTY__PSEUD__PROPERTY_GRID"
									v-on="controls.F_PROPERTY__PSEUD__PROPERTY_GRID.handlers" />
							</template>
							<!-- USE /[MANUAL TRA CUSTOM_TABLE F_PROPERTY__PSEUD__PROPERTY_GRID]/ -->
						</q-table>
					</q-col>
				</q-row>
				<q-row v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible">
					<q-col v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible">
						<q-table
							v-if="controls.F_PROPERTY__PSEUD__CONTACT_GRID.isVisible"
							v-bind="controls.F_PROPERTY__PSEUD__CONTACT_GRID"
							v-on="controls.F_PROPERTY__PSEUD__CONTACT_GRID.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.F_PROPERTY__PSEUD__CONTACT_GRID"
									v-on="controls.F_PROPERTY__PSEUD__CONTACT_GRID.handlers" />
							</template>
							<!-- USE /[MANUAL TRA CUSTOM_TABLE F_PROPERTY__PSEUD__CONTACT_GRID]/ -->
						</q-table>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormFPropertyViewModel.js'

	const requiredTextResources = ['QFormFProperty', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_INCLUDEJS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormFProperty',

		components: {
			QSeeMoreFPropertyBrokerName: defineAsyncComponent(() => import('@/views/forms/FormFProperty/dbedits/FPropertyBrokerNameSeeMore.vue')),
			QSeeMoreFPropertyCityCity: defineAsyncComponent(() => import('@/views/forms/FormFProperty/dbedits/FPropertyCityCitySeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'F_PROPERTY',
					location: 'form-F_PROPERTY',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormFProperty', false),

				interfaceMetadata: {
					id: 'QFormFProperty', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'F_PROPERTY',
					route: 'form-F_PROPERTY',
					area: 'PROPERTY',
					primaryKey: 'ValCodproperty',
					designation: computed(() => this.Resources.PROPERTY43977),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					F_PROPERTY__PSEUD__NEWGRP02: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.MAIN_INFO53406),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_PROPERTY__PROPERTY__PHOTO', 'F_PROPERTY__PROPERTY__TITLE', 'F_PROPERTY__PROPERTY__PRICE'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__PHOTO: new fieldControlClass.ImageControl({
						modelField: 'ValPhoto',
						valueChangeEvent: 'fieldChange:property.photo',
						id: 'F_PROPERTY__PROPERTY__PHOTO',
						name: 'PHOTO',
						size: 'mini',
						label: computed(() => this.Resources.PHOTO38852),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP02',
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.PHOTO38852)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__TITLE: new fieldControlClass.StringControl({
						modelField: 'ValTitle',
						valueChangeEvent: 'fieldChange:property.title',
						id: 'F_PROPERTY__PROPERTY__TITLE',
						name: 'TITLE',
						size: 'xxlarge',
						label: computed(() => this.Resources.TITLE11628),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP02',
						maxLength: 80,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__PRICE: new fieldControlClass.CurrencyControl({
						modelField: 'ValPrice',
						valueChangeEvent: 'fieldChange:property.price',
						id: 'F_PROPERTY__PROPERTY__PRICE',
						name: 'PRICE',
						size: 'medium',
						label: computed(() => this.Resources.PRICE06900),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP02',
						maxIntegers: 12,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__BROKER__NAME: new fieldControlClass.LookupControl({
						modelField: 'TableBrokerName',
						valueChangeEvent: 'fieldChange:broker.name',
						id: 'F_PROPERTY__BROKER__NAME',
						name: 'NAME',
						size: 'xxlarge',
						label: computed(() => this.Resources.BROKERS_NAME02545),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValBrokers_fk',
							dependencyEvent: 'fieldChange:property.brokers_fk'
						},
						dependentFields: () => ({
							set 'broker.codbroker'(value) { vm.model.ValBrokers_fk.updateValue(value) },
							set 'broker.name'(value) { vm.model.TableBrokerName.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__NEWGRP01: new fieldControlClass.GroupControl({
						id: 'F_PROPERTY__PSEUD__NEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.DETAILS46953),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['F_PROPERTY__PROPERTY__BATHROOM_NUMBER', 'F_PROPERTY__PROPERTY__DATE', 'F_PROPERTY__PROPERTY__SIZE'],
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__BATHROOM_NUMBER: new fieldControlClass.NumberControl({
						modelField: 'ValBathroom_number',
						valueChangeEvent: 'fieldChange:property.bathroom_number',
						id: 'F_PROPERTY__PROPERTY__BATHROOM_NUMBER',
						name: 'BATHROOM_NUMBER',
						size: 'medium',
						label: computed(() => this.Resources.BATHROOM_NUMBER01832),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						maxIntegers: 2,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__DATE: new fieldControlClass.DateControl({
						modelField: 'ValDate',
						valueChangeEvent: 'fieldChange:property.date',
						id: 'F_PROPERTY__PROPERTY__DATE',
						name: 'DATE',
						size: 'small',
						label: computed(() => this.Resources.DAT56009),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						dateTimeType: 'date',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__SIZE: new fieldControlClass.NumberControl({
						modelField: 'ValSize',
						valueChangeEvent: 'fieldChange:property.size',
						id: 'F_PROPERTY__PROPERTY__SIZE',
						name: 'SIZE',
						size: 'mini',
						label: '',
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'F_PROPERTY__PSEUD__NEWGRP01',
						maxIntegers: 5,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__CITY__CITY: new fieldControlClass.LookupControl({
						modelField: 'TableCityCity',
						valueChangeEvent: 'fieldChange:city.city',
						id: 'F_PROPERTY__CITY__CITY',
						name: 'CITY',
						size: 'xxlarge',
						label: computed(() => this.Resources.CITY35974),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCity_fk',
							dependencyEvent: 'fieldChange:property.city_fk'
						},
						dependentFields: () => ({
							set 'city.codcity'(value) { vm.model.ValCity_fk.updateValue(value) },
							set 'city.city'(value) { vm.model.TableCityCity.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__BUILDINGTYPE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValBuildingtype',
						valueChangeEvent: 'fieldChange:property.buildingtype',
						id: 'F_PROPERTY__PROPERTY__BUILDINGTYPE',
						name: 'BUILDINGTYPE',
						size: 'mini',
						label: computed(() => this.Resources.BUILDINGTYPE40152),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxLength: 1,
						arrayName: 'building_type',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PROPERTY__TOPOOGY: new fieldControlClass.RadioGroupControl({
						modelField: 'ValTopoogy',
						valueChangeEvent: 'fieldChange:property.topoogy',
						id: 'F_PROPERTY__PROPERTY__TOPOOGY',
						name: 'TOPOOGY',
						label: computed(() => this.Resources.TOPOLOGY47951),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						maxIntegers: 1,
						maxDecimals: 0,
						arrayName: 'Typology',
						columns: 1,
						controlLimits: [
						],
					}, this),
					F_PROPERTY__PSEUD__PROPERTY_GRID: new fieldControlClass.TableListControl({
						id: 'F_PROPERTY__PSEUD__PROPERTY_GRID',
						name: 'PROPERTY_GRID',
						size: 'block',
						label: computed(() => this.Resources.PROPERTIES34868),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPERTY',
						action: 'F_property_ValProperty_grid',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTitle',
								area: 'PROPERTY',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE11628),
								dataLength: 80,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 2,
								name: 'ValPhoto',
								area: 'PROPERTY',
								field: 'PHOTO',
								label: computed(() => this.Resources.PHOTO38852),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.PHOTO38852)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValProperty_grid',
							serverMode: true,
							pkColumn: 'ValCodproperty',
							tableAlias: 'PROPERTY',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTIES34868),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CITY', 'changed-BROKER', 'changed-PROPERTY'],
						uuid: 'F_property_ValProperty_grid',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'property'],
								dependencyEvents: ['fieldChange:property.codproperty'],
								dependencyField: 'PROPERTY.CODPROPERTY',
								fnValueSelector: (model) => model.ValCodproperty.value
							},
						],
					}, this),
					F_PROPERTY__PSEUD__CONTACT_GRID: new fieldControlClass.TableListControl({
						id: 'F_PROPERTY__PSEUD__CONTACT_GRID',
						name: 'CONTACT_GRID',
						size: 'block',
						label: computed(() => this.Resources.CONTACT05134),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'PROPERTY',
						action: 'F_property_ValContact_grid',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'ValDate',
								area: 'CONTACT',
								field: 'DATE',
								label: computed(() => this.Resources.DATE13470),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValClient_name',
								area: 'CONTACT',
								field: 'CLIENT_NAME',
								label: computed(() => this.Resources.CLIENT_NAME18061),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDescription',
								area: 'CONTACT',
								field: 'DESCRIPTION',
								label: computed(() => this.Resources.DESCRIPTION07438),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValContact_grid',
							serverMode: true,
							pkColumn: 'ValCodcontact',
							tableAlias: 'CONTACT',
							tableNamePlural: computed(() => this.Resources.CONTACT05134),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CONTACT05134),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTACT',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTACT',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTACT',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTACT',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'CONTACT',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA__CONTACT',
								name: '_CONTACT',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'CONTACT',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'CONTACT': {
									fnKeySelector: (row) => row.Fields.ValCodcontact,
									isPopup: true
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CONTACT', 'changed-PROPERTY'],
						uuid: 'F_property_ValContact_grid',
						allSelectedRows: 'false',
						controlLimits: [
							{
								identifier: ['id', 'property'],
								dependencyEvents: ['fieldChange:property.codproperty'],
								dependencyField: 'PROPERTY.CODPROPERTY',
								fnValueSelector: (model) => model.ValCodproperty.value
							},
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'F_PROPERTY__PSEUD__NEWGRP02',
					'F_PROPERTY__PSEUD__NEWGRP01',
				]),

				tableFields: readonly([
					'F_PROPERTY__PSEUD__PROPERTY_GRID',
					'F_PROPERTY__PSEUD__CONTACT_GRID',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Broker: {
						get ValName() { return vm.model.TableBrokerName.value },
						set ValName(value) { vm.model.TableBrokerName.updateValue(value) },
					},
					City: {
						get ValCity() { return vm.model.TableCityCity.value },
						set ValCity(value) { vm.model.TableCityCity.updateValue(value) },
					},
					Property: {
						get ValBathroom_number() { return vm.model.ValBathroom_number.value },
						set ValBathroom_number(value) { vm.model.ValBathroom_number.updateValue(value) },
						get ValBrokers_fk() { return vm.model.ValBrokers_fk.value },
						set ValBrokers_fk(value) { vm.model.ValBrokers_fk.updateValue(value) },
						get ValBuildingtype() { return vm.model.ValBuildingtype.value },
						set ValBuildingtype(value) { vm.model.ValBuildingtype.updateValue(value) },
						get ValCity_fk() { return vm.model.ValCity_fk.value },
						set ValCity_fk(value) { vm.model.ValCity_fk.updateValue(value) },
						get ValDate() { return vm.model.ValDate.value },
						set ValDate(value) { vm.model.ValDate.updateValue(value) },
						get ValPhoto() { return vm.model.ValPhoto.value },
						set ValPhoto(value) { vm.model.ValPhoto.updateValue(value) },
						get ValPrice() { return vm.model.ValPrice.value },
						set ValPrice(value) { vm.model.ValPrice.updateValue(value) },
						get ValSize() { return vm.model.ValSize.value },
						set ValSize(value) { vm.model.ValSize.updateValue(value) },
						get ValTitle() { return vm.model.ValTitle.value },
						set ValTitle(value) { vm.model.ValTitle.updateValue(value) },
						get ValTopoogy() { return vm.model.ValTopoogy.value },
						set ValTopoogy(value) { vm.model.ValTopoogy.updateValue(value) },
					},
					keys: {
						/** The primary key of the PROPERTY table */
						get property() { return vm.model.ValCodproperty },
						/** The foreign key to the BROKER table */
						get broker() { return vm.model.ValBrokers_fk },
						/** The foreign key to the CITY table */
						get city() { return vm.model.ValCity_fk },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_CODEJS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA COMPONENT_BEFORE_UNMOUNT F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_LOAD_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_LOADED_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_APPLY_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_APPLY_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_SAVE_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_SAVE_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_DEL_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_DEL_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA BEFORE_EXIT_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA AFTER_EXIT_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA DLGUPDT F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA CTRLBLR F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA CTRLUPD F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FUNCTIONS_JS F_PROPERTY]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
