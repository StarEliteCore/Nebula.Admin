# Destiny.Core.Flow中使用IdentityServer4

+ ## IdentityServer4使用Destiny.Core.Flow中的上下文持久化数据库

  什么是 IdentityServer4 ？

  ![](https://wangzewei.oss-cn-beijing.aliyuncs.com/imges/20201127105012.png)

  1、先看看概念

  > IdentityServer4 is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.
  >
  > IdentityServer是基于OpenID Connect协议标准的身份认证和授权程序，它实现了OpenID Connect 和 OAuth 2.0 协议。
  > 同一种概念，不同的文献使用不同的术语，比如你看到有些文献把他叫做安全令牌服务（Security Token Service），
  > 身份提供（Identity Provider），授权服务器（Authorization Server），IP-STS 等等。其实他们都是一个意思，目的都是在软件应用中为客户端颁发令牌并用于安全访问的。

  2、IdentityServer的功能

  >保护你的资源
  >使用本地帐户或通过外部身份提供程序对用户进行身份验证
  >提供会话管理和单点登录
  >管理和验证客户机
  >向客户发出标识和访问令牌
  >验证令牌

+ ## 会归重点，不使用IdentityServer4的默认上下文

  1、先说为什么不使用IdentityServer4默认的上下文

  >IdentityServer的上下文可扩展性差，虽然他可以重写它里面验证的一些接口，但是我们想把Client、resources以及一些其他的做成后台管里端，IdentityServer4默认不携带管理端，实现的方式有两种：分别是手撸数据库和撸代码
  >
  >
  >
  >
  >
  >IdentityServer4默认的上下文有两个分别是ConfigurationDbContext、PersistedGrantDbContext
  >
  >PersistedGrantDbContext上下文的作用
  >
  >

+ 

+ 



