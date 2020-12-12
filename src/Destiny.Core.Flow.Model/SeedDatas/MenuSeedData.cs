using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Menu;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Destiny.Core.Flow.Model.SeedDatas
{
    [Dependency(ServiceLifetime.Singleton)]
    public class MenuSeedData : SeedDataDefaults<MenuEntity, Guid>
    {
        public MenuSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        protected override Expression<Func<MenuEntity, bool>> Expression(MenuEntity entity)
        {

            return o => true;
        }

        protected override MenuEntity[] SetSeedData()
        {
            return new MenuEntity[] {
                 new MenuEntity(){
                  Id=Guid.Parse("08d88973-3848-4139-8979-50ba65aa6985"),
                  Name="查询菜单树",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  Depth=0,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:03.140933"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 },
                 new MenuEntity(){
                  Id=Guid.Parse("08d88973-4ebe-43b6-83fd-d1343e3c3db3"),
                  Name="查询菜单分页表格",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  Depth=0,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,

                 },
                  new MenuEntity(){
                  Id=Guid.Parse("08d88973-93b1-4093-889d-97bedabc2233"),
                  Name="菜单添加",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAddTreeMenu",

                 },new MenuEntity(){
                  Id=Guid.Parse("08d88973-9a33-4a25-8252-e8bff2507cfb"),
                  Name="修改菜单",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,

                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleEditTreeMenu",

                 },
                  new MenuEntity(){
                  Id=Guid.Parse("08d88973-a35e-4936-84cf-7d8a715f12d2"),
                  Name="删除菜单",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDeleteTreeMenu",

                 },
                  new MenuEntity(){
                  Id=Guid.Parse("08d88bd7-2037-4b83-8204-31e2cf867fc3"),
                  Name="删除",
                  Path="handleDelete",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-f67c-4299-8d3a-c3243fcb5bc7"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDelete",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd8-177c-40fe-82b6-e4e6484f7c95"),
                  Name="添加功能",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAddMenuFunction",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd8-4bc8-4952-8603-1c232987ce0b"),
                  Name="编辑功能",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleEditMenuFunction",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd8-87b6-4737-8f8b-2778c807fe43"),
                  Name="删除功能",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDeleteMenuFunction",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd8-a84f-434e-8e97-255bab78ccf2"),
                  Name="分配菜单功能",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="showAddMenuFunction",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-5550-4db7-8ee9-0fc027e5b289"),
                  Name="添加组织机构树",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAddTree",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-66e3-4001-8b57-bd83187c2bfc"),
                  Name="更新组织机构树",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleEditTree",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-8bb4-45ae-83a3-79c4c7949a22"),
                  Name="删除组织架构树",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDeleteTree",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-ac4f-4261-8fd2-743db9af6739"),
                  Name="添加",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAdd",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-bb50-4e9c-8669-3393abe8d475"),
                  Name="修改",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleUpdate",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88bd9-cdfc-48a6-8958-bef859429e8e"),
                  Name="删除",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDelete",

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88bda-448c-42e7-8f54-2cf879cd1ad5"),
                  Name="查询菜单功能",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88bda-a94d-40e5-82ae-dd6f5f728265"),
                  Name="查询组织构架树",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88bda-b12e-4ad2-8c19-1ba86e696050"),
                  Name="查询组织构",
                  Sort=0,
                  ParentId=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88598-8230-4d89-892b-e8d34ea95e9a",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88c90-8d28-42ec-8f52-c0838b9ea12f"),
                  Name="得到C#类型",
                  Sort=0,
                  ParentId=Guid.Parse("08d86484-8c20-4aa8-8a80-1ecb288beabc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88c91-a02e-42dc-8672-220082fc01e1"),
                  Name="查看菜单删除",
                  Sort=0,
                  ParentId=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-dae5-4891-83d3-38a134d63506",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="deleteFun",

                 }
                   ,new MenuEntity(){
                  Id=Guid.Parse("08d81dd2-dc25-4ffa-8518-4b28558ba714"),
                  Name="添加",
                  Sort=1,
                  ParentId=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  Component="add",
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAdd",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  Name="用户管理",
                  Sort=1,
                  Path="/identity/user",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="identity/user-managerment/user-managerment",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d87ffe-50db-4b11-8ffa-55602e216862"),
                  Name="操作审计",
                  Sort=1,
                  Path="/system/auditlog",
                  ParentId=Guid.Parse("08d88645-31bd-42e5-8211-753786aaf90b"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b",
                  Component="system/audit-log-managerment/audit-log-managerment",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88595-506f-4b2b-8583-fe22dddb3fed"),
                  Name="查询",
                  Sort=1,
                  ParentId=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  Name="系统管理",
                  Sort=1,
                  Path="/layout",
                  ParentId=Guid.Parse("00000000-0000-0000-0000-000000000000"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  Name="角色管理",
                  Sort=2,
                  Path="/identity/role",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="identity/role-managerment/role-managerment",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                   ,new MenuEntity(){
                  Id=Guid.Parse("08d83c69-a522-4175-8e0c-5efc57fd6456"),
                  Name="修改",
                  Sort=2,
                  Path="update",
                  ParentId=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc",
                  Component="dasda",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleUpdate"

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d8444f-875e-4a45-861d-f12dbb72c463"),
                  Name="添加",
                  Sort=2,
                  Path="add",
                  ParentId=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Component="primary",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAdd"

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d87ffe-c251-4779-8054-15c04038a8f1"),
                  Name="数据审计",
                  Sort=2,
                  Path="/system/auditentry",
                  ParentId=Guid.Parse("08d88645-31bd-42e5-8211-753786aaf90b"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b",
                  Component="system/audit-entry-managerment/audit-entry-managerment",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d815d8-dae5-4891-83d3-38a134d63506"),
                  Name="菜单管理",
                  Sort=3,
                  Path="/identity/menu",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="identity/menu-managerment/menu-managerment",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d84450-4c1f-4f06-8652-ab6a2c1c888f"),
                  Name="修改",
                  Sort=3,
                  Path="update",
                  ParentId=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Component="primary",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleUpdate",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88596-cb6b-43e1-84fb-b5a0a194e545"),
                  Name="删除",
                  Sort=3,
                  Path="update",
                  ParentId=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc",
                  Component="primary",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDelete",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d815d8-f67c-4299-8d3a-c3243fcb5bc7"),
                  Name="功能管理",
                  Sort=4,
                  Path="/identity/function",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="identity/function-managerment/function-managerment",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d84450-78cf-499b-897c-56a4304f139f"),
                  Name="删除",
                  Sort=4,
                  Path="delete",
                  ParentId=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Component="primary",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleDelete",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88598-b792-4bba-850e-0a15a2644a1c"),
                  Name="分配权限",
                  Sort=4,
                  ParentId=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAuth",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d86484-8c20-4aa8-8a80-1ecb288beabc"),
                  Name="代码生成器管理",
                  Sort=5,
                  Path="/system/codeGenerator",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="system/code-generator-managerment/code-generator",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88594-14ae-4de2-8e55-dfdf1e41e40d"),
                  Name="用户分配角色",
                  Sort=5,
                  ParentId=Guid.Parse("08d83d35-9456-4c13-8004-ff7f8e3fe2e9"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d83d35-9456-4c13-8004-ff7f8e3fe2e9",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="allocationRole",

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88597-6b34-4f44-8261-dcfa2736e8fe"),
                  Name="查询",
                  Sort=5,
                  ParentId=Guid.Parse("08d815d8-868f-45cc-8fdf-0dff5acac7fc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-868f-45cc-8fdf-0dff5acac7fc",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,

                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88645-31bd-42e5-8211-753786aaf90b"),
                  Name="审计管理",
                  Path="/layout-empty",
                  Sort=5,
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,
                  Layout="/layout",
                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d84379-988d-4ff9-8f47-db14075addc2"),
                  Name="添加",
                  Path="add",
                  Sort=6,
                  ParentId=Guid.Parse("08d815d8-f67c-4299-8d3a-c3243fcb5bc7"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7",
                  Component="add",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleAdd"
                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88597-a9d2-467d-84cf-73ed0f9c04d3"),
                  Name="修改",
                  Sort=7,
                  ParentId=Guid.Parse("08d815d8-f67c-4299-8d3a-c3243fcb5bc7"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7",
                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="handleUpdate"
                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88598-8230-4d89-892b-e8d34ea95e9a"),
                  Name="组织架构",
                  Sort=7,
                  Path="/system/organization",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",
                  Component="identity/organization-managerment/organization-managerment",
                  Depth=2,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,
                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88597-eb63-428c-8422-9480fc807c31"),
                  Name="查询",
                  Sort=8,
                  ParentId=Guid.Parse("08d815d8-f67c-4299-8d3a-c3243fcb5bc7"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d815d8-f67c-4299-8d3a-c3243fcb5bc7",

                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d8896e-5fb8-447e-86ce-d3e1548f65f0"),
                  Name="数据字典",
                  Sort=9,
                  Path="/system/dictionary",
                  ParentId=Guid.Parse("fd8a36d4-d6d8-a6bb-2924-77455100a305"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305",

                  Depth=2,
                  Component="system/data-dictionary-managerment/data-dictionary-managerment",
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Menu,
                  IsHide=false,
                 }
                   ,new MenuEntity(){
                  Id=Guid.Parse("08d88598-3180-446c-8a9f-79af05025956"),
                  Name="生成代码",
                  Sort=9,
                  ParentId=Guid.Parse("08d86484-8c20-4aa8-8a80-1ecb288beabc"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d86484-8c20-4aa8-8a80-1ecb288beabc",

                  Depth=3,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false,
                  EventName="save"
                 }
                 ,new MenuEntity(){
                  Id=Guid.Parse("08d88598-4b78-42f3-86e2-a6602135964b"),
                  Name="查询",
                  Sort=10,
                  ParentId=Guid.Parse("08d87ffe-50db-4b11-8ffa-55602e216862"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-50db-4b11-8ffa-55602e216862",

                  Depth=4,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false
                 }
                  ,new MenuEntity(){
                  Id=Guid.Parse("08d88598-7120-46ab-85b4-a7f40af04d3a"),
                  Name="查询",
                  Sort=11,
                  ParentId=Guid.Parse("08d87ffe-c251-4779-8054-15c04038a8f1"),
                  ParentNumber="fd8a36d4-d6d8-a6bb-2924-77455100a305.08d88645-31bd-42e5-8211-753786aaf90b.08d87ffe-c251-4779-8054-15c04038a8f1",

                  Depth=4,
                  IsDeleted=false,
                  CreatedTime=DateTime.Parse("2020-11-15 22:32:40.825658"),
                  Type=MenuEnum.Function,
                  IsHide=false
                 }
            };
        }
    }
}
