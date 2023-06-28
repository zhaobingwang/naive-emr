<template>
  <div class="console">
    <h2>console</h2>
    <div class="emr-editor"></div>
  </div>
</template>

<script setup lang="ts">
import { Editor, RowFlex } from '@zhao-internal/emr-editor'
import { onMounted, reactive } from 'vue'

const config = reactive({
  header: [
    {
      value: 'naive-emr-header',
      rowFlex: RowFlex.CENTER,
    },
  ],
  main: [
    {
      value: 'xxxxxxxxxxxxxxxxx',
    },
  ],
  footer: [
    {
      value: 'naive-emr-footer',
      size: 12,
      rowFlex: RowFlex.CENTER,
    },
  ],
})
onMounted(() => {
  const container: Element | null = document.querySelector('.emr-editor')
  if (container === null) return
  new Editor(container, config, {})
})
</script>
<style lang="less" scoped>
.console {
}
</style>
