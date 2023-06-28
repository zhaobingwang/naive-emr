<template>
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

        <t-dropdown
          trigger="click"
          @click="handleHeaderClick"
          :class="{ 'is-active': isHeadingActive() }"
          maxColumnWidth="100"
          maxHeight="300"
        >
          <t-button variant="text" shape="square">
            <t-tooltip content="标题">
              <Icon size="24">
                <Heading />
              </Icon>
            </t-tooltip>
          </t-button>
          <t-dropdown-menu>
            <t-dropdown-item
              v-for="item in headers"
              :key="item.value"
              :class="{ 'is-active': isHeadingActive(item.value) }"
              divider="true"
            >
              <t-tooltip :content="item.label">
                <Icon size="24">
                  <component :is="item.comp"></component>
                </Icon>
              </t-tooltip>
            </t-dropdown-item>
          </t-dropdown-menu>
        </t-dropdown>

        <t-button
          variant="text"
          shape="square"
          @click="editor.chain().focus().toggleBulletList().run()"
          :class="{ 'is-active': editor.isActive('bulletList') }"
        >
          <t-tooltip content="无序列表">
            <Icon size="24">
              <UnorderedListOutlined />
            </Icon>
          </t-tooltip>
        </t-button>
        <t-button
          variant="text"
          shape="square"
          @click="editor.chain().focus().toggleOrderedList().run()"
          :class="{ 'is-active': editor.isActive('orderedList') }"
        >
          <t-tooltip content="有序列表">
            <Icon size="24">
              <OrderedListOutlined />
            </Icon>
          </t-tooltip>
        </t-button>

        <t-dropdown
          trigger="click"
          @click="handleFontsClick"
          :class="{ 'is-active': isFontsActive() }"
          maxColumnWidth="100"
          maxHeight="300"
        >
          <t-button variant="text" shape="square">
            <t-tooltip content="字体">
              <Icon size="24">
                <TextFont />
              </Icon>
            </t-tooltip>
          </t-button>
          <t-dropdown-menu>
            <t-dropdown-item
              v-for="item in fonts"
              :key="item.value"
              :class="{ 'is-active': isFontsActive(item.value) }"
              divider="true"
            >
              {{ item.content }}
              <!-- <t-tooltip :content="item.label">
                <Icon size="24">
                  <component :is="item.comp"></component>
                </Icon>
              </t-tooltip> -->
            </t-dropdown-item>
          </t-dropdown-menu>
        </t-dropdown>

        <t-space>
          <t-select
            autoWidth
            borderless
            v-model="value1"
            :options="options1"
            placeholder="请选择字体"
            @change="handleFontChange"
          ></t-select>
        </t-space>

        <t-button variant="text" shape="square" @click="handleSetContent">
          <t-tooltip content="生成一段测试内容"> 测试 </t-tooltip>
        </t-button>
      </t-tab-panel>
      <t-tab-panel value="help" label="帮助"> <t-button variant="text">HOLD...</t-button> </t-tab-panel>
    </t-tabs>
    <!-- </t-space> -->
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { Editor } from '@tiptap/vue-3';
import { export2Json, readAsStringFromJsonFile } from '@/utils/fileUtil';
import { Icon } from '@vicons/utils';
import { FileExport, FileImport, Bold, Italic, Strikethrough, Heading, H1, H2, H3, H4, H5, H6 } from '@vicons/tabler';
import { OrderedListOutlined, UnorderedListOutlined } from '@vicons/antd';
import { TextFont } from '@vicons/carbon';

const menuTabValue = ref('edit');

const props = defineProps({
  editor: {
    type: Editor,
    required: true,
  },
});

// const editor = props.editor;
const handleExport2Json = () => {
  const jsonObj = props.editor.getJSON();
  console.log('json', jsonObj);
  export2Json(JSON.stringify(jsonObj));
};

const handleImportFromJson = () => {
  const input = document.createElement('input');
  input.setAttribute('type', 'file');
  input.setAttribute('accept', '.html');
  input.onchange = function () {
    readAsStringFromJsonFile(this, function (jsonStr: string) {
      props.editor.commands.setContent(JSON.parse(jsonStr));
    });
  };

  input.click();
};

const headers = [
  // { key: 'Paragraph', comp: null, value: 0, label: '段落' },
  { key: 'H1', comp: H1, value: 1, label: '一级标题' },
  { key: 'H2', comp: H2, value: 2, label: '二级标题' },
  { key: 'H3', comp: H3, value: 3, label: '三级标题' },
  { key: 'H4', comp: H4, value: 4, label: '四级标题' },
  { key: 'H5', comp: H5, value: 5, label: '五级标题' },
  { key: 'H6', comp: H6, value: 6, label: '六级标题' },
];

const fonts = [
  { content: '默认', value: '' },
  { content: '阿里妈妈东方大楷', value: '阿里妈妈东方大楷' },
  { content: '阿里巴巴普惠体Thin', value: '阿里巴巴普惠体Thin' },
  { content: '阿里巴巴普惠体Light', value: '阿里巴巴普惠体Light' },
];

const options1 = [
  { label: '默认', value: '默认', title: '默认' },
  { label: '阿里妈妈东方大楷', value: '阿里妈妈东方大楷' },
  { label: '阿里巴巴普惠体Thin', value: '阿里巴巴普惠体Thin' },
  { label: '阿里巴巴普惠体Light', value: '阿里巴巴普惠体Light', disabled: true },
];
const value1 = ref('');

const isHeadingActive = (head?: number) => {
  if (head) {
    if (head <= 0) {
      return props.editor.isActive('paragraph');
    }
    return props.editor.isActive('heading', { level: head });
  } else {
    return (
      props.editor.isActive('heading', { level: 1 }) ||
      props.editor.isActive('heading', { level: 2 }) ||
      props.editor.isActive('heading', { level: 3 }) ||
      props.editor.isActive('heading', { level: 4 }) ||
      props.editor.isActive('heading', { level: 5 }) ||
      props.editor.isActive('heading', { level: 6 })
    );
  }
};

const isFontsActive = (font?: string) => {
  console.log('font', font, props.editor.isActive('textStyle', { fontFamily: '' }));

  if (font) {
    // :class="{ 'is-active': editor.isActive('textStyle', { fontFamily: 'Inter' }) }"
    return props.editor.isActive('textStyle', { fontFamily: font });
  } else {
    return props.editor.isActive('textStyle', { fontFamily: '' });
  }
};

const handleHeaderClick = (data: any) => {
  if (data.key <= 0) {
    props.editor.chain().focus().setParagraph().run();
  } else {
    props.editor.chain().focus().toggleHeading({ level: data.key }).run();
  }
};

const handleFontsClick = (data: any) => {
  if (data.key) {
    props.editor.chain().focus().setFontFamily(data.key).run();
  } else {
    props.editor.chain().focus().unsetFontFamily().run();
  }
  // if (data.key <= 0) {
  //   // props.editor.chain().focus().setParagraph().run();
  // } else {
  //   // props.editor.chain().focus().toggleHeading({ level: data.key }).run();
  //   props.editor.chain().focus().setFontFamily('阿里妈妈东方大楷').run();
  // }
};

const handleFontChange = (value: any) => {
  console.log('handleFontChange', value);
  if (value === '默认') {
    props.editor.chain().focus().unsetFontFamily().run();
  } else {
    props.editor.chain().focus().setFontFamily(value).run();
  }
};
</script>
