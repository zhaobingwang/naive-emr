import { mergeAttributes, Node } from '@tiptap/core';
import { VueNodeViewRenderer } from '@tiptap/vue-3';
import Checkbox from './Checkbox.vue';

export default Node.create({
  name: 'Checkbox',

  group: 'inline',

  // atom: true,
  inline: true,

  addAttributes() {
    return {
      checked: {
        default: [],
      },
    };
  },

  parseHTML() {
    return [
      {
        tag: 'checkbox',
      },
    ];
  },

  renderHTML({ HTMLAttributes }) {
    return ['checkbox', mergeAttributes(HTMLAttributes)];
  },

  addNodeView() {
    return VueNodeViewRenderer(Checkbox);
  },
});
