import { Editor } from '@tiptap/vue-3';
import StarterKit from '@tiptap/starter-kit';

export function useTheEditor(props: any, emit: any) {
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

  return { editor };
}
