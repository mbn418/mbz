import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/CONTACT/:mode/:id?',
			name: 'form-CONTACT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormContact/QFormContact.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONTACT',
				humanKeyFields: [],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/COUNTRY/:mode/:id?',
			name: 'form-COUNTRY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCountry/QFormCountry.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'COUNTRY',
				humanKeyFields: ['ValCountry'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_BROKER/:mode/:id?',
			name: 'form-F_BROKER',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFBroker/QFormFBroker.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'BROKER',
				humanKeyFields: ['ValName', 'ValEmail'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/F_PROPERTY/:mode/:id?',
			name: 'form-F_PROPERTY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFProperty/QFormFProperty.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPERTY',
				humanKeyFields: ['ValTitle', 'ValPrice'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/PHOTO/:mode/:id?',
			name: 'form-PHOTO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPhoto/QFormPhoto.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PHOTO_ALBUM',
				humanKeyFields: [],
				isPopup: false
			}
		},
	]
}
