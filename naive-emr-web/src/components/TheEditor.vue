<template>
  <main>
    <div class="editor-header" v-if="editor">
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
        <Icon size="24">
          <italic />
        </Icon>
      </t-button>
      <t-button
        variant="text"
        shape="square"
        @click="editor.chain().focus().toggleStrike().run()"
        :disabled="!editor.can().chain().focus().toggleStrike().run()"
        :class="{ 'is-active': editor.isActive('strike') }"
      >
        <Icon size="24">
          <strikethrough />
        </Icon>
      </t-button>
    </div>
    <!-- <t-divider></t-divider> -->
    <div class="editor-body">
      <editor-content :editor="editor" />
    </div>
    <div class="editor-footer">footer</div>
  </main>
</template>

<script setup lang="ts">
import { watch, onBeforeUnmount } from 'vue';
import { Editor, EditorContent } from '@tiptap/vue-3';
import StarterKit from '@tiptap/starter-kit';
import { Icon } from '@vicons/utils';
import { Bold, Italic, Strikethrough } from '@vicons/tabler';

const props = defineProps({
  modelValue: {
    type: String,
    default: '',
  },
});

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
</script>

<style lang="scss">
main {
  border: 1px dashed #000;
  border-radius: 8px;
}
.ProseMirror {
  // background-color: #fff;
  // border: 1px solid rgb(105, 100, 100);
  min-height: calc(100vh - 90px);
}
.ProseMirror-focused {
  // border: 1px dashed #000;
  outline: none;
}

.editor-header {
  // height: 30px;
  // background-color: #fff;
  // border: 1px solid #000;
  padding-left: 20px;
  padding-right: 20px;
  border-bottom: 1px dashed #000;
}
.editor-body {
  padding-left: 30px;
  padding-right: 30px;
  overflow-y: auto;
  height: calc(100vh - 70px);

  // ::-webkit-scrollbar {
  //   width: 6px;
  // }

  // ::-webkit-scrollbar-thumb {
  //   border-radius: 10px;
  //   background: rgba(0, 0, 0, 0.2);
  // }

  // ::-webkit-scrollbar-track {
  //   border-radius: 0;
  //   background: rgba(0, 0, 0, 0.1);
  // }
}
.editor-footer {
  border-top: 1px dashed #000;
}

::-webkit-scrollbar {
  /*高宽分别对应横竖滚动条的尺寸*/
  width: 8px;
  height: 8px;
}
::-webkit-scrollbar-thumb {
  border-radius: 10px !important;
  box-shadow: inset 0 0 5px rgba(0, 0, 0, 0.2) !important;
  /* 颜色 */
  /* background:#b6b6b6!important; */
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
  background: #ededed !important;
}
</style>
