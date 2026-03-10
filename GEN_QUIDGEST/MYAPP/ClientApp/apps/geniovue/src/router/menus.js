// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/TRA/menu/TRA_31',
			name: 'menu-TRA_31',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_31/QMenuTra31.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '31',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
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
			path: '/:culture/:system/TRA/menu/TRA_41',
			name: 'menu-TRA_41',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_41/QMenuTra41.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '41',
				baseArea: 'CONTACT',
				hasInitialPHE: false,
				humanKeyFields: [],
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
