<template>
  <t-layout class="editor-container">
    <t-header style="height: 85px">
      <div class="editor-header" v-if="editor">
        <!-- <t-space direction="vertical"> -->
        <t-tabs v-model="menuTabValue" theme="card">
          <t-tab-panel value="file" label="文件">
            <t-button variant="text" shape="square">
              <t-button variant="text" shape="square" @click="handleExport2Json">
                <t-tooltip content="导出到本地">
                  <Icon size="24">
                    <FileExport />
                  </Icon>
                </t-tooltip>
              </t-button>
            </t-button>

            <t-button variant="text" shape="square">
              <t-button variant="text" shape="square" @click="handleImportFromJson">
                <t-tooltip content="从本地导入">
                  <Icon size="24">
                    <FileImport />
                  </Icon>
                </t-tooltip>
              </t-button>
            </t-button>
          </t-tab-panel>
          <t-tab-panel value="edit" label="编辑">
            <t-button
              variant="text"
              shape="square"
              @click="editor.chain().focus().toggleBold().run()"
              :disabled="!editor.can().chain().focus().toggleBold().run()"
              :class="{ 'is-active': editor.isActive('bold') }"
            >
              <t-tooltip content="粗体">
                <Icon size="24">
                  <bold />
                </Icon>
              </t-tooltip>
            </t-button>
            <t-button
              variant="text"
              shape="square"
              @click="editor.chain().focus().toggleItalic().run()"
              :disabled="!editor.can().chain().focus().toggleItalic().run()"
              :class="{ 'is-active': editor.isActive('italic') }"
            >
              <t-tooltip content="斜体">
                <Icon size="24">
                  <italic />
                </Icon>
              </t-tooltip>
            </t-button>
            <t-button
              variant="text"
              shape="square"
              @click="editor.chain().focus().toggleStrike().run()"
              :disabled="!editor.can().chain().focus().toggleStrike().run()"
              :class="{ 'is-active': editor.isActive('strike') }"
            >
              <t-tooltip content="删除线">
                <Icon size="24">
                  <strikethrough />
                </Icon>
              </t-tooltip>
            </t-button>
          </t-tab-panel>
          <t-tab-panel value="help" label="帮助"> <t-button variant="text">HOLD...</t-button> </t-tab-panel>
        </t-tabs>
        <!-- </t-space> -->
      </div>
    </t-header>
    <t-content class="editor-body">
      <!-- <div class="editor-body"> -->
      <editor-content :editor="editor" class="editor-content" />
      <!-- </div> -->
    </t-content>
    <t-footer>
      <div class="editor-footer">footer</div>
    </t-footer>
  </t-layout>
</template>

<script setup lang="ts">
import { watch, onBeforeUnmount, ref } from 'vue';
import { Editor, EditorContent } from '@tiptap/vue-3';
import StarterKit from '@tiptap/starter-kit';
import { Icon } from '@vicons/utils';
import { FileExport, FileImport, Bold, Italic, Strikethrough } from '@vicons/tabler';
import { createDocument, getDocument } from '@/api/Document';
import { export2Json, readAsStringFromJsonFile } from '@/utils/fileUtil';

const props = defineProps({
  modelValue: {
    type: String,
    default: '',
  },
});

const menuTabValue = ref('edit');

const editor = new Editor({
  content: props.modelValue,
  extensions: [StarterKit],
  onUpdate: () => {
    // HTML
    emit('update:modelValue', editor.getHTML());

    // JSON
    // this.$emit('update:modelValue', this.editor.getJSON())
  },
});

const emit = defineEmits(['update:modelValue']);

onBeforeUnmount(() => {
  editor.destroy();
});

watch(
  () => props.modelValue,
  (value, oldValue) => {
    const isSame = editor.getHTML() === value;
    if (isSame) {
      return;
    }
    editor.commands.setContent(value, false);
  },
);

const handleExport2Json = () => {
  const jsonObj = editor.getJSON();
  console.log('json', jsonObj);
  export2Json(JSON.stringify(jsonObj));
};

const handleImportFromJson = () => {
  const input = document.createElement('input');
  input.setAttribute('type', 'file');
  input.setAttribute('accept', '.html');
  input.onchange = function () {
    readAsStringFromJsonFile(this, function (jsonStr: string) {
      editor.commands.setContent(JSON.parse(jsonStr));
    });
  };

  input.click();
};

// const save = () => {
//   const json = editor.getJSON();
//   console.log('json', json);
//   createDocument({
//     jsonContent: JSON.stringify(json),
//   });
// };

// getDocument('6992E2FB-A052-4F79-BCB9-716F1514B8E4').then((res) => {
//   console.log('xx', res);
//   editor.commands.setContent(JSON.parse(res.jsonContent));
// });
</script>

<style lang="less" scoped>
.editor-container {
  height: 100vh;

  .editor-header {
    //
  }

  .editor-body {
    padding: 10px 0px;
    overflow-y: auto;
    display: flex;
    justify-content: center;

    :deep(.ProseMirror) {
      min-height: 100%;
      background-color: #ffffff;
      width: 850px;
      padding: 30px 30px;
    }
    :deep(.ProseMirror-focused) {
      outline: none;
    }
  }

  .editor-footer {
    height: 30px;
    background-color: #f3f3f3;
  }
}

:deep(.t-layout__footer) {
  padding: 10px 0 0 !important;
}

:deep(.t-tabs__nav--card) {
  background-color: #2b579a;
  color: #fff;
}

:deep(.t-tabs__nav--card):hover {
  color: #fff;
  background-color: #124078 !important;
}

:deep(.t-tabs__nav--card.t-tabs__nav-item):not(:first-of-type) {
  border-left: none;
}
:deep(.t-tabs__nav--card.t-tabs__nav-item):last-of-type {
  border-right: none;
}

::-webkit-scrollbar {
  width: 18px;
  // height: 18px;
}
::-webkit-scrollbar-thumb {
  border: 1px solid rgb(198, 193, 193);
  border-radius: 5px !important;
  box-shadow: inset 0 0 5px rgba(0, 0, 0, 0.2) !important;
  /* 颜色 */
  background: #fff !important;
  /* 线性渐变背景 */
  // background-image: linear-gradient(
  //   45deg,
  //   #ffbd61 25%,
  //   #ffbd61 25%,
  //   #ff8800 25%,
  //   #ff8800 50%,
  //   #ffbd61 50%,
  //   #ffbd61 75%,
  //   #ff8800 75%,
  //   #ff8800 100%
  // ) !important;
}
::-webkit-scrollbar-track {
  border-radius: 10px !important;
  box-shadow: inset 0 0 5px rgba(0, 0, 0, 0.2) !important;
  background: #f3f3f3 !important;
}
</style>
