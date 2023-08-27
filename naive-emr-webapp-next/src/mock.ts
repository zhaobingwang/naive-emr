const header = [
  {
    value: '某某某人民医院',
    size: 32,
    rowFlex: 'center',
  },
  {
    value: '\n门诊病历',
    size: 18,
    rowFlex: 'center',
  },
  {
    value: '\n',
    type: 'separator',
  },
]

const footer = [
  {
    value: 'naive-emr-footer',
    size: 12,
    rowFlex: 'center',
  },
]
const main = [
  {
    type: 'title',
    level: 'first',
    value: '',
    valueList: [{ value: '主诉：\n', size: 18, bold: true }],
  },
  {
    value: '这是一段主诉内容\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n',
    size: 16,
  },
  {
    value: '测试2\n',
    size: 16,
  },
  {
    type: 'title',
    level: 'first',
    value: '',
    valueList: [{ value: '现病史：\n', size: 18, bold: true }],
  },
  {
    value: '这是一段现病史内容\n',
    size: 16,
  },
]

const main2 = [
  {
    type: 'title',
    level: 'first',
    value: '',
    valueList: [{ value: '主诉22：\n', size: 18, bold: true }],
  },
  {
    value: '这是一段主诉内容22\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n',
    size: 16,
  },
  {
    value: '测试222\n',
    size: 16,
  },
  {
    type: 'title',
    level: 'first',
    value: '',
    valueList: [{ value: '现病史22：\n', size: 18, bold: true }],
  },
  {
    value: '这是一段现病史内容222\n',
    size: 16,
  },
]

export { header, main, main2, footer }
