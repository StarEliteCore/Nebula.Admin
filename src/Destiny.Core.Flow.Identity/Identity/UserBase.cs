using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Destiny.Core.Flow.Identity
{
    public abstract class UserBase<TUserKey> : EntityBase<TUserKey>
         where TUserKey : IEquatable<TUserKey>
    {
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("标准化的用户名")]
        public string NormalizedUserName { get; set; }

        [DisplayName("用户昵称")]
        public string NickName { get; set; }

        [DisplayName("电子邮箱"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("标准化的电子邮箱"), DataType(DataType.EmailAddress)]
        public string NormalizeEmail { get; set; }

        [DisplayName("电子邮箱确认")]
        public bool EmailConfirmed { get; set; }

        [DisplayName("密码哈希值")]
        public string PasswordHash { get; set; }

        [DisplayName("用户头像")]
        public string HeadImg { get; set; }

        [DisplayName("安全标识")]
        public string SecurityStamp { get; set; }

        [DisplayName("版本标识")]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [DisplayName("手机号码")]
        public string PhoneNumber { get; set; }

        [DisplayName("手机号码确定")]
        public bool PhoneNumberConfirmed { get; set; }

        [DisplayName("双因子身份验证")]
        public bool TwoFactorEnabled { get; set; }

        [DisplayName("锁定时间")]
        public DateTimeOffset? LockoutEnd { get; set; }

        [DisplayName("是否登录锁")]
        public bool LockoutEnabled { get; set; }

        [DisplayName("登录失败次数")]
        public int AccessFailedCount { get; set; }

        [DisplayName("是否系统")]
        public bool IsSystem { get; set; }

        [DisplayName("姓别")]
        public Sex Sex { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return UserName;
        }
    }
}