<template>
  <t-layout class="editor-container">
    <t-header style="height: 85px">
      <editor-header :editor="editor" />
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
import EditorHeader from '@/components/TheHeader.vue';
// import StarterKit from '@tiptap/starter-kit';
// import { createDocument, getDocument } from '@/api/Document';

import { useTheEditor } from '@/composables/editor';

const props = defineProps({
  modelValue: {
    type: String,
    default: '',
  },
});
const emit = defineEmits(['update:modelValue']);

const { editor } = useTheEditor(props, emit);

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
