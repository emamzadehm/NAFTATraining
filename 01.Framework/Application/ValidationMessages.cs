using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Framework.Application
{
    public class ValidationMessages
    {
        public const string IsRequired = "*پر کردن این فیلد اجباری می باشد.";
        public const string MaxFileSize = "*حجم فایل بیشتر از حد مجاز می باشد.";
        public const string FileExtention = "*فرمت فایل وارد شده معتبر نمی باشد.";
        public const string PasswordCompare = "*رمز عبور وارد شده با تکرار آن مطابقت ندارد.";
        public const string Email = "*ایمیل وارد شده صحیح نمی باشد.";

    }
}
