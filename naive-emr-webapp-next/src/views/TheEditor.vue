<template>
  <div class="container">
    <div class="header">头部内容</div>
    <div class="content">
      <div class="emr-editor"></div>
    </div>
    <div class="footer">底部内容</div>
  </div>
</template>

<script lang="ts" setup>
import { onMounted } from 'vue'
import {
  Editor,
  RowFlex,
  ElementType,
  type IEditorData,
  type IElement,
  type IEditorOption,
} from '@zhao-internal/emr-editor'
import { header, main, main2, footer } from '@/mock'

const option: IEditorOption = {
  watermark: {
    data: 'Naive Emr',
    size: 120,
  },
  pageNumber: {
    format: '第{pageNo}页/共{pageCount}页',
  },
}
const config: IEditorData | IElement[] = {
  header: header as IElement[] | undefined,
  main: main as IElement[],
  footer: footer as IElement[],
}

let editor: Editor
let editorContainer: HTMLDivElement
onMounted(() => {
  const container = document.querySelector<HTMLDivElement>('.emr-editor')
  if (container) {
    editorContainer = container
    editor = new Editor(editorContainer, config, option)
    editor.listener.contentChange = () => {
      const docValue = editor.command.getValue()
      console.log('@change', docValue.data.main, main)
    }
  }
})
</script>

<style lang="less" scoped>
.container {
  margin: 0;
  padding: 0;
  height: 100vh;
  display: flex;
  flex-direction: column;
}

.header {
  //   position: fixed;
  //   top: 0;
  //   width: 100%;
  //   background-color: #f3f3f3;
  //   height: 80px;
  //   z-index: 9;
  background-color: #f5f5f5;
  height: 60px;
  width: 100%;
  align-self: flex-start;
}

.content {
  background-color: #e6e6e6;
  flex: 1;
  overflow-y: auto;
  .emr-editor {
    // height: 500px;

    // :deep(div:first-of-type) {
    //   margin: 80px auto;
    // }

    :deep(.ce-page-container canvas:last-of-type) {
      margin-bottom: 0;
    }
  }
  .emr-editor > :deep(div) {
    margin: 10px auto;
  }
}

.footer {
  height: 30px;
  width: 100%;
  background-color: #f3f3f3;
  align-self: flex-end;
}
</style>
