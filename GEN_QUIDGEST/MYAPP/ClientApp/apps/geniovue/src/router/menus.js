// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_421',
			name: 'menu-TRA_421',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_421/QMenuTra421.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '421',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
				isPopup: false
			}
		},
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
			path: '/:culture/:system/TRA/menu/TRA_411',
			name: 'menu-TRA_411',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_411/QMenuTra411.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '411',
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
	]
}
