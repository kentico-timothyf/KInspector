import Vue from 'vue'
import Vuex from 'vuex'
import instances from './modules/instances'
import reports from './modules/reports'
import api from '../api'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  state: {
    appVersion: ""
  },
  actions: {
    async getAppVersion ({ commit }) {
      commit('setAppVersion', await api.getAppVersion())
    },
  },
  mutations: {
    setAppVersion (state, appVersion) {
      state.appVersion = appVersion
    }
  },
  modules: {
    instances,
    reports
  },
  strict: debug
})