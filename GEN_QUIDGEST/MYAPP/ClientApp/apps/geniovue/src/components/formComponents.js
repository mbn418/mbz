import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormContact', defineAsyncComponent(() => import('@/views/forms/FormContact/QFormContact.vue')))
		app.component('QFormCountry', defineAsyncComponent(() => import('@/views/forms/FormCountry/QFormCountry.vue')))
		app.component('QFormFBroker', defineAsyncComponent(() => import('@/views/forms/FormFBroker/QFormFBroker.vue')))
		app.component('QFormFProperty', defineAsyncComponent(() => import('@/views/forms/FormFProperty/QFormFProperty.vue')))
		app.component('QFormPhoto', defineAsyncComponent(() => import('@/views/forms/FormPhoto/QFormPhoto.vue')))
	}
}
