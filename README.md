# MYABPTest
ABP框架尝试使用 功能后续完善 ui（AdminLTE）
多数据库
#
  创建或更新数据库 Update-Database -ConfigurationTypeName Configuration文件名
  生成迁移文件 Add-Migration -ConfigurationTypeName Configuration文件名  迁移文件名
  生成Configuration文件 Enable-Migrations -ContextTypeName "DbContext名称" -ProjectName "项目名" -StartUpProjectName "开始启动项目名" -ConnectionStringName "链接字符串" -MigrationsDirectory 新Configuration所在文件
地区管理
#地区管理增 删 改功能
