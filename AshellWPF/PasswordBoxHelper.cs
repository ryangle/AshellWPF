using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AshellWPF
{
    public class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordBoxHelper),
            new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));
        
        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordProperty, value);
        }

        /// <summary>
        /// 当PasswordProperty发生变化时调用此方法
        /// </summary>
        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordChanged;
                passwordBox.Password = (string)e.NewValue;//ViewModel的变化更新到View
                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        /// <summary>
        /// 当PasswordBox的密码发生更改时调用此方法
        /// </summary>
        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                //重复设置并不会引起死循环，但是还是不要这样做
                SetPassword(passwordBox, passwordBox.Password);//View的变化更新到ViewModel
            }
        }
    }
}
