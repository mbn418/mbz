// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
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
			path: '/:culture/:system/TRA/menu/TRA_411',
			name: 'menu-TRA_411',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_411/QMenuTra411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '411',
				baseArea: 'PROPERTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				limitations: ['broker' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/TRA/menu/TRA_511',
			name: 'menu-TRA_511',
			component: () => import('@/views/menus/ModuleTRA/MenuTRA_511/QMenuTra511.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRA',
				order: '511',
				baseArea: 'PROPERTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle', 'ValPrice'],
				isPopup: false
			}
		},
	]
}
