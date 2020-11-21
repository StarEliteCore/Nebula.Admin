# Destiny.Core.Flow模块化快速开发框架
![.NET Core](https://github.com/DestinyCore/Destiny.Core.Flow/workflows/.NET%20Core/badge.svg)  [![Front](https://img.shields.io/badge/Front-React-d.svg)](#) [![sdk](https://img.shields.io/badge/sdk-3.1-d.svg)](#)  [![License MIT](https://img.shields.io/badge/license-Apache-blue.svg?style=flat-square)](https://github.com/anjoy8/Blog.Core/blob/master/LICENSE) [![Language](https://img.shields.io/badge/language-csharp-d.svg)](#) [![博客园](https://img.shields.io/badge/博客园-微微Kawhi-brightgreen.svg)](https://www.cnblogs.com/pual13/)

**Destiny.Core.Flow是一个基于`.net core3.1`平台轻量级的模块化开发框架Admin管理应用框架，旨在提升团队的快速开发输出能力，由常用公共操作类（工具类、帮助类）、分层架构基类，第三方组件封装等组成。
Destiny.Core.Flow重写微软的identity用户角色和重写IDS4的实体，以及IDS4的查询仓库实现，将IDS4和Identity以及其他模块合并成为一个上下文，在使用IDS4时不需要在维护几个上下文，统一了上下文管理。
框架lambda查询不需要在后台写各种判断，所有的查询条件通过前端传入，从而减少后台的一些字符段判断等，使用动态拼接lambda。**
+ ## 在线地址

✔ [在线展示](http://admin.destinycore.club)

账号Test002    123456
 

✔ [在线展示后端API链接](http://api.destinycore.club) 

✔ [VUE版本]
 
 https://github.com/DestinyCore/Destiny.Core.Flow.WebUI

+ ## 关联前端

✔ [关联前端项目链接](https://github.com/DestinyCore/Destiny.Core.Flow.WebUI)

+ ## 采用技术栈

  ![](https://wangzewei.oss-cn-beijing.aliyuncs.com/imges/20201109171810.png)

+ ## 1.框架功能

  + ### 该项目是基础版不提供工作流版本     
  + ### 系统设置

    + #### 用户管理

    + #### 角色管理

    + #### 菜单管理
      
    + #### 功能管理

    + #### 数据字典

    + #### 组织架构
   
    + #### 操作审计
    
    + #### 数据审计
    
    + #### 工作流（暂时不支持）

    + To do

+ ## 2.框架分层

  + ### Infrastructure 基础建设层

    + #### Destiny.Core.Flow

      用来替换之前的Common层，实现注解式模块化挂载、事件总线、自动DI注册、通用查询模型、lambda表达式动态生成、仓储接口定义、权限接口定义、自定义扩展方法等。

    + #### Destiny.Core.Flow.EntityFrameworkCore

      EFCore上下文定义、扩展EF映射数据库配置接口以及类、在SaveChanges实现发送日志事件进行记录数据操作日志、仓储接口实现、EFCore模块抽象类定义。

    + #### Destiny.Core.Flow.Identitys

      重写微软Identity自带用户角色的代码。
      
    + #### Destiny.Core.Flow.IdentityServer
 
      重写IdentityServer相关接口，及相关映射，实现通过仓储操作相关数据
      
     + #### Destiny.Core.Flow.IdentityServer.Entities
 
       IdentityServer相关实体
      
    + #### Destiny.Core.Flow.AspNetCore

      NetCoreAPI通用层，权限过滤器，日志过滤器、异常中间件、控制器返回同意格式模型。

    + #### Destiny.Core.Flow.CodeGenerator 代码生成器

      已实现，可以生成实体、DTO、接口、控制器。

    + to do...

  + ### Business  业务层

    + #### Destiny.Core.Flow.Dtos 

      前端与后端交互Dto模型定义。

    + #### Destiny.Core.Flow.IServices

      业务接口定义。

    + #### Destiny.Core.Flow.Services

      业务接口实现。

    + #### Destiny.Core.Flow.Model

      数据库实体模型定义

    + #### Destiny.Core.Flow.API

      API接口定义。
   
    + #### Destiny.Core.Flow.AuthenticationCenter
      IdentityServer授权中心
    + to do...

  + ## Moduls 模块层

    + #### Destiny.Core.Flow.Aop 模块

      使用AspectCore来实现AOP动态代理。

    + ####  Destiny.Core.Flow.AutoMapper 模块

    + #### Destiny.Core.Flow.Caching  缓存接口定义模块

    + #### Destiny.Core.Flow.Caching.CSRedis 基于CSRedis实现缓存功能模块

    + #### Destiny.Core.Flow.Consul 服务发现模块

    + #### Destiny.Core.Flow.SwaggerUI 模块
    
    + #### Destiny.Core.Flow.MongoDB 模块
      注意MongoDB链接 mongodb://127.0.0.2/Test
      集成MongoDB分页查询，添加，更新，删除。实现MongoDB单独仓储
+ ## 3.框架技术

  + ### 数据库

    + #### MySql

    + #### Redis
    
    + #### MongoDB

  + ### .Net Core技术

    + #### MSDI （**个人扩展批量注入**）

    + #### Consul服务注册发现

    + #### 基于MediatR实现事件总线

    + #### AutoMapper对象映射

      + 在仓储层实现了自动转实体层不需要手动注入实现转化

    + #### SignalR即时通信(暂时不支持)

    + #### EntityFrameworkCore ORM框架

    + ### MongoDB 切记MongoDB链接 mongodb://127.0.0.2/Test
    + ### Redis 

  + 

## 部署环境

+ Linux
  + Ubuntu Server19.04
  + Docker
+ 容器管理
  + Portainer

### 框架博客

+ https://www.cnblogs.com/pual13/p/12587113.html 项目名字可能有些不同思路一样



