import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
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
	]
}
