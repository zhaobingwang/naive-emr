<template>
  <node-view-wrapper class="checkbox">
    <t-space direction="vertical"
      ><t-checkbox>基础多选框</t-checkbox>
      <p>选中值: {{ checked }}</p>
      <t-checkbox-group
        @click="handleClick"
        @change="handleChange"
        v-model="checked"
        :options="['选项一', '选项二', '选项三']"
        name="city"
      ></t-checkbox-group>
    </t-space>
  </node-view-wrapper>
</template>

<script setup lang="ts">
import { nodeViewProps, NodeViewWrapper } from '@tiptap/vue-3';
import type { CheckboxGroupChangeContext, CheckboxGroupValue } from 'tdesign-vue-next';
import { ref } from 'vue';

const props = defineProps({
  node: {
    type: Object,
    required: true,
  },
  updateAttributes: {
    type: Function,
    required: true,
  },
});

const checked = ref(props.node.attrs.checked);

const handleChange = (value: CheckboxGroupValue, context: CheckboxGroupChangeContext) => {
  console.log('xxx', checked, value);

  props.updateAttributes({
    checked: value,
  });
};

const handleClick = (e: any) => {
  // e.target.click();
  console.log('click', e);
};
</script>
