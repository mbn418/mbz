<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers" />
					</template>
					<!-- USE /[MANUAL TRA CUSTOM_TABLE TRA_Menu_411]/ -->
				</q-table>
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuTRA_411ViewModel.js'

	const requiredTextResources = ['QMenuTRA_411', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_INCLUDEJS TRA_MENU_411]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuTra411',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuTRA_411', false),

				interfaceMetadata: {
					id: 'QMenuTRA_411', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '411',
					isMenuList: true,
					designation: computed(() => this.Resources.PROPERTIES34868),
					acronym: 'TRA_411',
					name: 'PROPERTY',
					route: 'menu-TRA_411',
					order: '411',
					controller: 'PROPERTY',
					action: 'TRA_Menu_411',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'TRA_Menu_411',
						controller: 'PROPERTY',
						action: 'TRA_Menu_411',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.ArrayColumn({
								order: 1,
								name: 'ValTopoogy',
								area: 'PROPERTY',
								field: 'TOPOOGY',
								label: computed(() => this.Resources.TOPOOGY11786),
								scrollData: 1,
								maxDigits: 1,
								decimalPlaces: 0,
								export: 1,
								array: computed(() => new qProjArrays.QArrayTypology(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayTypology.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 2,
								name: 'ValSize',
								area: 'PROPERTY',
								field: 'SIZE',
								scrollData: 5,
								maxDigits: 5,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValTitle',
								area: 'PROPERTY',
								field: 'TITLE',
								label: computed(() => this.Resources.TITLE11628),
								dataLength: 80,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'City.ValCity',
								area: 'CITY',
								field: 'CITY',
								label: computed(() => this.Resources.CITY35974),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodcity',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'Broker.ValName',
								area: 'BROKER',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodbroker',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValBathroom_number',
								area: 'PROPERTY',
								field: 'BATHROOM_NUMBER',
								label: computed(() => this.Resources.BATHROOM_NUMBER01832),
								scrollData: 2,
								maxDigits: 2,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 7,
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
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'ValDate',
								area: 'PROPERTY',
								field: 'DATE',
								label: computed(() => this.Resources.DAT56009),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 9,
								name: 'ValBuildingtype',
								area: 'PROPERTY',
								field: 'BUILDINGTYPE',
								label: computed(() => this.Resources.BUILDINGTYPE40152),
								dataLength: 1,
								scrollData: 1,
								export: 1,
								array: computed(() => new qProjArrays.QArrayBuilding_type(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayBuilding_type.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.CurrencyColumn({
								order: 10,
								name: 'ValPrice',
								area: 'PROPERTY',
								field: 'PRICE',
								label: computed(() => this.Resources.PRICE06900),
								scrollData: 15,
								maxDigits: 12,
								decimalPlaces: 2,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'TRA_Menu_411',
							serverMode: true,
							pkColumn: 'ValCodproperty',
							tableAlias: 'PROPERTY',
							tableNamePlural: computed(() => this.Resources.PROPERTIES34868),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PROPERTIES34868),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
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
							allowFileExport: true,
							allowFileImport: true,
							defaultSearchColumnName: 'ValTitle',
							defaultSearchColumnNameOriginal: 'ValTitle',
							defaultColumnSorting: {
								columnName: 'ValTitle',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CITY', 'changed-BROKER', 'changed-PROPERTY'],
						uuid: 'c1c8fa01-8256-4245-9d7a-77197d5d7efb',
						allSelectedRows: 'false',
						headerLevel: 1,
						/** Menu limits */
						controlLimits: [
							/** DB */
							{
								identifier: 'broker',
								dependencyEvents: [],
								dependencyField: '',
								fnValueSelector: () => vm.$route.params['broker'],
							},
						],
						isActiveControl: computed(() => this.isActiveMenu)
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FORM_CODEJS TRA_MENU_411]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA COMPONENT_BEFORE_UNMOUNT TRA_MENU_411]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA FUNCTIONS_JS TRA_411]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL TRA LISTING_CODEJS TRA_MENU_411]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
