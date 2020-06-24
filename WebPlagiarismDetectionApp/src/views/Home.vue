<template>
  <div class="home">
    <el-table :data="tableData" stripe style="width: 100%">
      <el-table-column prop="title" label="标题"></el-table-column>
      <el-table-column prop="createTime" label="创建时间" :formatter="dateFormatter"></el-table-column>
      <el-table-column prop="detectBeginTime" label="检测开始时间" :formatter="dateFormatter"></el-table-column>
      <el-table-column prop="detectEndTime" label="检测结束时间" :formatter="dateFormatter"></el-table-column>
    </el-table>
  </div>
</template>

<script>
// @ is an alias to /src
import { format } from "date-fns";

export default {
  name: "Home",
  components: {},
  data() {
    return {
      tableData: []
    };
  },
  created() {
    this.$http.get("/api/wpds").then(response => {
      this.tableData = response.data;
    });
  },
  methods: {
    dateFormatter(row, column, cellValue, index) {
      return format(new Date(cellValue), "yyyy-MM-dd HH:mm:ss");
    }
  }
};
</script>
