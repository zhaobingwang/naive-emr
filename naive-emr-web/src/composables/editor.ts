import { Editor } from '@tiptap/vue-3';
import StarterKit from '@tiptap/starter-kit';
import Document from '@tiptap/extension-document';
import FontFamily from '@tiptap/extension-font-family';
import Paragraph from '@tiptap/extension-paragraph';
import Text from '@tiptap/extension-text';
import TextStyle from '@tiptap/extension-text-style';
import Checkbox from '@/components/checkbox/main';

export function useTheEditor(props: any, emit: any) {
  const editor = new Editor({
    content: props.modelValue,
    extensions: [StarterKit, Document, Paragraph, Text, TextStyle, FontFamily, Checkbox],
    onUpdate: () => {
      // HTML
      emit('update:modelValue', editor.getHTML());

      // JSON
      // this.$emit('update:modelValue', this.editor.getJSON())
    },
  });

  return { editor };
}
