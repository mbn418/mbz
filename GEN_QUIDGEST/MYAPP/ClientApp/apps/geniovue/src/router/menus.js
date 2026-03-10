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
			path: '/:culture/:system/TRA/menu/TRA_61',
			name: 'menu-TRA_61',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_61/QMenuTra61.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '61',
				baseArea: 'BROKER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValEmail'],
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
			path: '/:culture/:system/TRA/menu/TRA_611',
			name: 'menu-TRA_611',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_611/QMenuTra611.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '611',
				baseArea: 'PROPERTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				limitations: ['broker' /* DB */],
				isPopup: false
			}
		},
	]
}
