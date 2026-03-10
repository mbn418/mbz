// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_32',
			name: 'menu-TRA_32',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_32/QMenuTra32.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '32',
				baseArea: 'PHOTO_ALBUM',
				hasInitialPHE: false,
				humanKeyFields: [],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_11',
			name: 'menu-TRA_11',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_11/QMenuTra11.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '11',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValEmail'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_71',
			name: 'menu-TRA_71',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_71/QMenuTra71.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '71',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValEmail'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_51',
			name: 'menu-TRA_51',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_51/QMenuTra51.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '51',
				baseArea: 'COUNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_21',
			name: 'menu-TRA_21',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_21/QMenuTra21.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '21',
				baseArea: 'PROPERTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_711',
			name: 'menu-TRA_711',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_711/QMenuTra711.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '711',
				baseArea: 'PROPERTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				limitations: ['broker' /* DB */],
				isPopup: false
			}
		},
	]
}
