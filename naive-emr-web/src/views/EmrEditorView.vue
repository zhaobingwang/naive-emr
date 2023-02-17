<template>
  <div>
    <editor v-model="content" />

    <!-- <div class="content">
      <h3>Content</h3>
      <pre><code>{{ content }}</code></pre>
    </div> -->
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Editor from '@/components/TheEditor.vue';

const content = ref('<p>这是一段测试内容</p>');
</script>
