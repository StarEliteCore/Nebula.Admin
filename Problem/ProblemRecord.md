IdentityServer4Problem：

+ IdentityServer4 前后分离登录/退出登录配置：

  + 前端登录

  + ```tsx
    #安装oidc-client
    创建一个ApplicationUserManager.ts 类 继承UserManager 
    export  class ApplicationUserManager  extends UserManager{
      constructor () {
        super({
          authority: LoginConfig.authority,
          client_id: LoginConfig.client_id,
          redirect_uri: LoginConfig.redirect_uri,
          response_type: LoginConfig.response_type,
          scope: LoginConfig.scope,
          post_logout_redirect_uri: LoginConfig.post_logout_redirect_uri
        })
      }
      /**
       * 登录
       */
      public async Login  () {
        this.signinRedirect(); //执行重定向
      };
      /**
       * 登出
       */
      async Logout () {
        return this.signoutRedirect()
      }
    }
    const applicationUserManager = new ApplicationUserManager()
    export { applicationUserManager as default }
    
    import {UserManager} from "oidc-client";# 引入oidc-client
    
    
    
    
    ```

  + 后端登录需要修改验证用户名密码改成自己的服务层就可以了

  + 退出登录

  + ![](https://wangzewei.oss-cn-beijing.aliyuncs.com/imges/20201105115226.png)

  + ```
    需要配置AccountOptions中的AutomaticRedirectAfterSignOut为true
    
    
    ```

  + 

  + 

+ 