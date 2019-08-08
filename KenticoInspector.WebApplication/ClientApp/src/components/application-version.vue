<template>
  <div>
    Version {{appVersion}}
  </div>
</template>

<script>
import { mapActions, mapState } from 'vuex'

export default {
  mounted () {
    this.getAppVersion()
  },
  computed: {
    ...mapState(['appVersion']),
  },
  methods: {
    ...mapActions(['getAppVersion']),
  }
}
</script>