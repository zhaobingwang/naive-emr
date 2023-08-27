<template>
  <div class="console">
    <div class="menu">
      <h2>Naive EMR Console</h2>
      <t-space>
        <t-button theme="primary" @click="setDocument">写入文档内容</t-button>
        <t-button theme="primary" @click="setDocument2">写入文档内容2</t-button>
        <t-button theme="primary" @click="getDocument">获取文档内容</t-button>
      </t-space>
    </div>
    <div class="main">
      <div class="emr-editor"></div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {
  Editor,
  RowFlex,
  ElementType,
  type IEditorData,
  type IElement,
  type IEditorOption,
} from '@zhao-internal/emr-editor'
import { onMounted, reactive } from 'vue'
import { header, main, main2, footer } from '@/mock'
import { getEmrDocument, createEmrDocument } from '@/api/EmrDocument'

// const config = reactive({
//   header,
//   main: content,
//   footer,
// })
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
  main: [] as IElement[],
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

const getDocument = async () => {
  const docValue = editor.command.getValue()
  const json = JSON.stringify(docValue.data)
  console.log(json)
  const response = await getEmrDocument('')
  const responseObj = JSON.parse(response.jsonContent)
  // const response2 = await createEmrDocument(docValue.data)
  console.log('@responseObj', responseObj)

  // console.log('xx', xx)

  editor.command.executeSetValue(responseObj)
}

const setDocument = () => {
  const newConfig: Partial<IEditorData> = {
    main: main as IElement[],
  }
  editor.command.executeSetValue(newConfig)
  // editor.command.executeSetValue(payload: Partial<IEditorData>)
}

const setDocument2 = () => {
  const newConfig: Partial<IEditorData> = {
    main: main2 as IElement[],
  }
  editor.command.executeSetValue(newConfig)
}
</script>
<style lang="less" scoped>
.console {
  display: flex;
  flex-direction: column;
  height: 100vh - 4px;
  background-color: #e6e6e6;
  .menu {
    width: 100%;
    background-color: #fff;
  }
  .main {
    flex: 1;
    width: 100%;
    overflow-y: scroll;
  }
  .emr-editor {
    :deep(div:first-child) {
      margin: 30px auto;
    }
  }
}
</style>
